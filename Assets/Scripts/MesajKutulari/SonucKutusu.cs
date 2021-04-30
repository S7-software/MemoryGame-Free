using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SonucKutusu : MonoBehaviour
{
    public Text[] txtRekor, txtSure, txtSureYazi, txtBaslik;
    public Button[] buttonlar;//menu,tekrar,sonraki
    public Image[] yildizlar;
    GameObject canvasSonuc;
    int _hangiSahne;
    SesKutusuUI sesKutusu;

 [SerializeField]   Text txtBolumNumarasi;



    void Start()
    {
        Tanimlamalar();
        Atamalar();
    }

    private void Atamalar()
    {
        DilleriAta();
    }

    private void DilleriAta()
    {
        txtRekor[0].text = YAZI.Rekor();
        txtRekor[1].text = YAZI.Rekor();
        txtSureYazi[0].text = YAZI.Sure();
        txtSureYazi[1].text = YAZI.Sure();
        txtBolumNumarasi.text = _hangiSahne.ToString();
    }

    private void Tanimlamalar()
    {
        sesKutusu = FindObjectOfType<SesKutusuUI>();
        _hangiSahne = SceneManager.GetActiveScene().buildIndex;
        buttonlar[0].onClick.AddListener(MenuyeDon);
        buttonlar[1].onClick.AddListener(OyunuTekrarla);
        buttonlar[2].onClick.AddListener(SonrakiOyun);

    }

    private void SonrakiOyun()
    {
        ReklamKontrol.secenekler.ShowGecis();

        sesKutusu.PlayButtonClick();
        SceneManager.LoadScene(_hangiSahne + 1);
    }

    private void OyunuTekrarla()
    {
        ReklamKontrol.secenekler.ShowGecis();

        sesKutusu.PlayButtonClick();

        SceneManager.LoadScene(_hangiSahne);
    }

    private void MenuyeDon()
    {
        ReklamKontrol.secenekler.ShowGecis();

        sesKutusu.PlayButtonClick();

        SceneManager.LoadScene("Menu");
    }

    private void canvasSonucAl()
    {
        canvasSonuc = GameObject.Find("CanvasSonuc");


    }

    public void SonucKutusunuCikar(int yildizSayisi, int sure, bool rekorVar)
    {

        canvasSonucAl();
        string _yildiz = yildizSayisi.ToString();

        SureyiYazdir(sure);
        RekorVar(rekorVar);

        if (yildizSayisi != 0)
        {
            canvasSonuc.GetComponent<Animator>().SetTrigger("y" + yildizSayisi);
            BaslikKazandi(true);
        }
        else
        {
            BaslikKazandi(false);
            buttonlar[2].interactable = false;
        }


    }
    private void RekorVar(bool var)
    {
        txtRekor[0].enabled = var;
        txtRekor[1].enabled = var;
    }

    public void SureyiYazdir(int sure)
    {
        int _dakika, _saniye;
        string _sure = "";
        if (sure >= 60)
        {
            _dakika = sure / 60;
            if (_dakika >= 10)
            {
                _sure += _dakika;
            }
            else
            {
                _sure += "0" + _dakika;
            }

            _sure += ":";
            _saniye = sure % 60;
            if (_saniye >= 10)
            {
                _sure += _saniye;
            }
            else
            {
                _sure += "0" + _saniye;
            }
        }
        else
        {
            _sure += "00:";
            _saniye = sure;
            if (_saniye >= 10)
            {
                _sure += _saniye;
            }
            else
            {
                _sure += "0" + _saniye;
            }
        }



        txtSure[0].text = _sure;
        txtSure[1].text = _sure;
    }

     void BaslikKazandi(bool deger)
    {
        if (deger)
        {
            txtBaslik[0].text = YAZI.BolumTamamlandi();
        }
        else txtBaslik[0].text = YAZI.Basarisiz();


    }

}
