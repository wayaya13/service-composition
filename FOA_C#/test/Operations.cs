using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Operations
    {
        public static double compute_fiteness(int[] a, List<ServiceSet>[] service)//计算适应值
        {

            double fitness = 0.0;
            for (int i = 0; i < Parameters.Sub_Num; i++)
            {    
                fitness += Parameters.weight[0] * service[i][a[i]].Get_avilability()
                         + Parameters.weight[1] * service[i][a[i]].Get_cost()
                         + Parameters.weight[2] * service[i][a[i]].Get_reputation()
                         + Parameters.weight[3] * service[i][a[i]].Get_responsetime();
            }
            return fitness;
        }
        public static Location Init(List<ServiceSet>[] services)//初始化果蝇种群的位置并映射到序列号
        {
            Location fly = new Location(); ;
            double[] a = new double[Parameters.Sub_Num];//存储位置
            int[] c=new int[Parameters.Sub_Num];//存储由横纵坐标计算得出的服务序列号
            double d = 0.0;//与原点的距离
            double s = 0.0;//浓度
            double smell = 0.0;//由浓度计算而来
            Random ran=new Random();
            for (int i = 0; i < Parameters.Sub_Num; i++)//每个种群位置的初始化
            {
                a[i] = services[0].Count *ran.NextDouble();//初始化位置
                d = Math.Sqrt(a[i]*a[i]);//计算与原点的距离
                s = 1 / d;//计算浓度
                smell = 1 / s;//通过位置计算序列号
                c[i] =(int)(smell);//
            }           
            fly.Set_All(a,c);
            return fly;
        }
        public static double p(double a, double t)
        {
            a = -a;
            double k = Math.Exp(a / t);
            return k;
        }
        public static double getrk()
        {
            return 0.3;
        }
        public static Location run_foa(Location fly, List<ServiceSet>[] Services,Random ran,ref double bestFitness)//反复迭代选取最优路径
        {
            //bestFitness = compute_fiteness(fly.Get_Task(),Services);//初始化最优适应值
            bestFitness = 1000.0;
            double nowbest = 1000.0;
            Location bestfly = new Location(fly.Get_X(),fly.Get_Task());
            Location nowbestfly = new Location(fly.Get_X(), fly.Get_Task());
            double[] a=new double[Parameters.Sub_Num];//存储果蝇位置
            double d = 0.0;//距离
            double s = 0.0;//浓度
            double smell = 0.0;//由浓度计算而来
            //int sum = 0;
            Random RN = new Random();
            int[] c=new int[Parameters.Sub_Num];//存储由位置计算得出的服务序列号
            List<Location>flys=new List<Location>();//存储服务组合路径
            List<double> fit = new List<double>();//存储每条服务路径所对应的适应值

            double T = 40, T_r = 0.99;
            const double eps = 1e-11;

            
            for(int i=0;i<Parameters.Num;i++)//初始化链表
            {
                flys.Add(new Location());
                fit.Add(new double());
            }
            //Random ran = new Random();
            System.Random r = new Random(System.DateTime.Now.Millisecond);
            for (int iteration = 0; iteration < Parameters.Iteration; iteration++)//迭代多次
            {
                
                for (int i = 0; i < Parameters.Num; i++)//遍历每个服务组合以最优的果蝇位置进行改变位置
                {                   
                    for (int j = 0; j < Parameters.Sub_Num; j++)//改变位置
                    {
                        a[j] = bestfly.Get_XIndex(j) + Parameters.speed * (ran.NextDouble())* ran.Next(-2,3);//根据最优位置进行改变
                        //a[j] = fly.Get_XIndex(j) + 2000 * (2*ran.NextDouble()-1);//根据最优位置进行改变
                        if (a[j] < 0)
                            a[j] = a[j] + Services[0].Count;
                        a[j] = a[j] % Services[0].Count;
                        d = Math.Sqrt(a[j] * a[j]);//计算与原点的距离
                        s = 1 / d;//计算浓度
                        smell = 1 / s;//通过位置计算序列号
                        c[j] = (int)(smell);//                            
                        if (c[j] < 0)
                            c[j] = Services[0].Count + c[j];
                        c[j] = c[j] % Services[0].Count;
                    }
                    flys[i].Set_All(a, c);                   
                    fit[i] = compute_fiteness(c,Services);//将适应值加入链表
                }
                double groupbestfit = 1000.0;
                for (int i = 0; i < Parameters.Num; i++)//寻找种群中最优的适应值并存入fly里面
                {
                    if (fit[i] < groupbestfit)
                    {
                        groupbestfit = fit[i];
                        fly.Set_All(flys[i].Get_X(),flys[i].Get_Task());
                    }
                }

                if (groupbestfit < nowbest)
                {
                    nowbest = groupbestfit;
                    if (nowbest < bestFitness)
                    {
                        bestFitness = nowbest;
                        bestfly.Set_All(fly.Get_X(), fly.Get_Task());
                    }
                    nowbestfly.Set_All(fly.Get_X(), fly.Get_Task());
                }
                else
                {
                    if (p(groupbestfit - nowbest, T) < getrk())
                    {
                        //Console.WriteLine("{0},{1},{2}",p(groupbestfit-bestFitness,T),rk,T);
                        nowbest = groupbestfit;
                        nowbestfly.Set_All(fly.Get_X(), fly.Get_Task());
                    }
                }
                T *= T_r;
                if (T <= eps) T = 40;
                //if(iteration%10==0)
                //Console.WriteLine("第{0}代，适应值：{1}",iteration,bestFitness);
                //if (bestFitness < 0.57)
                //{
                //    Console.WriteLine("第{0}代", iteration);
                //    break;
                //}
                //Console.WriteLine("{0},{1},{2},{3},{4}", fly.Get_TaskIndex(0), fly.Get_TaskIndex(1), fly.Get_TaskIndex(2), fly.Get_TaskIndex(3), fly.Get_TaskIndex(4));             
            }
                return bestfly;
        }
    }
}
