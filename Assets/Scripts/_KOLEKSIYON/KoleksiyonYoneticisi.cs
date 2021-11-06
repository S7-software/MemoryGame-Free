using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KoleksiyonYoneticisi : MonoBehaviour
{
    [SerializeField] List<Koleksiyon> koleksiyonlar;
    [SerializeField] Button btnAnasayfa,
        btnSol,
        btnSag;
    [SerializeField] Sayfalar sayfalar;
    [SerializeField] ResimKutusu resimKutusu;
    int enSonsayfa;
    Dictionary<int,bool> koleksiyonOlanBolumlar;
    List<int> butunKoleksiyonNumaralari;
  [SerializeField]  SesKutusuUI ses;
    private void Awake()
    {
        Tanimlamalar();
        Atamalar();
        
    }

    private void Atamalar()
    {
        ButonlaraDegerAta();
        ButtonSayfalariAyarla();
        MevcutKoleksiyonlariAl();
        AcikKoleksiyonlariAta();
    }

    private void MevcutKoleksiyonlariAl()
    {
        butunKoleksiyonNumaralari = KAYIT.GetKoleksiyonSayilarini();
        foreach (var item in butunKoleksiyonNumaralari)
        {
            if (KAYIT.GetBuBolumdeKoleksiyonVar(item))
            {
                koleksiyonOlanBolumlar.Add(item, true);
            }
            else
            {
                koleksiyonOlanBolumlar.Add(item, false);
            }
        }

    }

    private void AcikKoleksiyonlariAta()
    {
        int  _sayi = (6 * enSonsayfa)-6;
        int _i = 0;
        int _j = 1;
        foreach (var item in koleksiyonOlanBolumlar)
        {

            if (_j<=_sayi)
            {
                _j++;
                continue;
            }
            if (item.Value)//item.Value
            {
                int gecici = item.Key ;
                //print("Key: " + gecici);
                koleksiyonlar[_i].KoleksiyonAcik(resimKutusu.IstenilenHayvaniVer(gecici));

            }
            _i++;

            if (_i==6)
            {
                break;
            }

        }

    }

    private void ButtonSayfalariAyarla()
    {
        if (enSonsayfa==1)
        {
            btnSag.interactable = true;
            btnSol.interactable = false;
        }
        else if (enSonsayfa==5)
        {
            btnSag.interactable = false;
            btnSol.interactable = true;
        }
        else
        {
            btnSag.interactable = true;
            btnSol.interactable = true;
        }
    }

    private void Tanimlamalar()
    {
        ButunKartlariKapa();
        
        enSonsayfa = KAYIT.GetEnSonSayfaKoleksiyon();
        sayfalar.SetSayfa(enSonsayfa);
        koleksiyonOlanBolumlar = new Dictionary<int, bool>();
    }

    private void ButunKartlariKapa()
    {
        foreach (var item in koleksiyonlar)
        {
            item.KoleksiyonKapali();
        }
    }

    private void ButonlaraDegerAta()
    {
        btnAnasayfa.onClick.AddListener(AnaSayfaOlustur);
        btnSol.onClick.AddListener(ButtonSOL);
        btnSag.onClick.AddListener(ButtonSAG);
    }

    private void ButtonSAG()
    {
        ses.PlayButtonClick();
        enSonsayfa++;
        ButunKartlariKapa();

        SayfaDegistir();
        AcikKoleksiyonlariAta();
    }

    private void ButtonSOL()
    {
        ses.PlayButtonClickGeri();
        enSonsayfa--;
        ButunKartlariKapa();
        SayfaDegistir();
        AcikKoleksiyonlariAta();
    }

    void SayfaDegistir()
    {

        KAYIT.SetEnSonSayfaKoleksiyon(enSonsayfa);
        sayfalar.SetSayfa(enSonsayfa);
        ButtonSayfalariAyarla();
    }

    private void AnaSayfaOlustur()
    {
        ses.PlayButtonClick();
        StartCoroutine(AnaSayfa());
    }

    IEnumerator AnaSayfa()
    {
        FindObjectOfType<SahnelerArasiGecis>().SetCikis();
        yield return new WaitForSeconds(0.5f);
        Fonksiyon.SahneDegistir(1);

    }
}
