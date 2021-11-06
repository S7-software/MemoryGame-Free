using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AyarlarYoneticisi : MonoBehaviour
{
    [SerializeField] List<Button> btnDiller;
    [SerializeField] Button btnSil;
    [SerializeField] Button btnHakkimizda;
    [SerializeField] Button btnAnaMenu;
    [SerializeField] List<Slider> sliders;
    [SerializeField] List<Text> txtDil;
    [SerializeField] List<Text> txtRekor;
    [SerializeField] Text txtSil;
    [SerializeField] Text txtHakkimizda;
    [SerializeField] Text txtAyarlar;
    [SerializeField] Text txtAnaMenu;
    [SerializeField] float sure = 0.5f;
    [SerializeField] GameObject hakkimizda;
    [SerializeField] GameObject uyariKutusuAyarlariSil;
    [SerializeField]  SesKutusuUI ses;
    [SerializeField] SahnelerArasiGecis gecis;
    void Start()
    {
        DilButtonlariCek(KAYIT.GetDilSecilen());
        Tanimlamalar();
        TextlereVeriCek();
        SliderVeriCek();
    }

    private void SliderVeriCek()
    {
        sliders[0].value = KAYIT.GetAyarlarSesDerecesi();
        sliders[1].value = KAYIT.GetAyarlarMuzikDerecesi();
        sliders[0].onValueChanged.AddListener(SliderSesAyarlar);
        sliders[1].onValueChanged.AddListener(SliderMuzikAyarlar);
        ses.SetSesDerecesi( KAYIT.GetAyarlarSesDerecesi());
    }

    public void SliderSesAyarlar(float a)
    {
        if (KAYIT.GetAyarlarSesDerecesi()>a)
        {
            ses.PlaySesYukselt();
        }
        else
        {
           ses.PlaySesYukselt();
        }
        KAYIT.SetAyarlarSesDerecesi(a);
        ses.SetSesDerecesi(a);
    }
  public  void SliderMuzikAyarlar(float a)
    {
        if (KAYIT.GetAyarlarSesDerecesi() > a)
        {
            ses.PlaySesYukselt();
        }
        else
        {
           ses.PlaySesYukselt();
        }
        KAYIT.SetAyarlarMuziksDerecesi(a);
    }

    private void TextlereVeriCek()
    {
        Fonksiyon.TextBoxlaraYazdir(txtDil, YAZI.Dil());
        txtHakkimizda.text = YAZI.Hakkimizda();
        txtSil.text = YAZI.Sil();
        txtRekor[0].text = YAZI.ButunRekorlariVeAyarlariSil();
        txtRekor[1].text = YAZI.ButunRekorlariVeAyarlariSil();
        txtAyarlar.text = YAZI.Ayarlar();
        txtAnaMenu.text = YAZI.AnaMenu();
    }

    private void Tanimlamalar()
    {
        ButtonlaraFonksiyonAta();
    }

    private void ButtonlaraFonksiyonAta()
    {
        btnSil.onClick.AddListener(RekorSilUyariKutusunuAktifEt);
        btnHakkimizda.onClick.AddListener(HakkimizdaUyariKutusunuAktifEt);
        btnAnaMenu.onClick.AddListener(AnaMenuyeGit);
    }

    private void AnaMenuyeGit()
    {
        ses.PlayButtonClick();

        StartCoroutine(SahneyeGit("Ana"));
    }

    private void HakkimizdaUyariKutusunuAktifEt()
    {
        ses.PlayButtonClick();

        Instantiate(hakkimizda, transform.position, Quaternion.identity);
    }

    private void RekorSilUyariKutusunuAktifEt()
    {
        ses.PlayButtonClick();
        Instantiate(uyariKutusuAyarlariSil, transform.position, Quaternion.identity);
    }

    public void DilleriAta(string hangi)
    {
        ses.PlayButtonClick();

        KAYIT.SetAppDil(hangi);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void DilButtonlariCek(string hangi)
    {
        foreach (Button btn in btnDiller)
        {
            btn.interactable = btn.name != hangi ? true : false;
        }
    }

    IEnumerator SahneyeGit(string hangi)
    {
        gecis.SetCikis();
        yield return new WaitForSeconds(sure);
        SceneManager.LoadScene(hangi);
    }
}
