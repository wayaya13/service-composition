using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA
{
    class Server          //各服务属性设置
    {
        private double availability;
        private double cost;
        private double reputation;
        private double responsetime;

        public Server()
        {
        }

        public Server(double availability, double cost, double reputation, double responsetime)
        {
            this.responsetime = responsetime;
            this.cost = cost;
            this.availability = availability;
            this.reputation = reputation;
        }
        public Server(Server s)
        {
            this.responsetime = s.responsetime;
            this.cost = s.cost;
            this.availability = s.availability;
            this.reputation = s.reputation;
        }
        public void SetServer(Server s)
        {
            this.responsetime = s.responsetime;
            this.cost = s.cost;
            this.availability = s.availability;
            this.reputation = s.reputation;
        }

        public double getresponsetime()
        {
            return responsetime;
        }
        public double getcost()
        {
            return cost;
        }
        public double getavailability()
        {
            return availability;
        }
        public double getreputation()
        {
            return reputation;
        }

        public void setresponsetime(double responsetime)
        {
            this.responsetime = responsetime;
        }
        public void setcost(double cost)
        {
            this.cost = cost;
        }
        public void setavailability(double availability)
        {
            this.availability = availability;
        }
        public void setreputation(double reputation)
        {
            this.reputation = reputation;
        }
    }
}
