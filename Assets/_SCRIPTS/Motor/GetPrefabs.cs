using UnityEngine;
using System.Collections;

public class GetPrefabs : MonoBehaviour
{
    public static GameObject UyariKutusu(HangiUyariKutusu hangiUyariKutusu)
    {
        return Resources.Load<GameObject>("Prefabs/" + hangiUyariKutusu.ToString());
    }
}
