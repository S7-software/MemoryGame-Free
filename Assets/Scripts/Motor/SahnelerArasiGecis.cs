using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SahnelerArasiGecis : MonoBehaviour
{
    [SerializeField] Image imagePanel;
    [SerializeField] Image imgResim;
    [SerializeField] Image imgResim2;
    [SerializeField] List<Sprite> spriteHayvanlar;
    Animator myAnim;


    void Start()
    {
        OtomatikResimAta();
        myAnim = GetComponent<Animator>();
    }

    private void OtomatikResimAta()
    {
        imgResim.sprite = spriteHayvanlar[UnityEngine.Random.Range(0, spriteHayvanlar.Count)];
        imgResim2.sprite = imgResim.sprite;
    }

    /// <summary>
    /// deger = true --> giris, deger = false --> cikis
    /// </summary>
    /// <param name="deger"></param>
    public void SetCikis()
    {
        OtomatikResimAta();
        
            myAnim.SetTrigger("cikis");
        
    }

   
}
