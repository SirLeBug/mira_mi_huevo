using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;


public class MenuControllerAudio : MonoBehaviour
{
    [Header("Volume Setting")]
    [SerializeField] private TextMeshProUGUI volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;

    public AudioMixer masterMixer;
    private float vol;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float volume)
    {
        vol = volume;
        volume = (volume + 80) * 1.25f;
        volumeTextValue.text = volume.ToString("0");
    }

    public void VolumeApplyMaster()
    {
        PlayerPrefs.SetFloat("masterVolume", vol);
        masterMixer.SetFloat("masterVol", vol);
    }
    
    public void VolumeApplyMusic()
    {
        PlayerPrefs.SetFloat("musicVolume", vol);
        masterMixer.SetFloat("musicVol", vol);
    }
    public void VolumeApplyEffects()
    {
        PlayerPrefs.SetFloat("effectsVolume", vol);
        masterMixer.SetFloat("effectsVol", vol);
    }
}
