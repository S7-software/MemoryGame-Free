using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelReklamSonrasi : MonoBehaviour
{

    Image panel;
    [SerializeField] List<Image> panelCizgi;
    [SerializeField] GameObject button;
    Kart[] kartlar;
    // Start is called before the first frame update
    void Awake()
    {
        Tanimlamalar();
    }

    private void Tanimlamalar()
    {
        if (!ReklamKontrol.GetReklamSonrasiOyunBasladi())        {            return;                   }
        kartlar = FindObjectsOfType<Kart>();
        panel = GetComponent<Image>();
        button.GetComponent<Button>().onClick.AddListener(HandleOyunuBaslat);

    }

    private void HandleOyunuBaslat()
    {
        foreach (Kart kart in kartlar)
        {
            kart.IlkAcilis();
        }
        Saat.secenekler.CoroutineOyunuBaslatIlkBesSaniye();
        ReklamKontrol.SetReklamSonrasiOyunBasliyor(false);
        FindObjectOfType<SesKutusuUI>().PlayButtonClick();
        SetActive(false);
    }

    public void SetActive(bool aktif)
    {
        button.SetActive(aktif);
        panel.enabled = aktif;

        foreach (var pane in panelCizgi)
        {
            pane.gameObject.SetActive(aktif);
        }
    }
}
