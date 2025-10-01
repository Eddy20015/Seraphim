using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject OriginalPanel;
    [SerializeField] private AudioClip ClickSound;
    [SerializeField] private AudioSource UISounds;

    public AudioMixer FullMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void OnClickBack()
    {
        PlayClickSound();
        gameObject.SetActive(false);
        OriginalPanel.SetActive(true);
    }

    public void SetMusicVolume(float volume)
    {
        FullMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        FullMixer.SetFloat("SFXVolume", volume);
    }

    public void SetQuality(int qualityIdx)
    {
        UISounds.PlayOneShot(ClickSound);
        QualitySettings.SetQualityLevel(qualityIdx);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        UISounds.PlayOneShot(ClickSound);
        Screen.fullScreen = isFullScreen;
    }

    public void PlayClickSound()
    {
        //UISounds.PlayOneShot(ClickSound);
    }
}