using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Yaratici : MonoBehaviour
{
    [Header("Parametreler")]
    [Range(0, 7)] public int kacNumaraliObje = 0;
    public bool escAktif = true;

    [Header("Tanımlanacaklar")]
    public GameObject[] objeler;

    [SerializeField] Text txtYildizKolay;
    [SerializeField] Text txtYildizNormal;
    [SerializeField] Text txtYildizZor;

    private void Start()
    {
        YildizlariCek();
    }

    private void YildizlariCek()
    {
        txtYildizKolay.text = KAYIT.GetToplamYildizSayisi(0);
        txtYildizNormal.text = KAYIT.GetToplamYildizSayisi(1);
        txtYildizZor.text = KAYIT.GetToplamYildizSayisi(2);
    }

    void Update()
    {
        if (escAktif)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                

                if (transform.childCount==0)
                {
                    UyariCercevesiCikar();
                }
                else
                {
                    
                }
               
            }
        }
        
    }

    public void UyariCercevesiCikar()
    {
        FindObjectOfType<SesKutusuUI>().PlayButtonClick();
        GameObject uyariKutusu = Instantiate(objeler[0], transform.position, transform.rotation) as GameObject;
        uyariKutusu.transform.SetParent(transform);
        uyariKutusu.transform.localScale = new Vector3(1, 1, 1);
    }



}
