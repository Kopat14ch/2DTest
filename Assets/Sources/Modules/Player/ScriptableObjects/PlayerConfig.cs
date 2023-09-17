using UnityEngine;

namespace Sources.Modules.Player.ScriptableObjects
{
    [CreateAssetMenu(fileName = FileName, menuName = MenuName)]
    internal class PlayerConfig : ScriptableObject
    {
        [field: SerializeField, Range(MinSpeed, MaxSpeed)] public float Speed { get; private set; }
        [field: SerializeField, Range(MinJumpForce, MaxJumpForce)] public float JumpForce { get; private set; }

        private const string FileName = "PlayerConfig";
        private const string MenuName = "Configs/" + FileName;
        
        private const int MinSpeed = 1;
        private const int MaxSpeed = 15;

        private const int MinJumpForce = 1;
        private const int MaxJumpForce = 1000;

    }
}
