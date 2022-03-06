using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnCikis : MonoBehaviour
{
    Saat saat;

    public GameObject canvasPause;
    // Start is called before the first frame update
    void Start()
    {
        saat = FindObjectOfType<Saat>();

    }

    public void CikisButtonu()
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.click);


        //  Instantiate(canvasPause, , Quaternion.identity);
        canvasPause.SetActive(true);
        saat.OyunDuraklat();
        ReklamKontrol.secenekler.ShowBanner();

    }
}
