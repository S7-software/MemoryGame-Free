using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroGecis : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Intro());
        IlkAcilisKontrol();
    }

    private void IlkAcilisKontrol()
    {
        if (!KAYIT.GetIlkAcilisVeyaReset()) return;

        KAYIT.SetKacinciBolumNORMAL(1);
        KAYIT.SetKacinciBolumZOR(1);
        KAYIT.SetKacinciBolumSURESIZ(1);
        DiliAyarlar();


    }

    private void DiliAyarlar()
    {
        if (Application.systemLanguage == SystemLanguage.Turkish) KAYIT.SetAppDil("tr");
        else if (Application.systemLanguage == SystemLanguage.French) KAYIT.SetAppDil("fr");
        else if (Application.systemLanguage == SystemLanguage.Japanese) KAYIT.SetAppDil("jp");
        else if (Application.systemLanguage == SystemLanguage.Spanish) KAYIT.SetAppDil("es");
        else if (Application.systemLanguage == SystemLanguage.Russian) KAYIT.SetAppDil("ru");
        else if (Application.systemLanguage == SystemLanguage.German) KAYIT.SetAppDil("de");
        else if (Application.systemLanguage == SystemLanguage.Polish) KAYIT.SetAppDil("pl");
        else   KAYIT.SetAppDil("en");
    }
    IEnumerator Intro()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Ana");

    }
}
