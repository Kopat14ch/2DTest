using UnityEngine;

namespace Sources.Modules.Player.Scripts
{
    public class PlayerFactory : MonoBehaviour
    {
        private PlayerRoot _playerPrefab;
        
        public PlayerRoot CurrentPlayer { get; private set; }

        public void Init(PlayerRoot playerPrefab)
        {
            _playerPrefab = playerPrefab;
            Spawn();
        }

        private void Spawn()
        {
            CurrentPlayer = Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity);
            CurrentPlayer.Init();
            CurrentPlayer.Enable();
        }
    }
}