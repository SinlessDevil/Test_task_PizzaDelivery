using UnityEngine;
using DG.Tweening;
using AudioGame;
using System.Threading.Tasks;

public class StateOfPlay : MonoBehaviour
{
    [SerializeField] private GameObject _panelWinGame;
    [SerializeField] private GameObject _panelGameOver;
    [SerializeField] private GameObject[] _gameUI;

    [SerializeField] private ParticleSystem _winEffect;
    private void OnEnable()
    {
        CharacterCollison.GameOverEvent += GameOver;
        Pizza.WinGameEvent += WinGame;
    }

    public void OnDisable()
    {
        CharacterCollison.GameOverEvent -= GameOver;
        Pizza.WinGameEvent -= WinGame;
    }

    private async void WinGame()
    {
        _winEffect.Play();
        GamePause(_panelWinGame);
        await Task.Delay(1000);
        AudioClips.Instance.PlayClip(SoundDictionary.AUDIO_CLIP_FIREWORK_START);
        AudioClips.Instance.PlayClip(SoundDictionary.AUDIO_CLIP_FIREWORK_END);
        AudioClips.Instance.PlayClip(SoundDictionary.AUDIO_CLIP_YOU_WIN);
    }

    private async void GameOver()
    {
        GamePause(_panelGameOver);
        await Task.Delay(1000);
        AudioClips.Instance.PlayClip(SoundDictionary.AUDIO_CLIP_GAME_OVER);
    }
    private void GamePause(GameObject activePanel)
    {
        StopAllCoroutines();

        for (int i = 0; i < _gameUI.Length; i++){
            _gameUI[i].SetActive(false);
        }

        activePanel.SetActive(true);

        DOTween.Sequence()
            .AppendInterval(1f)
            .Append(activePanel.transform.DOScale(1, 2f))
            .AppendCallback(Pause);
    }

    private void Pause()
    {
        AudioClips.Instance.PlayClip(name);
        Time.timeScale = 0f;
    }
}