using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2D_Engine
{
    class Scene
    {
        public Dictionary<string, GameObject> gameObjs;
        public List<GameObject> activedGameObjs;
        public List<GameObject> vanishedGameObj;
        public Dictionary<GameObject, GameObject> colliders;
        public void CollideWithDefault(GameObject go1)
        {
            foreach (GameObject go2 in activedGameObjs)
            {
                if (go1.IsCollideWith(go2))
                {
                    go1.Take(go2);
                }
            }
        }
        public void Colliding()
        {
            foreach (GameObject go1 in colliders.Keys)
            {
                GameObject go2 = colliders[go1];
                if (go2.isDefaultCollide)
                {
                    CollideWithDefault(go1);
                    continue;
                }
                if (go1.IsCollideWith(go2))
                {
                    go1.Take(go2);
                }
            }
        }
        public void SetCollideRela(GameObject go1,GameObject go2)
        {
            if (go1.hasTake)
            {
                colliders.Add(go1, go2);
            }
            else
            {
                colliders.Add(go2, go1);
            }
        }
    }
}
