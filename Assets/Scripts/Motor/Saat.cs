using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Saat : MonoBehaviour
{
    public static Saat secenekler;

    [Header("Parametreler")]
    [Range(1, 10)] [SerializeField] int baslangicSuresi = 4;
    [Range(1, 100)] [SerializeField] public int oyunSuresi = 5;


    [Header("Tanımlanacaklar")]
    public Sprite[] spriteBarlar;
    public Image imgBar;
    public Text[] txtSureler;
    public Slider slider;
    public int mevcutSure = 5;
    private bool oyunBasladi = false;
    public bool oyunBitti;
    KartKontrol kartKontrol;
    OyunYoneticisi oyunYoneticisi;
    Button btnCikis;
    btnNasilOynanir buttonNasiOynanir;
    int toplamKartSayisi;
    SesKutusuUI sesKutusu;
    private void Awake()
    {
        secenekler = this;
    }

    void Start()
    {
        Tanimlama();


        //          Reklam sonrası oyun başlama tepkisi
        if (ReklamKontrol.GetReklamSonrasiOyunBasladi())
        {
            FindObjectOfType<PanelReklamSonrasi>().SetActive(true);
        }
        else
        {
            CoroutineOyunuBaslatIlkBesSaniye();
        }
        
    }



    private void Tanimlama()
    {
        btnCikis = GameObject.Find("btnCikis").GetComponent<Button>();
        buttonNasiOynanir = FindObjectOfType<btnNasilOynanir>();
        kartKontrol = FindObjectOfType<KartKontrol>();
        imgBar.sprite = spriteBarlar[0];
        mevcutSure = baslangicSuresi;
        slider.maxValue = baslangicSuresi;
        SureyiTexteYazdir(mevcutSure);
        oyunBitti = false;
        oyunYoneticisi = FindObjectOfType<OyunYoneticisi>();
        toplamKartSayisi = oyunYoneticisi.GetKartSayisi();
        sesKutusu = FindObjectOfType<SesKutusuUI>();

    }

    IEnumerator BesSaniyeGeriSayim()
    {
        do
        {
            SureyiTexteYazdir(mevcutSure);
            yield return new WaitForSeconds(1);

            mevcutSure--;
            slider.value = mevcutSure;

        } while (mevcutSure >= 0);


        StartCoroutine(OyunuBaslat());


        BesSaniyeSonraOyunuBaslatGENEL();


    }

    private void BesSaniyeSonraOyunuBaslatGENEL()
    {
        btnCikis.interactable = true;
        buttonNasiOynanir.SetInteractable(true);
        sesKutusu.PlayOyunBasladi();
    }

    IEnumerator OyunuBaslat()
    {
        if (!oyunBasladi)
        {
            mevcutSure = oyunSuresi;
            slider.maxValue = oyunSuresi;

            oyunBasladi = true;
            kartKontrol.BulunmamisButunKartlarinCollideriniAc(true);
        }


        if (KAYIT.GetOyunZorluk() == 0)
        {
            do
            {
                slider.maxValue = mevcutSure;
                slider.value = mevcutSure;

                SureyiTexteYazdir(mevcutSure);
                SliderBarBelirleme(mevcutSure);
                yield return new WaitForSeconds(1);
                mevcutSure++;


            } while (mevcutSure > 0);

        }
        else
        {
            do
            {
                slider.value = mevcutSure;

                SureyiTexteYazdir(mevcutSure);
                SliderBarBelirleme(mevcutSure);
                yield return new WaitForSeconds(1);
                mevcutSure--;



            } while (mevcutSure > 0);
            slider.value = mevcutSure;

            SureyiTexteYazdir(mevcutSure);
        }



        if (KAYIT.GetOyunZorluk() != 0)
        {
            OyunBitti();
        }

    }



    private void OyunBitti()
    {
        oyunYoneticisi.Kaybetti();
    }

    public void SureyiTexteYazdir(int sure)
    {
        txtSureler[0].text = sure.ToString();
        txtSureler[1].text = sure.ToString();
    }


    private void SliderBarBelirleme(int sure)
    {

        if (oyunYoneticisi.GetZorluk() == 0)
        {

             imgBar.sprite = spriteBarlar[0];
        }
        else
        {


            if (sure <= 10 && sure > 5)
            {
                imgBar.sprite = spriteBarlar[1];
            }
            else if (sure <= 5)
            {
                imgBar.sprite = spriteBarlar[2];
            }
            else
            {
                imgBar.sprite = spriteBarlar[0];
            }
        }
    }


    public void CoroutineOyunuBaslatIlkBesSaniye()
    {
        StartCoroutine(BesSaniyeGeriSayim());
    }
    public void OyunBittiButunCoroutineleriDurdur()
    {
        StopAllCoroutines();
    }

    public void OyunDuraklat()
    {
        SetColliderler(false);
        StopAllCoroutines();

    }

    public void OyunDevamEttir()
    {
        SetColliderler(true);
        StartCoroutine(OyunuBaslat());
    }

    void SetColliderler(bool acik)
    {
        List<Kart> _kartlar = kartKontrol.GetColliderButunKapaliKartlar();
        foreach (Kart kart in _kartlar)
        {
            kart.myCollider.enabled = acik;
        }
    }
}
