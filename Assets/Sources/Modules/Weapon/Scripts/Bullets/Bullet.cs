using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Sources.Modules.Weapon.Scripts.Bullets
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Bullet : MonoBehaviour
    {
        private const float StartRotateZ = -90;
        
        private Rigidbody2D _rigidbody2D;
        private CancellationTokenSource _tokenSource;
        private CancellationToken _cancellation;
        private Transform _gunTransform;
        private Transform _transform;
        private float _speed;
        private float _timeSecondsToDisable;

        private async void OnEnable()
        {
            _transform.rotation = Quaternion.Euler(0,0, _gunTransform.rotation.eulerAngles.z - StartRotateZ);
            Vector2 gunDirection = new Vector2(_gunTransform.right.x, _gunTransform.right.y);
            
            _rigidbody2D.velocity = gunDirection.normalized * _speed;
            
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(_timeSecondsToDisable), _cancellation);
                Disable();
            }
            catch (Exception e)
            {
                //
            }
        }
        
        private void OnDestroy() => _tokenSource.Cancel();
        
        public void Init(float speed, float timeSecondsToDisable, Transform gunTransform)
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _speed = speed;
            _timeSecondsToDisable = timeSecondsToDisable;
            _gunTransform = gunTransform;
            _tokenSource = new CancellationTokenSource();
            _cancellation = _tokenSource.Token;
            _transform = transform;
        }

        public void Enable() => gameObject.SetActive(true);
        public void Disable() => gameObject.SetActive(false);
        
        public void SetPosition(Vector3 position) => _transform.position = position;

        public void SetRotate(float rotateZ)
        {
            Debug.Log($"Rotate - {rotateZ - StartRotateZ}");
            transform.rotation = Quaternion.Euler(0,0, rotateZ - StartRotateZ);
        }
    }
}