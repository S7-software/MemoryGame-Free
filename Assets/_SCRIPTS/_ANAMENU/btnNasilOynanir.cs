using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnNasilOynanir : MonoBehaviour
{
    [SerializeField] GameObject NasilOynanirKutusu;
    Button myButton;
    void Start()
    {
        Tanimlamalar();
        Atamalar();
    }

    private void Atamalar()
    {
        myButton.onClick.AddListener(NasiOynanirYarat);
    }
    private void Tanimlamalar()
    {
        myButton = GetComponent<Button>();
    }
    public void NasiOynanirYarat()
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.click);
        Instantiate(NasilOynanirKutusu, transform.position, Quaternion.identity);
    }

    public void SetInteractable(bool deger)
    {
        myButton.interactable = deger;
    }
}

    

