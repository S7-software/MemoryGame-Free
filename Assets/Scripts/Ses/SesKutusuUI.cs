using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKutusuUI : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField]
    AudioClip
        sfxKartSecme,
        sfxClick,
        sfxClickGeri,
        sfxBolumSecildi;
    [SerializeField] GameObject sesler;

    void Awake()
    {
        SetSesDerecesi(KAYIT.GetAyarlarSesDerecesi());
    }

    public void SetSesDerecesi(float volume)
    {
        audioSource.volume = volume;
    }

    public void PlayButtonClick()
    {
        audioSource.clip = sfxClick;
        PlayNormal();
    }
    public void PlayButtonClickGeri()
    {
        audioSource.clip = sfxClickGeri;
        PlayNormal();
    }
    public void PlayKartSec()
    {
        audioSource.clip = sfxKartSecme;
        PlayNormal();
    }





    public void PlayKartBulma()
    {


        GameObject playKartBulma = Instantiate(sesler, transform.position, Quaternion.identity);
        playKartBulma.name = "Ses Kart Bulundu";
        playKartBulma.GetComponent<Ses>().StartKartBulma();
        Destroy(playKartBulma, 3f);
    }



    public void PlayBolumTamamlandi()
    {
        GameObject playBolumTamamlandi = Instantiate(sesler, transform.position, Quaternion.identity);
        playBolumTamamlandi.GetComponent<Ses>().StartBolumTamamlandi();
        playBolumTamamlandi.name = "Ses Bölüm Tamamlandý";
        Destroy(playBolumTamamlandi, 3f);
    }
   
    public void PlayBolumTamamlanmadi()
    {
        GameObject playBolumTamamlanmadi = Instantiate(sesler, transform.position, Quaternion.identity);
        playBolumTamamlanmadi.GetComponent<Ses>().StartBolumTamamlanmadi();
        playBolumTamamlanmadi.name = "Ses Bölüm Tamamlanmadý";
        Destroy(playBolumTamamlanmadi, 3f);

    }
    public void PlayBolumSecildi()
    {
        audioSource.clip = sfxBolumSecildi;
        PlayNormal();
    }
    
    public void PlayOyunBasladi()
    {
        GameObject playOyunBasladi = Instantiate(sesler, transform.position, Quaternion.identity);
        playOyunBasladi.name = "Ses Oyun Baþladý";
        playOyunBasladi.GetComponent<Ses>().StartOyunBasladi();
        Destroy(playOyunBasladi, 3f);
    }

    private void PlayNormal()
    {
        audioSource.Play();
    }

    private void PlayBekle()
    {
        if (!audioSource.isPlaying) { audioSource.Play(); }
    }

    public void PlaySesYukselt()
    {
        audioSource.clip = sfxClick;
        PlayBekle();
    }
    public void PlayAzalt()
    {
        audioSource.clip = sfxClickGeri;
        PlayBekle();
    }


}
