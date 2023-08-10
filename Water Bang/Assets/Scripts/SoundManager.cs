using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioMixer audioMixer;
    public AudioClip[] stageBgm;

    public AudioClip buttonSfx;
    public AudioClip startSfx;

    private AudioSource audioBgm;
    private AudioSource audioSfx;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(instance);
        audioBgm = this.transform.GetChild(0).GetComponent<AudioSource>();
        audioSfx = this.transform.GetChild(1).GetComponent<AudioSource>();

        audioMixer.SetFloat("Bgm", 0f);
        audioMixer.SetFloat("Sfx", 0f);
    }
    public void PlayBgm()
    {
        audioBgm.PlayOneShot(stageBgm[GameManager.instance.currentStage]);
    }
    public void StopBgm()
    {
        audioBgm.Stop();
    }
    public void PlayButtonSfx()
    {
        audioSfx.PlayOneShot(buttonSfx);
    }
    public void PlayStartSfx()
    {
        audioSfx.PlayOneShot(startSfx);
    }

    public void SetBgmVolume(float value)
    {
        audioMixer.SetFloat("Bgm", Mathf.Log10(value) * 20f);

        float result;
        audioMixer.GetFloat("Bgm", out result);
        Debug.Log("Bgm" + result);
    }

    public void SetSfxVolume(float value)
    {
        audioMixer.SetFloat("Sfx", Mathf.Log10(value) * 20f);

        float result;
        audioMixer.GetFloat("Sfx", out result);
        Debug.Log("Sfx" + result);
    }
}
