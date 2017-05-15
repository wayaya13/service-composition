using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSO
{
    class Relation
    {
        private int[] front = new int[2];
        private double policy = 0;
        private int[] back = new int[2];

        public int[] Front
        {
            get
            {
                return front;
            }
            set
            {
                front[0] = value[0];
                front[1] = value[1];
            }
        }

        public int[] Back
        {
            get
            {
                return back;
            }
            set
            {
                back[0] = value[0];
                back[1] = value[1];
            }
        }

        public double Policy
        {
            get
            {
                return policy;
            }
            set
            {
                policy = value;
            }
        }

        public Relation()
        {

        }
        public Relation(int[] front, double policy, int[] back)
        {
            this.front[0] = front[0];
            this.front[1] = front[1];
            this.policy = policy;
            this.back[0] = back[0];
            this.back[1] = back[1];

        }

        public void SetRelation(Relation re)
        {
            this.front[0] = re.front[0];
            this.front[1] = re.front[1];
            this.policy = re.policy;
            this.back[0] = re.back[0];
            this.back[1] = re.back[1];
        }
    }
}
