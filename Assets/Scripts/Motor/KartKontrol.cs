using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartKontrol : MonoBehaviour
{

    [Header("Parametreler")]
    [Range(0f, 3f)] public float kapanmaSuresi = 0.55f;


    public GameObject kartlarArkaPlan;
    public Transform cikarilanKartlar;
    [SerializeField] GameObject anlikSaniye;

    Kart[] kartlar;

    Kart acikKart1, acikKart2;
    Saat saat;
    OyunYoneticisi oyunYoneticisi;
    int _zorluk;
    SesKutusuUI sesKutusu;
    GameObject konum;


    // Start is called before the first frame update
    void Start()
    {
        Tanimlanacaklar();

    }


    private void Tanimlanacaklar()
    {
        kartlar = kartlarArkaPlan.GetComponentsInChildren<Kart>();
        saat = FindObjectOfType<Saat>();
        oyunYoneticisi = FindObjectOfType<OyunYoneticisi>();
        _zorluk = oyunYoneticisi.GetZorluk();
        sesKutusu = FindObjectOfType<SesKutusuUI>();
        konum = GameObject.Find("cikacakYer");
    }



    public void BulunmamisButunKartlarinCollideriniAc(bool deger)
    {
        foreach (Kart kart in kartlar)
        {
            kart.myCollider.enabled = deger;
        }
    }
    public void ButunKartlariAl()
    {
        kartlar = kartlarArkaPlan.GetComponentsInChildren<Kart>();
    }


    public void KartCiftKontrol()
    {
        if (oyunYoneticisi.oyunBitti) { return; }
        if (ikiKartAcik())
        {
            BulunmamisButunKartlarinCollideriniAc(false);
            acikKart1 = null;
            acikKart2 = null;
            foreach (Kart kart in kartlar)
            {
                if (kart.kartAcik)
                {
                    if (acikKart1 == null)
                    {
                        acikKart1 = kart;
                    }
                    else
                    {
                        acikKart2 = kart;
                        break;
                    }
                }
            }
            // iki açık kart aynı
            if (acikKart2.sprtHayvan.name == acikKart1.sprtHayvan.name)
            {
                sesKutusu.PlayKartBulma();
                acikKart1.GetComponentInParent<Transform>().SetParent(cikarilanKartlar);
                acikKart2.GetComponentInParent<Transform>().SetParent(cikarilanKartlar);
                acikKart1.SetCerceveKartBulundu();
                acikKart2.SetCerceveKartBulundu();
                ButunKartlariAl();
                BulunmamisButunKartlarinCollideriniAc(true);
                if (kartlar.Length != 0)
                {
                    if (_zorluk != 0)
                    {
                        Sureye5SaniyeEkle();
                    }

                }


            }
            //iki açık kart aynı değil
            else
            {
                acikKart1.kartAcik = false;
                acikKart2.kartAcik = false;
                StartCoroutine(KartKapa(kapanmaSuresi));
            }

        }
    }


    bool ikiKartAcik()
    {
        int _kacTane = 0;
        foreach (Kart kart in kartlar)
        {
            if (kart.kartAcik)
            {
                _kacTane++;
            }
        }
        if (_kacTane == 2)
        {
            return true;
        }
        else
        {
            return false;
        }

    }


    IEnumerator KartKapa(float sure)
    {
        yield return new WaitForSeconds(sure);
        acikKart1.animator.SetBool("Ac", false);
        acikKart2.animator.SetBool("Ac", false);
        ButunKartlariAl();

        BulunmamisButunKartlarinCollideriniAc(true);

    }

    void Sureye5SaniyeEkle()
    {
        saat.mevcutSure += 5;
        saat.oyunSuresi += 5;
        saat.SureyiTexteYazdir(saat.mevcutSure);
        saat.slider.maxValue = saat.oyunSuresi;
        saat.slider.value = saat.mevcutSure;
        ArtiBesSaniyeResimCikar();

    }

    private void ArtiBesSaniyeResimCikar()
    {
        
        GameObject besSaniyeAnlik = Instantiate(anlikSaniye, konum.transform.position, Quaternion.identity);
        besSaniyeAnlik.transform.SetParent(konum.transform);
        Destroy(besSaniyeAnlik, 0.6f);
    }

    public List<Kart> GetColliderButunKapaliKartlar()
    {
        List<Kart> _kartlar = new List<Kart>();
        ButunKartlariAl();
        foreach (Kart kart in kartlar)
        {
            if (!kart.kartAcik)
            {
                _kartlar.Add(kart);
            }
        }
        return _kartlar;
    }

}
