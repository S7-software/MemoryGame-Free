using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Cerceve : MonoBehaviour
{

    [Header("Parametreller")]
    [SerializeField] bool cerceveAcik = true;
    [Range(1, 3)] [SerializeField] int hangiCerceve = 1;
    [Range(1, 5)] [SerializeField] float kartAcikKalmaSuresi = 3f;
    [Range(1, 5)] [SerializeField] float oyunIlkAcilisSuresi = 3f;

    [Header("Tanimlanacaklar")]
    public Sprite[] imgsCerceveOn;
    public Sprite[] imgsCerceveArka;
    public SpriteRenderer imgHayvan, imgCerceveOn, imgCerceveArka;

    public string cerceveAdi = "Davuk";



    void Start()
    {
        Tanimlama();
        StartCoroutine(OyunIlkAcilis());
    }

    

    private void Tanimlama()
    {
        imgCerceveOn.sprite = imgsCerceveOn[hangiCerceve - 1];
        imgCerceveArka.sprite = cerceveAcik ? null : imgsCerceveArka[hangiCerceve - 1];
    }



    void OnMouseDown()
    {

        Debug.Log("OnmouseGiriş");
    }

    
    IEnumerator KartKontrol()
    {
        yield return new WaitForSeconds(kartAcikKalmaSuresi);
    }
    IEnumerator OyunIlkAcilis()
    {
        yield return new WaitForSeconds(oyunIlkAcilisSuresi);
        cerceveAcik = false;
        Tanimlama();
    }
}
