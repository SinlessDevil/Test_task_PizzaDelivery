using System;
using System.Collections;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    public static event Action WinGameEvent;

    private const float WAIT_TIME = 1f;
    private void OnEnable()
    {
        StartCoroutine(WinGameCoroutine());
    }

    private IEnumerator WinGameCoroutine()
    {
        yield return new WaitForSeconds(WAIT_TIME);
        WinGameEvent?.Invoke();
    }
}