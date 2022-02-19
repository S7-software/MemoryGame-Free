using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ReklamKontrol : MonoBehaviour
{
    #region Degisktenler
    public static ReklamKontrol secenekler;
    const string REKLAM_GOSTERILDI = "reklam gösterildi";
    const string gosterilecekAralik = "GosterilecekAralik";

    string gameId = "4078909";

    bool testMode = false;
    private string reklamId = "gecis";
    private string reklamIdBanner = "bannerYeniMemoryGame";


    #endregion

    #region Awake Start Update
    private void Awake()
    {
        secenekler = this;
    }


    void Start()
    {
        Advertisement.Initialize(gameId, testMode);

    }
    #endregion


    public void ShowGecis()
    {
        if ( Goster())
        {
            Advertisement.Show(reklamId);
            SetReklamSonrasiOyunBasliyor(true);

        }
    }
    #region Banner
    public void ShowBanner()
    {
        StartCoroutine(ShowBannerWhenInitialized());
    }

    public void CloseBanner()
    {
        Advertisement.Banner.Hide();
    }


    IEnumerator ShowBannerWhenInitialized()
    {
        Advertisement.Banner.Load(reklamIdBanner);
        
            yield return new WaitForSeconds(0f);
        
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);

        Advertisement.Banner.Show(reklamIdBanner);
    }
    #endregion

    //              Gösterilecek Aralık
    bool Goster()
    {
        if (!PlayerPrefs.HasKey(gosterilecekAralik))
        {
            PlayerPrefs.SetInt(gosterilecekAralik, 10);
            return false;
        }
        int sayi = PlayerPrefs.GetInt(gosterilecekAralik);
        if (sayi == 1)
        {
            PlayerPrefs.SetInt(gosterilecekAralik, Random.Range(5, 7));
            return true;
        }
        else
        {
            sayi--;
            PlayerPrefs.SetInt(gosterilecekAralik, sayi);
            return false;
        }
    }


    #region Static Kontroller
    public static bool GetReklamSonrasiOyunBasladi()
    {
        if (!PlayerPrefs.HasKey(REKLAM_GOSTERILDI))
        {
            return false;
        }
        return PlayerPrefs.GetInt(REKLAM_GOSTERILDI) == 1 ? true : false;
    }
    public static void SetReklamSonrasiOyunBasliyor(bool dogru) { PlayerPrefs.SetInt(REKLAM_GOSTERILDI, dogru == true ? 1 : 0); }
    #endregion
}
