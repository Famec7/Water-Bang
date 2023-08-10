using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    private Slider audioSlider;
    public AudioMixer audioMixer;

    private void Awake()
    {
        audioSlider = GetComponent<Slider>();
    }
    public void SetBgmVolume(float value)
    {
        audioMixer.SetFloat("Bgm", Mathf.Log10(value) * 20f);

        float result;
        audioMixer.GetFloat(this.name, out result);
        Debug.Log(result);
    }

    public void SetSfxVolume(float value)
    {
        audioMixer.SetFloat("Sfx", Mathf.Log10(value) * 20f);

        float result;
        audioMixer.GetFloat(this.name, out result);
        Debug.Log(result);
    }
}
