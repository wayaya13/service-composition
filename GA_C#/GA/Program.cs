using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    class Program          //主函数调用GA_Server，GA_Server调用Server。实验结果为fitness平均值、运行时间、平均方差。
    {
        static void Main(string[] args)
        {

            //真实数据集
            //string[] filepath = { "../Data/RealData/S1_500.txt", "../Data/RealData/S2_500.txt", "../Data/RealData/S3_500.txt", "../Data/RealData/S4_500.txt", "../Data/RealData/S5_500.txt" };//数据集规模500
            string[] filepath = { "../Data/RealData/S1_400.txt", "../Data/RealData/S2_400.txt", "../Data/RealData/S3_400.txt", "../Data/RealData/S4_400.txt", "../Data/RealData/S5_400.txt" };//数据集规模400
            //string[] filepath = { "../Data/RealData/S1_300.txt", "../Data/RealData/S2_300.txt", "../Data/RealData/S3_300.txt", "../Data/RealData/S4_300.txt", "../Data/RealData/S5_300.txt" };//数据集规模300
            //string[] filepath = { "../Data/RealData/S1_200.txt", "../Data/RealData/S2_200.txt", "../Data/RealData/S3_200.txt", "../Data/RealData/S4_200.txt", "../Data/RealData/S5_200.txt" };//数据集规模200
            //string[] filepath = { "../Data/RealData/S1_100.txt", "../Data/RealData/S2_100.txt", "../Data/RealData/S3_100.txt", "../Data/RealData/S4_100.txt", "../Data/RealData/S5_100.txt" };//数据集规模100

            //随机数据集
            //string[] filepath = { "../Data/Random/S1_500.txt", "../Data/Random/S2_500.txt", "../Data/Random/S3_500.txt", "../Data/Random/S4_500.txt", "../Data/Random/S5_500.txt" };//数据集规模500
            //string[] filepath = { "../Data/Random/S1_400.txt", "../Data/Random/S2_400.txt", "../Data/Random/S3_400.txt", "../Data/Random/S4_400.txt", "../Data/Random/S5_400.txt" };//数据集规模400
            //string[] filepath = { "../Data/Random/S1_300.txt", "../Data/Random/S2_300.txt", "../Data/Random/S3_300.txt", "../Data/Random/S4_300.txt", "../Data/Random/S5_300.txt" };//数据集规模300
            //string[] filepath = { "../Data/Random/S1_200.txt", "../Data/Random/S2_200.txt", "../Data/Random/S3_200.txt", "../Data/Random/S4_200.txt", "../Data/Random/S5_200.txt" };//数据集规模200
            //string[] filepath = { "../Data/Random/S1_100.txt", "../Data/Random/S2_100.txt", "../Data/Random/S3_100.txt", "../Data/Random/S4_100.txt", "../Data/Random/S5_100.txt" };//数据集规模100

            GA_Server bestserver = new GA_Server();
            List<GA_Server> scrlist = new List<GA_Server>();
            List<Server>[] wlist = new List<Server>[ConstNum.PARTICE_DIM];
            double fit=0, totaltime=0;
            wlist = GetData.splitedatafromfile(filepath, ConstNum.PARTICE_DIM);
            Timing dobj = new Timing();
            int sum = 0;
            double totalfit = 0;
            double RMSE = 0;
            double[] ttfit = new double[101];
            for (int i = 0; i < 100; i++)
            {
                scrlist = GA_Server.GetinitGA_server(wlist);
              
                dobj.startTime();
                bestserver = GA.GetBest(scrlist, wlist, ref fit);
                dobj.StopTime();
               
                totaltime += dobj.Result().Milliseconds;
                totaltime += dobj.Result().Seconds * 1000;
                totalfit += fit;
                ttfit[i] = fit;

                if (Math.Abs(fit - 0.5608) <= 0.0005)//QWS--500,400
                {
                    sum++;
                }
                //if (Math.Abs(fit - 0.6835) <= 0.0005)//QWS-300
                //{
                //    sum++;
                //}
                //if (Math.Abs(fit - 0.7802) <= 0.0005)//QWS-200
                //{
                //    sum++;
                //}
                //if (Math.Abs(fit - 0.8733) <= 0.0005)//QWS-100
                //{
                //    sum++;
                //}

                //if (Math.Abs(fit - 1.4482) <= 0.0005)//RWS--500
                //{
                //    sum++;
                //}
                //if (Math.Abs(fit - 1.4569) <= 0.0005)//RWS--400
                //{
                //    sum++;
                //}
                //if (Math.Abs(fit - 1.4742) <= 0.0005)//RWS--300
                //{
                //    sum++;
                //}
                //if (Math.Abs(fit - 1.5292) <= 0.0005)//RWS--200
                //{
                //    sum++;
                //}
                //if (Math.Abs(fit - 1.5711) <= 0.0005)//RWS--100
                //{
                //    sum++;
                //}
                Console.WriteLine("Best fit={0}", fit);
                Console.WriteLine("The Best combination is {0},{1},{2},{3},{4}", bestserver.getIndextask(0), bestserver.getIndextask(1), bestserver.getIndextask(2), bestserver.getIndextask(3), bestserver.getIndextask(4));
             
                Console.WriteLine("The time cost is {0}ms,{1}s,********{2}", dobj.Result().Milliseconds, dobj.Result().Seconds,sum);

            }
            //求均方根误差
            for (int i = 0; i < 100; i++)
            {
                RMSE += (ttfit[i] - totalfit / 100) * (ttfit[i] - totalfit / 100);
            }
            RMSE = RMSE / 100;
            RMSE = Math.Sqrt(RMSE);
            //Console.WriteLine("Average is {0},time is {1},RMSE is {2},*******{3}", totalfit/ 100, totaltime / 100,RMSE,(double)sum/100);
            Console.WriteLine("Average is {0}", totalfit / 100);
            Console.WriteLine("time is {0}", totaltime / 100);
            Console.WriteLine("RMSE is {0}", RMSE);
            Console.WriteLine("*******{0}", (double)sum / 100);
            Console.ReadKey();
        }
    }
}
