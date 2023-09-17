using UnityEngine;

namespace Sources.Modules.Weapon.Scripts
{
    public class ShootPoint : MonoBehaviour
    {
        private Transform _transform;
        public Vector2 CurrentPosition => _transform.position;

        public void Init()
        {
            _transform = transform;
        }
    }
}