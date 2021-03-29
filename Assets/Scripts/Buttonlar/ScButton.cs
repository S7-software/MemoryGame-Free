using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScButton : MonoBehaviour
{
    [Header("String Değer Girişleri")]
    public string hangiSahneye;

    [Header("Button Özellikleri")]
    public bool islemYapma;
    public bool sahneDegistir;
    public bool kontrolAnasayfayaDon;

    private Button button;
    SesKutusuUI sesKutusu;


    private void Start()
    {
        Tanimlama();
        IslemleriTanimlama();

    }


    private void IslemleriTanimlama()
    {
        if (islemYapma)
        {

        }
        else if (sahneDegistir)
        {
            button.onClick.AddListener(SahneyeGit);
        }
       
        else if (kontrolAnasayfayaDon)
        {
            button.onClick.AddListener(KONTROLANASAYFAYAGIT);
        }
    }


    private void SahneyeGit()
    {
        sesKutusu.PlayButtonClick();

        SceneManager.LoadScene(hangiSahneye);
    }

    private void KONTROLANASAYFAYAGIT()
    {
        sesKutusu.PlayButtonClick();
        SceneManager.LoadScene(1);
    }

  

    private void Tanimlama()
    {
        sesKutusu = FindObjectOfType<SesKutusuUI>();
        button = GetComponent<Button>();
        
    }

    
}
