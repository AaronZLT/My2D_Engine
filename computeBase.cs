using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2D_Engine
{
    static unsafe class computeBase
    {
        public static float invSqrt(float x)
        {
            float xhalf = 0.5f * x;
            int i = *(int*)&x; 
            i = 0x5f3759df - (i >> 1);
            x = *(float*)&i; 
            x = x * (1.5f - xhalf * x * x); 
            return x;
        }

        public static double multiplus(double x,double y)
        {
            return x * y;
        }
    }
}
