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
    void Start()
    {
        Tanimlamalar();
        DilleriCek();
        ButtonlaraAtamaYap();
    }

    private void Tanimlamalar()
    {
      myAnimator = GetComponent<Animator>();

        Fonksiyon.SetGameObjectSizeForTablet(GetComponent<CanvasScaler>(), 1000);
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
        SoundBox.instance.PlayOneShot(NamesOfSound.click);


        Application.OpenURL("http://s7-software.com");
    }

    private void Mail1()
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.click);

        Application.OpenURL("mailto:sinantekin90@gmail.com");
    }
    private void Mail2()
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.click);

        Application.OpenURL("mailto:sinantekin@s7-software.com");
    }

    private void SiteyeGit()
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.click);

        Application.OpenURL("http://s7-software.com");
        
    }
    private void UyariKutusunuKapat()
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.clickGeri1);
        myAnimator.SetBool("gecis", true);
        Destroy(gameObject, 0.5f);
    }

    private void AnaSayfayaGit()
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.click);
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
