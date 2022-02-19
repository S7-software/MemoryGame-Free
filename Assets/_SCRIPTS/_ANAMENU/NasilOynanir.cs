using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NasilOynanir : MonoBehaviour
{
    [SerializeField] List<Button> buttonlar;
    [SerializeField] Text txtBaslik;
    [SerializeField] Text txtButtonText;
    [SerializeField] Image[] slotlar;
    [SerializeField] Sprite[] imgResimler;
    [SerializeField] GameObject cursor;
    [SerializeField] GameObject onay;
    Animator anim;
    SesKutusuUI sesKutusu;
    int _baslangicSayisi = 0;

    bool oyunda;
    void Start()
    {
        Tanimlamalar();
       anim = GetComponent<Animator>();
        ButtonlaraDegerAtama();
        ButtonlariAktifEt(_baslangicSayisi);
        DilleriAl();
    }

    private void Tanimlamalar()
    {
        sesKutusu = GameObject.Find("SesKutusu").GetComponent<SesKutusuUI>();
        oyunda = SceneManager.GetActiveScene().name == "Ana" ? false : true;
        OyundaysaYapilacak(oyunda);
    }

    private void OyundaysaYapilacak(bool oyunda)
    {
        if (!oyunda) return;

        FindObjectOfType<Saat>().OyunDuraklat();
    }

    private void DilleriAl()
    {
        txtBaslik.text = YAZI.NasilOynanir();
        txtButtonText.text = YAZI.Anladim();
    }

    private void ButtonlaraDegerAtama()
    {
        buttonlar[0].interactable = false;
        buttonlar[0].onClick.AddListener(SolButton);
        buttonlar[1].onClick.AddListener(SagButton);
        buttonlar[2].onClick.AddListener(OnayButton);
        if (!KAYIT.GetAnladimDahaOncedenAcildi())
        {
            buttonlar[2].interactable = false;
            KAYIT.SetAnladimDahaOncedenAcildi(1);
        }
        
       

    }

    private void SagButton()
    {
        sesKutusu.PlayButtonClick();
        _baslangicSayisi++;
        ButtonlariAktifEt(_baslangicSayisi);
    }

    private void ButtonlariAktifEt(int baslangicSayisi)
    {
        switch (baslangicSayisi)
        {
            case 0:
                anim.SetInteger("sayi", 0);
                slotlar[0].sprite = imgResimler[2];
                slotlar[1].sprite = imgResimler[0];
                slotlar[2].sprite = imgResimler[0];
                slotlar[3].sprite = imgResimler[2];
                break;
            case 1:
                anim.SetInteger("sayi", 1);
                slotlar[0].sprite = imgResimler[4];
                slotlar[1].sprite = imgResimler[4];
                slotlar[2].sprite = imgResimler[4];
                slotlar[3].sprite = imgResimler[4];
                break;
            case 2:
                anim.SetInteger("sayi", 2);
                slotlar[0].sprite = imgResimler[4];
                slotlar[1].sprite = imgResimler[4];
                slotlar[2].sprite = imgResimler[0];
                slotlar[3].sprite = imgResimler[4];
                break;
            case 3:
                anim.SetInteger("sayi", 3);
                slotlar[0].sprite = imgResimler[4];
                slotlar[1].sprite = imgResimler[1];
                slotlar[2].sprite = imgResimler[1];
                slotlar[3].sprite = imgResimler[4];
                break;
            case 4:

                slotlar[0].sprite = imgResimler[3];
                slotlar[1].sprite = imgResimler[1];
                slotlar[2].sprite = imgResimler[1];
                slotlar[3].sprite = imgResimler[3];

                break;

            default:
                break;
        }


        if (baslangicSayisi == 0)
        {
            
            buttonlar[0].interactable = false;
            onay.SetActive(false);
            cursor.SetActive(false);
        }
        else if (baslangicSayisi == 4)
        {
            buttonlar[1].interactable = false;
            buttonlar[2].interactable = true;
            onay.SetActive(true);
            cursor.SetActive(false);
            
        }
        else
        {
            buttonlar[0].interactable = true;
            buttonlar[1].interactable = true;
            onay.SetActive(false);
            if (!cursor.activeInHierarchy)
            {
                cursor.SetActive(true);
            }
        }
    }


    public void Oyundaysa()
    {
        print(SceneManager.GetActiveScene().name);
    }
    private void OnayButton()
    {
        sesKutusu.PlayButtonClick();
        if (oyunda) FindObjectOfType<Saat>().OyunDevamEttir();
        Destroy(gameObject);
    }

    private void SolButton()
    {
        sesKutusu.PlayButtonClickGeri();
        _baslangicSayisi--;
        ButtonlariAktifEt(_baslangicSayisi);

    }



}
