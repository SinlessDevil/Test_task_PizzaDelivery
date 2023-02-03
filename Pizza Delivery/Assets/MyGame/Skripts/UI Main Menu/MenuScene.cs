using UnityEngine;
using UnityEngine.SceneManagement;
using AudioGame;

namespace UIMenu
{
    [RequireComponent(typeof(MenuButton))]
    public class MenuScene : MonoBehaviour
    {
        [SerializeField] private GameObject _audioManager;
        private void Awake()
        {
            if (GameObject.Find("[AUDIO MANAGER](Clone)") == null)
            {
                Instantiate(_audioManager, transform.position, Quaternion.identity);
            }
        }

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