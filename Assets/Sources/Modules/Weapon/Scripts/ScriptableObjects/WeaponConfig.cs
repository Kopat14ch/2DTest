using Sources.Modules.Weapon.Scripts.Bullets;
using UnityEngine;

namespace Sources.Modules.Weapon.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = FileName, menuName = MenuName)]
    public class WeaponConfig : ScriptableObject
    {
        [field: SerializeField, Range(MinBulletSpeed, MaxBulletSpeed)] public float BulletSpeed { get; private set; }
        [field: SerializeField, Range(MinTimeToDestroy, MaxTimeToDestroy)] public float TimeToDestroyBullet { get; private set; }
        
        [field: SerializeField, Range(MinCurrentBulletsLimit, MaxCurrentBulletsLimit)] public int MaxCurrentBullets { get; private set; }
        [field: SerializeField] public WeaponRoot WeaponRoot { get; private set; }
        [field: SerializeField] public Bullet Bullet { get; private set; }

        private const string FileName = "WeaponConfig";
        private const string MenuName = "Configs/" + FileName;

        private const int MinBulletSpeed = 1;
        private const int MaxBulletSpeed = 100;

        private const int MinTimeToDestroy = 1;
        private const int MaxTimeToDestroy = 10;

        private const int MinCurrentBulletsLimit = 5;
        private const int MaxCurrentBulletsLimit = 60;

    }
}