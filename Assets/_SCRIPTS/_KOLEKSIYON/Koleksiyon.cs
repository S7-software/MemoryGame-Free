using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Koleksiyon : MonoBehaviour
{
    [SerializeField] public Image imgHayvan;
    [SerializeField] Image imgArkaPlan;
    [SerializeField] List<Text> txtHayvan;
    [SerializeField] Sprite sptKilit;
    [SerializeField] Sprite sptKapali;
    [SerializeField] Sprite sptAcik;
    [SerializeField] Sprite sptKoleksiyonCaliyor;
    bool koleksiyoVar;
    Button myBtn;
    private void Start()
    {
        Tanimlamalar();
        ButtonaAtama();
    }

    private void ButtonaAtama()
    {
        myBtn.onClick.AddListener(Islemler); 
    }

   
    void Islemler()
    {
        SesiBaslat();
    }

    

  

    private void SesiBaslat()
    {
        
        imgArkaPlan.sprite = sptKoleksiyonCaliyor;
        myBtn.interactable = false;
        FindObjectOfType<SesKutusuHayvanlar>().PlayHayvanSesi(imgHayvan.sprite.name);
    }


    private void Tanimlamalar()
    {
        myBtn = GetComponent<Button>();
    }

    public void SetPasifYap()
    {
        if (!koleksiyoVar) { return; }
        imgArkaPlan.sprite = sptAcik;
        myBtn.interactable = true;
    }

   

    /// //////////////////////////////////////////////////////
    public void KoleksiyonKapali()
    {
        imgHayvan.sprite = sptKilit;
        Fonksiyon.TextBoxlaraYazdir(txtHayvan, "???????");
        imgArkaPlan.sprite = sptKapali;
        txtHayvan[1].color = Color.white;
        koleksiyoVar = false;
        gameObject.GetComponent<Button>().interactable = false;

    }
  
    public void KoleksiyonAcik(Sprite hayvan)
    {
        imgHayvan.sprite = hayvan;
        imgArkaPlan.sprite = sptAcik;
        txtHayvan[1].color = new Color32(255, 230, 206, 255);
        string _yazi = YAZI.GetHayvanAdi(imgHayvan.sprite.name);
        Fonksiyon.TextBoxlaraYazdir(txtHayvan, _yazi);
        koleksiyoVar = true;
        gameObject.GetComponent<Button>().interactable = true;


    }

}
