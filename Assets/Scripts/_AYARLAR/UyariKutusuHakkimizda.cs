using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UyariKutusuHakkimizda : MonoBehaviour
{
    [SerializeField] List<Text> txtAciklama;
    [SerializeField] List<Text> txtGizlilikPolitikasi;
    [SerializeField] Text txtHakimizda;
    [SerializeField] Button btnLinkSite;
    [SerializeField] Button btnLinkGizlilikPolitikasi;
    [SerializeField] Button btnLinkMail1;
    [SerializeField] Button btnLinkMail2;
    [SerializeField] Button btnAnaMenu;
    [SerializeField] Button btnAyarlar;

    Animator myAnimator;
    SesKutusuUI ses;
    void Start()
    {
        Tanimlamalar();
        DilleriCek();
        ButtonlaraAtamaYap();
    }

    private void Tanimlamalar()
    {
        ses = FindObjectOfType<SesKutusuUI>();
      myAnimator = GetComponent<Animator>();
    }

    private void ButtonlaraAtamaYap()
    {
        btnAnaMenu.onClick.AddListener(AnaSayfayaGit);
        btnAyarlar.onClick.AddListener(UyariKutusunuKapat);
        btnLinkGizlilikPolitikasi.onClick.AddListener(GizlilikPolitikasi);
        btnLinkSite.onClick.AddListener(SiteyeGit);
        btnLinkMail1.onClick.AddListener(Mail1);
        btnLinkMail2.onClick.AddListener(Mail2);
    }

    private void GizlilikPolitikasi()
    {
        ses.PlayButtonClick();

        Application.OpenURL("http://s7-software.com");
    }

    private void Mail1()
    {
        ses.PlayButtonClick();

        Application.OpenURL("mailto:sinantekin90@gmail.com");
    }
    private void Mail2()
    {
        ses.PlayButtonClick();

        Application.OpenURL("mailto:sinantekin@s7-software.com");
    }

    private void SiteyeGit()
    {
        ses.PlayButtonClick();

        Application.OpenURL("http://s7-software.com");
        
    }
    private void UyariKutusunuKapat()
    {
        ses.PlayButtonClickGeri();
      myAnimator.SetBool("gecis", true);
        Destroy(gameObject, 0.5f);
    }

    private void AnaSayfayaGit()
    {
        ses.PlayButtonClick();
        StartCoroutine(AnaSayfa());
    }

    private void DilleriCek()
    {
        Fonksiyon.TextBoxlaraYazdir(txtAciklama, YAZI.HakkimizdaAciklama());
        Fonksiyon.TextBoxlaraYazdir(txtGizlilikPolitikasi, YAZI.GizlilikPolitikasi());
        txtHakimizda.text = YAZI.Hakkimizda();
    }

    public void SetActive()
    {
        gameObject.SetActive(true);
    }

    IEnumerator AnaSayfa()
    {
        FindObjectOfType<SahnelerArasiGecis>().SetCikis();
        yield return new WaitForSeconds(0.5f);
        Fonksiyon.SahneDegistir(1);

    }
}
