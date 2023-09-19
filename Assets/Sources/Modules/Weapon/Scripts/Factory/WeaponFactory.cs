using Sources.Modules.Weapon.Scripts.ScriptableObjects;
using UnityEngine;

namespace Sources.Modules.Weapon.Scripts.Factory
{
    public class WeaponFactory : MonoBehaviour
    {
        private const float Offset = 1.5f;
        
        public WeaponRoot CurrentWeaponRoot { get; private set; }
        
        public void Init(Transform playerTransform, WeaponConfig config)
        {
            Vector3 newPosition = playerTransform.position;
            newPosition.x += Offset;
            
            config.WeaponRoot.Disable();

            CurrentWeaponRoot = Instantiate(config.WeaponRoot, newPosition, Quaternion.identity, playerTransform);
            CurrentWeaponRoot.Init(config, playerTransform);
            config.WeaponRoot.Enable();
        }
    }
}
