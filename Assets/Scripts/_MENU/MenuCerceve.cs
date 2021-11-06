using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCerceve : MonoBehaviour
{


    [Header("Parametreler")]
    bool koleksiyonVar;
    bool cerceveAktif;

    [Header("Tanimlanacaklar")]
    public GameObject koleksiyon;
    public Image imgON;
    public List<Sprite> spriteOnCerceveler;
    public Image imgHayvan;
    public Sprite spriteHayvan;
    public GameObject kilit;
    public Button button;
    public GameObject yizdizlar;
    [SerializeField] Text txtRekor;
    [SerializeField] Text txtNumara;
    int _cerceveNumarasi;
    SesKutusuUI sesKutusu;
   


    // Start is called before the first frame update

    void Start()
    {
        Tanimlamalar();
    }


    public void SetCerceveyeSprit(int hangiSayfa, bool cerceveAktif)
    {

        if (!cerceveAktif)
        {
            imgON.sprite = spriteOnCerceveler[0];
        }
        else
        {
            switch (hangiSayfa)
            {
                case 1:
                    imgON.sprite = spriteOnCerceveler[1];
                    break;
                case 2:
                    imgON.sprite = spriteOnCerceveler[2];
                    break;
                case 3:
                    imgON.sprite = spriteOnCerceveler[3];
                    break;
                case 4:
                    imgON.sprite = spriteOnCerceveler[4];
                    break;
                default:
                    imgON.sprite = spriteOnCerceveler[5];
                    break;
            }
            
        }

    }


    public void SetImgHayvan(Sprite sprite)
    {
        imgHayvan.sprite = sprite;

    }

    private void Tanimlamalar()
    {
        sesKutusu = FindObjectOfType<SesKutusuUI>();
    }

    public void SetHangiBolume()
    {
        
        button.onClick.AddListener(SahneyeGit);
    }
    public void SetYildiz(int yildizSayisi)
    {
        for (int i = 0; i < yizdizlar.transform.childCount; i++)
        {

            if (i == yildizSayisi - 1)
                yizdizlar.transform.GetChild(i).gameObject.SetActive(true);
            else
                yizdizlar.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void SetKoleksiyonVar(bool durum)
    {
        koleksiyonVar = durum;
        koleksiyon.SetActive(koleksiyonVar);
    }
    public void SetCerceveAktif(bool aktif)
    {
        cerceveAktif = aktif;
        if (aktif)//aktif 
        {
            imgHayvan.color = new Color(255, 255, 255);
            kilit.SetActive(false);
            button.interactable = true;
        }
        else
        {
            kilit.SetActive(true);
            button.interactable = false;
            imgHayvan.color = new Color(0, 0, 0);
        }



    }

    public void SahneyeGit()
    {
        FindObjectOfType<ReklamKontrol>().CloseBanner();
        sesKutusu.PlayBolumSecildi();
        StartCoroutine(SahneyegitCorotuine());
    }

    IEnumerator SahneyegitCorotuine()
    {
        FindObjectOfType<SahnelerArasiGecis>().SetCikis();
        yield return new WaitForSeconds(0.65f);
        SceneManager.LoadScene(_cerceveNumarasi);

    }
    public void KacYildiz(int kac)
    {
        for (int i = 0; i < yizdizlar.transform.childCount; i++)
        {

            if (i == kac - 1)
                yizdizlar.transform.GetChild(i).gameObject.SetActive(true);
            else
                yizdizlar.transform.GetChild(i).gameObject.SetActive(false);
        }


    }

    public void SetCerceveNumarsi(int Numara)
    {
        _cerceveNumarasi = Numara;
        txtNumara.text = "" + Numara;
        SetHangiBolume();
    }

    public void SetRekor(int rekorSure)
    {
        if (rekorSure == 0) { txtRekor.text = "--:--"; }
        else { txtRekor.text = Fonksiyon.intgerToStringTime(rekorSure); }
    }
    public void SetRekor(string rekorSure)
    {
        txtRekor.text = rekorSure;
    }
}
