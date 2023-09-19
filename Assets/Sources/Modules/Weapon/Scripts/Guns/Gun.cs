using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sources.Modules.Weapon.Scripts.Guns
{
    internal abstract class Gun : MonoBehaviour, IShooting
    {
        [SerializeField] private ShootPoint _shootPoint;
        [SerializeField] private float _indent;

        protected int CurrentBullets;

        private const int MinBullets = 0;
        
        private PlayerInput _playerInput;
        private Transform _playerTransform;
        private Transform _transform;
        private Vector3 _unFlippedVector3;
        private Vector3 _flippedVector3;
        private int _maxCurrentBullets;

        public event Action Shooting;
        public ShootPoint ShootPoint => _shootPoint;
        
        private bool IsFlipped => _transform.localScale == _flippedVector3;

        private void OnEnable()
        {
            _playerInput.Enable();
            _playerInput.Player.Shoot.performed += Shoot;
            _playerInput.Player.ChangeMousePosition.performed += OnChangeMousePosition;
        }

        private void OnDisable()
        {
            _playerInput.Disable();
            _playerInput.Player.Shoot.performed -= Shoot;
            _playerInput.Player.ChangeMousePosition.performed -= OnChangeMousePosition;
        }
        
        public void Init(int maxCurrentBullets, Transform playerTransform)
        {
            _transform = transform;
            Vector3 localScale = _transform.localScale;
            
            _maxCurrentBullets = maxCurrentBullets;
            CurrentBullets = _maxCurrentBullets;
            _playerTransform = playerTransform;
            _unFlippedVector3 = localScale;
            _flippedVector3 = localScale;
            _flippedVector3.y = -_flippedVector3.y;
            _playerInput = new PlayerInput();
        }

        protected virtual void Shoot(InputAction.CallbackContext ctx)
        {
            if (CurrentBullets <= MinBullets)
                Reload();
            
            Shooting?.Invoke();
        }

        private void Reload()
        {
            CurrentBullets = _maxCurrentBullets;
        }

        private void OnChangeMousePosition(InputAction.CallbackContext ctx)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            
            Vector3 directionToMouse = mousePosition - _playerTransform.position;

            if (directionToMouse.x < 0 && IsFlipped == false)
                transform.localScale = _flippedVector3;
            else if (directionToMouse.x > 0 && IsFlipped)
                _transform.localScale = _unFlippedVector3;

            SetPosition(directionToMouse);
            SetRotation(directionToMouse);
        }

        private void SetPosition(Vector3 directionToMouse)
        {
            Vector3 weaponPosition = _playerTransform.position + directionToMouse.normalized * _indent;
            
            _transform.position = weaponPosition;
        }

        private void SetRotation(Vector3 directionToMouse)
        {
            float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
            
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            _transform.rotation = rotation;
        }
    }
}