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
    [SerializeField] GameObject uyariKutusuAyarlariSil,_goMenu,_goArkaPlan;
    [SerializeField] SahnelerArasiGecis gecis;

    ReklamKontrol reklamKontrol;
    private void Awake()
    {
        reklamKontrol = FindObjectOfType<ReklamKontrol>();
        Fonksiyon.SetGameObjectSizeForTablet(_goMenu, 0.7f);
        Fonksiyon.SetGameObjectSizeForTablet(_goArkaPlan, 1.3f);
    }
    void Start()
    {
        reklamKontrol.ShowBanner();
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

        SoundBox.instance.SetVolume(KAYIT.GetAyarlarSesDerecesi());
    }

    public void SliderSesAyarlar(float a)
    {
        if (KAYIT.GetAyarlarSesDerecesi()>a)
        {
          SoundBox.instance.PlayIfDontPlay(NamesOfSound.clickGeri1);
        }
        else
        {
            SoundBox.instance.PlayIfDontPlay(NamesOfSound.click);

        }
        KAYIT.SetAyarlarSesDerecesi(a);
        SoundBox.instance.SetVolume(a);

    }
    public  void SliderMuzikAyarlar(float a)
    {
        if (KAYIT.GetAyarlarSesDerecesi() > a)
        {
            SoundBox.instance.PlayIfDontPlay(NamesOfSound.clickGeri1);
        }
        else
        {
            
            SoundBox.instance.PlayIfDontPlay(NamesOfSound.click);

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
        reklamKontrol.CloseBanner();
        SoundBox.instance.StopAndPlay(NamesOfSound.click);


        StartCoroutine(SahneyeGit("Ana"));
    }

    private void HakkimizdaUyariKutusunuAktifEt()
    {
        SoundBox.instance.StopAndPlay(NamesOfSound.click);


        Instantiate(hakkimizda, transform.position, Quaternion.identity);
    }

    private void RekorSilUyariKutusunuAktifEt()
    {
        SoundBox.instance.StopAndPlay(NamesOfSound.click);

        Instantiate(uyariKutusuAyarlariSil, transform.position, Quaternion.identity);
    }

    public void DilleriAta(string hangi)
    {
        SoundBox.instance.StopAndPlay(NamesOfSound.click);


        KAYIT.SetAppDil(hangi);
        StartCoroutine(SahneyeGit("Ayarlar"));
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
