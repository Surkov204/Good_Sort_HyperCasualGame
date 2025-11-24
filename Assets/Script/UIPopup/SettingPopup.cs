using JS;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : UIBase
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Button closeButton;

    private const string MUSIC_KEY = "MusicVolume";
    private const string SFX_KEY = "SfxVolume";

    private void Start()
    {
        // Load volume vào slider
        musicSlider.value = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        sfxSlider.value = PlayerPrefs.GetFloat(SFX_KEY, 1f);

        // Setup events
        musicSlider.onValueChanged.AddListener(OnMusicChanged);
        sfxSlider.onValueChanged.AddListener(OnSfxChanged);

        closeButton.onClick.AddListener(() =>
        {
            UIManager.Instance.Hide(UIName.GameSettingScreen);
        });
    }

    private void OnMusicChanged(float v)
    {
        AudioManager.Instance.SetMusicVolume(v);
        PlayerPrefs.SetFloat(MUSIC_KEY, v);
    }

    private void OnSfxChanged(float v)
    {
        AudioManager.Instance.SetSFXVolume(v);
        PlayerPrefs.SetFloat(SFX_KEY, v);
    }
}
