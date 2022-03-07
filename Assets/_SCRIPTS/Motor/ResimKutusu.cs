using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResimKutusu : MonoBehaviour
{
    public Sprite[] hayvanResimleri;
    List<Sprite> _bolumIcinHayvanlar= new List<Sprite>();
    List<Sprite> _butunHayvanlar = new List<Sprite>();
    int _hangiBolum;




   public void Tanimlamalar(int kacKartVar,int hangiBolum)
    {
        _hangiBolum = hangiBolum-1;
        ButunHayvanlariAta();
        BolumIcinHayvanSec(kacKartVar/2);
    }

    private void BolumIcinHayvanSec(int kacTane)
    {
        int x = 1;
        int y = 0;
        _bolumIcinHayvanlar.Add(_butunHayvanlar[_hangiBolum]);
        _bolumIcinHayvanlar.Add(_butunHayvanlar[_hangiBolum]);
        _butunHayvanlar.RemoveAt(_hangiBolum);
        while (x<kacTane)
        {
            y = UnityEngine.Random.Range(0, _butunHayvanlar.Count);
            _bolumIcinHayvanlar.Add(_butunHayvanlar[y]);
            _bolumIcinHayvanlar.Add(_butunHayvanlar[y]);
            _butunHayvanlar.RemoveAt(y);
            x++;
        }
    }

    public Sprite RasgeleResimVer()
    {
        Sprite _sprite = _bolumIcinHayvanlar[UnityEngine.Random.Range(0, _bolumIcinHayvanlar.Count)];
        _bolumIcinHayvanlar.Remove(_sprite);
        return _sprite;
    }

    private void ButunHayvanlariAta()
    {
        foreach (Sprite hayvan in hayvanResimleri)
        {
            _butunHayvanlar.Add(hayvan);
        }
    }

    public Sprite IstenilenHayvaniVer(int hangi)
    {
        try
        {
            return hayvanResimleri[hangi - 1];
        }
        catch (Exception)
        {

            return hayvanResimleri[0];
        }
        

    }
    public Sprite IstenilenHayvaniVer(string hangi)
    {
        foreach (Sprite item in hayvanResimleri)
        {
            if (item.name==hangi)
            {
              //  print(item.name);
                return item;
               
            }
        }
            return hayvanResimleri[0];
    }
}
