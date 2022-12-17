using UnityEngine;
using DG.Tweening;
using AudioGame;
using System.Threading.Tasks;

public class StateOfPlay : MonoBehaviour
{
    [Header("--------- Panel ---------")]
    [SerializeField] private GameObject _panelWinGame;
    [SerializeField] private GameObject _panelGameOver;
    [SerializeField] private GameObject _panelIsNotInteractive;
    [Space(10)]
    [SerializeField] private GameObject[] _gameUI;
    [Space(10)]
    [SerializeField] private ParticleSystem _winEffect;
    private void OnEnable()
    {
        CharacterCollison.GameOverEvent += GameOver;
        Pizza.WinGameEvent += WinGame;
    }

    private void OnDisable()
    {
        CharacterCollison.GameOverEvent -= GameOver;
        Pizza.WinGameEvent -= WinGame;
    }

    private async void WinGame()
    {
        PlayFireWork();
        GamePause(_panelWinGame);

        await Task.Delay(1000);

        AudioClips.Instance.PlayClip(SoundDictionary.AUDIO_CLIP_YOU_WIN);
    }
    private void PlayFireWork()
    {
        AudioClips.Instance.PlayClip(SoundDictionary.AUDIO_CLIP_FIREWORK_START);
        AudioClips.Instance.PlayClip(SoundDictionary.AUDIO_CLIP_FIREWORK_END);
        _winEffect.Play();
    }

    private async void GameOver()
    {
        GamePause(_panelGameOver);

        await Task.Delay(1000);

        AudioClips.Instance.PlayClip(SoundDictionary.AUDIO_CLIP_GAME_OVER);
    }
    private void GamePause(GameObject activePanel)
    {
        //Stop All Coroutines (Timer,Spawner)
        StopAllCoroutines();

        //Turn off unnecessary panels
        for (int i = 0; i < _gameUI.Length; i++){
            _gameUI[i].SetActive(false);
        }

        //Active current Panel
        activePanel.SetActive(true);

        //Animation Panel
        DOTween.Sequence()
            .AppendInterval(1f)
            .Append(activePanel.transform.DOScale(1, 2f))
            .AppendCallback(Pause);
    }
    private void Pause()
    {
        _panelIsNotInteractive.SetActive(false);

        Time.timeScale = 0f;
    }
}