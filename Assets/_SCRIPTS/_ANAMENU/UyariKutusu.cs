using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UyariKutusu : MonoBehaviour
{
    [Header("Parametreler")]
    public string hangiSayfaya;

    [Header("Tanımlanacaklar")]
    
    public Button[] buttonlar;
    public List<Text>mesaj;
    public Text baslik;
    Animator anim;

    void Start()
    {
        Tanimlamalar();
        DilleriCek();
    }

    private void DilleriCek()
    {
        Fonksiyon.TextBoxlaraYazdir(mesaj, YAZI.OyundanCikmakIstediginizeEminMisiniz());
        baslik.text = YAZI.Uyari();
    }

    private void Tanimlamalar()
    {
        anim = GetComponent<Animator>();
        CarpiButton();
        OnayButton();
    }

    private void CarpiButton()
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.clickGeri1);
        buttonlar[0].onClick.AddListener(Iptal);
    }
    private void Iptal()
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.clickGeri1);


        anim.SetTrigger("triggerCikis");
        Destroy(gameObject,0.6f);
    }

    private void OnayButton()
    {
        buttonlar[1].onClick.AddListener(Onay);
    }

    private void Onay()
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.click);

        Application.Quit();
    }
}   
