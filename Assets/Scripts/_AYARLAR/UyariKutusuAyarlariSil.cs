using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UyariKutusuAyarlariSil : MonoBehaviour
{
    [SerializeField] Text txtBaslik;
    [SerializeField] List<Text> txtYazi;
    [SerializeField] Button btnOnay, btnIptal;
    Animator myAnim;
    SesKutusuUI ses;
    void Start()
    {
        Tanimlar();
        Atamalar();

    }

    private void Atamalar()
    {
        ButtonlaraFonksiyonAta();
        DilleriCek();
    }

    private void ButtonlaraFonksiyonAta()
    {
        btnOnay.onClick.AddListener(CikisButton);
        btnIptal.onClick.AddListener(IptalButton);
    }

    private void IptalButton()
    {
        ses.PlayButtonClickGeri();
        myAnim.SetTrigger("cikis");
        Destroy(gameObject, 0.5f);
    }

    private void CikisButton()
    {
        ses.PlayButtonClick();
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Intro");
    }

    private void DilleriCek()
    {
        Fonksiyon.TextBoxlaraYazdir(txtYazi, YAZI.ButunRekorlarVeAyarlarSilinecek());
        txtBaslik.text = YAZI.Uyari();
    }

    private void Tanimlar()
    {
        ses = GameObject.Find("SesKutusu").GetComponent<SesKutusuUI>() ;
        myAnim = GetComponent<Animator>();
    }
}
