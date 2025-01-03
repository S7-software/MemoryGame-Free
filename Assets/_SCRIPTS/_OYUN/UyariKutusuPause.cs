﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UyariKutusuPause : MonoBehaviour
{
    public Button[] buttonlar; // 0- devam, 1- tekrar, 2- menuye don, 4- çarpı
    public GameObject canvasPause;
    public Animator myAnim;

    Saat saat;

    int hangiSahne;
    void Start()
    {
        Tanimlamalar();
        Atama();
    }

    private void Atama()
    {
        buttonlar[1].onClick.AddListener(AyniSayfayaGit);
        buttonlar[2].onClick.AddListener(MenuyeGit);
        buttonlar[0].onClick.AddListener(OyunaDevam);
        buttonlar[3].onClick.AddListener(OyunaDevam);
        saat = FindObjectOfType<Saat>();
    }

    private void OyunaDevam()
    {

        SoundBox.instance.PlayOneShot(NamesOfSound.click);
        StartCoroutine(CikisAnimasyon());
    }
    private void MenuyeGit()
    {
        ReklamKontrol.secenekler.CloseBanner();

        SoundBox.instance.PlayOneShot(NamesOfSound.clickGeri1);
        ReklamGoster();
        Invoke(nameof(MenuyeGit2), 0.3f);
    }
    void MenuyeGit2() { SceneManager.LoadScene("Menu"); }
    private void AyniSayfayaGit()
    {
        ReklamKontrol.secenekler.CloseBanner();

        SoundBox.instance.PlayOneShot(NamesOfSound.clickGeri1);
        ReklamGoster();
        SceneManager.LoadScene(hangiSahne);
    }

    private void Tanimlamalar()
    {
        hangiSahne = SceneManager.GetActiveScene().buildIndex;
        myAnim = canvasPause.GetComponent<Animator>();
    }
    IEnumerator CikisAnimasyon()
    {
        myAnim.SetTrigger("cikis");
        yield return new WaitForSeconds(0.4F);
        ReklamKontrol.secenekler.CloseBanner();
        saat.OyunDevamEttir();
        canvasPause.SetActive(false);
       

    }

    //              ReklamlFonksiyonu
    void ReklamGoster() { ReklamKontrol.secenekler.ShowGecis(); }

}
