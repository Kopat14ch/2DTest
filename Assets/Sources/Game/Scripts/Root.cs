using Sources.Modules.Player.Scripts;
using Sources.Modules.PlayerFactory.Scripts;
using UnityEngine;

namespace Sources.Game.Scripts
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private PlayerRoot _playerRoot;
        [SerializeField] private PlayerFactory _playerFactory;

        private void Awake()
        {
            _playerRoot.Disable();
            _playerFactory.Init(_playerRoot);
        }
    }
}
