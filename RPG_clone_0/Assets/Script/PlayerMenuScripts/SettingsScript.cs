using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Audio;

public class SettingsScript : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public AudioMixer audioMixer;
    public Toggle isFullScreen;
    public Text label;

    Resolution[] resolutions;

    private void Start()
    {
        if (Screen.fullScreen == true)
        {
            isFullScreen.isOn = true;
        }
        else
        {
            isFullScreen.isOn = false;
        }

        int CurrentResolutionIndex = 0;
        resolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == 60).ToArray();

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string Option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(Option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                
                Debug.Log("Entrou nesse if do screen");
                CurrentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt("gameResolutionIndex");
        resolutionDropdown.RefreshShownValue();
        Debug.Log($"CurrentResolutionIndex: {CurrentResolutionIndex}");
        //Screen.SetResolution();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        PlayerPrefs.SetInt("gameResolutionIndex", resolutionIndex);
        label.GetComponent<TextMesh>();
        label.text = resolution.ToString().Replace("@", "").Replace("60Hz", "");
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode);
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
    }


}
