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
    [SerializeField] CanvasScaler canvasScaler;
    Animator anim;
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
    #region Handler Button
    private void Geri()
    {
 
        SoundBox.instance.PlayOneShot(NamesOfSound.clickGeri1);

        anim.SetTrigger("geri");
        StartCoroutine(GeriGit());
        ReklamKontrol.secenekler.CloseBanner();
    }
   
    private void Zor()
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.click);
        KAYIT.SetOyunZorluk(2);
        StartCoroutine(SahneyeGit());
        ReklamKontrol.secenekler.CloseBanner();
    }

    private void Normal()
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.click);

        KAYIT.SetOyunZorluk(1);
        StartCoroutine(SahneyeGit());
        ReklamKontrol.secenekler.CloseBanner();
    }

    private void Suresiz()
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.click);
        KAYIT.SetOyunZorluk(0);
        StartCoroutine(SahneyeGit());
        ReklamKontrol.secenekler.CloseBanner();
    }
    #endregion



    private void Tanimlamalar()
    {
       anim = GetComponent<Animator>();

      
        Fonksiyon.SetGameObjectSizeForTablet(canvasScaler, 1100);
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
