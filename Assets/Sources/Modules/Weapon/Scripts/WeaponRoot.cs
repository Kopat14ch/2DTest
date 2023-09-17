using Sources.Modules.Weapon.Scripts.Guns;
using Sources.Modules.Weapon.Scripts.ScriptableObjects;
using UnityEngine;

namespace Sources.Modules.Weapon.Scripts
{
    [RequireComponent(typeof(Gun))]
    public class WeaponRoot : MonoBehaviour
    {
        private Gun _gun;

        public IShooting Shooting { get; private set; }

        public void Init(WeaponConfig weaponConfig)
        {
            _gun = GetComponent<Gun>();
            _gun.Init(weaponConfig.MaxCurrentBullets);
            
            Shooting = _gun;
            Enable();
        }
        
        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }
    }
}
