using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Location
    {
        double[] x=new double[Parameters.Sub_Num];//果蝇位置
        int[] task=new int[Parameters.Sub_Num];//由果蝇位置所计算出的服务序列号
        public Location()//空构造函数
        {
        }
        public Location(double[] a,int[] c)//有值构造函数
        {
            for (int i = 0; i < Parameters.Sub_Num; i++)//赋值
            {
                x[i] = a[i];
                task[i] = c[i];
            }
        }
        public double Get_XIndex(int i)//返回果蝇位置
        {
            return x[i];
        }
        public int Get_TaskIndex(int i)//返回由第i个果蝇所计算得出的服务序列号
        {
            return task[i];
        }

        public double[] Get_X()
        {
            return x;
        }
        public int[] Get_Task()//返回整个服务序列号
        {
            return task;
        }

        public void Set_X(double[] a)//设置位置
        {
            for (int i = 0; i < Parameters.Sub_Num; i++)
            {
                x[i] = a[i];
            }
        }
        public void Set_Task(int[] a)//设置整个数组
        {
            for (int i = 0; i < Parameters.Sub_Num; i++)
            {
                task[i] = a[i];
            }
        }

        public void Set_All(double[] a, int[] b)//设置位置和序列号
        {
            for (int i = 0; i < Parameters.Sub_Num; i++)
            {
                x[i] = a[i];
                task[i] = b[i];
            }
        }
        public void Set_XIndex(int i, double b)//设置第i个位置为b
        {
            x[i] = b;
        }
        public void Set_TaskIndex(int i, int b)//设置固定位置的序列号
        {
            task[i] = b;
        }
    }
}
