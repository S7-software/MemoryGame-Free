﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ReklamKontrol : MonoBehaviour,IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    #region Degisktenler
    public static ReklamKontrol secenekler;
    const string REKLAM_GOSTERILDI = "reklam gösterildi";
    const string gosterilecekAralik = "GosterilecekAralik";

    string gameId = "4078909";

    bool testMode = true;
    bool testTelefon = false;
    private string reklamId = "gecis";
    private string reklamIdBanner = "bannerYeniMemoryGame";
    private string reklamIdOdul = "reklamOdulMemoryGameEkSure";

    
    #endregion

    #region Awake Start Update
    private void Awake()
    {
        secenekler = this;
    }


    void Start()
    {
        Advertisement.Initialize(gameId, testMode, secenekler);

    }
    #endregion


    public void ShowGecis()
    {
        if (testTelefon) return;
        if ( Goster())
        {
            Advertisement.Show(reklamId, secenekler);
            SetReklamSonrasiOyunBasliyor(true);

        }
    }
    #region Banner
    public void ShowBanner()
    {
        if (testTelefon) return;

        StartCoroutine(ShowBannerWhenInitialized());
    }

    public void CloseBanner()
    {
        if (testTelefon) return;

        Advertisement.Banner.Hide();
    }


    IEnumerator ShowBannerWhenInitialized()
    {
        Advertisement.Banner.Load(reklamIdBanner);
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        yield return new WaitForSeconds(0f);
        
        

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

    public void ShowOdul()
    {
        if (testTelefon) return;
        Advertisement.Show(reklamIdOdul,secenekler);
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

    public void OnInitializationComplete()
    {
       
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log(placementId);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }

    public void OnUnityAdsShowStart(string placementId)
    {
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {

        if (placementId != reklamIdOdul) return;
        switch (showCompletionState)
        {
            case UnityAdsShowCompletionState.SKIPPED:

                OyunYoneticisi.instance.ReklamOdulBasarisiz();
                break;
            case UnityAdsShowCompletionState.COMPLETED:
                OyunYoneticisi.instance.ReklamOdulBasarili();

                break;
            case UnityAdsShowCompletionState.UNKNOWN:

                OyunYoneticisi.instance.ReklamOdulBasarisiz();

                break;
            default:
                OyunYoneticisi.instance.ReklamOdulBasarisiz();


                break;
        }

    }

}
