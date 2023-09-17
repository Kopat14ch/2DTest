using Sources.Modules.Player.Scripts;
using Sources.Modules.Weapon.Scripts.BulletsPool;
using Sources.Modules.Weapon.Scripts.Factory;
using Sources.Modules.Weapon.Scripts.ScriptableObjects;
using UnityEngine;

namespace Sources.Game.Scripts
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private PlayerRoot _playerRoot;
        [SerializeField] private PlayerFactory _playerFactory;
        [SerializeField] private WeaponConfig _deagleConfig;
        [SerializeField] private WeaponFactory _weaponFactory;
        [SerializeField] private BulletsPool _bulletsPool;

        private void Awake()
        {
            _bulletsPool.Disable();
            _playerRoot.Disable();
            
            _playerFactory.Init(_playerRoot);
            
            _weaponFactory.Init(_playerFactory.CurrentPlayer.transform, _deagleConfig);
            _bulletsPool.Init(_deagleConfig, _weaponFactory.CurrentWeaponRoot.Shooting, _weaponFactory.CurrentWeaponRoot.transform);
        }
    }
}
