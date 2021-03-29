using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ses : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField]
    AudioClip
         sfxBolumTamamlandi,
         sfxBolumTamamlanmadi,
         sfxKartBulundu,
        sfxOyunBasladi
        ;

    void Awake()
    {
        audioSource.volume = KAYIT.GetAyarlarSesDerecesi();
    }
        public void StartKartBulma()
    {
        audioSource.clip = sfxKartBulundu;
        PlayNormal();


    }


    public void StartOyunBasladi()
    {
        audioSource.clip = sfxOyunBasladi;
        PlayNormal();
    }
    public void StartBolumTamamlanmadi()
    {
        audioSource.clip = sfxBolumTamamlanmadi;
        PlayNormal();
    }

    public void StartBolumTamamlandi()
    {
        audioSource.clip = sfxBolumTamamlandi;
        PlayNormal();
    }

    private void PlayNormal()
    {
        audioSource.Play();
    }
}


