using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PSO
{
    class Program
    {
        static void Main(string[] args)
        {

            //真实数据集
            string[,] filepath = { { "../Data/RealData/S1_500.txt", "../Data/RealData/S2_500.txt", "../Data/RealData/S3_500.txt", "../Data/RealData/S4_500.txt", "../Data/RealData/S5_500.txt" }, { "../Data/RealData/S1_400.txt", "../Data/RealData/S2_400.txt", "../Data/RealData/S3_400.txt", "../Data/RealData/S4_400.txt", "../Data/RealData/S5_400.txt" }, { "../Data/RealData/S1_300.txt", "../Data/RealData/S2_300.txt", "../Data/RealData/S3_300.txt", "../Data/RealData/S4_300.txt", "../Data/RealData/S5_300.txt" }, { "../Data/RealData/S1_200.txt", "../Data/RealData/S2_200.txt", "../Data/RealData/S3_200.txt", "../Data/RealData/S4_200.txt", "../Data/RealData/S5_200.txt" }, { "../Data/RealData/S1_100.txt", "../Data/RealData/S2_100.txt", "../Data/RealData/S3_100.txt", "../Data/RealData/S4_100.txt", "../Data/RealData/S5_100.txt" } };

            //string[,] filepath = { { "../Data/Random/S1_500.txt", "../Data/Random/S2_500.txt", "../Data/Random/S3_500.txt", "../Data/Random/S4_500.txt", "../Data/Random/S5_500.txt" }, { "../Data/Random/S1_400.txt", "../Data/Random/S2_400.txt", "../Data/Random/S3_400.txt", "../Data/Random/S4_400.txt", "../Data/Random/S5_400.txt" }, { "../Data/Random/S1_300.txt", "../Data/Random/S2_300.txt", "../Data/Random/S3_300.txt", "../Data/Random/S4_300.txt", "../Data/Random/S5_300.txt" }, { "../Data/Random/S1_200.txt", "../Data/Random/S2_200.txt", "../Data/Random/S3_200.txt", "../Data/Random/S4_200.txt", "../Data/Random/S5_200.txt" }, { "../Data/Random/S1_100.txt", "../Data/Random/S2_100.txt", "../Data/Random/S3_100.txt", "../Data/Random/S4_100.txt", "../Data/Random/S5_100.txt" } };

            //真实数据集关系集
            string[,] repath = { 
                                { "../data/relation/real/s10/s_500.txt", "../data/relation/real/s10/s_400.txt", "../data/relation/real/s10/s_300.txt", "../data/relation/real/s10/s_200.txt", "../data/relation/real/s10/s_100.txt" }, 
                                { "../data/relation/real/s11/s_500.txt", "../data/relation/real/s11/s_400.txt", "../data/relation/real/s11/s_300.txt", "../data/relation/real/s11/s_200.txt", "../data/relation/real/s11/s_100.txt" }, 
                                { "../data/relation/real/s12/s_500.txt", "../data/relation/real/s12/s_400.txt", "../data/relation/real/s12/s_300.txt", "../data/relation/real/s12/s_200.txt", "../data/relation/real/s12/s_100.txt" }, 
                                { "../data/relation/real/s13/s_500.txt", "../data/relation/real/s13/s_400.txt", "../data/relation/real/s13/s_300.txt", "../data/relation/real/s13/s_200.txt", "../data/relation/real/s13/s_100.txt" }, 
                                { "../data/relation/real/s14/s_500.txt", "../data/relation/real/s14/s_400.txt", "../data/relation/real/s14/s_300.txt", "../data/relation/real/s14/s_200.txt", "../data/relation/real/s14/s_100.txt" }, 
                                { "../data/relation/real/s15/s_500.txt", "../data/relation/real/s15/s_400.txt", "../data/relation/real/s15/s_300.txt", "../data/relation/real/s15/s_200.txt", "../data/relation/real/s15/s_100.txt" },
                                { "../data/relation/real/s16/s_500.txt", "../data/relation/real/s16/s_400.txt", "../data/relation/real/s16/s_300.txt", "../data/relation/real/s16/s_200.txt", "../data/relation/real/s16/s_100.txt"},
                                { "../data/relation/real/s17/s_500.txt", "../data/relation/real/s17/s_400.txt", "../data/relation/real/s17/s_300.txt", "../data/relation/real/s17/s_200.txt", "../data/relation/real/s17/s_100.txt"},
                                { "../data/relation/real/s18/s_500.txt", "../data/relation/real/s18/s_400.txt", "../data/relation/real/s18/s_300.txt", "../data/relation/real/s18/s_200.txt", "../data/relation/real/s18/s_100.txt"},
                                { "../data/relation/real/s19/s_500.txt", "../data/relation/real/s19/s_400.txt", "../data/relation/real/s19/s_300.txt", "../data/relation/real/s19/s_200.txt", "../data/relation/real/s19/s_100.txt"},
                                { "../data/relation/real/s20/s_500.txt", "../data/relation/real/s20/s_400.txt", "../data/relation/real/s20/s_300.txt", "../data/relation/real/s20/s_200.txt", "../data/relation/real/s20/s_100.txt"},
                                { "../data/relation/real/s21/s_500.txt", "../data/relation/real/s21/s_400.txt", "../data/relation/real/s21/s_300.txt", "../data/relation/real/s21/s_200.txt", "../data/relation/real/s21/s_100.txt"},
                                { "../data/relation/real/s22/s_500.txt", "../data/relation/real/s22/s_400.txt", "../data/relation/real/s22/s_300.txt", "../data/relation/real/s22/s_200.txt", "../data/relation/real/s22/s_100.txt"},
                                { "../data/relation/real/s23/s_500.txt", "../data/relation/real/s23/s_400.txt", "../data/relation/real/s23/s_300.txt", "../data/relation/real/s23/s_200.txt", "../data/relation/real/s23/s_100.txt"},
                                { "../data/relation/real/s24/s_500.txt", "../data/relation/real/s24/s_400.txt", "../data/relation/real/s24/s_300.txt", "../data/relation/real/s24/s_200.txt", "../data/relation/real/s24/s_100.txt"},
                                { "../data/relation/real/s25/s_500.txt", "../data/relation/real/s25/s_400.txt", "../data/relation/real/s25/s_300.txt", "../data/relation/real/s25/s_200.txt", "../data/relation/real/s25/s_100.txt"},
                                { "../data/relation/real/s26/s_500.txt", "../data/relation/real/s26/s_400.txt", "../data/relation/real/s26/s_300.txt", "../data/relation/real/s26/s_200.txt", "../data/relation/real/s26/s_100.txt"},
                                { "../data/relation/real/s27/s_500.txt", "../data/relation/real/s27/s_400.txt", "../data/relation/real/s27/s_300.txt", "../data/relation/real/s27/s_200.txt", "../data/relation/real/s27/s_100.txt"},
                                { "../data/relation/real/s28/s_500.txt", "../data/relation/real/s28/s_400.txt", "../data/relation/real/s28/s_300.txt", "../data/relation/real/s28/s_200.txt", "../data/relation/real/s28/s_100.txt"},
                                { "../data/relation/real/s29/s_500.txt", "../data/relation/real/s29/s_400.txt", "../data/relation/real/s29/s_300.txt", "../data/relation/real/s29/s_200.txt", "../data/relation/real/s29/s_100.txt"},
                                { "../data/relation/real/s30/s_500.txt", "../data/relation/real/s30/s_400.txt", "../data/relation/real/s30/s_300.txt", "../data/relation/real/s30/s_200.txt", "../data/relation/real/s30/s_100.txt"},
                                { "../data/relation/real/s31/s_500.txt", "../data/relation/real/s31/s_400.txt", "../data/relation/real/s31/s_300.txt", "../data/relation/real/s31/s_200.txt", "../data/relation/real/s31/s_100.txt"},
                                { "../data/relation/real/s32/s_500.txt", "../data/relation/real/s32/s_400.txt", "../data/relation/real/s32/s_300.txt", "../data/relation/real/s32/s_200.txt", "../data/relation/real/s32/s_100.txt"},
                                { "../data/relation/real/s33/s_500.txt", "../data/relation/real/s33/s_400.txt", "../data/relation/real/s33/s_300.txt", "../data/relation/real/s33/s_200.txt", "../data/relation/real/s33/s_100.txt"},
                                { "../data/relation/real/s34/s_500.txt", "../data/relation/real/s34/s_400.txt", "../data/relation/real/s34/s_300.txt", "../data/relation/real/s34/s_200.txt", "../data/relation/real/s34/s_100.txt"},
                                { "../data/relation/real/s35/s_500.txt", "../data/relation/real/s35/s_400.txt", "../data/relation/real/s35/s_300.txt", "../data/relation/real/s35/s_200.txt", "../data/relation/real/s35/s_100.txt"},
                                { "../data/relation/real/s36/s_500.txt", "../data/relation/real/s36/s_400.txt", "../data/relation/real/s36/s_300.txt", "../data/relation/real/s36/s_200.txt", "../data/relation/real/s36/s_100.txt"},
                                { "../data/relation/real/s37/s_500.txt", "../data/relation/real/s37/s_400.txt", "../data/relation/real/s37/s_300.txt", "../data/relation/real/s37/s_200.txt", "../data/relation/real/s37/s_100.txt"},
                                { "../data/relation/real/s38/s_500.txt", "../data/relation/real/s38/s_400.txt", "../data/relation/real/s38/s_300.txt", "../data/relation/real/s38/s_200.txt", "../data/relation/real/s38/s_100.txt"},
                                { "../data/relation/real/s39/s_500.txt", "../data/relation/real/s39/s_400.txt", "../data/relation/real/s39/s_300.txt", "../data/relation/real/s39/s_200.txt", "../data/relation/real/s39/s_100.txt"},{ "../data/relation/real/s0/s_500.txt", "../data/relation/real/s0/s_400.txt", "../data/relation/real/s0/s_300.txt", "../data/relation/real/s0/s_200.txt", "../data/relation/real/s0/s_100.txt"}
                                };
            ////随机数据集关系集
            //string[,] repath = { 
            //                   { "../Data/Relation/Random/S10/S_500.txt", "../Data/Relation/Random/S10/S_400.txt", "../Data/Relation/Random/S10/S_300.txt", "../Data/Relation/Random/S10/S_200.txt", "../Data/Relation/Random/S10/S_100.txt" }, 
            //                   { "../Data/Relation/Random/S11/S_500.txt", "../Data/Relation/Random/S11/S_400.txt", "../Data/Relation/Random/S11/S_300.txt", "../Data/Relation/Random/S11/S_200.txt", "../Data/Relation/Random/S11/S_100.txt" }, 
            //                   { "../Data/Relation/Random/S12/S_500.txt", "../Data/Relation/Random/S12/S_400.txt", "../Data/Relation/Random/S12/S_300.txt", "../Data/Relation/Random/S12/S_200.txt", "../Data/Relation/Random/S12/S_100.txt" }, 
            //                   { "../Data/Relation/Random/S13/S_500.txt", "../Data/Relation/Random/S13/S_400.txt", "../Data/Relation/Random/S13/S_300.txt", "../Data/Relation/Random/S13/S_200.txt", "../Data/Relation/Random/S13/S_100.txt" }, 
            //                   { "../Data/Relation/Random/S14/S_500.txt", "../Data/Relation/Random/S14/S_400.txt", "../Data/Relation/Random/S14/S_300.txt", "../Data/Relation/Random/S14/S_200.txt", "../Data/Relation/Random/S14/S_100.txt" }, 
            //                   { "../Data/Relation/Random/S15/S_500.txt", "../Data/Relation/Random/S15/S_400.txt", "../Data/Relation/Random/S15/S_300.txt", "../Data/Relation/Random/S15/S_200.txt", "../Data/Relation/Random/S15/S_100.txt" },
            //                   { "../Data/Relation/Random/S16/S_500.txt", "../Data/Relation/Random/S16/S_400.txt", "../Data/Relation/Random/S16/S_300.txt", "../Data/Relation/Random/S16/S_200.txt", "../Data/Relation/Random/S16/S_100.txt"},
            //                   { "../Data/Relation/Random/S17/S_500.txt", "../Data/Relation/Random/S17/S_400.txt", "../Data/Relation/Random/S17/S_300.txt", "../Data/Relation/Random/S17/S_200.txt", "../Data/Relation/Random/S17/S_100.txt"},
            //                   { "../Data/Relation/Random/S18/S_500.txt", "../Data/Relation/Random/S18/S_400.txt", "../Data/Relation/Random/S18/S_300.txt", "../Data/Relation/Random/S18/S_200.txt", "../Data/Relation/Random/S18/S_100.txt"},
            //                   { "../Data/Relation/Random/S19/S_500.txt", "../Data/Relation/Random/S19/S_400.txt", "../Data/Relation/Random/S19/S_300.txt", "../Data/Relation/Random/S19/S_200.txt", "../Data/Relation/Random/S19/S_100.txt"},
            //                   { "../Data/Relation/Random/S20/S_500.txt", "../Data/Relation/Random/S20/S_400.txt", "../Data/Relation/Random/S20/S_300.txt", "../Data/Relation/Random/S20/S_200.txt", "../Data/Relation/Random/S20/S_100.txt"},
            //                   { "../Data/Relation/Random/S21/S_500.txt", "../Data/Relation/Random/S21/S_400.txt", "../Data/Relation/Random/S21/S_300.txt", "../Data/Relation/Random/S21/S_200.txt", "../Data/Relation/Random/S21/S_100.txt"},
            //                   { "../Data/Relation/Random/S22/S_500.txt", "../Data/Relation/Random/S22/S_400.txt", "../Data/Relation/Random/S22/S_300.txt", "../Data/Relation/Random/S22/S_200.txt", "../Data/Relation/Random/S22/S_100.txt"},
            //                   { "../Data/Relation/Random/S23/S_500.txt", "../Data/Relation/Random/S23/S_400.txt", "../Data/Relation/Random/S23/S_300.txt", "../Data/Relation/Random/S23/S_200.txt", "../Data/Relation/Random/S23/S_100.txt"},
            //                   { "../Data/Relation/Random/S24/S_500.txt", "../Data/Relation/Random/S24/S_400.txt", "../Data/Relation/Random/S24/S_300.txt", "../Data/Relation/Random/S24/S_200.txt", "../Data/Relation/Random/S24/S_100.txt"},
            //                   { "../Data/Relation/Random/S25/S_500.txt", "../Data/Relation/Random/S25/S_400.txt", "../Data/Relation/Random/S25/S_300.txt", "../Data/Relation/Random/S25/S_200.txt", "../Data/Relation/Random/S25/S_100.txt"},
            //                   { "../Data/Relation/Random/S26/S_500.txt", "../Data/Relation/Random/S26/S_400.txt", "../Data/Relation/Random/S26/S_300.txt", "../Data/Relation/Random/S26/S_200.txt", "../Data/Relation/Random/S26/S_100.txt"},
            //                   { "../Data/Relation/Random/S27/S_500.txt", "../Data/Relation/Random/S27/S_400.txt", "../Data/Relation/Random/S27/S_300.txt", "../Data/Relation/Random/S27/S_200.txt", "../Data/Relation/Random/S27/S_100.txt"},
            //                   { "../Data/Relation/Random/S28/S_500.txt", "../Data/Relation/Random/S28/S_400.txt", "../Data/Relation/Random/S28/S_300.txt", "../Data/Relation/Random/S28/S_200.txt", "../Data/Relation/Random/S28/S_100.txt"},
            //                   { "../Data/Relation/Random/S29/S_500.txt", "../Data/Relation/Random/S29/S_400.txt", "../Data/Relation/Random/S29/S_300.txt", "../Data/Relation/Random/S29/S_200.txt", "../Data/Relation/Random/S29/S_100.txt"},
            //                   { "../Data/Relation/Random/S30/S_500.txt", "../Data/Relation/Random/S30/S_400.txt", "../Data/Relation/Random/S30/S_300.txt", "../Data/Relation/Random/S30/S_200.txt", "../Data/Relation/Random/S30/S_100.txt"},
            //                   { "../Data/Relation/Random/S31/S_500.txt", "../Data/Relation/Random/S31/S_400.txt", "../Data/Relation/Random/S31/S_300.txt", "../Data/Relation/Random/S31/S_200.txt", "../Data/Relation/Random/S31/S_100.txt"},
            //                   { "../Data/Relation/Random/S32/S_500.txt", "../Data/Relation/Random/S32/S_400.txt", "../Data/Relation/Random/S32/S_300.txt", "../Data/Relation/Random/S32/S_200.txt", "../Data/Relation/Random/S32/S_100.txt"},
            //                   { "../Data/Relation/Random/S33/S_500.txt", "../Data/Relation/Random/S33/S_400.txt", "../Data/Relation/Random/S33/S_300.txt", "../Data/Relation/Random/S33/S_200.txt", "../Data/Relation/Random/S33/S_100.txt"},
            //                   { "../Data/Relation/Random/S34/S_500.txt", "../Data/Relation/Random/S34/S_400.txt", "../Data/Relation/Random/S34/S_300.txt", "../Data/Relation/Random/S34/S_200.txt", "../Data/Relation/Random/S34/S_100.txt"},
            //                   { "../Data/Relation/Random/S35/S_500.txt", "../Data/Relation/Random/S35/S_400.txt", "../Data/Relation/Random/S35/S_300.txt", "../Data/Relation/Random/S35/S_200.txt", "../Data/Relation/Random/S35/S_100.txt"},
            //                   { "../Data/Relation/Random/S36/S_500.txt", "../Data/Relation/Random/S36/S_400.txt", "../Data/Relation/Random/S36/S_300.txt", "../Data/Relation/Random/S36/S_200.txt", "../Data/Relation/Random/S36/S_100.txt"},
            //                   { "../Data/Relation/Random/S37/S_500.txt", "../Data/Relation/Random/S37/S_400.txt", "../Data/Relation/Random/S37/S_300.txt", "../Data/Relation/Random/S37/S_200.txt", "../Data/Relation/Random/S37/S_100.txt"},
            //                   { "../Data/Relation/Random/S38/S_500.txt", "../Data/Relation/Random/S38/S_400.txt", "../Data/Relation/Random/S38/S_300.txt", "../Data/Relation/Random/S38/S_200.txt", "../Data/Relation/Random/S38/S_100.txt"},
            //                   { "../Data/Relation/Random/S39/S_500.txt", "../Data/Relation/Random/S39/S_400.txt", "../Data/Relation/Random/S39/S_300.txt", "../Data/Relation/Random/S39/S_200.txt", "../Data/Relation/Random/S39/S_100.txt"},
            //                   { "../Data/Relation/Random/S0/S_500.txt", "../Data/Relation/Random/S0/S_400.txt", "../Data/Relation/Random/S0/S_300.txt", "../Data/Relation/Random/S0/S_200.txt", "../Data/Relation/Random/S0/S_100.txt"}
            //                   };
            string savefilep = "../Data/result.txt";
            FileStream fsr = new FileStream(savefilep, FileMode.Create);
            StreamWriter wte = new StreamWriter(fsr);

            for (int k1 = 0; k1 < 5; k1++)
            {
                wte.WriteLine("Data Set "+(500-100*k1)+":");

                string[] filep = { filepath[k1, 0], filepath[k1, 1], filepath[k1, 2], filepath[k1, 3], filepath[k1, 4] };
                for (int k2 = 30; k2 < 31; k2++)
                {
                    wte.WriteLine("     Relation set S"+(10+k2)+":");
                    PServer bestserver = new PServer();
                    List<PServer> scrlist = new List<PServer>();
                    List<Server>[] wlist = new List<Server>[Constnum.PARTICE_DIM];
                    List<Relation> re = new List<Relation>();
                    double fit = 0, totaltime = 0;
                    wlist = GetData.splitedatafromfile(filep, Constnum.PARTICE_DIM);
                    re = GetData.GetRelation(repath[k2,k1]);

                    Timing dobj = new Timing();
                    int sum = 0;
                    double totalfit = 0;
                    double RMSE = 0;
                    double[] ttfit = new double[101];
                    for (int i = 0; i < 100; i++)
                    {
                        scrlist = PServer.GetinitPserver(wlist);
                        dobj.startTime();
                        bestserver = PSO.GetBest(scrlist, wlist, ref fit, re);
                        dobj.StopTime();

                        totaltime += dobj.Result().Milliseconds;
                        totaltime += dobj.Result().Seconds * 1000;
                        totalfit += fit;
                        ttfit[i] = fit;

                        Console.WriteLine("Best fit={0}", fit);
                        Console.WriteLine("The Best combination is {0},{1},{2},{3},{4}", bestserver.getIndextask(0), bestserver.getIndextask(1), bestserver.getIndextask(2), bestserver.getIndextask(3), bestserver.getIndextask(4));

                        Console.WriteLine("The time cost is {0}ms,{1}s,**********{2}", dobj.Result().Milliseconds, dobj.Result().Seconds, sum);
                        wte.WriteLine("             Run "+i+" th result is: fit= "+fit+" ,time= "+(dobj.Result().Seconds*1000+dobj.Result().Milliseconds));
                    }
                    //求均方根误差
                    for (int i = 0; i < 100; i++)
                    {
                        RMSE += (ttfit[i] - totalfit / 100) * (ttfit[i] - totalfit / 100);
                    }
                    RMSE = RMSE / 100;
                    RMSE = Math.Sqrt(RMSE);
                    Console.WriteLine("Average is {0},time is {1},RMSE is {2},********{3}", totalfit / 100, totaltime / 100, RMSE, (double)sum / 100);

                    wte.WriteLine("         Average is " + totalfit / 100 + " ,time is " + totaltime / 100 + " ,RMSE is "+ RMSE);
                }
                    
            }
            wte.Close();
            fsr.Close();
        }
    }
}
