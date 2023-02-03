using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIGame{
    public class GameButton : MonoBehaviour{
        public static event Action ButtonClickExitToMenu;
        public static event Action ButtonClickRestart;

        [Header("----------------------- Win Panel Buttons -----------------------")]
        [SerializeField] private Button _buttonExitToMenuWinPanel;
        [Space(10)]
        [Header("----------------------- Game Over Panel Buttons -----------------------")]
        [SerializeField] private Button _buttonExitToMenuGameOverPanel;
        [SerializeField] private Button _buttonRestartGameOverPanel;

        private void Start()
        {
            _buttonExitToMenuWinPanel.onClick.RemoveAllListeners();
            _buttonExitToMenuWinPanel.onClick.AddListener(OnExitToMenuButtonClick);

            _buttonExitToMenuGameOverPanel.onClick.RemoveAllListeners();
            _buttonExitToMenuGameOverPanel.onClick.AddListener(OnExitToMenuButtonClick);

            _buttonRestartGameOverPanel.onClick.RemoveAllListeners();
            _buttonRestartGameOverPanel.onClick.AddListener(OnRestartGameButtonClick);
        }

        private void OnExitToMenuButtonClick() => ButtonClickExitToMenu?.Invoke();
        private void OnRestartGameButtonClick() => ButtonClickRestart?.Invoke();
    }
}