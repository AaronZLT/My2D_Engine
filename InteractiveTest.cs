using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2D_Engine
{
    class InteractiveTest
    {
        public InteractiveTest() { }
        public List<testClass> tests = new List<testClass>();
        public testClass test = new testClass();
        public void it()
        {
            tests.Add(test);
            test.num = 1;
            Console.WriteLine(test.num);
            Console.WriteLine(tests[0].num);
            
        }
    }
    class testClass
    {

        public testClass() { }
        public double num = 0;
    }
    class player : GameObject
    {
        
    }
}
