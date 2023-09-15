using Sources.Modules.Player.Scripts;
using UnityEngine;

namespace Sources.Modules.PlayerFactory.Scripts
{
    public class PlayerFactory : MonoBehaviour
    {
        private PlayerRoot _playerPrefab;

        public void Init(PlayerRoot playerPrefab)
        {
            _playerPrefab = playerPrefab;
            Spawn();
        }

        private void Spawn()
        {
            PlayerRoot playerInstance = Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity);
            playerInstance.Init();
            playerInstance.Enable();
        }
    }
}