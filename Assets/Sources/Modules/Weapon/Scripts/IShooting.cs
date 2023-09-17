using System;

namespace Sources.Modules.Weapon.Scripts
{
    public interface IShooting
    {
        public ShootPoint ShootPoint { get; }
        
        public event Action Shooting;
    }
}