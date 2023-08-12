using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioMixer audioMixer;

    public AudioClip mainBgm;
    public AudioClip[] stageBgm;

    public AudioClip buttonSfx;
    public AudioClip startSfx;
    public AudioClip gameOverSfx;
    public AudioClip gameClearSfx;

    public AudioSource audioBgm;
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
    public void PlayMainBgm()
    {
        if (audioBgm.clip == stageBgm[GameManager.instance.currentStage])
            audioBgm.Stop();
        if (!audioBgm.isPlaying)
        {
            audioBgm.loop = true;
            audioBgm.clip = mainBgm;
            audioBgm.Play();
        }
    }
    public void PlayBgm()
    {
        audioBgm.Stop();
        audioBgm.loop = false;
        audioBgm.clip = stageBgm[GameManager.instance.currentStage];
        audioBgm.PlayOneShot(audioBgm.clip);
    }
    public void PlayButtonSfx()
    {
        audioSfx.PlayOneShot(buttonSfx);
    }
    public void PlayStartSfx()
    {
        audioSfx.PlayOneShot(startSfx);
    }

    public void PlayGameOverSfx()
    {
        audioBgm.Stop();
        audioSfx.PlayOneShot(gameOverSfx);
    }

    public void PlayGameClearSfx()
    {
        audioBgm.Stop();
        audioSfx.PlayOneShot(gameClearSfx);
    }
    public void SetBgmVolume(float value)
    {
        audioMixer.SetFloat("Bgm", Mathf.Log10(value) * 20f);
    }

    public void SetSfxVolume(float value)
    {
        audioMixer.SetFloat("Sfx", Mathf.Log10(value) * 20f);
    }
}
