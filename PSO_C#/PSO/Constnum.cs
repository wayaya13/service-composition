using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSO
{
    class Constnum
    {
        public static int PARTICE_DIM = 5;//子任务个数
        public static int WEIGHT_DIM = 4;

        public static double[] weight = { 0.3, 0.2, 0.2, 0.3 };//R,A,C,T
        public static int T = 1000;//迭代次数 

        public static int NP = 100;//种群规模
        //PSO相关参数
        public static double wmax = 0.9, wmin = 0.1;
        public static double c1max = 2, c2max = 2, c1min = 0.5, c2min = 0.5;
       
    }
}
