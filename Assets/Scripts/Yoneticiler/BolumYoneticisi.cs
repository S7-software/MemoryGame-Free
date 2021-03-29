using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BolumYoneticisi : MonoBehaviour
{

    int zorluk,
        enSonBolum,
        enSonSayfa;
    MenuCerceve[] menuCerceveleri;
    ResimKutusu resimKutusu;
    public Text txtBolumler;

    [SerializeField]
    Button btnIleri,
        btnGeri,
        btnAnaSayfa;

    [SerializeField] Sayfalar sayfalar;
    SesKutusuUI sesKutusu;
    [SerializeField] Text txtYildizSayisiVarOlan;
    [SerializeField] Text txtYildizSayisiToplam;
 
    private void Awake()
    {
        Tanimlamalar();
        Atamalar();
    }

    private void Atamalar()
    {
        CerceveleriKapaliOlarakAta();
        DilleriCek();
        AktifCerceveleriAtama();
    }

    private void AktifCerceveleriAtama()
    {

        int _baslangicDegeri = BaslangicDegeri(enSonSayfa);
        int _i = 0;
        int yildizVarolan = 0;

        for (int i = _baslangicDegeri; i < _baslangicDegeri + 16; i++)
        {
            if (enSonBolum > i)
            {
                menuCerceveleri[_i].SetCerceveyeSprit(enSonSayfa, true);
                menuCerceveleri[_i].SetCerceveAktif(true);
                menuCerceveleri[_i].SetRekor(KAYIT.GetRekorSure(zorluk, i + 1));
               // print("zorluk: " + zorluk + ", i: " + i + "+1, " + KAYIT.GetRekorSure(zorluk, i + 1));
                menuCerceveleri[_i].KacYildiz(KAYIT.GetRekorYildiz(zorluk, i + 1));
                yildizVarolan += KAYIT.GetRekorYildiz(zorluk, i + 1);
            }

            else
            {
                break;

            }

            _i++;
        }
        txtYildizSayisiVarOlan.text = yildizVarolan.ToString(); ;
    }



    private void DilleriCek()
    {

        if (zorluk == 0) { txtBolumler.text = YAZI.Suresiz(); }
        else if (zorluk == 1) { txtBolumler.text = YAZI.Normal(); }
        else if (zorluk == 2) { txtBolumler.text = YAZI.Zor(); }
        else { txtBolumler.text = "Hata"; }

    }

    private void CerceveleriKapaliOlarakAta()
    {
        int _baslangicDeger = BaslangicDegeri(enSonSayfa);

        int _i = 0;
        int yildizToplam = 0;

        for (int i = _baslangicDeger; i < 16 + _baslangicDeger; i++)
        {
            menuCerceveleri[_i].SetCerceveAktif(false);
            if (zorluk == 1)
            {
                if (KAYIT.GetKoleksiyonAdiNORMAL(i + 1) == "yok" || KAYIT.GetRekorSure(zorluk, i + 1)!=0)
                {
                    menuCerceveleri[_i].SetKoleksiyonVar(false);
                }
                else
                {
                    menuCerceveleri[_i].SetKoleksiyonVar(true);

                }

            }
            else if (zorluk == 2)
            {
                if (KAYIT.GetKoleksiyonAdiZOR(i + 1) == "yok" || KAYIT.GetRekorSure(zorluk, i + 1) != 0)
                {
                    menuCerceveleri[_i].SetKoleksiyonVar(false);
                }
                else
                {
                    menuCerceveleri[_i].SetKoleksiyonVar(true);

                }
            }
            else
            {
                menuCerceveleri[_i].SetKoleksiyonVar(false);
            }
            try
            {
                menuCerceveleri[_i].SetImgHayvan(resimKutusu.hayvanResimleri[i]);
              menuCerceveleri[_i].SetCerceveyeSprit(enSonSayfa, false);
               // menuCerceveleri[_i].SetCerceveyeSprit(enSonSayfa, true); //Bölüm çerçevelerini deneme
                menuCerceveleri[_i].SetCerceveNumarsi(i + 1);
                menuCerceveleri[_i].SetRekor(0);
                menuCerceveleri[_i].KacYildiz(0);
                yildizToplam +=3;
            }
            catch (Exception )
            {
               // print(e);
                menuCerceveleri[_i].SetImgHayvan(menuCerceveleri[_i].kilit.GetComponent<Image>().sprite);
                menuCerceveleri[_i].SetCerceveyeSprit(enSonSayfa, false);
                menuCerceveleri[_i].SetCerceveNumarsi(i + 1);
                menuCerceveleri[_i].SetRekor("Very Soon");
                menuCerceveleri[_i].KacYildiz(0);
            }

            _i++;
        }
        txtYildizSayisiToplam.text = yildizToplam.ToString();
    }

    private int BaslangicDegeri(int enSonSayfa)
    {
        switch (enSonSayfa)
        {
            case 1: sayfalar.SetSayfa(1); return 0;
            case 2: sayfalar.SetSayfa(2); return 16;
            case 3: sayfalar.SetSayfa(3); return 32;
            case 4: sayfalar.SetSayfa(4); return 48;
            case 5: sayfalar.SetSayfa(5); return 64;
            case 6: sayfalar.SetSayfa(6); return 80;
            case 7: return 83;

            default:
                return 0;

        }
    }

    private void Tanimlamalar()
    {
        sesKutusu = FindObjectOfType<SesKutusuUI>();
        zorluk = KAYIT.GetOyunZorluk();
        enSonBolum = EnSonBolumuAl(zorluk);
        enSonSayfa = KAYIT.GetMenuKacinciSayfadaKaldi(zorluk);
        menuCerceveleri = GameObject.Find("MenuCerceveler").GetComponentsInChildren<MenuCerceve>();
        resimKutusu = FindObjectOfType<ResimKutusu>();
        ButtonlaraFonksiyonAtama();
    }

    private void ButtonlaraFonksiyonAtama()
    {
        if (enSonSayfa == 1)
        {
            btnGeri.interactable = false;
            btnIleri.interactable = true;
        }
        else if (enSonSayfa == 5)
        {
            btnGeri.interactable = true;
            btnIleri.interactable = false;
        }
        else
        {
            btnGeri.interactable = true;
            btnIleri.interactable = true;
        }

        btnIleri.onClick.AddListener(SayfaIleri);
        btnGeri.onClick.AddListener(SayfaGeri);
        btnAnaSayfa.onClick.AddListener(AnaSayfayaGit);
    }

    private void AnaSayfayaGit()
    {
        sesKutusu.PlayButtonClickGeri();
        StartCoroutine(AnaSayfa());
    }
    IEnumerator AnaSayfa()
    {
        FindObjectOfType<SahnelerArasiGecis>().SetCikis();
        yield return new WaitForSeconds(0.5f);
        Fonksiyon.SahneDegistir(1);
    }

    private int EnSonBolumuAl(int zorluk)
    {
        switch (zorluk)
        {
            case 1: return KAYIT.GetKacinciBolumNORMAL();
            case 2: return KAYIT.GetKacinciBolumZOR();


            default:
                return KAYIT.GetKacinciBolumSURESIZ();

        }
    }
    void SayfaGeri()
    {
        sesKutusu.PlayButtonClickGeri();
        if (btnIleri.interactable == false) { btnIleri.interactable = true; }
        enSonSayfa--;
        sayfalar.SetSayfa(enSonSayfa);
        KAYIT.SetMenuKacinciSayfadaKaldi(zorluk, enSonSayfa);
        BaslangicDegeri(enSonSayfa);
        SayfaDegistir();
        if (enSonSayfa == 1) { btnGeri.interactable = false; }
    }
    void SayfaIleri()
    {
        sesKutusu.PlayButtonClick();
        if (btnGeri.interactable == false) { btnGeri.interactable = true; }
        enSonSayfa++;
        sayfalar.SetSayfa(enSonSayfa);

        KAYIT.SetMenuKacinciSayfadaKaldi(zorluk, enSonSayfa);
        BaslangicDegeri(enSonSayfa);
        SayfaDegistir();
        if (enSonSayfa == 5) { btnIleri.interactable = false; }
    }


    void SayfaDegistir()
    {
        CerceveleriKapaliOlarakAta();
        AktifCerceveleriAtama();
    }
}
