using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace My2D_Engine
{
    class GameObject
    {
        public bool hasTake;
        public bool isDefaultCollide;
        public bool isActive;
        public bool isRigid;
        public _Point location;
        public RigidBody rigidBody;
        public Motion motion;
        public Collider collider;
        public SpriteCG spCG;
        public int SetRigid()
        {
            isRigid = true;
            return 0;
        }
        public void DisableRigid()
        {
            isRigid = false;
        }
        public int SetRigid(RigidBody rb)
        {
            rigidBody = rb;
            isRigid = true;
            return 0;
        }
        public void Take(GameObject gameObject) { }
        public void Active() { }
        public void Vanish() { }
        public void Update() { }
        public bool IsCollideWith(GameObject gameObject)
        {
            return this.collider.isCollideWith(gameObject.collider);
        }
    }
}
