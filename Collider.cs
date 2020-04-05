using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace My2D_Engine
{
    class Collider
    {
        public int ColliderID;
        public GameObject gameObj;
        public double r;
        public Collider() { }
        public Collider(GameObject gobj)
        {
            gameObj = gobj;
        }
        public bool isCollideWith(Collider collider)
        {
            return ColliderDectDelegate.Collide(this, collider);
        }
    }

    class RoundCollider : Collider
    {
        public RoundCollider()
        {
            base.ColliderID = 1;
        }
        public double r;

        public bool isCollideWith(Collider collider)
        {
            return false;
        }
    }

    class RectCollider : Collider
    {
        public double EdgeHorizontal;
        public double EdgeVertical;
        public Rectangle box = new Rectangle();
        public Point point = new Point();

        public double r()
        {
            return Math.Sqrt((EdgeHorizontal * EdgeHorizontal + EdgeVertical * EdgeVertical) / 2);
        }
        public RectCollider(double hor, double ver)
        {
            base.ColliderID = 2;
            EdgeHorizontal = hor;
            EdgeVertical = ver;
        }
        public void setBoundary(double hor, double ver)
        {
            EdgeHorizontal = hor;
            EdgeVertical = ver;
        }
        public bool isCollideWith(Collider collider)
        {
            return false;
        }
    }

    class SelfDEfCollider : Collider
    {
        public SelfDEfCollider()
        {
            base.ColliderID = 3;
        }
        public SelfDEfCollider(List<_Point> points)
        {
            base.ColliderID = 3;
            this.points = points;
        }
        public List<_Point> points;

        public bool isCollideWith(Collider collider)
        {
            return false;
        }
    }

    class DefaultCollider : Collider
    {
        public DefaultCollider()
        {
            base.ColliderID = 0;
        }
        public bool isCollideWith(Collider collider)
        {
            return false;
        }
    }

    static class ColliderDectDelegate
    {
        public static bool Collide(Collider co1, Collider co2)
        {
            if (co1.ColliderID + co2.ColliderID == 2)
            {
                return co1.gameObj.location._DistanceSquare(co2.gameObj.location) <= (co1.r + co2.r) * (co1.r + co2.r);
            }
            if (co1.ColliderID + co2.ColliderID == 3)
            {
                if(co1.ColliderID == 1)
                {
                    return CrossCircleAndRectangle((RoundCollider)co1, (RectCollider)co2);
                }
                else
                {
                    return CrossCircleAndRectangle((RoundCollider)co2, (RectCollider)co1);
                }
            }
            if (co1.ColliderID == 2 && co2.ColliderID == 2)
            {
                return RectAndRect((RectCollider)co1, (RectCollider)co2);
            }
            //then self def
            //
            return false;
        }
        public static bool CrossCircleAndRectangle(RoundCollider roc, RectCollider rec)
        {
            VectorXY v = new VectorXY(Math.Abs(roc.gameObj.location.xPoint - rec.gameObj.location.xPoint), Math.Abs(roc.gameObj.location.yPoint - rec.gameObj.location.yPoint));
            VectorXY h = new VectorXY(rec.EdgeHorizontal / 2, rec.EdgeVertical / 2);
            VectorXY u = v - h;
            u.vx = (Math.Max(u.vx, 0));
            u.vy = (Math.Max(u.vy, 0));
            return u.NormSuquare() - Math.Pow(roc.r, 2) <= 0;
        }
        public static bool RectAndRect(RectCollider rec1,RectCollider rec2)
        {
            Rectangle r1 = new Rectangle((int)rec1.gameObj.location.xPoint, (int)rec1.gameObj.location.yPoint, (int)rec1.EdgeHorizontal, (int)rec1.EdgeVertical);
            Rectangle r2 = new Rectangle((int)rec2.gameObj.location.xPoint, (int)rec2.gameObj.location.yPoint, (int)rec2.EdgeHorizontal, (int)rec2.EdgeVertical);
            return r1.IntersectsWith(r2);
        }
    }
}