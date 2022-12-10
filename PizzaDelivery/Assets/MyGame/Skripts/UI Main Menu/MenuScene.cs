using UnityEngine;
using UnityEngine.SceneManagement;
using AudioGame;

namespace UIMenu
{
    [RequireComponent(typeof(MenuButton))]
    public class MenuScene : MonoBehaviour
    {
        public void OnEnable()
        {
            MenuButton.ButtonClickPlayGameEvent += PlayGame;
            MenuButton.ButtonClickExitEvent += ExitThisGame;
        }

        public void OnDisable()
        {
            MenuButton.ButtonClickPlayGameEvent -= PlayGame;
            MenuButton.ButtonClickExitEvent -= ExitThisGame;
        }

        private void PlayGame()
        {
            AudioClips.Instance.PlayClip(SoundDictionary.AUDIO_CLIP_BUTTON_CLIKC);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void ExitThisGame()
        {
            AudioClips.Instance.PlayClip(SoundDictionary.AUDIO_CLIP_BUTTON_CLIKC);

            Application.Quit();
            Debug.Log("Exit");
        }
    }
}