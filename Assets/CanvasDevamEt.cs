using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasDevamEt : MonoBehaviour
{
    [SerializeField] Button _btnIptal, _btnOnay;
    Animator _anim;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        _btnIptal.onClick.AddListener(() => StartCoroutine(HandleIptal()));
        _btnOnay.onClick.AddListener(() => StartCoroutine(HandleOnay()));
    }

    IEnumerator HandleIptal()
    {
        _anim.SetBool("giris", false);
        OyunYoneticisi.instance.CanvasDevamEtIptal();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }
    IEnumerator HandleOnay()
    {
        SoundBox.instance.PlayOneShot(NamesOfSound.click);

        _anim.SetBool("giris", false);
        OyunYoneticisi.instance.CanvasDevamEtOnay();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
      
    }
}
