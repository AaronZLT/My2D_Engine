using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2D_Engine
{
    class Motion
    {
        GameObject gameobj;
        //public double velocity;
        public Force force;
        public Vector2d VD;
        public Acce acceleration;
        public void ActiveForce()
        {
            while (gameobj.isActive)
            {
                acceleration.vx = force.vx / gameobj.rigidBody.Mass;
                acceleration.vy = force.vy / gameobj.rigidBody.Mass;
            }
        }
        public Vector2d LM()
        {
            return new Vector2d(VD.vx,VD.vy,gameobj.rigidBody.Mass * VD.velocity);
            //return 0;
        }
        public double KE()
        {
            return 0.5 * gameobj.rigidBody.Mass * VD.velocity * VD.velocity;
        }
    }
}
