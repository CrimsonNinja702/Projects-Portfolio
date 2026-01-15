using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_and_classes
{
    class Human
    {
        public String name;
        public int speed;

        public void Run()
        {
            Console.WriteLine($"{name} is running at {speed}km/h!");
        }

        public void Stop()
        {
            Console.WriteLine($"{name} has taken a break!");
        }
    }
}
