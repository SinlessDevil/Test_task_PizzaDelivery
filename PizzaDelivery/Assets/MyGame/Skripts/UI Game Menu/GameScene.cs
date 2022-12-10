using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using AudioGame;

namespace UIGame
{
    [RequireComponent(typeof(GameButton))]
    public class GameScene : MonoBehaviour
    {
        [SerializeField] private Image _fadePanel;

        private void Start()
        {
            FadeAtStart();
        }

        public void FadeAtStart()
        {
            _fadePanel.DOFade(0f, 1.3f).From(1f);
        }

        public void OnEnable()
        {
            GameButton.ButtonClickExitToMenu += ExitToMenu;
            GameButton.ButtonClickRestart += Restart;
        }
        public void OnDisable()
        {
            GameButton.ButtonClickExitToMenu -= ExitToMenu;
            GameButton.ButtonClickRestart -= Restart;
        }

        private void ExitToMenu()
        {
            AudioClips.Instance.PlayClip(SoundDictionary.AUDIO_CLIP_BUTTON_CLIKC);
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
        private void Restart()
        {
            AudioClips.Instance.PlayClip(SoundDictionary.AUDIO_CLIP_BUTTON_CLIKC);
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
    }
}