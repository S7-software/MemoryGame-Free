using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sayfalar : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites;
    [SerializeField] List<Image> images;

    public void SetSayfa(int hangi)
    {
        Image _image = images[hangi - 1];
        _image.sprite = sprites[hangi];
        foreach (Image image in images)
        {
            if (_image.name==image.name)
            {
                continue;
            }
            image.sprite = sprites[0];
        }
    }
}
