using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Sound : MonoBehaviour
{
    public static Sound Manager;

    public AudioMixer Mixer;
    
    [Header("AudioSource")]
    public AudioSource SfxPlayer;
    public AudioSource MusPlayer;


    
    [Header("Slider")]
    public Slider SfxSlider;
    public Slider MusSlider;

    [Space(20)]
    public AudioClip UIClick;
    
    [Header("AudioClips")]
    public AudioClip[] SfxClips;
    public AudioClip[] MusClips;
    
    private void Awake()
    {
        Manager = this;
        SoundVolInit();

    }

    private void SoundVolInit()
    {
        
        Manager.SetMusVol(Settings.GetMusVol());
        Manager.SetSfxVol(Settings.GetSfxVol());

        SfxSlider.value = Settings.GetSfxVol();
        MusSlider.value = Settings.GetMusVol();

        StartCoroutine(Manager.SoundEnable());
    }
    private IEnumerator SoundEnable()
    {
        yield return new WaitForSeconds(0.5f); 
        Mixer.SetFloat("MasterVol", 0);
    }
    
    
   
    public void SetSfxVol(float vol)
    {
        if (vol == 0) vol = 0.001f; //Log10(0)=1
        Mixer.SetFloat("SfxVol", Mathf.Log10(vol) * 20);
    }

    public void SetMusVol(float vol)
    {
        if (vol == 0) vol = 0.001f; //Log10(0)=1
        Mixer.SetFloat("MusVol", Mathf.Log10(vol) * 20);
    }
    
    public void PlaySfx(int clip)
    {
        SfxPlayer.pitch = Random.Range(0.8f, 1.2f);
        SfxPlayer.PlayOneShot(SfxClips[clip]);
    }   

    public void PlayMus(int clip)
    {
        MusPlayer.Stop();
        MusPlayer.clip = MusClips[clip];
        MusPlayer.Play();

    }

    public void UI_Click()
    {
        SfxPlayer.PlayOneShot(UIClick);
    }
    
    public void OnSfxSliderChange(float vol)
    {
        Manager.SetSfxVol(vol);
        Settings.SetSfxVol(vol);
    }
    
    public void OnMusSliderChange(float vol)
    {
        Manager.SetMusVol(vol);
        Settings.SetMusVol(vol);
    }
}
