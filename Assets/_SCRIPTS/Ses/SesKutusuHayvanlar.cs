using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKutusuHayvanlar : MonoBehaviour
{
   [SerializeField] List<AudioClip> hayvanSesleri;
    AudioSource audioSource;
    bool birKezOynat;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        birKezOynat = false;
    }

    private void Update()
    {
        if (audioSource.isPlaying) { return; }
        if (!birKezOynat) { return; }
        SifirKonumu();

    }

    private void SifirKonumu()
    {
        Koleksiyon[] koleksiyons = FindObjectsOfType<Koleksiyon>();
        foreach (Koleksiyon koleksiyon in koleksiyons)
        {
            koleksiyon.SetPasifYap();
        }
        birKezOynat = false;

    }

    public AudioClip GetHayvanSesi(string spriteAdi)
    {
        if (spriteAdi== "Kopek2")
        {
            return hayvanSesleri[15];
        }
        foreach (AudioClip audioClip in hayvanSesleri)
        {
            if (YAZI.GetHayvanAdi(audioClip.name)==YAZI.GetHayvanAdi(spriteAdi))
            {
                return audioClip;
            }
        }

        return hayvanSesleri[21];
    }

    public void PlayHayvanSesi(string spriteAdi)
    {
        audioSource.Stop();
        audioSource.clip = GetHayvanSesi(spriteAdi);
        audioSource.Play();
        Koleksiyon[] koleksiyons = FindObjectsOfType<Koleksiyon>();
        foreach (Koleksiyon  koleksiyon in koleksiyons)
        {
            if (koleksiyon.imgHayvan.sprite.name != spriteAdi)
            {
                koleksiyon.SetPasifYap();
            }
        }

        birKezOynat = true;
    }
}
