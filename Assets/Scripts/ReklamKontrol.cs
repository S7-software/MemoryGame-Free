using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ReklamKontrol : MonoBehaviour
{
    #region Degisktenler
    public static ReklamKontrol secenekler;
    const string REKLAM_GOSTERILDI = "reklam gösterildi";
    string gameId = "4078909";

   bool testMode = true;
    private string reklamId = "gecis";


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


    public void ReklamiGoster()
    {
        if (Advertisement.IsReady() && Goster())
        {
            Advertisement.Show(reklamId);
            SetReklamSonrasiOyunBasliyor(true);

        }
    }


    //              Gösterilecek Aralık
    bool Goster()
    {
        if (!PlayerPrefs.HasKey("GosterilecekAralik"))
        {
            PlayerPrefs.SetInt("GosterilecekAralik", 5);
            return false;
        }
        int sayi = PlayerPrefs.GetInt("GosterilecekAralik");
        if (sayi == 1)
        {
            PlayerPrefs.SetInt("GosterilecekAralik", Random.Range(2, 4));
            return true;
        }
        else
        {
            sayi--;
            PlayerPrefs.SetInt("GosterilecekAralik", sayi);
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
