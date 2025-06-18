using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class UI_Setting : MonoBehaviour
{

    public Slider handleSlider_SFX;
    public Image viewSlider_SFX;

    public Slider handleSlider_BGM;
    public Image viewSlider_BGM;

    public AudioMixer audioMixer;

    public void SFXValueSync()
    {
        viewSlider_SFX.fillAmount = handleSlider_SFX.value;

        SetVolume("SFXVolume", Mathf.Log10(handleSlider_SFX.value) * 20);
    }
    public void BGMValueSync()
    {
        viewSlider_BGM.fillAmount = handleSlider_BGM.value;
        SetVolume("BGMVolume", Mathf.Log10(handleSlider_BGM.value) * 20);
    }

    public void SetVolume(string volName, float value)
    {
        audioMixer.SetFloat(volName, value);
    }
}
