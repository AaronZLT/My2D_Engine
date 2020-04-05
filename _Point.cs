using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2D_Engine
{
    class _Point
    {
        public _Point(double x,double y)
        {
            xPoint = x;
            yPoint = y;
        }
        public double xPoint;
        public double yPoint;
        public double _Distance(_Point p)
        {
            return 1 / (computeBase.invSqrt((float)((xPoint - p.xPoint) * (xPoint - p.xPoint) + (yPoint - p.yPoint) * (yPoint - p.yPoint))));
        }
        public double _DistanceSquare(_Point p)
        {
            return (xPoint - p.xPoint) * (xPoint - p.xPoint) + (yPoint - p.yPoint) * (yPoint - p.yPoint);
        }
    }
    class VectorXY
    {
        public VectorXY() { }
        public VectorXY(double x, double y)
        {
            vx = x;
            vy = y;
        }
        public double vx = 0;
        public double vy = 0;

        public static VectorXY operator +(VectorXY v1,VectorXY v2)
        {
            return new VectorXY(v1.vx + v2.vx, v1.vy + v2.vy);
        }
        public static VectorXY operator -(VectorXY v1, VectorXY v2)
        {
            return new VectorXY(v1.vx - v2.vx, v1.vy - v2.vy);
        }
        public double NormSuquare()
        {
            return Math.Pow(vx, 2) + Math.Pow(vy, 2);
        }
    }
    class Vector2d
    {
        public Vector2d() {  }
        public Vector2d(double x,double y,double v)
        {
            vx = x;
            vy = y;
            velocity = v;
        }
        public Vector2d(double x,double y)
        {
            vx = x;
            vy = y;
        }
        public double vx = 0;
        public double vy = 0;
        public double velocity = 0;
    }
    class Force:VectorXY { }
    class Acce:VectorXY { }
}
