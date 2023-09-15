using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sources.Modules.Player.Scripts
{
    internal class PlayerMovement
    {
        private readonly Rigidbody2D _rigidbody2D;
        private readonly PlayerInput _playerInput;
        private readonly float _speed;

        internal PlayerMovement(Rigidbody2D rigidbody2D, float speed)
        {
            _rigidbody2D = rigidbody2D;
            _speed = speed;
            _playerInput = new PlayerInput();
        }

        public void Enable()
        {
            _playerInput.Enable(); 
            _playerInput.Player.Move.performed += Move;
        }

        public void Disable()
        {
            _playerInput.Disable();
            _playerInput.Player.Move.performed -= Move;
        }

        private async void Move(InputAction.CallbackContext ctx)
        {
            Vector2 directionVector2 = new Vector2(ctx.ReadValue<float>(), 0);
            
            while (directionVector2.magnitude != 0)
            {
                directionVector2.x = ctx.ReadValue<float>();
                _rigidbody2D.velocity = new Vector2(_speed * directionVector2.x, _rigidbody2D.velocity.y);
                await Task.Yield();
            }

            await Task.CompletedTask;
        }
    }
}
