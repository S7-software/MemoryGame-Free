using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBox : MonoBehaviour
{
    public static SoundBox instance;
  public  AudioSource audioSource;
    private void Awake()
    {
        if (FindObjectsOfType<SoundBox>().Length > 1 && instance != this)
        {
            Destroy(this);
        }
       
            //DontDestroyOnLoad(this);
        
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOneShot(NamesOfSound name)
    {
        audioSource.PlayOneShot(GetAudioClip(name));
    }
    public void PlayIfDontPlay(NamesOfSound name)
    {
        if (!audioSource.isPlaying) PlayOneShot(name);
    }

    public void StopAndPlay( NamesOfSound name)
    {
        audioSource.Stop();

        PlayOneShot(name);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
    AudioClip GetAudioClip(NamesOfSound name)
    {
        return Resources.Load<AudioClip>("Sounds/" + name.ToString());
    }
}
