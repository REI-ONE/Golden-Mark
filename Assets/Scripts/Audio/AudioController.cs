using UnityEngine;

namespace Game.Audio
{
    public interface IAudioController
    {
        public Component Type { get; }

        public void PlayMusic(AudioClip music);
        public void PauseMusic();
        public void StopMusic();

        public void PlaySound(AudioClip sound);
        public void PauseSound();
        public void StopSound();
    }

    public class AudioController : MonoBehaviour, IAudioController
    {
        [SerializeField] private AudioSource _music;
        [SerializeField] private AudioSource _sound;

        public Component Type => this;

        public void PlayMusic(AudioClip music)
        {
            _music.clip = music;
            _music.Play();
        }

        public void PauseMusic()
        {
            _music.Pause();
        }

        public void StopMusic()
        {
            _music.Stop();
        }

        public void PlaySound(AudioClip sound)
        {
            _sound.clip = sound;
            _sound.Play();
        }

        public void PauseSound()
        {
            _sound.Pause();
        }

        public void StopSound()
        {
            _sound.Stop();
        }
    }
}