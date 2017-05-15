using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class ServiceSet
    {
        private double availability;
        private double cost;
        private double reputation;
        private double responsetime;

        public ServiceSet()
        {
        }

        public ServiceSet(double availability, double cost, double reputation, double responsetime)
        {
            this.availability = availability;
            this.cost = cost;
            this.reputation = reputation;
            this.responsetime = responsetime;
        }

        public double Get_avilability()//获取availability
        {
            return this.availability;
        }
        public void Set_avalability(double new_availability)//设置一个新的availability
        {
            this.availability = new_availability;
        }

        public double Get_cost()//获取cost
        {
            return this.cost;
        }
        public void Set_cost(double new_cost)//设置一个新的cost
        {
            this.cost = new_cost;
        }

        public double Get_reputation()//获取reputation
        {
            return this.reputation;
        }
        public void Set_reputation(double new_reputation)//设置一个新的cost
        {
            this.reputation = new_reputation;
        }

        public double Get_responsetime()//获取responsetime
        {
            return this.responsetime;
        }
        public void Set_responsetime(double new_responsetime)//设置一个新的responsetime
        {
            this.responsetime = new_responsetime;
        }
    }
}