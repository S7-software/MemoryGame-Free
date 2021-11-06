using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnaMenuYoneticisi : MonoBehaviour
{
    [SerializeField] List<Button> buttonlar;
    [SerializeField] ZolukKutusu zolukKutusu;
    SesKutusuUI sesKutusu;
    [SerializeField] SahnelerArasiGecis gecisEfekti;
    // Start is called before the first frame update
    void Start()
    {
        OyunaIlkGiris();
        Tanimlamalar();
        Atamaalar();
    }

    private void OyunaIlkGiris()
    {
        if (!KAYIT.IlkGirisAnaMenu()) { return; }
        StartCoroutine(NasilOynaniriAc());

    }

    private void Atamaalar()
    {
        ButtonlaraFonksiyonAta();
        KoleksiyonButtonunuAyarla();
    }

    private void KoleksiyonButtonunuAyarla()
    {
        if (PlayerPrefs.HasKey("koleksiyonBolum1") || (PlayerPrefs.HasKey("koleksiyonBolum4")))
            buttonlar[1].interactable = true;
        else
            buttonlar[1].interactable = false;
    }

    private void ButtonlaraFonksiyonAta()
    {
        buttonlar[0].onClick.AddListener(ZorlukPenceresiniAc);
        buttonlar[1].onClick.AddListener(KoleksiyonlaraGit);
        buttonlar[2].onClick.AddListener(AyarlaraGit);
    }

    private void AyarlaraGit()
    {
        sesKutusu.PlayButtonClick();
        StartCoroutine(SahneyeGit("Ayarlar"));
    }

    private void KoleksiyonlaraGit()
    {
        sesKutusu.PlayButtonClick();

        StartCoroutine(SahneyeGit("Koleksiyon"));
    }

    private void ZorlukPenceresiniAc()
    {
        sesKutusu.PlayButtonClick();
        zolukKutusu.SetActive();
        ReklamKontrol.secenekler.ShowBanner();
    }

    private void Tanimlamalar()
    {
        sesKutusu = FindObjectOfType<SesKutusuUI>();
    }

    IEnumerator SahneyeGit(string hangiSahne)
    {
        gecisEfekti.SetCikis();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(hangiSahne);
    }
    IEnumerator NasilOynaniriAc()
    {
        yield return new WaitForSeconds(2);
        FindObjectOfType<btnNasilOynanir>().NasiOynanirYarat();

    }
}
