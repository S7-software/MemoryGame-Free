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
    void Start()
    {
        Fonksiyon.SetGameObjectSizeForTablet(GetComponent<CanvasScaler>(), 1000);
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
        SoundBox.instance.PlayOneShot(NamesOfSound.clickGeri1);
        myAnim.SetTrigger("cikis");
        Destroy(gameObject, 0.5f);
    }

    private void CikisButton()
    {
        ReklamKontrol.secenekler.CloseBanner();
        SoundBox.instance.PlayOneShot(NamesOfSound.click);
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
        myAnim = GetComponent<Animator>();
    }
}
