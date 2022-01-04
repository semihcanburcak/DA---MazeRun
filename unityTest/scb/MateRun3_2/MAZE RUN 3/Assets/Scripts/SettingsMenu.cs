using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen(bool isFullscreen) //This is a dynamic boolean, in the Editor there is a section called "dynamic"
    {
        Screen.fullScreen = isFullscreen; //Set fullscreen or not
    }

    public void SetQuality(int qualityIndex) //This a dynamic int -''-
    {
        QualitySettings.SetQualityLevel(qualityIndex); //Change Qualitylevel (0-low, 1-med, 2-high)
    } 
}
