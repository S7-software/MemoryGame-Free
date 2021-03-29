using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnCikis : MonoBehaviour
{
    Saat saat;
    SesKutusuUI sesKutusu;

    public GameObject canvasPause;
    // Start is called before the first frame update
    void Start()
    {
        saat = FindObjectOfType<Saat>();
        sesKutusu = FindObjectOfType<SesKutusuUI>();

    }

    public void CikisButtonu()
    {
        sesKutusu.PlayButtonClick();

        //  Instantiate(canvasPause, , Quaternion.identity);
        canvasPause.SetActive(true);
        saat.OyunDuraklat();

    }
}
