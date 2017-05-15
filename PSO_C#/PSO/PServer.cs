using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSO
{
    class PServer
    {
        private int[] task = new int[Constnum.PARTICE_DIM];

        public PServer()
        {
        }

        public PServer(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
                task[i] = a[i];
        }
        public void setIndextask(int index, int t)
        {
            task[index] = t;
        }

        public int getIndextask(int index)
        {
            return task[index];
        }
        public void setservers(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
                task[i] = a[i];
        }
        public static double fitness(PServer sc, List<Server>[] wlist,List<Relation>re)
        {

            double p = 0;
            for (int i = 0; i < Constnum.PARTICE_DIM; i++)
            {
                for (int j = 0; j < re.Count; j++)
                {
                    if (re[j].Front[0] == i && re[j].Front[1]==sc.task[i])
                    {
                        for (int k = i+1; k < Constnum.PARTICE_DIM; k++)
                        {
                            if (re[j].Back[0] == k && re[j].Back[1] == sc.task[k])
                            {
                                p += re[j].Policy;
                            }
                        }
                    }
                       
                }
            }
            double fit = 0;
            double A = 1, T = 0, C = 0, R = 1;
            for (int i = 0; i < Constnum.PARTICE_DIM; i++)
            {
                //fit += Constnum.weight[0] * wlist[i][sc.getIndextask(i)].getresponsetime() +
                //    Constnum.weight[1] * wlist[i][sc.getIndextask(i)].getcost() +
                //    Constnum.weight[2] * wlist[i][sc.getIndextask(i)].getavailability() +
                //    Constnum.weight[3] * wlist[i][sc.getIndextask(i)].getreputation();
                //A *= Constnum.weight[2] * wlist[i][sc.getIndextask(i)].getavailability();
                //T += Constnum.weight[0] * wlist[i][sc.getIndextask(i)].getresponsetime();
                C += wlist[i][sc.getIndextask(i)].getcost();
                //R *= Constnum.weight[3] * wlist[i][sc.getIndextask(i)].getreputation();
            }
            //fit = A + T + C + R;
            fit = C-p;
            return fit;
        }
        public static List<PServer> GetinitPserver(List<Server>[] wlist)//获取初始服务集
        {
            List<PServer> dlist = new List<PServer>();
            Random rad=new Random();
            for (int k = 0; k < Constnum.NP; k++)
            {
                int[] a = new int[Constnum.PARTICE_DIM];
                for (int i = 0; i < Constnum.PARTICE_DIM; i++)
                    a[i] = rad.Next(0, wlist[i].Count - 1);
                dlist.Add(new PServer(a));
            }
            return dlist;
        }

        public static List<PServer> getInitV(List<PServer> scrlist)//获取初始速度V
        {
            Random rad = new Random();
            List<PServer> V = new List<PServer>();
            for (int i = 0; i < scrlist.Count; i++)
            {
                int[] a = new int[Constnum.PARTICE_DIM];
                for (int k = 0; k < Constnum.PARTICE_DIM; k++)
                {
                    a[k] = rad.Next((int)(-0.005 * scrlist.Count), (int)(0.005 * scrlist.Count));
                }
                V.Add(new PServer(a));
            }
            return V;
        }
    }
}
