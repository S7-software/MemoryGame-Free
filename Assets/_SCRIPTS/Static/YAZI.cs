using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YAZI : MonoBehaviour
{

    const string BOLUM_TAMAMLANDI = "Uyarı kutusu bölüm tamamlandı";
    const string BASARISIZ = "Uyarı kutusu başarısız";
    const string SURE = "Uyarı kutusu süre";
    const string REKOR = "Uyarı kutusu rekor";

    const string AYARLAR = "Ayarlar ayarlar";
    const string DIL = "Ayarlar dil";
    const string BUTUN_AYARLARI_VE_REKORLARI_SIL = "Ayarlar bütün rekorları ve ayarlari sil";
    const string BUTUN_AYARLAR_VE_REKORLAR_SIL = "Ayarlar bütün rekorlar ve ayarlar sil";
    const string UYARI = "Uyari";

   

    const string HAKKIMIZDA = "Ayarlar hakkımızda";
    const string ANA_MENU = "Ayarlar ana menü";
    const string SIL = "Ayarlar sil";

    const string BOLUMLAR = "UI bölümler";
    const string OYUNDAN_CIKMAK_ISTEDIGINIZE_EMNIN_MISINIZ = "UI Oyundan çıkmak istediğinize emin misiniz?";

    const string ZAMAN_SINIRLAMASI_YOK = "Mod zaman sınırlaması yok";
    const string BES_SANIYE_SURE_VE = "Mod dört saniye süre ve";
    const string YIRMI_SANIYE_SURE_VE = "Mod yirmi saniye süre ve";
    const string SURESIZ = "Mod süresiz";
    const string NORMAL = "Mod normal";
    const string ZOR = "Mod zor";

    const string NASIL_OYNANIR = "Text nasıl oynanır";
    const string ANLADIM = "Text Anladim";
    const string SECILEN = "Dil Seçilen";

    const string HAKKIMIZDA_Aciklama = "Text hakkımızda açıklama";
    const string GIZLILIK_POLITIKASI = "Text gizlilik politikası";

    const string KOLEKSIYON_BULUNDU = "koleksiyon bulundu";

    const string AGACKAKAN = "ağaçkakan";
    const string ASLAN = "aslan";
    const string AT = "at";
    const string AYI = "ayı";
    const string BAYKUS = "baykuş";
    const string BOGA = "boğa";
    const string CAKAL = "çakal";
    const string CITA = "çita";
    const string DEVE = "deve";
    const string DEVEKUSU = "devekuşu";
    const string FARE = "fare";
    const string FIL = "fil";
    const string GERGEDAN = "gergedan";
    const string GEYIK = "geyik";
    const string HOROZ = "horoz";
    const string KANGURU = "kanguru";
    const string KAPLAN = "kaplan";
    const string KAPLUMBAGA = "kaplumbağa";
    const string KIRPI = "kirpi";
    const string KOALA = "koala";
    const string KOC = "koç";
    const string KOKARCA = "kokarca";
    const string KOPEK = "köpek";
    const string KOYUN = "koyun";
    const string KURT = "kurt";
    const string KUS = "kuş";
    const string LEOPAR = "leopar";
    const string ORDEK = "ördek";
    const string PANDA = "panda";
    const string PANTER = "panter";
    const string PELIKAN = "pelikan";
    const string RAKUN = "rakun";
    const string SAHIN = "şahin";
    const string SIRTLAN = "sırtlan";
    const string SUAYGIRI = "suaygırı";
    const string SU_KAPLUMBAGASI = "su kaplumbağası";
    const string SUMUKLUBOCEK = "sümüklü böcek";
    const string TAVSAN = "tavşan";
    const string TAVUK = "tavuk";
    const string TILKI = "tilki";
    const string TIMSAH = "timsah";
    const string YABAN_ORDEGI = "yaban ördeği";
    const string YILAN = "yilan";
    const string ZEBRA = "zebra";
    const string KARTAL = "kartal";

    static void HayvanDilleriAta(string dil)
    {
        switch (dil)
        {
            case "tr":
                PlayerPrefs.SetString(ASLAN, "ASLAN");
                PlayerPrefs.SetString(AGACKAKAN, "AĞAÇKAKAN");
                PlayerPrefs.SetString(AT, "AT");
                PlayerPrefs.SetString(AYI, "AYI");
                PlayerPrefs.SetString(BAYKUS, "BAYKUŞ");
                PlayerPrefs.SetString(BOGA, "BOĞA");
                PlayerPrefs.SetString(CAKAL, "ÇAKAL");
                PlayerPrefs.SetString(CITA, "ÇİTA");
                PlayerPrefs.SetString(DEVE, "DEVE");
                PlayerPrefs.SetString(DEVEKUSU, "DEVE KUŞU");
                PlayerPrefs.SetString(FARE, "FARE");
                PlayerPrefs.SetString(FIL, "FİL");
                PlayerPrefs.SetString(GERGEDAN, "GERGEDAN");
                PlayerPrefs.SetString(GEYIK, "GEYİK");
                PlayerPrefs.SetString(HOROZ, "HOROZ");
                PlayerPrefs.SetString(KAPLAN, "KAPLAN");
                PlayerPrefs.SetString(KOC, "KOÇ");
                PlayerPrefs.SetString(KOPEK, "KÖPEK");
                PlayerPrefs.SetString(KOYUN, "KOYUN");
                PlayerPrefs.SetString(KURT, "KURT");
                PlayerPrefs.SetString(KUS, "KUŞ");
                PlayerPrefs.SetString(LEOPAR, "LEOPAR");
                PlayerPrefs.SetString(ORDEK, "ÖRDEK");
                PlayerPrefs.SetString(PANTER, "PANTER");
                PlayerPrefs.SetString(PELIKAN, "PELİKAN");
                PlayerPrefs.SetString(RAKUN, "RAKUN");
                PlayerPrefs.SetString(SAHIN, "ŞAHİN");
                PlayerPrefs.SetString(SIRTLAN, "SIRTLAN");
                PlayerPrefs.SetString(SUAYGIRI, "SU AYGIRI");
                PlayerPrefs.SetString(TILKI, "TİLKİ");
                PlayerPrefs.SetString(TIMSAH, "TİMSAH");
                PlayerPrefs.SetString(YABAN_ORDEGI, "YABAN ÖRDEĞİ");
                PlayerPrefs.SetString(YILAN, "YILAN");
                PlayerPrefs.SetString(ZEBRA, "ZEBRA");
                PlayerPrefs.SetString(KARTAL, "KARTAL");
                PlayerPrefs.SetString(TAVUK, "TAVUK");
                break;
                
            case "fr":
                PlayerPrefs.SetString(ASLAN, "LION");
                PlayerPrefs.SetString(AGACKAKAN, "PIVERT");
                PlayerPrefs.SetString(AT, "CHEVAL");
                PlayerPrefs.SetString(AYI, "OURS");
                PlayerPrefs.SetString(BAYKUS, "CHOUETTE");
                PlayerPrefs.SetString(BOGA, "TAUREAU");
                PlayerPrefs.SetString(CAKAL, "COQ");
                PlayerPrefs.SetString(CITA, "GUÉPARD");
                PlayerPrefs.SetString(DEVE, "CHAMEAU");
                PlayerPrefs.SetString(DEVEKUSU, "AUTRUCHE");
                PlayerPrefs.SetString(FARE, "SOURIS");
                PlayerPrefs.SetString(FIL, "L'ÉLÉPHANT");
                PlayerPrefs.SetString(GERGEDAN, "RHINOCÉROS");
                PlayerPrefs.SetString(GEYIK, "CERF");
                PlayerPrefs.SetString(HOROZ, "COQ");
                PlayerPrefs.SetString(KAPLAN, "TIGRE");
                PlayerPrefs.SetString(KOC, "RAM");
                PlayerPrefs.SetString(KOPEK, "CHIEN");
                PlayerPrefs.SetString(KOYUN, "MOUTON");
                PlayerPrefs.SetString(KURT, "LOUP");
                PlayerPrefs.SetString(KUS, "OISEAU");
                PlayerPrefs.SetString(LEOPAR, "LÉOPARD");
                PlayerPrefs.SetString(ORDEK, "CANARD");
                PlayerPrefs.SetString(PANTER, "PANTHÈRE");
                PlayerPrefs.SetString(PELIKAN, "PÉLICAN");
                PlayerPrefs.SetString(RAKUN, "RATON LAVEUR");
                PlayerPrefs.SetString(SAHIN, "FAUCON");
                PlayerPrefs.SetString(SIRTLAN, "HYÈNE");
                PlayerPrefs.SetString(SUAYGIRI, "HIPPOPOTAME");
                PlayerPrefs.SetString(TILKI, "RENARD");
                PlayerPrefs.SetString(TIMSAH, "CROCODILE");
                PlayerPrefs.SetString(YABAN_ORDEGI, "CANARD SAUVAGE");
                PlayerPrefs.SetString(YILAN, "SERPENT");
                PlayerPrefs.SetString(ZEBRA, "ZÈBRE");
                PlayerPrefs.SetString(KARTAL, "AIGLE");
                PlayerPrefs.SetString(TAVUK, "POULET");
                break;
                
            case "jp":
                PlayerPrefs.SetString(ASLAN, "ライオン");
                PlayerPrefs.SetString(AGACKAKAN, "キツツキ");
                PlayerPrefs.SetString(AT, "うま");
                PlayerPrefs.SetString(AYI, "くま");
                PlayerPrefs.SetString(BAYKUS, "フクロウ");
                PlayerPrefs.SetString(BOGA, "ブル");
                PlayerPrefs.SetString(CAKAL, "コヨーテ");
                PlayerPrefs.SetString(CITA, "チーター");
                PlayerPrefs.SetString(DEVE, "キャメル");
                PlayerPrefs.SetString(DEVEKUSU, "ダチョウ");
                PlayerPrefs.SetString(FARE, "マウス");
                PlayerPrefs.SetString(FIL, "象");
                PlayerPrefs.SetString(GERGEDAN, "サイ");
                PlayerPrefs.SetString(GEYIK, "鹿");
                PlayerPrefs.SetString(HOROZ, "オンドリ");
                PlayerPrefs.SetString(KAPLAN, "虎");
                PlayerPrefs.SetString(KOC, "羊");
                PlayerPrefs.SetString(KOPEK, "犬");
                PlayerPrefs.SetString(KOYUN, "羊");
                PlayerPrefs.SetString(KURT, "狼");
                PlayerPrefs.SetString(KUS, "鳥");
                PlayerPrefs.SetString(LEOPAR, "ヒョウ");
                PlayerPrefs.SetString(ORDEK, "アヒル");
                PlayerPrefs.SetString(PANTER, "パンサー");
                PlayerPrefs.SetString(PELIKAN, "ペリカン");
                PlayerPrefs.SetString(RAKUN, "ラクーン");
                PlayerPrefs.SetString(SAHIN, "鷹");
                PlayerPrefs.SetString(SIRTLAN, "ハイエナ");
                PlayerPrefs.SetString(SUAYGIRI, "カバ");
                PlayerPrefs.SetString(TILKI, "狐");
                PlayerPrefs.SetString(TIMSAH, "クロコダイル");
                PlayerPrefs.SetString(YABAN_ORDEGI, "鴨");
                PlayerPrefs.SetString(YILAN, "ヘビ");
                PlayerPrefs.SetString(ZEBRA, "シマウマ");
                PlayerPrefs.SetString(KARTAL, "鷲");
                PlayerPrefs.SetString(TAVUK, "チキン");
                break;
            case "pl":
                PlayerPrefs.SetString(ASLAN, "LEW");
                PlayerPrefs.SetString(AGACKAKAN, "DZIĘCIOŁ");
                PlayerPrefs.SetString(AT, "KOŃ");
                PlayerPrefs.SetString(AYI, "NIEDŹWIEDŹ");
                PlayerPrefs.SetString(BAYKUS, "SOWA");
                PlayerPrefs.SetString(BOGA, "BYK");
                PlayerPrefs.SetString(CAKAL, "KOJOT");
                PlayerPrefs.SetString(CITA, "GEPARD");
                PlayerPrefs.SetString(DEVE, "WIELBŁĄD");
                PlayerPrefs.SetString(DEVEKUSU, "STRUŚ");
                PlayerPrefs.SetString(FARE, "MYSZ");
                PlayerPrefs.SetString(FIL, "SŁOŃ");
                PlayerPrefs.SetString(GERGEDAN, "NOSOROŻEC");
                PlayerPrefs.SetString(GEYIK, "JELEŃ");
                PlayerPrefs.SetString(HOROZ, "KOGUT");
                PlayerPrefs.SetString(KAPLAN, "TYGRYS");
                PlayerPrefs.SetString(KOC, "BARAN");
                PlayerPrefs.SetString(KOPEK, "PIES");
                PlayerPrefs.SetString(KOYUN, "OWCA");
                PlayerPrefs.SetString(KURT, "WILK");
                PlayerPrefs.SetString(KUS, "PTAK");
                PlayerPrefs.SetString(LEOPAR, "LAMPART");
                PlayerPrefs.SetString(ORDEK, "KACZKA");
                PlayerPrefs.SetString(PANTER, "PANTERA");
                PlayerPrefs.SetString(PELIKAN, "PELIKAN");
                PlayerPrefs.SetString(RAKUN, "SZOP PRACZ");
                PlayerPrefs.SetString(SAHIN, "JASTRZĄB");
                PlayerPrefs.SetString(SIRTLAN, "HIENA");
                PlayerPrefs.SetString(SUAYGIRI, "HIPOPOTAM");
                PlayerPrefs.SetString(TILKI, "LIS");
                PlayerPrefs.SetString(TIMSAH, "KROKODYL");
                PlayerPrefs.SetString(YABAN_ORDEGI, "DZIKA KACZKA");
                PlayerPrefs.SetString(YILAN, "WĄŻ");
                PlayerPrefs.SetString(ZEBRA, "ZEBRA");
                PlayerPrefs.SetString(KARTAL, "ORZEŁ");
                PlayerPrefs.SetString(TAVUK, "KURCZAK");
                break;
                
                /*
            case "es":
                PlayerPrefs.SetString(ASLAN, "ASLAN");
                PlayerPrefs.SetString(AGACKAKAN, "AĞAÇKAKAN");
                PlayerPrefs.SetString(AT, "AT");
                PlayerPrefs.SetString(AYI, "AYI");
                PlayerPrefs.SetString(BAYKUS, "BAYKUŞ");
                PlayerPrefs.SetString(BOGA, "BOĞA");
                PlayerPrefs.SetString(CAKAL, "ÇAKAL");
                PlayerPrefs.SetString(CITA, "ÇİTA");
                PlayerPrefs.SetString(DEVE, "DEVE");
                PlayerPrefs.SetString(DEVEKUSU, "DEVE KUŞU");
                PlayerPrefs.SetString(FARE, "FARE");
                PlayerPrefs.SetString(FIL, "FİL");
                PlayerPrefs.SetString(GERGEDAN, "GERGEDAN");
                PlayerPrefs.SetString(GEYIK, "GEYİK");
                PlayerPrefs.SetString(HOROZ, "HOROZ");
                PlayerPrefs.SetString(KAPLAN, "KAPLAN");
                PlayerPrefs.SetString(KOC, "KOÇ");
                PlayerPrefs.SetString(KOPEK, "KÖPEK");
                PlayerPrefs.SetString(KOYUN, "KOYUN");
                PlayerPrefs.SetString(KURT, "KURT");
                PlayerPrefs.SetString(KUS, "KUŞ");
                PlayerPrefs.SetString(LEOPAR, "LEOPAR");
                PlayerPrefs.SetString(ORDEK, "ÖRDEK");
                PlayerPrefs.SetString(PANTER, "PANTER");
                PlayerPrefs.SetString(PELIKAN, "PELİKAN");
                PlayerPrefs.SetString(RAKUN, "RAKUN");
                PlayerPrefs.SetString(SAHIN, "ŞAHİN");
                PlayerPrefs.SetString(SIRTLAN, "SIRTLAN");
                PlayerPrefs.SetString(SUAYGIRI, "SU AYGIRI");
                PlayerPrefs.SetString(TILKI, "TİLKİ");
                PlayerPrefs.SetString(TIMSAH, "TİMSAH");
                PlayerPrefs.SetString(YABAN_ORDEGI, "YABAN ÖRDEĞİ");
                PlayerPrefs.SetString(YILAN, "YILAN");
                PlayerPrefs.SetString(ZEBRA, "ZEBRA");
                PlayerPrefs.SetString(KARTAL, "KARTAL");
                PlayerPrefs.SetString(TAVUK, "TAVUK");
                break;
                */
            case "ru":
                PlayerPrefs.SetString(ASLAN, "Лев");
                PlayerPrefs.SetString(AGACKAKAN, "ДЯТЕЛ");
                PlayerPrefs.SetString(AT, "ЛОШАДЬ");
                PlayerPrefs.SetString(AYI, "МЕДВЕДЬ");
                PlayerPrefs.SetString(BAYKUS, "СОВА");
                PlayerPrefs.SetString(BOGA, "БЫК");
                PlayerPrefs.SetString(CAKAL, "ШАКАЛ");
                PlayerPrefs.SetString(CITA, "ЧИТА");
                PlayerPrefs.SetString(DEVE, "CAMEL");
                PlayerPrefs.SetString(DEVEKUSU, "СТРАУС");
                PlayerPrefs.SetString(FARE, "МЫШЬ");
                PlayerPrefs.SetString(FIL, "СЛОН");
                PlayerPrefs.SetString(GERGEDAN, "НОСОРОГ");
                PlayerPrefs.SetString(GEYIK, "ОЛЕНЬ");
                PlayerPrefs.SetString(HOROZ, "ПЕТУХ");
                PlayerPrefs.SetString(KAPLAN, "ТИГР");
                PlayerPrefs.SetString(KOC, "баран");
                PlayerPrefs.SetString(KOPEK, "СОБАКА");
                PlayerPrefs.SetString(KOYUN, "ОВЦА");
                PlayerPrefs.SetString(KURT, "ВОЛК");
                PlayerPrefs.SetString(KUS, "ПТИЦА");
                PlayerPrefs.SetString(LEOPAR, "ЛЕОПАРД");
                PlayerPrefs.SetString(ORDEK, "УТКА");
                PlayerPrefs.SetString(PANTER, "ПАНТЕРА");
                PlayerPrefs.SetString(PELIKAN, "ПЕЛИКАН");
                PlayerPrefs.SetString(RAKUN, "ЕНОТ");
                PlayerPrefs.SetString(SAHIN, "ЯСТРЕБ");
                PlayerPrefs.SetString(SIRTLAN, "ГИЕНА");
                PlayerPrefs.SetString(SUAYGIRI, "БЕГЕМОТ");
                PlayerPrefs.SetString(TILKI, "ЛИСА");
                PlayerPrefs.SetString(TIMSAH, "КРОКОДИЛ");
                PlayerPrefs.SetString(YABAN_ORDEGI, "ДИКАЯ УТКА");
                PlayerPrefs.SetString(YILAN, "ЗМЕЯ");
                PlayerPrefs.SetString(ZEBRA, "ЗЕБРА");
                PlayerPrefs.SetString(KARTAL, "ОРЕЛ");
                PlayerPrefs.SetString(TAVUK, "КУРИЦА");
                break;
               
            case "de":
                PlayerPrefs.SetString(ASLAN, "LÖWE");
                PlayerPrefs.SetString(AGACKAKAN, "SPECHT");
                PlayerPrefs.SetString(AT, "PFERD");
                PlayerPrefs.SetString(AYI, "AYI");
                PlayerPrefs.SetString(BAYKUS, "EULE");
                PlayerPrefs.SetString(BOGA, "STIER");
                PlayerPrefs.SetString(CAKAL, "KOJOTE");
                PlayerPrefs.SetString(CITA, "GEPARD");
                PlayerPrefs.SetString(DEVE, "KAMEL");
                PlayerPrefs.SetString(DEVEKUSU, "STRAUSS");
                PlayerPrefs.SetString(FARE, "MAUS");
                PlayerPrefs.SetString(FIL, "ELEFANT");
                PlayerPrefs.SetString(GERGEDAN, "NASHORN");
                PlayerPrefs.SetString(GEYIK, "HIRSCH");
                PlayerPrefs.SetString(HOROZ, "GOCKEL");
                PlayerPrefs.SetString(KAPLAN, "TIGER");
                PlayerPrefs.SetString(KOC, "RAM");
                PlayerPrefs.SetString(KOPEK, "HUND");
                PlayerPrefs.SetString(KOYUN, "SCHAF");
                PlayerPrefs.SetString(KURT, "WÖLFIN");
                PlayerPrefs.SetString(KUS, "VOGEL");
                PlayerPrefs.SetString(LEOPAR, "LEOPARD");
                PlayerPrefs.SetString(ORDEK, "ENTE");
                PlayerPrefs.SetString(PANTER, "PANTHER");
                PlayerPrefs.SetString(PELIKAN, "PELIKAN");
                PlayerPrefs.SetString(RAKUN, "WASCHBÄR");
                PlayerPrefs.SetString(SAHIN, "FALKE");
                PlayerPrefs.SetString(SIRTLAN, "HYÄNE");
                PlayerPrefs.SetString(SUAYGIRI, "NILPFERD");
                PlayerPrefs.SetString(TILKI, "FUCHS");
                PlayerPrefs.SetString(TIMSAH, "KROKODIL");
                PlayerPrefs.SetString(YABAN_ORDEGI, "WILDE ENTE");
                PlayerPrefs.SetString(YILAN, "SCHLANGE");
                PlayerPrefs.SetString(ZEBRA, "ZEBRA");
                PlayerPrefs.SetString(KARTAL, "ADLER");
                PlayerPrefs.SetString(TAVUK, "HÄHNCHEN");
                break;

              
            default:
                PlayerPrefs.SetString(ASLAN, "LION");
                PlayerPrefs.SetString(AGACKAKAN, "WOODPECKER");
                PlayerPrefs.SetString(AT, "AT");
                PlayerPrefs.SetString(AYI, "HORSE");
                PlayerPrefs.SetString(BAYKUS, "OWL");
                PlayerPrefs.SetString(BOGA, "BULL");
                PlayerPrefs.SetString(CAKAL, "COYOTE");
                PlayerPrefs.SetString(CITA, "CHEETAH");
                PlayerPrefs.SetString(DEVE, "CAMEL");
                PlayerPrefs.SetString(DEVEKUSU, "OSTRICH");
                PlayerPrefs.SetString(FARE, "MOUSE");
                PlayerPrefs.SetString(FIL, "ELEPHANT");
                PlayerPrefs.SetString(GERGEDAN, "RHINO");
                PlayerPrefs.SetString(GEYIK, "DEER");
                PlayerPrefs.SetString(HOROZ, "ROOSTER");
                PlayerPrefs.SetString(KAPLAN, "TIGER");
                PlayerPrefs.SetString(KOC, "RAM");
                PlayerPrefs.SetString(KOPEK, "DOG");
                PlayerPrefs.SetString(KOYUN, "SHEEP");
                PlayerPrefs.SetString(KURT, "WOLF");
                PlayerPrefs.SetString(KUS, "BIRD");
                PlayerPrefs.SetString(LEOPAR, "LEOPARD");
                PlayerPrefs.SetString(ORDEK, "DUCK");
                PlayerPrefs.SetString(PANTER, "PANTHER");
                PlayerPrefs.SetString(PELIKAN, "PELICAN");
                PlayerPrefs.SetString(RAKUN, "RACCOON");
                PlayerPrefs.SetString(SAHIN, "HAWK");
                PlayerPrefs.SetString(SIRTLAN, "HYENA");
                PlayerPrefs.SetString(SUAYGIRI, "HIPPO");
                PlayerPrefs.SetString(TILKI, "FOX");
                PlayerPrefs.SetString(TIMSAH, "CROCODILE");
                PlayerPrefs.SetString(YABAN_ORDEGI, "WILD DUCK");
                PlayerPrefs.SetString(YILAN, "SNAKE");
                PlayerPrefs.SetString(ZEBRA, "ZEBRA");
                PlayerPrefs.SetString(KARTAL, "EAGLE");
                PlayerPrefs.SetString(TAVUK, "CHICKEN");
                break;
        }
    }


    public static string GetHayvanAdi(string spriteName)
    {
        switch (spriteName)
        {
            case "Aslan2":
            case "aslan":
            case "Aslan": return PlayerPrefs.GetString(ASLAN);
            case "agackakan":
            case "agac kakan 2":
            case "AgacKakan": return PlayerPrefs.GetString(AGACKAKAN);
            case "At2":
            case "at":
            case "At": return PlayerPrefs.GetString(AT);
            case "BozAyi":
            case "Ayi":
            case "Ayi2": return PlayerPrefs.GetString(AYI);
            case "Baykus3":
            case "Baykus":
            case "Baykus4":
            case "BayKus2": return PlayerPrefs.GetString(BAYKUS);
            case "Boga":
            case "Boga2": return PlayerPrefs.GetString(BOGA);
            case "Cakal": return PlayerPrefs.GetString(CAKAL);
            case "Cita": return PlayerPrefs.GetString(CITA);
            case "Deve": return PlayerPrefs.GetString(DEVE);
            case "Fil":
            case "Fil2": return PlayerPrefs.GetString(FIL);
            case "Gergedan":
            case "Gergedan3":
            case "Gergedan4":
            case "Gergedan2": return PlayerPrefs.GetString(GERGEDAN);
            case "Geyik":
            case "Geyik3":
            case "Geyik2": return PlayerPrefs.GetString(GEYIK);
            case "Horoz": return PlayerPrefs.GetString(HOROZ);
            case "kaplan 2":
            case "Kaplan": return PlayerPrefs.GetString(KAPLAN);
            case "kartal":
            case "kartal2": return PlayerPrefs.GetString(KARTAL);
            case "Kopek":
            case "kopek":
            case "Kopek2": return PlayerPrefs.GetString(KOPEK);
            case "Koyun": return PlayerPrefs.GetString(KOYUN);
            case "Kurt": return PlayerPrefs.GetString(KURT);
            case "Kus":
            case "kus normal":
            case "Kus4":
            case "Kus3":
            case "Kus5":
            case "Kus2": return PlayerPrefs.GetString(KUS);
            case "Leopar": return PlayerPrefs.GetString(LEOPAR);
            case "Fare": return PlayerPrefs.GetString(FARE);
            case "Ordek":
            case "Ordek2":
            case "ordek 3":
            case "Ordek3": return PlayerPrefs.GetString(ORDEK);
            case "YabanOrdegi": return PlayerPrefs.GetString(YABAN_ORDEGI);
            case "Sahin": return PlayerPrefs.GetString(SAHIN);
            case "Yilan":
            case "snake":
            case "Yilan2":
            case "Yilan3": return PlayerPrefs.GetString(YILAN);
            case "SuAygiri": return PlayerPrefs.GetString(SUAYGIRI);
            case "Tavuk": return PlayerPrefs.GetString(TAVUK);



            default:
                return PlayerPrefs.GetString(ASLAN);

        }
    }
    public static NamesOfSound GetHayvanAdiEnum(string spriteName)
    {
        switch (spriteName)
        {
            case "Aslan2":
            case "aslan":
            case "Aslan": return NamesOfSound.aslan;
            case "agackakan":
            case "agac kakan 2":
            case "AgacKakan": return NamesOfSound.agacKakan1;
            case "At2":
            case "at":
            case "At": return NamesOfSound.at;
            case "BozAyi":
            case "Ayi":
            case "Ayi2": return NamesOfSound.ayi;
            case "Baykus3":
            case "Baykus":
            case "Baykus4":
            case "BayKus2": return NamesOfSound.baykus;
            case "Boga":
            case "Boga2": return NamesOfSound.boga;
            case "Cakal": return NamesOfSound.cakal;
            case "Cita": return NamesOfSound.cita;
            case "Deve": return NamesOfSound.deve;
            case "Fil":
            case "Fil2": return NamesOfSound.fil;
            case "Gergedan":
            case "Gergedan3":
            case "Gergedan4":
            case "Gergedan2": return NamesOfSound.gergedan;
            case "Geyik":
            case "Geyik3":
            case "Geyik2": return NamesOfSound.geyik;
            case "Horoz": return NamesOfSound.horoz;
            case "kaplan 2":
            case "Kaplan": return NamesOfSound.kaplan1;
            case "kartal":
            case "kartal2": return NamesOfSound.kartal;
            case "Kopek":
            case "kopek": return NamesOfSound.kopek;
            case "Kopek2": return NamesOfSound.kopekKucuk;
            case "Koyun": return NamesOfSound.koyun;
            case "Kurt": return NamesOfSound.kurt;
            case "Kus":
            case "kus normal":
            case "Kus4":
            case "Kus3":
            case "Kus5":
            case "Kus2": return NamesOfSound.kus1;
            case "Leopar": return NamesOfSound.leopar;
            case "Fare": return NamesOfSound.mouse;
            case "Ordek":
            case "Ordek2":
            case "ordek 3":
            case "Ordek3": return NamesOfSound.ordek3;
            case "YabanOrdegi": return NamesOfSound.ordek3;
            case "Sahin": return NamesOfSound.sahin;
            case "Yilan":
            case "snake":
            case "Yilan2":
            case "Yilan3": return NamesOfSound.snake;
            case "SuAygiri": return NamesOfSound.suAygiri;
            case "Tavuk": return NamesOfSound.tavuk;



            default:
                return NamesOfSound.bayrakKaldir;

        }
    }

    public static void DiliAyarla(string dil)
    {
        HayvanDilleriAta(dil);
        switch (dil)
        {
            case "tr":
                PlayerPrefs.SetString(BASARISIZ, "TEKRAR DENE!");
                PlayerPrefs.SetString(BOLUM_TAMAMLANDI, "BÖLÜM TAMAMLANDI!");
                PlayerPrefs.SetString(REKOR, "*Rekor!");
                PlayerPrefs.SetString(SURE, "Süre:");

                PlayerPrefs.SetString(AYARLAR, "AYARLAR");
                PlayerPrefs.SetString(ANA_MENU, "ANA MENÜ");
                PlayerPrefs.SetString(BUTUN_AYARLARI_VE_REKORLARI_SIL, "Bütün Ayarları ve Rekorları Sil");
                PlayerPrefs.SetString(BUTUN_AYARLAR_VE_REKORLAR_SIL, "Bütün ayarlar ve rekorlar silinecek. Silmek istediğinizden emin misiniz?");
                PlayerPrefs.SetString(DIL, "DİL");
                PlayerPrefs.SetString(HAKKIMIZDA, "HAKKIMIZDA");
                PlayerPrefs.SetString(SIL, "SİL");
                PlayerPrefs.SetString(UYARI, "UYARI!");

                PlayerPrefs.SetString(BOLUMLAR, "BÖLÜMLER");
                PlayerPrefs.SetString(OYUNDAN_CIKMAK_ISTEDIGINIZE_EMNIN_MISINIZ, "Oyundan çıkmak istediğinize emin misiniz?");

                PlayerPrefs.SetString(SURESIZ, "SÜRESİZ");
                PlayerPrefs.SetString(NORMAL, "NORMAL");
                PlayerPrefs.SetString(ZOR, "ZOR");
                PlayerPrefs.SetString(ZAMAN_SINIRLAMASI_YOK, "Zaman sınırlaması yok.");
                PlayerPrefs.SetString(BES_SANIYE_SURE_VE, "5 saniye süre ve her bulunan çift kart için +5 saniye süre.");
                PlayerPrefs.SetString(YIRMI_SANIYE_SURE_VE, "30 saniye süre ve her bulunan çift kart için +5 saniye süre.");


                PlayerPrefs.SetString(ANLADIM, "ANLADIM");
                PlayerPrefs.SetString(NASIL_OYNANIR, "NASIL OYNANIR?");

                PlayerPrefs.SetString(HAKKIMIZDA_Aciklama, "Memory Game S7-SOFTWARE markası adı altında yayınlanmıştır.");
                PlayerPrefs.SetString(GIZLILIK_POLITIKASI, "Gizlilik Politikası");

                PlayerPrefs.SetString(KOLEKSIYON_BULUNDU, "KOLEKSİYON BULUNDU!");

                PlayerPrefs.SetString(SECILEN, dil);
                break;

            case "fr":
                PlayerPrefs.SetString(BASARISIZ, "ESSAYEZ ENCORE !");
                PlayerPrefs.SetString(BOLUM_TAMAMLANDI, "PARTIE TERMINÉE !");
                PlayerPrefs.SetString(REKOR, "*Record !");
                PlayerPrefs.SetString(SURE, "Heure :");

                PlayerPrefs.SetString(AYARLAR, "RÉGLAGES");
                PlayerPrefs.SetString(ANA_MENU, "MENU PRINCIPAL");
                PlayerPrefs.SetString(BUTUN_AYARLARI_VE_REKORLARI_SIL, "Effacez tous les paramètres et enregistrements ");
                PlayerPrefs.SetString(BUTUN_AYARLAR_VE_REKORLAR_SIL, "Tous les paramètres et enregistrements seront définitivement supprimés. Êtes-vous sûr de vouloir les supprimer ?");
                PlayerPrefs.SetString(DIL, "LANGUE");
                PlayerPrefs.SetString(HAKKIMIZDA, "À PROPOS DE NOUS");
                PlayerPrefs.SetString(SIL, "SUPPRIMER");
                PlayerPrefs.SetString(UYARI, "ATTENTION !");

                PlayerPrefs.SetString(BOLUMLAR, "SECTIONS");
                PlayerPrefs.SetString(OYUNDAN_CIKMAK_ISTEDIGINIZE_EMNIN_MISINIZ, "Vous êtes sûr de vouloir quitter le jeu ?");

                PlayerPrefs.SetString(SURESIZ, "INDÉFINIE");
                PlayerPrefs.SetString(NORMAL, "NORMAL");
                PlayerPrefs.SetString(ZOR, "DIFFICILE");
                PlayerPrefs.SetString(ZAMAN_SINIRLAMASI_YOK, "Il n'y a pas de limite de temps.");
                PlayerPrefs.SetString(BES_SANIYE_SURE_VE, "5 secondes et +5 secondes pour chaque paire trouvée.");
                PlayerPrefs.SetString(YIRMI_SANIYE_SURE_VE, "30 secondes et +5 secondes pour chaque paire trouvée.");


                PlayerPrefs.SetString(ANLADIM, "JE COMPRENDS");
                PlayerPrefs.SetString(NASIL_OYNANIR, "COMMENT JOUER ?");

                PlayerPrefs.SetString(HAKKIMIZDA_Aciklama, "Memory Game a été publié sous la marque S7-SOFTWARE.");
                PlayerPrefs.SetString(GIZLILIK_POLITIKASI, "Politique de confidentialité");

                PlayerPrefs.SetString(KOLEKSIYON_BULUNDU, "COLLECTION TROUVÉE !");

                PlayerPrefs.SetString(SECILEN, dil);
                break;
            
            case "ru":
                PlayerPrefs.SetString(BASARISIZ, "ПОПРОБУЙ СНОВА!");
                PlayerPrefs.SetString(BOLUM_TAMAMLANDI, "ЗАДАЧА ЗАВЕРШЕНА!");
                PlayerPrefs.SetString(REKOR, "*Рекорд!");
                PlayerPrefs.SetString(SURE, "Время:");

                PlayerPrefs.SetString(AYARLAR, "НАСТРОЙКИ");
                PlayerPrefs.SetString(ANA_MENU, "ГЛАВНОЕ МЕНЮ");
                PlayerPrefs.SetString(BUTUN_AYARLARI_VE_REKORLARI_SIL, "Сбросить все настройки и рекорды");
                PlayerPrefs.SetString(BUTUN_AYARLAR_VE_REKORLAR_SIL, "Все настройки и записи будут удалены без возможности восстановления. Вы уверены, что хотите удалить?");
                PlayerPrefs.SetString(DIL, "ЯЗЫК");
                PlayerPrefs.SetString(HAKKIMIZDA, "О НАС");
                PlayerPrefs.SetString(SIL, "УДАЛИТЬ");
                PlayerPrefs.SetString(UYARI, "ПРЕДУПРЕЖДЕНИЕ!");

                PlayerPrefs.SetString(BOLUMLAR, "РАЗДЕЛЫ");
                PlayerPrefs.SetString(OYUNDAN_CIKMAK_ISTEDIGINIZE_EMNIN_MISINIZ, "Уверены, что хотите выйти из игры");

                PlayerPrefs.SetString(SURESIZ, "БЕЗ ВРЕМЕНИ");
                PlayerPrefs.SetString(NORMAL, "НОРМАЛЬНЫЙ");
                PlayerPrefs.SetString(ZOR, "ТЯЖЁЛЫЙ");
                PlayerPrefs.SetString(ZAMAN_SINIRLAMASI_YOK, "Безлимитное время.");
                PlayerPrefs.SetString(BES_SANIYE_SURE_VE, "5 секунд и +5 секунд для каждой найденной пары.");
                PlayerPrefs.SetString(YIRMI_SANIYE_SURE_VE, "30 секунд и +5 секунд для каждой найденной пары.");


                PlayerPrefs.SetString(ANLADIM, "ПОНЯЛ(А)");
                PlayerPrefs.SetString(NASIL_OYNANIR, "ПРАВИЛА ИГРЫ?");

                PlayerPrefs.SetString(HAKKIMIZDA_Aciklama, "Memory Game выпущена Под Маркой S7-SOFTWARE ");
                PlayerPrefs.SetString(GIZLILIK_POLITIKASI, "Политика Конфиденциальности");

                PlayerPrefs.SetString(KOLEKSIYON_BULUNDU, "НАЙДЕНА КОЛЛЕКЦИЯ!");

                PlayerPrefs.SetString(SECILEN, dil);




                PlayerPrefs.SetString(SECILEN, dil); break;

            /*
        case "es":

            PlayerPrefs.SetString(SECILEN, dil); break;
             */
            case "de":
                PlayerPrefs.SetString(BASARISIZ, "VERSUCHE NOCHMAL!");
                PlayerPrefs.SetString(BOLUM_TAMAMLANDI, "AUFGABE ERLEDIGT!");
                PlayerPrefs.SetString(REKOR, "*Rekord!");
                PlayerPrefs.SetString(SURE, "Zeit:");

                PlayerPrefs.SetString(AYARLAR, "EINSTELLUNGEN");
                PlayerPrefs.SetString(ANA_MENU, "HAUPTMENÜ");
                PlayerPrefs.SetString(BUTUN_AYARLARI_VE_REKORLARI_SIL, "Alle Einstellungen und Daten zurücksetzen!");
                PlayerPrefs.SetString(BUTUN_AYARLAR_VE_REKORLAR_SIL, "Alle Einstellungen und Daten werden dauerhaft gelöscht. Sind Sie sicher dass Sie das löschen möchten?");
                PlayerPrefs.SetString(DIL, "SPRACHE");
                PlayerPrefs.SetString(HAKKIMIZDA, "ÜBER UNS");
                PlayerPrefs.SetString(SIL, "LÖSCHEN");
                PlayerPrefs.SetString(UYARI, "WARNUNG!");

                PlayerPrefs.SetString(BOLUMLAR, "ABSCHNITTE");
                PlayerPrefs.SetString(OYUNDAN_CIKMAK_ISTEDIGINIZE_EMNIN_MISINIZ, "Sind Sie sicher dass Sie das Spiel beenden möchten?");

                PlayerPrefs.SetString(SURESIZ, "UNBESTIMMT");
                PlayerPrefs.SetString(NORMAL, "NORMAL");
                PlayerPrefs.SetString(ZOR, "KOMPLIZIERT");
                PlayerPrefs.SetString(ZAMAN_SINIRLAMASI_YOK, "Unbegrenzte Zeit");
                PlayerPrefs.SetString(BES_SANIYE_SURE_VE, "5 Sekunden und +5 Sekunden für jedes gefundene Paar");
                PlayerPrefs.SetString(YIRMI_SANIYE_SURE_VE, "30 Sekunden und +5 Sekunden für jedes gefundene Paar.");


                PlayerPrefs.SetString(ANLADIM, "VERSTADEN");
                PlayerPrefs.SetString(NASIL_OYNANIR, "SPIELREGELN");

                PlayerPrefs.SetString(HAKKIMIZDA_Aciklama, "Memory Game ist unter der Marke S7-SOFTWARE hergestellt. ");
                PlayerPrefs.SetString(GIZLILIK_POLITIKASI, "Datenschutzerklärung");

                PlayerPrefs.SetString(KOLEKSIYON_BULUNDU, "SAMMLUNG GEFUNDEN!");
                PlayerPrefs.SetString(SECILEN, dil); break; 


            case "jp":
                PlayerPrefs.SetString(BASARISIZ, "再試行！");
                PlayerPrefs.SetString(BOLUM_TAMAMLANDI, "タスクが完了しました！");
                PlayerPrefs.SetString(REKOR, "*記録!");
                PlayerPrefs.SetString(SURE, "時間：");

                PlayerPrefs.SetString(AYARLAR, "設定");
                PlayerPrefs.SetString(ANA_MENU, "メインメニュー");
                PlayerPrefs.SetString(BUTUN_AYARLARI_VE_REKORLARI_SIL, "すべての設定とレコードを消去する！");
                PlayerPrefs.SetString(BUTUN_AYARLAR_VE_REKORLAR_SIL, "すべての設定とレコードは完全に削除されます。 削除してもよろしいですか？");
                PlayerPrefs.SetString(DIL, "言語");
                PlayerPrefs.SetString(HAKKIMIZDA, "私たちについて");
                PlayerPrefs.SetString(SIL, "削除");
                PlayerPrefs.SetString(UYARI, "警告！");

                PlayerPrefs.SetString(BOLUMLAR, "セクション");
                PlayerPrefs.SetString(OYUNDAN_CIKMAK_ISTEDIGINIZE_EMNIN_MISINIZ, "ゲームを終了してもよろしいですか？");

                PlayerPrefs.SetString(SURESIZ, "不定");
                PlayerPrefs.SetString(NORMAL, "標準");
                PlayerPrefs.SetString(ZOR, "ハード");
                PlayerPrefs.SetString(ZAMAN_SINIRLAMASI_YOK, "時間制限はありません。");
                PlayerPrefs.SetString(BES_SANIYE_SURE_VE, "見つかったペアごとに5秒と+5秒。");
                PlayerPrefs.SetString(YIRMI_SANIYE_SURE_VE, "見つかったペアごとに30秒と+5秒。");


                PlayerPrefs.SetString(ANLADIM, "了解");
                PlayerPrefs.SetString(NASIL_OYNANIR, "遊び方");

                PlayerPrefs.SetString(HAKKIMIZDA_Aciklama, "「メモリーゲーム」はS7-SOFTWAREのブランド名で公開されています。");
                PlayerPrefs.SetString(GIZLILIK_POLITIKASI, "個人情報保護方");

                PlayerPrefs.SetString(KOLEKSIYON_BULUNDU, "コレクションが見つかりました！");

                PlayerPrefs.SetString(SECILEN, dil); break;

            case "pl":
                PlayerPrefs.SetString(BASARISIZ, "SPRÓBUJ PONOWNIE!");
                PlayerPrefs.SetString(BOLUM_TAMAMLANDI, "ZADANIE ZAKOŃCZONE!");
                PlayerPrefs.SetString(REKOR, "*Rekord !");
                PlayerPrefs.SetString(SURE, "Czas:");

                PlayerPrefs.SetString(AYARLAR, "USTAWIENIA");
                PlayerPrefs.SetString(ANA_MENU, "MENU GŁÓWNE");
                PlayerPrefs.SetString(BUTUN_AYARLARI_VE_REKORLARI_SIL, "Zresetuj wszytkie ustawienia i zapisy");
                PlayerPrefs.SetString(BUTUN_AYARLAR_VE_REKORLAR_SIL, "Wszytkie ustawienia nagrywania zostana trwale usuniete. Czy jestes pewien, że chcesz usunać?");
                PlayerPrefs.SetString(DIL, "JĘZYK");
                PlayerPrefs.SetString(HAKKIMIZDA, "O NAS");
                PlayerPrefs.SetString(SIL, "USUNĄĆ");
                PlayerPrefs.SetString(UYARI, "OSTRZEŻENIE");

                PlayerPrefs.SetString(BOLUMLAR, "SEKCJE");
                PlayerPrefs.SetString(OYUNDAN_CIKMAK_ISTEDIGINIZE_EMNIN_MISINIZ, "Koniecznie wyjsc z gry?");

                PlayerPrefs.SetString(SURESIZ, "NIEPEWNY");
                PlayerPrefs.SetString(NORMAL, "NORMAL");
                PlayerPrefs.SetString(ZOR, "CIĘŻKI");
                PlayerPrefs.SetString(ZAMAN_SINIRLAMASI_YOK, "ZNieograniczony czas.");
                PlayerPrefs.SetString(BES_SANIYE_SURE_VE, "5 sekund i + 5 sekund dla kazdej znalezionej pary");
                PlayerPrefs.SetString(YIRMI_SANIYE_SURE_VE, "30 sekund i + 5 sekund dla kazdej znalezionej pary");


                PlayerPrefs.SetString(ANLADIM, "WSZYTKO JASNE");
                PlayerPrefs.SetString(NASIL_OYNANIR, "ZASADY GRY?");

                PlayerPrefs.SetString(HAKKIMIZDA_Aciklama, "Memory Game wydany pod marka S7-SOFTWARE");
                PlayerPrefs.SetString(GIZLILIK_POLITIKASI, "Polityka prywatnosci");

                PlayerPrefs.SetString(KOLEKSIYON_BULUNDU, "ZNALEZIENA ZBIÓRKA");

                PlayerPrefs.SetString(SECILEN, dil); break;
               
            //ingilizce
            default:
                PlayerPrefs.SetString(BASARISIZ, "TRY AGAIN!");
                PlayerPrefs.SetString(BOLUM_TAMAMLANDI, "PART COMPLETED!");
                PlayerPrefs.SetString(REKOR, "*Record!");
                PlayerPrefs.SetString(SURE, "Time:");

                PlayerPrefs.SetString(AYARLAR, "SETTINGS");
                PlayerPrefs.SetString(ANA_MENU, "MAIN MENU");
                PlayerPrefs.SetString(BUTUN_AYARLARI_VE_REKORLARI_SIL, "Erase All Settings and Records");
                PlayerPrefs.SetString(BUTUN_AYARLAR_VE_REKORLAR_SIL, "All settings and records will be permanently deleted. Are you sure you want to delete it?");
                PlayerPrefs.SetString(DIL, "LANGUAGE");
                PlayerPrefs.SetString(HAKKIMIZDA, "ABOUT US");
                PlayerPrefs.SetString(SIL, "DELETE");
                PlayerPrefs.SetString(UYARI, "WARNING!");

                PlayerPrefs.SetString(BOLUMLAR, "SECTIONS");
                PlayerPrefs.SetString(OYUNDAN_CIKMAK_ISTEDIGINIZE_EMNIN_MISINIZ, "Are you sure you want to quit the game?");

                PlayerPrefs.SetString(SURESIZ, "INDEFINITE");
                PlayerPrefs.SetString(NORMAL, "NORMAL");
                PlayerPrefs.SetString(ZOR, "HARD");
                PlayerPrefs.SetString(ZAMAN_SINIRLAMASI_YOK, "There is no time limit.");
                PlayerPrefs.SetString(BES_SANIYE_SURE_VE, "5 seconds and +5 seconds for each pair found.");
                PlayerPrefs.SetString(YIRMI_SANIYE_SURE_VE, "30 seconds and +5 seconds for each pair found.");


                PlayerPrefs.SetString(ANLADIM, "I UNDERSTAND");
                PlayerPrefs.SetString(NASIL_OYNANIR, "HOW TO PLAY?");

                PlayerPrefs.SetString(HAKKIMIZDA_Aciklama, "Memory Game has been published under the brand name S7-SOFTWARE.");
                PlayerPrefs.SetString(GIZLILIK_POLITIKASI, "Privacy Policy");

                PlayerPrefs.SetString(KOLEKSIYON_BULUNDU, "COLLECTION FOUND!");





                PlayerPrefs.SetString(SECILEN, "en"); break;

        }
    }

    public static string Uyari()    { return PlayerPrefs.GetString(UYARI);    }
    public static string KoleksiyonBulundu() { return PlayerPrefs.GetString(KOLEKSIYON_BULUNDU); }
    public static string HakkimizdaAciklama() { return PlayerPrefs.GetString(HAKKIMIZDA_Aciklama); }
    public static string GizlilikPolitikasi() { return PlayerPrefs.GetString(GIZLILIK_POLITIKASI); }
    public static string Anladim() { return PlayerPrefs.GetString(ANLADIM); }
    public static string NasilOynanir() { return PlayerPrefs.GetString(NASIL_OYNANIR); }

    public static string Normal() { return PlayerPrefs.GetString(NORMAL); }

    public static string Zor() { return PlayerPrefs.GetString(ZOR); }

    public static string Suresiz() { return PlayerPrefs.GetString(SURESIZ); }

    public static string ZamanSinirlamasiYok() { return PlayerPrefs.GetString(ZAMAN_SINIRLAMASI_YOK); }

    public static string BesSaniyeSureVe() { return PlayerPrefs.GetString(BES_SANIYE_SURE_VE); }

    public static string YirmiSaniyeSureVe() { return PlayerPrefs.GetString(YIRMI_SANIYE_SURE_VE); }

    public static string Basarisiz() { return PlayerPrefs.GetString(BASARISIZ); }

    public static string BolumTamamlandi() { return PlayerPrefs.GetString(BOLUM_TAMAMLANDI); }

    public static string Rekor() { return PlayerPrefs.GetString(REKOR); }

    public static string Sure() { return PlayerPrefs.GetString(SURE); }

    public static string Ayarlar() { return PlayerPrefs.GetString(AYARLAR); }

    public static string AnaMenu() { return PlayerPrefs.GetString(ANA_MENU); }

    public static string ButunRekorlariVeAyarlariSil() { return PlayerPrefs.GetString(BUTUN_AYARLARI_VE_REKORLARI_SIL); }
    public static string ButunRekorlarVeAyarlarSilinecek() { return PlayerPrefs.GetString(BUTUN_AYARLAR_VE_REKORLAR_SIL); }

    public static string Dil() { return PlayerPrefs.GetString(DIL); }

    public static string Hakkimizda() { return PlayerPrefs.GetString(HAKKIMIZDA); }

    public static string Sil() { return PlayerPrefs.GetString(SIL); }

    public static string Bolumler() { return PlayerPrefs.GetString(BOLUMLAR); }

    public static string OyundanCikmakIstediginizeEminMisiniz() { return PlayerPrefs.GetString(OYUNDAN_CIKMAK_ISTEDIGINIZE_EMNIN_MISINIZ); }


    public static string GetDilSecilen()
    {
        if (!PlayerPrefs.HasKey(SECILEN))
        {
            PlayerPrefs.SetString(SECILEN, "en");
            return "en";
        }
        return PlayerPrefs.GetString(SECILEN);
    }



}
