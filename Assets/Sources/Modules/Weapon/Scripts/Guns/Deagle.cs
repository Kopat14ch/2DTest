using UnityEngine.InputSystem;

namespace Sources.Modules.Weapon.Scripts.Guns
{
    internal class Deagle : Gun
    {
        protected override void Shoot(InputAction.CallbackContext ctx)
        {
            CurrentBullets--;
            
            base.Shoot(ctx);
        }
    }
}