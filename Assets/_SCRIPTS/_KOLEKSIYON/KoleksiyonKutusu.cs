using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoleksiyonKutusu : MonoBehaviour
{
    List<int> koleksiyonBolumler =
        new List<int> { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34, 37, 40, 43, 46, 49, 52, 55, 58, 61, 64, 67, 70, 73, 76 };

    public bool GetKoleksiyonVarMi(int hangi)
    {
       return koleksiyonBolumler.Contains(hangi);
    }
}
