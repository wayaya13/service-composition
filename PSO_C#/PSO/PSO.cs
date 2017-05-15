using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSO
{
    class PSO
    {
        public static PServer GetBest(List<PServer> scrlist, List<Server>[] wlist, ref double fit,List<Relation > re)//scrlist表示初始种群，wlist表示子服务集
        {
            PServer globalBest=new PServer();
            List<PServer> serverbest = new List<PServer>();
            double globalfit=1000;
            double c1, c2, w;
            
            List<double> serverfit = new List<double>();
            for (int i = 0; i < scrlist.Count; i++)//个体最有位置适应度
            {
                serverbest.Add(new PServer());
                serverfit.Add(new double());
                serverfit[i] = 1000;
            }
            List<PServer> v = new List<PServer>();
            v = PServer.getInitV(scrlist);
            for (int t = 0; t < Constnum.T; t++)//迭代次数
            {
                Random rad = new Random();
                for (int i = 0; i < scrlist.Count; i++)//求每个粒子的fitness
                {
                    if (serverfit[i] > PServer.fitness(scrlist[i], wlist,re))
                    {
                        serverfit[i] = PServer.fitness(scrlist[i], wlist,re);
                        int[] a = new int[Constnum.PARTICE_DIM];
                        for (int k = 0; k < Constnum.PARTICE_DIM; k++)
                            a[k] = scrlist[i].getIndextask(k);
                        serverbest[i].setservers(a);//最有位置保存
                    }
                    if (globalfit > serverfit[i])//全局最优
                    {
                        globalfit = serverfit[i];
                        int[] a = new int[Constnum.PARTICE_DIM];
                        for (int k = 0; k < Constnum.PARTICE_DIM; k++)
                            a[k] = serverbest[i].getIndextask(k);
                        globalBest.setservers(a);
                    }
                }

                //位置改变产生新的种群
                c1 = Constnum.c1max - t * (Constnum.c1max - Constnum.c1min) / Constnum.T;
                c2 = Constnum.c2max + t * (Constnum.c2max - Constnum.c2min) / Constnum.T;
                //w = Constnum.wmax - t * (Constnum.wmax - Constnum.wmin) / Constnum.T;
                w = (Constnum.wmax - Constnum.wmin) * (Constnum.T - t) / Constnum.T + Constnum.wmin;
                for (int i = 0; i < scrlist.Count; i++)
                {
                    for (int j = 0; j < Constnum.PARTICE_DIM; j++)
                    {
                        double sigema = rad.NextDouble();
                        double aita = rad.NextDouble();
                        double vt = w * v[i].getIndextask(j) + c1 * sigema * (serverbest[i].getIndextask(j) - scrlist[i].getIndextask(j)) + c2 * aita * (globalBest.getIndextask(j) - scrlist[i].getIndextask(j));
                        double xt = vt + scrlist[i].getIndextask(j);
                        v[i].setIndextask(j, (int)vt);
                        int p = (int)xt;
                        if (p < 0)
                        {
                            p = p % wlist[j].Count;
                            p += wlist[j].Count;
                        }
                        p = p % wlist[j].Count;
                        scrlist[i].setIndextask(j, p);
                    }
                }
            }
            fit = globalfit;
            return globalBest;
        }

    }
}
