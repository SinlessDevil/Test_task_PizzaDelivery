using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ProgressBar : MonoBehaviour
{
    private Image _fillBar;

    private void Start()
    {
        _fillBar = GetComponent<Image>();
        _fillBar.fillAmount = 0f;
    }

    public void OnEnable()
    {
        BicycleCharacter.ProgressBarEvent += SetProgressBar;
    }
    public void OnDisable()
    {
        BicycleCharacter.ProgressBarEvent -= SetProgressBar;
    }

    private void SetProgressBar(Transform currentPos, Transform lastPos)
    {
        float var = currentPos.position.x / lastPos.position.x;
        _fillBar.fillAmount = var;
    }
}