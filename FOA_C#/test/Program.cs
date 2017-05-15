using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(1/(5*Math.Sqrt(2)));
            //Console.WriteLine(1 / (5 * Math.Sqrt(2)));
            double bestFitness = 0.0;
            double[] gBestFitness=new double[Parameters.test_Num];//统计多次试验中的适应值
            double sum = 0.0,totalTime=0.0,ave=0.0,resm=0.0;
            Location bestfly = new Location();
            List<ServiceSet>[] Services = new List<ServiceSet>[Parameters.Sub_Num];//服务集
            //string[] filepath = { "../Data/S1_500.txt", "../Data/S2_500.txt", "../Data/S3_500.txt", "../Data/S4_500.txt", "../Data/S5_500.txt" };//数据集规模500
            //string[] filepath = { "../Data/S1_100.txt", "../Data/S2_100.txt", "../Data/S3_100.txt", "../Data/S4_100.txt", "../Data/S5_100.txt" };//数据集规模100
            //string[] filepath = { "../Data/S1_200.txt", "../Data/S2_200.txt", "../Data/S3_200.txt", "../Data/S4_200.txt", "../Data/S5_200.txt" };//数据集规模200
            //string[] filepath = { "../Data/S1_300.txt", "../Data/S2_300.txt", "../Data/S3_300.txt", "../Data/S4_300.txt", "../Data/S5_300.txt" };//数据集规模300
            //string[] filepath = { "../Data/S1_400.txt", "../Data/S2_400.txt", "../Data/S3_400.txt", "../Data/S4_400.txt", "../Data/S5_400.txt" };//数据集规模400
            string[] filepath = { "../Data/S1_100.txt", "../Data/S2_100.txt", "../Data/S3_100.txt", "../Data/S4_100.txt", "../Data/S5_100.txt" };//数据集规模100
            Services = GetData.splitedatafromfile(filepath, Parameters.Sub_Num);
            Random ran = new Random();
            int j = 0;
            for (int i = 0; i < Parameters.test_Num; i++)
            {
                Location fly = Operations.Init(Services);//初始化一个种群位置
                DateTime d1 = DateTime.Now;
                bestfly = Operations.run_foa(fly, Services,ran,ref bestFitness);
                gBestFitness[i] = bestFitness;//将每次的最优适应值存入数组，方便以后的方差计算
                if (gBestFitness[i] < 0.5609)
                {
                    j++;
                }
                sum += bestFitness;
                DateTime d2 = DateTime.Now;
                double time = (d2 - d1).TotalSeconds;
                totalTime += time;
                Console.Write("The {0}th：Runtime：{1}", i + 1, time);
                Console.WriteLine("  {0}->{1}->{2}->{3}->{4},Fitness={5}", bestfly.Get_TaskIndex(0), bestfly.Get_TaskIndex(1), bestfly.Get_TaskIndex(2), bestfly.Get_TaskIndex(3), bestfly.Get_TaskIndex(4), bestFitness);
            }
            ave = sum / Parameters.test_Num;
            sum = 0;
            //方差计算
            for (int i = 0; i < Parameters.test_Num; i++)
                sum += (gBestFitness[i] - ave) * (gBestFitness[i] - ave);
            sum = sum / 50;
            resm = Math.Sqrt(sum);
            Console.WriteLine("进行{0}次实验的均方差为：{1}，平均适应值为：{2}，平均用时{3}", Parameters.test_Num, resm, ave, totalTime / Parameters.test_Num);
            Console.WriteLine("达到最优路径为{0}次：",j);
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
