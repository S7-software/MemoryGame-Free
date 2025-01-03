﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunYoneticisi : MonoBehaviour
{
    public static OyunYoneticisi instance;
    #region Degiskenler
    [Header("Parametreler")]
    [SerializeField] int sureNormalOyun = 30;
    [SerializeField] int sureZorlOyun = 5;

    [Header("Tanimlanacaklar")]
    // public List<WaveConfig> waveConfigs;
    public GameObject kartlarArkaPlan;
    public Component[] kartlar;
    public int hangiBolum;
    public bool oyunBitti;
    [SerializeField] KoleksiyonBulundu koleksiyoBulundu;
    Saat saat;
    bool _reklamOdulGosterildi = false;

    ResimKutusu resimKutusu;
    int toplamKartSayisi,
        zorluk;
    public GameObject canvasSonuc;

    bool ilkDefaKoleksiyon;
    #endregion

    #region Awake, Update

    private void Awake()
    {
        instance = this;
        KameraOraniAyarlama();
        Tanimlama();
        Atama();
    }


    void Update()
    {
        OyunBitti();

    }
    #endregion

    #region in Awake
    private void KameraOraniAyarlama()
    {
        float kameraOlcek = ((float)((float)Camera.main.scaledPixelHeight / (float)Camera.main.scaledPixelWidth) - 2) * 2;
        if (kameraOlcek > 0)
            Camera.main.orthographicSize += kameraOlcek;
    }

    private void Tanimlama()
    {
        oyunBitti = false;
        resimKutusu = FindObjectOfType<ResimKutusu>();
        saat = FindObjectOfType<Saat>();
        ButunKartComponentleriAl();
        hangiBolum = SceneManager.GetActiveScene().buildIndex;
        toplamKartSayisi = kartlar.Length;
        zorluk = KAYIT.GetOyunZorluk();

        resimKutusu.Tanimlamalar(toplamKartSayisi, hangiBolum);
        ilkDefaKoleksiyon = KAYIT.GetRekorSure(zorluk, hangiBolum) == 0 ? true : false;

    }

    private void Atama()
    {

        SureAtama();
        KartlaraResimAta();


    }

    #endregion

    private void KartlaraResimAta()
    {
        foreach (Kart kart in kartlar)
        {
            kart.sprtHayvan = resimKutusu.RasgeleResimVer();
        }
    }
    int YildizVer()
    {

        //int _tamSure = Convert.ToInt32(saat.slider.maxValue) + 5;
        //int _gecenSure = _tamSure - saat.mevcutSure - 5;
        //int _ucYildiz = _tamSure / 2;
        //int _ikiYildiz = _ucYildiz + _ucYildiz / 2;
        //if (_ucYildiz >= _gecenSure)
        //{
        //    return 3;
        //}
        //else if (_ikiYildiz >= _gecenSure)
        //{
        //    return 2;
        //}
        //else
        //{
        //    return 1;
        //}
      return  saat.GetYildiz();
    }
    int YildizVerSuresiz()
    {
        int _gecenSure = saat.mevcutSure;
        int _tamSure = (toplamKartSayisi) * 4;
        int _yariSure = _tamSure / 2;
        int _ceyrekSure = _yariSure + _yariSure / 2;
        /*
        print("yari sure: " + _yariSure);
        print("ceyrek sure: " + _ceyrekSure);
        print("mevcut Sure: " + saat.mevcutSure);
        print("gecen Sure: " + _gecenSure);
        */
        if (_gecenSure < _yariSure) { return 3; }
        else if (_gecenSure < _ceyrekSure) { return 2; }
        else { return 1; }
    }
    void SureAtama()
    {

        switch (zorluk)
        {

            case 1: saat.oyunSuresi = sureNormalOyun; break;
            case 2: saat.oyunSuresi = sureZorlOyun; break;
            default:
                saat.oyunSuresi = 0;
                break;
        }

    }






    private void ButunKartComponentleriAl()
    {
        kartlar = kartlarArkaPlan.GetComponentsInChildren<Kart>();

    }
    public bool KartlarBitti()
    {
        Kart[] xcKartlar;
        xcKartlar = kartlarArkaPlan.GetComponentsInChildren<Kart>();
        if (xcKartlar.Length != 0)
        {
            return false;
        }
        return true;
    }



    public void OyunBitti()
    {
        if (!KartlarBitti()) { return; }
        if (oyunBitti) { return; }
        oyunBitti = true;
        saat.OyunBittiButunCoroutineleriDurdur();

        if (zorluk == 0) { SuresizBolumBitisi(); }
        else { SureliBolumBitisleri(); }


        SonrakiBolumuAc(zorluk, hangiBolum);
        KontrolKoleksiyonVarMi();




    }

    private void SuresizBolumBitisi()
    {
        int _maksimumSure = saat.mevcutSure;
        // print("Makisimum Sure: " + _maksimumSure);
        CanvasSonucGoster(true, YildizVerSuresiz(), _maksimumSure);
        KAYIT.SetRekorSure(zorluk, hangiBolum, _maksimumSure);
        KAYIT.SetRekorYildiz(zorluk, hangiBolum, YildizVerSuresiz());
    }

    private void SureliBolumBitisleri()
    {
        int _mevcutSure = (int)saat.slider.maxValue - saat.mevcutSure;

        CanvasSonucGoster(true, YildizVer(), _mevcutSure);
        KAYIT.SetRekorSure(zorluk, hangiBolum, _mevcutSure);
        KAYIT.SetRekorYildiz(zorluk, hangiBolum, YildizVer());
    }

    private void KontrolKoleksiyonVarMi()
    {
        if (zorluk == 1)
        {
            string _spriteName = KAYIT.GetKoleksiyonAdiNORMAL(hangiBolum);
            if (_spriteName != "yok")
            {
                if (ilkDefaKoleksiyon)
                {
                    koleksiyoBulundu.SetActive(resimKutusu.IstenilenHayvaniVer(_spriteName), YAZI.GetHayvanAdi(_spriteName));
                    KAYIT.SetKoleksiyonuKaydet(hangiBolum);

                    SoundBox.instance.PlayOneShot(YAZI.GetHayvanAdiEnum(_spriteName));

                }
                else { SoundBox.instance.PlayOneShot(NamesOfSound.bolumTamamlandi1); }

            }
            else { SoundBox.instance.PlayOneShot(NamesOfSound.bolumTamamlandi1); }

        }
        else if (zorluk == 2)
        {
            string _spriteName = KAYIT.GetKoleksiyonAdiZOR(hangiBolum);
            if (_spriteName != "yok")
            {
                if (ilkDefaKoleksiyon)
                {
                    koleksiyoBulundu.SetActive(resimKutusu.IstenilenHayvaniVer(_spriteName), YAZI.GetHayvanAdi(_spriteName));
                    KAYIT.SetKoleksiyonuKaydet(hangiBolum);

                    SoundBox.instance.PlayOneShot(YAZI.GetHayvanAdiEnum(_spriteName));


                }
                else { SoundBox.instance.PlayOneShot(NamesOfSound.bolumTamamlandi1); }

            }
            else { SoundBox.instance.PlayOneShot(NamesOfSound.bolumTamamlandi1); }

        }
        else
        {
            SoundBox.instance.PlayOneShot(NamesOfSound.bolumTamamlandi1);

        }
    }

    private void SonrakiBolumuAc(int zorluk, int hangiBolum)
    {
        switch (zorluk)
        {
            case 1: KAYIT.SetKacinciBolumNORMAL(hangiBolum + 1); break;
            case 2: KAYIT.SetKacinciBolumZOR(hangiBolum + 1); break;
            default:
                KAYIT.SetKacinciBolumSURESIZ(hangiBolum + 1);
                break;
        }
    }

    public void Kaybetti()
    {

        if (!_reklamOdulGosterildi)
        {
            saat.OyunDuraklat();
            Instantiate(GetPrefabs.UyariKutusu(HangiUyariKutusu.CanvasDevamEt));
            SoundBox.instance.PlayOneShot(NamesOfSound.click);
            _reklamOdulGosterildi = true;
        }

        else
        {
            SoundBox.instance.PlayOneShot(NamesOfSound.bolumTamamlandi0);
            CanvasSonucGoster(false, 0, (int)saat.slider.maxValue - saat.mevcutSure);
            Kart[] _kartlar = FindObjectsOfType<Kart>();
            foreach (Kart kart in _kartlar)
            {
                kart.myCollider.enabled = false;
            }
        }

    }

    void CanvasSonucGoster(bool Kazanildi, int YildizVer, int mevcutSure)
    {
        canvasSonuc.SetActive(true);
        SonucKutusu sonucKutusu = FindObjectOfType<SonucKutusu>();
        if (Kazanildi)
        {

            // print("Mevcut sure canvasGoster: " + mevcutSure);
            bool _rekorVar = KAYIT.GetRekorSure(zorluk, hangiBolum) > mevcutSure ? true : false;
            sonucKutusu.SonucKutusunuCikar(YildizVer, mevcutSure, _rekorVar);
        }
        else
        {
            sonucKutusu.SonucKutusunuCikar(0, (int)saat.slider.maxValue - saat.mevcutSure, false);

        }

    }


    #region Get Fonksiyonlari
    public int GetZorluk()
    {
        return zorluk;
    }

    public int GetKartSayisi()
    {
        return toplamKartSayisi;
    }
    #endregion


    public void CanvasDevamEtOnay()
    {
        ReklamKontrol.secenekler.ShowOdul();
    }
    public void CanvasDevamEtIptal()
    {
        Kaybetti();
    }

    public void ReklamOdulBasarili()
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.oyunBasladi);
        saat.slider.maxValue += 30;
        saat.mevcutSure += 30;
        saat.OyunDevamEttir();

    }
    public void ReklamOdulBasarisiz()
    {
        Kaybetti();
    }
}
