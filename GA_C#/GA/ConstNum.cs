using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    class ConstNum       //常量设置
    {
        public static int PARTICE_DIM = 5;//子服务个数
        public static int WEIGHT_DIM = 4;

        public static double[] weight = { 0.3, 0.2, 0.2, 0.3 };
        public static int T = 1000;//迭代次数 

        public static int NP = 50;//种群规模
        //GA参数
        public static double Mutation = 0.01;//变异概率
        public static double crossover = 0.7;//交叉概率
    }
}
