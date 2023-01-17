using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    //Singleton

    public static AudioManager Instance { get; private set; }

    /* 
     * AudioListener is basically our MasterMixer
     * We're using AudioSources as Mixer Categories
     * 
     * When Adding a new source, add an audioSource and a function to update it
     */

    [SerializeField]
    private AudioSource _musicSource, _effectSource;

    private float _savedVolume;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        _savedVolume = AudioListener.volume;
    }

    public void PlaySound(AudioClip audioClip) {
        _effectSource.PlayOneShot(audioClip);
    }

    public void PlaySound(AudioClip[] audioClips) {
        AudioClip audioClip = audioClips[Random.Range(0, audioClips.Length - 1)];
        _effectSource.PlayOneShot(audioClip);
    }

    public void ChangeMasterVolume(float volume) {
        AudioListener.volume = volume;
    }

    public void ChangeMusicVolume(float volume) {
        _musicSource.volume = volume;
    }

    public void ChangeEffectVolume(float volume) {
        _effectSource.volume = volume;
    }

    public void ToggleMaster() {
        if (AudioListener.volume <= 0) {
            AudioListener.volume = _savedVolume;
        } else {
            _savedVolume = AudioListener.volume;
            AudioListener.volume = 0;
        }
    }

    public void ToggleMusicSource() {
        _musicSource.mute = !_musicSource.mute;
    }

    public void ToggleEffectSource() {
        _effectSource.mute = !_effectSource.mute;
    }

    public void LowPass(bool isOn) {
        AudioLowPassFilter lowpass = GetComponentInChildren<AudioLowPassFilter>();
        lowpass.enabled = isOn;
    }
}
