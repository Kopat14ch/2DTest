using UnityEngine;

namespace Sources.Modules.Player.Scripts
{
    internal class PlayerMovement
    {
        private readonly Transform _transform;
        private readonly float _speed;
        
        internal PlayerMovement(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }
    }
}
