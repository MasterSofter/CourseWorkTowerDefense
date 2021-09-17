using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

namespace Level1
{
    public class TextHeader : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI textHeader;

        public void SetText(string text)
        {
            textHeader.text = text;
        }

        public void SetColor(Color color)
        {
            textHeader.color = color;
        }
    }
}

