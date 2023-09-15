using UnityEngine;
using UnityEngine.InputSystem;

namespace Sources.Modules.Player.Scripts
{
    internal class PlayerJump
    {
        private readonly Rigidbody2D _rigidbody2D;
        private readonly PlayerInput _playerInput;
        private readonly float _force;
        private const float RaycastDistance = 0.55f;
        
        internal PlayerJump(Rigidbody2D rigidbody2D, float force)
        {
            _rigidbody2D = rigidbody2D;
            _force = force;
            _playerInput = new PlayerInput();
        }
        
        public void Enable()
        {
            _playerInput.Enable();
            _playerInput.Player.Jump.performed += Jump;
        }

        public void Disable()
        {
            _playerInput.Disable();
            _playerInput.Player.Jump.performed -= Jump;
        }
        
        private void Jump(InputAction.CallbackContext ctx)
        {
            RaycastHit2D hit = Physics2D.Raycast(_rigidbody2D.transform.position, Vector2.down, RaycastDistance);

            if (hit.collider != null)
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
                _rigidbody2D.AddForce(_force * Vector2.up, ForceMode2D.Impulse);
            }
        }
    }
}