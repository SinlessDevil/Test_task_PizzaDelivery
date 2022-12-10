using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timer;
    [SerializeField] private TMP_Text _timerWinPanel;

    private sbyte _seconds;
    private sbyte _minutes;
    private sbyte _hourse;

    private void Start(){
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine(){
        while (true){
            _seconds++;
            if(_seconds >= 60){
                _seconds = 0;
                _minutes++;
            }
            if(_minutes >= 60){
                _minutes = 0;
                _hourse++;
            }

            UpdateTextTimer();

            yield return new WaitForSeconds(1f);
        }
    }

    private string UpdateTextTimer(){
        _timer.text = $"{_hourse:D2}:{_minutes:D2}:{_seconds:D2}";
        _timerWinPanel.text = _timer.text;
        return _timer.text;
    }
}
