using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    class GA_Server         //遗传算法服务设置
    {
        private int[] task = new int[ConstNum.PARTICE_DIM];
        private double fit=0;
        public double Fit
        {
            get
            {
                return fit;
            }
            set
            {
                fit = value;
            }
        }

        public GA_Server()
        {
        }

        public GA_Server(int[] a)
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
        //public double getfit()
        //{
        //    return fit;
        //}

        public void fitness(List<Server>[] wlist)
        {
            fit = 0;
            double A = 1, T = 0, C = 0, R = 1;
            for (int i = 0; i < ConstNum.PARTICE_DIM; i++)
            {
                ////fit += ConstNum.weight[0] * wlist[i][task[i]].getresponsetime() +
                //    ConstNum.weight[1] * wlist[i][task[i]].getcost() +
                //    ConstNum.weight[2] * wlist[i][task[i]].getavailability() +
                //    ConstNum.weight[3] * wlist[i][task[i]].getreputation();
                A *= ConstNum.weight[2] * wlist[i][task[i]].getavailability();
                T += ConstNum.weight[0] * wlist[i][task[i]].getresponsetime();
                C += ConstNum.weight[1] * wlist[i][task[i]].getcost();
                R *= ConstNum.weight[3] * wlist[i][task[i]].getreputation();
            }
            fit = A + T + C + R;
        }
        public static List<GA_Server> GetinitGA_server(List<Server>[] wlist)//获取初始服务集
        {
            List<GA_Server> dlist = new List<GA_Server>();
            Random rad = new Random();
            for (int k = 0; k < ConstNum.NP; k++)
            {
                int[] a = new int[ConstNum.PARTICE_DIM];
                for (int i = 0; i < ConstNum.PARTICE_DIM; i++)
                    a[i] = rad.Next(0, wlist[i].Count - 1);
                dlist.Add(new GA_Server(a));
            }
            return dlist;
        }
    }
}
