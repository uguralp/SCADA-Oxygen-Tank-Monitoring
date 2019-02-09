using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3UguralpOnbasli
{
     public class OxygenTank
    {
        private bool bleeding;
        private bool filling;
        private int counter;
        public bool Bleeding { get => bleeding; set => bleeding = value; }
        public bool Filling { get => filling; set => filling = value; }
        public int Counter { get => counter; set => counter = value; }

        public OxygenTank() { }
        public OxygenTank(bool bleeding, bool filling, int counter)
        {
            this.Bleeding = bleeding;
            this.Filling = filling;
            this.Counter = counter;
        }


    }
}
