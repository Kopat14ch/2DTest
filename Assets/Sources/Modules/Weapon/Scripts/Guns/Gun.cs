using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sources.Modules.Weapon.Scripts.Guns
{
    public abstract class Gun : MonoBehaviour, IShooting
    {
        [SerializeField] private ShootPoint _shootPoint;
        
        protected int CurrentBullets;

        private PlayerInput _playerInput;
        private int _maxCurrentBullets;
        private const int MinBullets = 0;
        
        public event Action Shooting;
        public ShootPoint ShootPoint => _shootPoint;

        private void OnEnable()
        {
            _playerInput.Enable();
            _playerInput.Player.Shoot.performed += Shoot;
        }

        private void OnDisable()
        {
            _playerInput.Disable();
            _playerInput.Player.Shoot.performed -= Shoot;
        }
        
        public void Init(int maxCurrentBullets)
        {
            _maxCurrentBullets = maxCurrentBullets;
            CurrentBullets = _maxCurrentBullets;
            _playerInput = new PlayerInput();
        }

        public float GetRotationZ() => transform.rotation.z;

        protected virtual void Shoot(InputAction.CallbackContext ctx)
        {
            Debug.Log("shoot");
            if (CurrentBullets <= MinBullets)
                Reload();
            
            Shooting?.Invoke();
        }

        private void Reload()
        {
            CurrentBullets = _maxCurrentBullets;
        }
    }
}