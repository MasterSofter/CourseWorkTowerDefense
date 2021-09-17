using UnityEngine;
using System.Collections;

namespace Level1
{
    public class Sprite : MonoBehaviour
    {
        void Update()
        {
            float cameraHeight = Camera.main.scaledPixelHeight / 1.5f; ;
            float cameraWidth = cameraHeight * Screen.width / Screen.height; // cameraHeight * aspect ratio

            gameObject.transform.localScale = Vector3.one * cameraHeight / 415f;
        }
    }
}
