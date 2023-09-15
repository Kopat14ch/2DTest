using UnityEngine;

namespace Sources.Modules.Player.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerRoot : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;

        private Rigidbody2D _rigidbody2D;
        private PlayerMovement _playerMovement;
        private PlayerJump _playerJump;

        public void Init()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            
            _playerMovement = new PlayerMovement(_rigidbody2D, _playerConfig.Speed);
            _playerJump = new PlayerJump(_rigidbody2D, _playerConfig.JumpForce);
        }

        public void Enable()
        {
            enabled = true;
        }

        public void Disable()
        {
            enabled = false;
        }

        private void OnEnable()
        {
            _playerMovement.Enable();
            _playerJump.Enable();
        }

        private void OnDisable()
        {
            _playerMovement.Disable();
            _playerJump.Disable();
        }
    }
}
