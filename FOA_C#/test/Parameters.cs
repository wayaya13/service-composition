using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Parameters
    {
        public static int Num = 120;//每个种群的果蝇数
        public static int Sub_Num = 5;//任务数
        public static int weight_Num = 4;//每个服务所含的QOS个数
        public static int Iteration = 1000;//迭代数
        public static int test_Num = 50;//实验数
        public static double speed = 30;//步长
        public static double[] weight = { 0.2, 0.2, 0.3, 0.3 }; //定义一个存储服务的QOs权值的数组
    }
}
