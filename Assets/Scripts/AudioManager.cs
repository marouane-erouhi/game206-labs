using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour {
    float defaultMasterVolume = 0.5f;
    float m_MasterVolume;
    public float BackgroundMusicVolume;
    public float SoundEffectVolume;
    public Slider MasterVolumeSlider;
    public Slider MusicVolumeSlider;
    public Slider SoundEffectVolumeSlider;
    public Text PlayButtonText;
    public AudioSource BackgroundMusic;
    public AudioClip ClickSound;
    public bool isPlaying = false;
    void Start(){
        m_MasterVolume = defaultMasterVolume;
        MasterVolumeSlider.value = defaultMasterVolume;
        MusicVolumeSlider.value = BackgroundMusicVolume;
        SoundEffectVolumeSlider.value = SoundEffectVolume;
        MasterVolumeSlider.onValueChanged.AddListener((val)=>SetMasterVolume(val));
        MusicVolumeSlider.onValueChanged.AddListener((val)=>SetMusicVolume(val));
        SoundEffectVolumeSlider.onValueChanged.AddListener((val)=>SetSoundEffectVolume(val));
        PlayButtonText.text = isPlaying ? "Pause Music" : "Play Music";

        BackgroundMusic.volume = BackgroundMusicVolume * m_MasterVolume;
        BackgroundMusic.Pause();

    }

    void Update(){
        
    }

    public void PlayUISoundEffect(AudioSource src){
        src.volume = SoundEffectVolume * m_MasterVolume;
        src.PlayOneShot(ClickSound);//TODO: collaps/expand buttons disable themselves beofre the audio can play
    }

    public void SetMasterVolume(float vol){
        m_MasterVolume = vol;
        BackgroundMusic.volume = BackgroundMusicVolume * m_MasterVolume;
    }
    public void SetMusicVolume(float val){
        BackgroundMusicVolume = val;
        BackgroundMusic.volume = BackgroundMusicVolume * m_MasterVolume;
    }
    public void SetSoundEffectVolume(float val){
        SoundEffectVolume = val;
    }
    public float GetMasterVolume(){
        return m_MasterVolume;
    }
    public void ToggleMusic(){
        isPlaying = !isPlaying;
        PlayButtonText.text = isPlaying ? "Pause Music" : "Play Music";
        if(isPlaying)
            BackgroundMusic.Play();
        else
            BackgroundMusic.Pause();
    }
}
