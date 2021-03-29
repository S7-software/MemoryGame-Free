using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KAYIT : MonoBehaviour
{
    const string OYUN_ZORLUK = "oyun zorluk";
    const string KACINCI_BOLUM_ZOR = "Kaçıncı bölüm zor";
    const string KACINCI_BOLUM_NORMAL = "Kaçıncı bölüm normal";
    const string KACINCI_BOLUM_SURESIZ = "Kaçıncı bölüm süresiz";
    const string AYARLAR_SES_DERECESI = " Ayarlar ses derecesi";
    const string AYARLAR_MUZIK_DERECESI = " Ayarlar müzik derecesi";
    const string APP_ILK_ACILIS_VEYA_RESET = "ilk açılış veya reset";

    const string KOLEKSIYON_ENSONSAYFA = "koleksiyon en son sayfa";

    const string ANAMENU_ILK_GIRIS = "ana menüye ilk giriş";

    const string ANLADIM_UYARI_EKRANI = "Anladım uyarı ekranı";

    static Dictionary<int, string> KoleksiyonNormal = new Dictionary<int, string>() {
           { 1, "Aslan" },
       {7,"Fil" },
       {13,"Koyun" },
       {19,"Ordek" },
       {25,"At" },
       {31,"BozAyi" },
       {37,"Baykus3" },
       {43,"Cita" },
       {49,"Kopek2" },
       {55,"Kurt" },
       {61,"kartal2" },
       {67,"Deve" }
         };
    static Dictionary<int, string> KoleksiyonZor = new Dictionary<int, string>() {
         {4,"Kopek" },
         {10,"Yilan2" },
         {16,"Tavuk" },
         {22,"Boga2" },
         {28,"Horoz" },
         {34,"AgacKakan" },
         {40,"SuAygiri" },
         {46,"Geyik2" },
         {52,"Kaplan" },
         {58,"Sahin" },
         {64,"Leopar" },
         {70,"Kus3" }
         };

    public static bool GetAnladimDahaOncedenAcildi()
    {
        if (PlayerPrefs.HasKey(ANLADIM_UYARI_EKRANI))
        {
            return PlayerPrefs.GetInt(ANLADIM_UYARI_EKRANI) == 1 ? true : false;
        }
        return false;
    }

    public static void SetAnladimDahaOncedenAcildi(int boolDeger) 
    {
        if (boolDeger==1)
        {
            PlayerPrefs.SetInt(ANLADIM_UYARI_EKRANI, boolDeger);
        }
        else
        {
            PlayerPrefs.SetInt(ANLADIM_UYARI_EKRANI, 0);

        }
    }
    public static List<int> GetKoleksiyonSayilarini()
    {
        List<int> _sayilar = new List<int>();
        foreach (var item in KoleksiyonNormal)
        {
            _sayilar.Add(item.Key);
        }
        foreach (var item in KoleksiyonZor)
        {
            _sayilar.Add(item.Key);
        }
        _sayilar.Sort();
        return _sayilar;

    }
    public static bool IlkGirisAnaMenu()
    {
        if (!PlayerPrefs.HasKey(ANAMENU_ILK_GIRIS))
        {
            PlayerPrefs.SetInt(ANAMENU_ILK_GIRIS, 1);
            return true;
        }

        return false;
    }

    public static void SetKoleksiyonuKaydet(int hangiBolum)
    {
        PlayerPrefs.SetString("koleksiyonBolum" + hangiBolum, "var");
    }

    public static bool GetBuBolumdeKoleksiyonVar(int hangi)
    {
        if (PlayerPrefs.HasKey("koleksiyonBolum" + hangi))
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// Eğer girilen key yok ise string "yok" döndürür
    /// </summary>
    /// <returns></returns>
    public static string GetKoleksiyonAdiNORMAL(int key)
    {
        try
        {
            return KoleksiyonNormal[key];
        }
        catch (System.Exception)
        {

            return "yok";
        }
    }
    /// <summary>
    /// Eğer girilen key yok ise string "yok" döndürür
    /// </summary>
    /// <returns></returns>
    public static string GetKoleksiyonAdiZOR(int key)
    {
        try
        {
            return KoleksiyonZor[key];
        }
        catch (System.Exception)
        {

            return "yok";
        }
    }
    public static void SetEnSonSayfaKoleksiyon(int sayfa)
    {
        if (sayfa >= 0 && sayfa <= 6)
        {
            PlayerPrefs.SetInt(KOLEKSIYON_ENSONSAYFA, sayfa);
        }

    }
    public static int GetEnSonSayfaKoleksiyon()
    {
        if (!PlayerPrefs.HasKey(KOLEKSIYON_ENSONSAYFA))
        {
            PlayerPrefs.SetInt(KOLEKSIYON_ENSONSAYFA, 1);
        }
        return PlayerPrefs.GetInt(KOLEKSIYON_ENSONSAYFA);
    }

    public static void SetAppDil(string dil) { YAZI.DiliAyarla(dil); }


    public static string GetDilSecilen() { return YAZI.GetDilSecilen(); }


    public static void SetMenuKacinciSayfadaKaldi(int zoluk, int sayfa)
    {
        PlayerPrefs.SetInt("zorluk" + zoluk + "sayfa numarasi", sayfa);
    }
    public static int GetMenuKacinciSayfadaKaldi(int zoluk)
    {
        int _index = PlayerPrefs.GetInt("zorluk" + zoluk + "sayfa numarasi");
        return _index == 0 ? 1 : _index;
    }



    public static bool GetIlkAcilisVeyaReset()
    {
        if (!PlayerPrefs.HasKey(APP_ILK_ACILIS_VEYA_RESET))
        {
            PlayerPrefs.SetInt(APP_ILK_ACILIS_VEYA_RESET, 1);
            return true;
        }

        return false;
    }

    public static void SetAyarlarSesDerecesi(float derece)
    {
        if (derece >= 0f && derece <= 1f)
        {
            PlayerPrefs.SetFloat(AYARLAR_SES_DERECESI, derece);

        }
    }

    public static void SetAyarlarMuziksDerecesi(float derece)
    {
        if (derece >= 0f && derece <= 1f)
        {
            PlayerPrefs.SetFloat(AYARLAR_MUZIK_DERECESI, derece);
        }
    }
    public static float GetAyarlarSesDerecesi()
    {

        if (PlayerPrefs.HasKey(AYARLAR_SES_DERECESI))
        {
            return PlayerPrefs.GetFloat(AYARLAR_SES_DERECESI);
        }
        PlayerPrefs.SetFloat(AYARLAR_SES_DERECESI, 1f);
        return 1f;
    }
    public static float GetAyarlarMuzikDerecesi()
    {
        if (PlayerPrefs.HasKey(AYARLAR_MUZIK_DERECESI))
        {
            return PlayerPrefs.GetFloat(AYARLAR_MUZIK_DERECESI);
        }
        PlayerPrefs.SetFloat(AYARLAR_MUZIK_DERECESI, 0.6f);
        return 0.6f;
    }


    public static void SetRekorSure(int zorluk, int bolum, int sure)
    {
        string _key = "zorluk" + zorluk + "bolum" + bolum;

        if (PlayerPrefs.HasKey(_key))
        {
            if (PlayerPrefs.GetInt(_key) > sure)
            {
                PlayerPrefs.SetInt(_key, sure);
            }
        }
        else
        {
            PlayerPrefs.SetInt(_key, sure);
        }
    }
    public static int GetRekorSure(int zorluk, int bolum)
    {
        if (!PlayerPrefs.HasKey("zorluk" + zorluk + "bolum" + bolum))
        {
            return 0;
        }
        return PlayerPrefs.GetInt("zorluk" + zorluk + "bolum" + bolum);
    }
    public static void SetRekorYildiz(int zorluk, int bolum, int yildiz)
    {
        string _key = "zorluk" + zorluk + "bolum" + bolum + "yildiz";

        if (PlayerPrefs.HasKey(_key))
        {
            if (PlayerPrefs.GetInt(_key) < yildiz)
            {
                PlayerPrefs.SetInt(_key, yildiz);
            }
        }
        else
        {
            PlayerPrefs.SetInt(_key, yildiz);
        }
    }
    public static int GetRekorYildiz(int zorluk, int bolum)
    {
        if (!PlayerPrefs.HasKey("zorluk" + zorluk + "bolum" + bolum + "yildiz"))
        {
            return 0;
        }
        return PlayerPrefs.GetInt("zorluk" + zorluk + "bolum" + bolum + "yildiz");
    }





    public static void SetKacinciBolumZOR(int hangiBolum)
    {
        if (hangiBolum > GetKacinciBolumZOR())
        {
            PlayerPrefs.SetInt(KACINCI_BOLUM_ZOR, hangiBolum);
        }

    }
    public static void SetKacinciBolumNORMAL(int hangiBolum)
    {
        if (hangiBolum > GetKacinciBolumNORMAL())
        {
            PlayerPrefs.SetInt(KACINCI_BOLUM_NORMAL, hangiBolum);
        }

    }
    public static void SetKacinciBolumSURESIZ(int hangiBolum)
    {
        if (hangiBolum > GetKacinciBolumSURESIZ())
        {
            PlayerPrefs.SetInt(KACINCI_BOLUM_SURESIZ, hangiBolum);
        }

    }

    public static int GetKacinciBolumZOR()
    {
        if (PlayerPrefs.HasKey(KACINCI_BOLUM_ZOR))
        {
            return PlayerPrefs.GetInt(KACINCI_BOLUM_ZOR);
        }
        else
        {
            PlayerPrefs.SetInt(KACINCI_BOLUM_ZOR, 1);

            return 1;
        }

    }
    public static int GetKacinciBolumNORMAL()
    {
        if (PlayerPrefs.HasKey(KACINCI_BOLUM_NORMAL))
        {
            return PlayerPrefs.GetInt(KACINCI_BOLUM_NORMAL);
        }
        else
        {
            PlayerPrefs.SetInt(KACINCI_BOLUM_NORMAL, 1);

            return 1;
        }

    }
    public static int GetKacinciBolumSURESIZ()
    {
        if (PlayerPrefs.HasKey(KACINCI_BOLUM_SURESIZ))
        {
            return PlayerPrefs.GetInt(KACINCI_BOLUM_SURESIZ);
        }
        else
        {
            PlayerPrefs.SetInt(KACINCI_BOLUM_SURESIZ, 1);

            return 1;
        }

    }

    /// <summary>
    /// 0- süresiz,
    /// 1- normal   (20 saniye),
    /// 2- zor      (4 saniye)
    /// </summary>
    /// <returns></returns>

    public static int GetOyunZorluk()
    {
        if (PlayerPrefs.HasKey(OYUN_ZORLUK))
        {
            return PlayerPrefs.GetInt(OYUN_ZORLUK);
        }
        PlayerPrefs.SetInt(OYUN_ZORLUK, 1);
        return PlayerPrefs.GetInt(OYUN_ZORLUK);
    }
    /// <summary>
    /// 0- süresiz,
    /// 1- normal   (30 saniye),
    /// 2- zor      (4 saniye)
    /// </summary>
    /// <returns></returns>
    public static void SetOyunZorluk(int zorluk)
    {
        PlayerPrefs.SetInt(OYUN_ZORLUK, zorluk);
    }

    /// <summary>
    /// 0- süresiz,
    /// 1- normal  
    /// 2- zor    
    /// </summary>
    /// <returns></returns>
    public static string GetToplamYildizSayisi(int zorluk)
    {
        int yildizSayisi = 0;
        int i= 1;
        while (GetRekorYildiz(zorluk, i )!=0)
        {
            yildizSayisi  +=GetRekorYildiz(zorluk, i );
            i++;
        }
        return yildizSayisi.ToString();
    }

}
