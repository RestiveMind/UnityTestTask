using UnityEngine;

namespace Gameplay.Components
{
    [RequireComponent(typeof(Unit))]
    public class DamageReceiverComponent : MonoBehaviour
    {
        private Unit _unit;
        private void Awake()
        {
            _unit = GetComponent<Unit>();
        }
        public void ReceiveDamage()
        {
            _unit.Destroy();
        }
    }
}
