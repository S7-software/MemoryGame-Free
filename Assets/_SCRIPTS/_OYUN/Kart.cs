using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Kart : MonoBehaviour
{

    [Header("Parametreller")]
    public bool kartAcik;


    [Header("Tanimlanacaklar")]
    public Sprite[] imgsCerceveOn;
    public Sprite[] imgsCerceveArka;
    public SpriteRenderer imgHayvan, imgCerceveOn, imgCerceveArka;
    public Sprite sprtHayvan;
    public GameObject Kartlar;
    public string cerceveAdi = "Davuk";
    public Sprite[] sprSecili;
    int hangiBolum;



    public Animator animator;

   public BoxCollider2D myCollider;
    KartKontrol kartKontrol;
    void Start()
    {
        Tanimlama();
        Atamalar();
    }

    private void Atamalar()
    {
        CerceveleriAta();
    }

    private void CerceveleriAta()
    {
        CerceveAta((hangiBolum - 1) / 16);
    }

    private void Tanimlama()
    {
        
        hangiBolum = SceneManager.GetActiveScene().buildIndex;
        imgHayvan.sprite = sprtHayvan;
        animator = GetComponent<Animator>();
        cerceveAdi = imgHayvan.sprite.name;
        kartAcik = false;
        myCollider = GetComponent<BoxCollider2D>();
        kartKontrol = FindObjectOfType<KartKontrol>();
        if (!ReklamKontrol.GetReklamSonrasiOyunBasladi())
        {
            IlkAcilis();
        }
    }

    public void CerceveAta(int hangi)
    {

        imgCerceveArka.sprite = imgsCerceveArka[hangi ];
        imgCerceveOn.sprite = imgsCerceveOn[hangi ];

    }

    public void SetCerceveKartBulundu()
    {
        imgCerceveArka.sprite = sprSecili[1];
        imgCerceveOn.sprite = sprSecili[0];
    }




    void OnMouseDown()
    {
        KartAc();
        SoundBox.instance.PlayOneShot(NamesOfSound.kartSecme);
    }

    void KartAc()
    {
        animator.SetBool("Ac", true);
        kartAcik = true;
        myCollider.enabled = false;
         kartKontrol.KartCiftKontrol();
    }

    public void IlkAcilis()
    {
        animator.SetBool("ilk", true);
    }

   
}
