using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KoleksiyonBulundu : MonoBehaviour
{
    [SerializeField] Image imgHayvan;
    [SerializeField] List<Text> txtHayvanAdi;
    [SerializeField] List<Text> txtKoleksiyonBulundu    ;

   public void SetActive(Sprite sptrite, string hayvanAdi)
    {
        
        imgHayvan.sprite = sptrite;
        Fonksiyon.TextBoxlaraYazdir(txtHayvanAdi, hayvanAdi);
        Fonksiyon.TextBoxlaraYazdir(txtKoleksiyonBulundu, YAZI.KoleksiyonBulundu()) ;
        gameObject.SetActive(true);

    }

   
}
