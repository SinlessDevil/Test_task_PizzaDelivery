using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIGame{
    public class GameButton : MonoBehaviour{
        public static event Action ButtonClickExitToMenu;
        public static event Action ButtonClickRestart;

        [Header("----------------------- Win Panel Buttons -----------------------")]
        [SerializeField] private Button _buttonWinPanelExitToMenu;
        [Space(10)]
        [Header("----------------------- Game Over Panel Buttons -----------------------")]
        [SerializeField] private Button _buttonGameOverPanelExitToMenu;
        [SerializeField] private Button _buttonGameOverPanelRestart;

        private void Start()
        {
            _buttonWinPanelExitToMenu.onClick.RemoveAllListeners();
            _buttonWinPanelExitToMenu.onClick.AddListener(OnExitToMenuButtonClick);

            _buttonGameOverPanelExitToMenu.onClick.RemoveAllListeners();
            _buttonGameOverPanelExitToMenu.onClick.AddListener(OnExitToMenuButtonClick);

            _buttonGameOverPanelRestart.onClick.RemoveAllListeners();
            _buttonGameOverPanelRestart.onClick.AddListener(OnRestartGameButtonClick);
        }

        private void OnExitToMenuButtonClick() => ButtonClickExitToMenu?.Invoke();
        private void OnRestartGameButtonClick() => ButtonClickRestart?.Invoke();
    }
}