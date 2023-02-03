using System;
using UnityEngine;
using AudioGame;

[RequireComponent(typeof(BoxCollider),typeof(Rigidbody))]
public class CharacterCollison : MonoBehaviour
{
  //public static event Action WinGameEvent;
    public static event Action GameOverEvent;

    [SerializeField] private GameObject _boomFx;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out LandTransport car))
        {
            Vector3 newPos = collision.contacts[0].point;
            SetParticleSystem(_boomFx, newPos);

            AudioClips.Instance.PlayClip(SoundDictionary.AUDIO_CLIP_BOOM);

            gameObject.SetActive(false);
            GameOverEvent?.Invoke();
        }
    }

    private void SetParticleSystem(GameObject prefab, Vector3 pos)
    {
        Instantiate(prefab, pos, Quaternion.identity);
    }
}