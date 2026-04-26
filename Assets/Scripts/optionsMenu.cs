using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class optionsMenu : MonoBehaviour
{
    public Toggle fullscreenTog;
    public AudioMixer mixer;
    public Slider slider;
    public TMP_Text valueLabel;
    void Start()
    {
        bool savedFullscreen = PlayerPrefs.GetInt("Fullscreen", Screen.fullScreen ? 1 : 0) == 1;

        fullscreenTog.isOn = savedFullscreen;
        Screen.fullScreen = savedFullscreen;

        fullscreenTog.onValueChanged.AddListener(SetFullscreen);

        if (PlayerPrefs.HasKey("Volume"))
        {
            float saved = PlayerPrefs.GetFloat("Volume");
            slider.value = saved;
            mixer.SetFloat("Volume", saved);
        }
    }

    void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void SetVolume()

    {
        valueLabel.text = Mathf.RoundToInt(slider.value + 80).ToString();
        mixer.SetFloat("Volume", slider.value);
        PlayerPrefs.SetFloat("Volume", slider.value);
        PlayerPrefs.Save();
    }
}

