using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGameObjectSize : MonoBehaviour
{
    [SerializeField] float size;
    [SerializeField] bool isCanvas;

    void Awake()
    {
        if (isCanvas)
        {
            Fonksiyon.SetGameObjectSizeForTablet(GetComponent<CanvasScaler>(), size);
        }
        else
        {
            Fonksiyon.SetGameObjectSizeForTablet(gameObject, size);

        }
    }


    public void SesYildiz()
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.yildizlar);
    }
  
}
