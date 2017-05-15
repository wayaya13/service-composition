using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//程序核心思想：利用交叉概率，选择交叉可得的算子个数，剩余的利用随机值选择保留的算子。即
namespace GA
{
    class GA
    {
        public static GA_Server GetBest(List<GA_Server> scrlist, List<Server>[] wlist, ref double fit)//scrlist表示初始种群，wlist表示子服务集
        {
            GA_Server globalbest = new GA_Server();
            double bestfit=100;
            Random rad = new Random();
            List<GA_Server> dlist = new List<GA_Server>();
            for (int i = 0; i < scrlist.Count; i++)
                dlist.Add(new GA_Server());
            for (int t = 0; t < ConstNum.T; t++)
            { 
                for (int i = 0; i < scrlist.Count; i++)//求每个粒子的适应度
                scrlist[i].fitness(wlist);
                for (int i = 0; i < scrlist.Count; i++)//保留每次进化产生的最优粒子
                    if (bestfit > scrlist[i].Fit)
                    {
                        bestfit = scrlist[i].Fit;
                        int[] a=new int[ConstNum.PARTICE_DIM];
                        for (int k = 0; k < ConstNum.PARTICE_DIM; k++)
                            a[k] = scrlist[i].getIndextask(k);
                        globalbest.setservers(a);
                    }
                //选择
                List<GA_Server> temp = new List<GA_Server>();
                for (int i = 0; i < ConstNum.NP; i++)
                {
                    temp.Add(new GA_Server());
                }
                double tfit = 0;
                //scrlist=GA.GA_Sort_fitness(scrlist);
                for (int i = 0; i < ConstNum.NP; i++)
                {
                    int[] a = new int[ConstNum.PARTICE_DIM];
                    for (int k = 0; k < ConstNum.PARTICE_DIM; k++)
                        a[k] = scrlist[i].getIndextask(k);
                    temp[i].setservers(a);
                    temp[i].Fit = 1/scrlist[i].Fit;
                    tfit += temp[i].Fit;
                }
                double tt = 0;
                for (int i = 0; i < ConstNum.NP; i++)              //两个for循环，轮盘赌选择
                {
                    tt += temp[i].Fit;
                    temp[i].Fit = tt / tfit;
                }
                for (int i = 0; i < ConstNum.NP; i++)
                {
                    double po;
                    int pos=0,j;
                    po = rad.NextDouble();
                    for (j = 0; j < ConstNum.NP-1; j++)
                    {
                        if (po < temp[j].Fit && j==0 )
                            pos = j;
                        else
                        {
                            if (po >= temp[j].Fit && po < temp[j + 1].Fit)
                            {
                                pos = j + 1;
                                break;
                            }
                        }                      
                    }
                    int[] a = new int[ConstNum.PARTICE_DIM];
                    for (int k = 0; k < ConstNum.PARTICE_DIM; k++)
                        a[k] = temp[pos].getIndextask(k);
                    dlist[i].setservers(a);
                    dlist[i].Fit = scrlist[pos].Fit;
                }

                //交叉:随机选择父体，进行交叉
                //GA_Sort_fitness(scrlist);
                int[] CrossoverNum = new int[(int)(ConstNum.crossover * ConstNum.NP)];
                for (int i = 0; i < CrossoverNum.Length; i++)
                {
                    int rad1, rad2,rad3;//rad1表示父本1;rad2表示父本2;rad3交叉位置
                    while (true)
                    {
                        rad1 = rad.Next(0, dlist.Count);
                        rad2 = rad.Next(0, dlist.Count);
                        if (rad1 != rad2)
                            break;
                    }
                    rad3 = rad.Next(0, ConstNum.PARTICE_DIM);
                    int a =0;
                    for (int j = rad3; j < ConstNum.PARTICE_DIM; j++)
                    {
                        a = dlist[rad1].getIndextask(j);
                        dlist[rad1].setIndextask(j, dlist[rad2].getIndextask(j));
                        dlist[rad2].setIndextask(j, a);
                    }
                }
                //变异
                for (int i = 0; i < (int)(ConstNum.Mutation * scrlist.Count); i++)
                {
                    int rd1, rd2,rd3;//rd1表示待变异的算子编号;rd2表示变异的位置;rd3表示变异结果
                    rd1 = rad.Next(0, scrlist.Count);
                    rd2 = rad.Next(0, ConstNum.PARTICE_DIM);
                    rd3 = rad.Next(0, wlist[rd2].Count);
                    dlist[rd1].setIndextask(rd2, rd3);
                }
                //新种群产生
                for (int i = 0; i < scrlist.Count; i++)
                {
                    int[] a = new int[ConstNum.PARTICE_DIM];
                    for (int k = 0; k < ConstNum.PARTICE_DIM; k++)
                        a[k] = dlist[i].getIndextask(k);
                    scrlist[i].setservers(a);
                }
            }
            fit = bestfit;
            return globalbest;
        }
        public static List<GA_Server> GA_Sort_fitness(List<GA_Server> scrlist)        //对fitness排序
        {
            for (int i = 0; i < scrlist.Count; i++)
            {
                for (int j = i + 1; j < scrlist.Count; j++)
                {
                    if (scrlist[i].Fit < scrlist[j].Fit)
                    {
                        int[] a = new int[ConstNum.PARTICE_DIM];
                        int[] b = new int[ConstNum.PARTICE_DIM];
                        double  t = 0;
                        for (int k = 0; k < ConstNum.PARTICE_DIM; k++)
                        {
                            a[k] = scrlist[i].getIndextask(k);
                            b[k] = scrlist[j].getIndextask(k);
                        }
                        scrlist[i].setservers(b);
                        scrlist[j].setservers(a);
                        t = scrlist[i].Fit;
                        scrlist[i].Fit = scrlist[j].Fit;
                        scrlist[j].Fit = t;
                    }
                }
            }

            return scrlist;
        }
    }
}
