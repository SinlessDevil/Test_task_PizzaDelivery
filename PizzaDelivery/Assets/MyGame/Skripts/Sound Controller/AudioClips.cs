using UnityEngine;
using System;

namespace AudioGame
{
    public class AudioClips : MonoBehaviour
    {
        public static AudioClips Instance;
        public Sound[] sounds;

        private void Awake()
        {
            if(Instance != null){
                Destroy(this.gameObject);
            }
            Instance = this;
            DontDestroyOnLoad(this);

            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
                s.source.playOnAwake = s.playOnAwake;
            }
        }

        private void Start()
        {
            PlayClip(SoundDictionary.AUDIO_CLIP_BG_MUSIC);
            PlayClip(SoundDictionary.AUDIO_CLIP_CARS_DRIVE);

        }

        #region Clip Methods

        public void PlayClip(string name)
        {
            FindSound(name).source.Play();
        }
        public void StopClip(string name)
        {
            FindSound(name).source.Stop();
        }

        private Sound FindSound(string nameSound)
        {
            Sound s = Array.Find(sounds, sound => sound.name == nameSound);
            if (s is null){
                Debug.LogWarning("Sound:" + name + "not found!");
                return null;
            }
            return s;
        }

        #endregion
    }
}