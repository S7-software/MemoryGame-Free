using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fonksiyon : MonoBehaviour
{
    /// <summary>
    /// Girilen int s?reyi dakika ve saniye olarak string format?nda verir. ?rnek 143 --> 02:23
    /// </summary>
    /// <param name="sure"></param>
    /// <returns></returns>
    public static string intgerToStringTime(int sure)
    {
        int _dakika = sure / 60;
        int _saniye = sure % 60;
        string _donen = "";
        if (_dakika>=10)
        {
            _donen += _dakika;
        }
        else
        {
            _donen += "0" + _dakika;
        }
        _donen += ":";
        if (_saniye >= 10) { _donen += _saniye; }
        else { _donen += "0" + _saniye; }

        return _donen;
    }

    public static void ButunAyarlariSifirla()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    public static void TextBoxlaraYazdir(List<Text> listText,string yazilacak)
    {
        foreach (Text yazi  in listText)
        {
            yazi.text = yazilacak;
        }
    }
    /// <summary>
    /// 1-Anasayfa, 2-Ayarlar, 3-Menu, 4- Koleksiyon, default Anasayfa.
    /// </summary>
    /// <param name="hangi"></param>
    public static void SahneDegistir(int hangi )
    {
        string _hangi="";
        if (hangi==1)
        {
            _hangi = "Ana";
        }
        else if (hangi == 2) { _hangi = "Ayarlar"; }
        else if (hangi == 3) { _hangi = "Menu"; }
        else if (hangi == 4) { _hangi = "Koleksiyon"; }
        else { _hangi = "Ana"; }
        switch (hangi)
        {
            
            default: SceneManager.LoadScene(_hangi); break;
        }
    }

    public static void SetGameObjectSizeForTablet(GameObject go,float boyut)
    {
        double a = System.Convert.ToDouble(Screen.height) / System.Convert.ToDouble(Screen.width);
        if (1.5f > a) go.transform.localScale = new Vector3(boyut, boyut, boyut);
        else go.transform.localScale = Vector3.one;
    }

    public static bool GetEkranTablet()
    {
        double a = System.Convert.ToDouble(Screen.height) / System.Convert.ToDouble(Screen.width);
        if (1.5f > a) return true;
        return false;
    }

}
