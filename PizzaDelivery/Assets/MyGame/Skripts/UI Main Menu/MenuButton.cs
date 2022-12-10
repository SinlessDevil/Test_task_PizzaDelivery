using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIMenu
{
    public class MenuButton : MonoBehaviour
    {
        public static event Action ButtonClickPlayGameEvent;
        public static event Action ButtonClickExitEvent;

        [Header("----------------------- Menu Buttons -----------------------")]
        [SerializeField] private Button _buttonPlayGame;
        [SerializeField] private Button _buttonExit;

        private void Start()
        {
            _buttonPlayGame.onClick.RemoveAllListeners();
            _buttonPlayGame.onClick.AddListener(OnPlayGameButtonClick);

            _buttonExit.onClick.RemoveAllListeners();
            _buttonExit.onClick.AddListener(OnExitButtonClick);

        }

        private void OnPlayGameButtonClick() => ButtonClickPlayGameEvent?.Invoke();
        private void OnExitButtonClick() => ButtonClickExitEvent?.Invoke();
    }
}