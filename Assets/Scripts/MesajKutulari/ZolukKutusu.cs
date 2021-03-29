using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ZolukKutusu : MonoBehaviour
{
    [SerializeField] List<Button> buttonlar;
    [SerializeField] List<Text> yazilar;
    [SerializeField] Text txtYildizKolay;
    [SerializeField] Text txtYildizNormal;
    [SerializeField] Text txtYildizZor;

    Animator anim;
    SesKutusuUI ses;
    // Start is called before the first frame update
    void Start()
    {
        Tanimlamalar();
        Atamalar();

    }

    private void Atamalar()
    {
        ButtonlaraFonksiyonAta();
        
        YazilariAta();
        YildizYazilariniAta();
    }

    private void YildizYazilariniAta()
    {
        txtYildizKolay.text = KAYIT.GetToplamYildizSayisi(0);
        txtYildizNormal.text =KAYIT.GetToplamYildizSayisi(1);
        txtYildizZor.text = KAYIT.GetToplamYildizSayisi(2);
    }

    private void ButtonlaraFonksiyonAta()
    {
        buttonlar[0].onClick.AddListener(Suresiz);
        buttonlar[1].onClick.AddListener(Normal);
        buttonlar[2].onClick.AddListener(Zor);
        buttonlar[3].onClick.AddListener(Geri);
    }

    private void YazilariAta()
    {
        yazilar[6].text = YAZI.Suresiz();
        yazilar[7].text = YAZI.Normal();
        yazilar[8].text = YAZI.Zor();
        yazilar[0].text = YAZI.ZamanSinirlamasiYok();
        yazilar[1].text = YAZI.ZamanSinirlamasiYok();
        yazilar[2].text = YAZI.YirmiSaniyeSureVe();
        yazilar[3].text = YAZI.YirmiSaniyeSureVe();
        yazilar[4].text = YAZI.BesSaniyeSureVe();
        yazilar[5].text = YAZI.BesSaniyeSureVe();
    }

    private void Geri()
    {
        ses.PlayButtonClickGeri();
       anim.SetTrigger("geri");
        StartCoroutine(GeriGit());
    }

    private void Zor()
    {
        ses.PlayButtonClick();

        KAYIT.SetOyunZorluk(2);
        StartCoroutine(SahneyeGit());


    }

    private void Normal()
    {
        ses.PlayButtonClick();

        KAYIT.SetOyunZorluk(1);
        StartCoroutine(SahneyeGit());


    }

    private void Suresiz()
    {
        ses.PlayButtonClick();
        KAYIT.SetOyunZorluk(0);
        StartCoroutine(SahneyeGit());
    }

    private void Tanimlamalar()
    {
        ses = FindObjectOfType<SesKutusuUI>();
       anim = GetComponent<Animator>();
      
    }

    IEnumerator SahneyeGit()
    {
        FindObjectOfType<SahnelerArasiGecis>().SetCikis();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Menu");
    }
    IEnumerator GeriGit()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }

    public void SetActive()
    {
        gameObject.SetActive(true);
    }
}
