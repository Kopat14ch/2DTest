using System.Collections.Generic;
using Sources.Modules.Weapon.Scripts.Bullets;
using Sources.Modules.Weapon.Scripts.ScriptableObjects;
using UnityEngine;

namespace Sources.Modules.Weapon.Scripts.BulletsPool
{
    public class BulletsPool : MonoBehaviour
    {
        private List<Bullet> _bullets;
        private IShooting _shooting;
        private Bullet _bulletPrefab;
        private Transform _gunTransform;
        private int _bulletIndex;

        private void OnEnable()
        {
            _shooting.Shooting += OnShooting;
        }

        private void OnDisable()
        {
            _shooting.Shooting -= OnShooting;
        }
        
        public void Init(WeaponConfig config, IShooting shooting, Transform gunTransform)
        {
            _gunTransform = gunTransform;
            
            _bullets = new List<Bullet>();
            _bulletIndex = 0;
            
            _bulletPrefab = config.Bullet;
            _bulletPrefab.Disable();

            _shooting = shooting;
            shooting.ShootPoint.Init();

            for (int i = 0; i < config.MaxCurrentBullets; i++)
            {
                Bullet instanceBullet = Instantiate(_bulletPrefab, Vector3.zero, Quaternion.Euler(0,0,-90), transform);
                instanceBullet.Init(config.BulletSpeed, config.TimeToDestroyBullet, _gunTransform);
                _bullets.Add(instanceBullet);
            }
            
            Enable();
            _bulletPrefab.Enable();
        }
        
        public void Disable()
        {
            gameObject.SetActive(false);
        }
        
        private void Enable()
        {
            gameObject.SetActive(true);
        }

        private void OnShooting()
        {
            Bullet currentBullet = _bullets[_bulletIndex];
            

            currentBullet.Enable();
            currentBullet.SetPosition(_shooting.ShootPoint.CurrentPosition);

            _bulletIndex++;
            _bulletIndex %= _bullets.Count;
        }
    }
}