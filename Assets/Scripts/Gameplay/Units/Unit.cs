using UnityEngine;

namespace Gameplay
{
    public abstract class Unit : MonoBehaviour
    {
        public virtual void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
