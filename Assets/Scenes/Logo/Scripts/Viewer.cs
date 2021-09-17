using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Logo
{
    public class Viewer : MonoBehaviour
    {
        private static Viewer _instance;
        public static Viewer Instance => _instance;
        public Image logo;

        [SerializeField]
        private TextMeshProUGUI textDiretedBy;

        [SerializeField]
        private TextMeshProUGUI textDescription;

        private int count = 0;

        void Start()
        {
            _instance = this;
            textDiretedBy.color = new Color(textDiretedBy.color.r, textDiretedBy.color.g, textDiretedBy.color.b, 0);
            textDescription.color = new Color(textDescription.color.r, textDescription.color.g, textDescription.color.b, 0);
        }






        public bool hideText(TextMeshProUGUI textMesh)
        {
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, textMesh.color.a - 0.01f);
            if (textMesh.color.a <= 0.1f)
            {
                textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);
                return true;
            }
            return false;
        }


        public bool showText(TextMeshProUGUI textMesh)
        {
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, textMesh.color.a + 0.01f);
            if (textMesh.color.a >= 0.9f)
            {
                textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 1);
                return true;
            }
            return false;
        }

        public bool hideLogo()
        {
            logo.color = new Color(logo.color.r, logo.color.g, logo.color.b, logo.color.a - 0.01f);
            if (logo.color.a <= 0.1f)
            {
                logo.color = new Color(logo.color.r, logo.color.g, logo.color.b, 0);
                return true;
            }
            return false;
        }

        public bool showScreen()
        {
            if (count == 0) { ScreenFader.Instatnce.fadeState = ScreenFader.FadeState.Out; count = 1; }
            if (ScreenFader.Instatnce.fadeState == ScreenFader.FadeState.OutEnd)
                { count = 0; return true; }
            else return false;
        }

        public bool hideScreen()
        {
            if (count == 0) { ScreenFader.Instatnce.fadeState = ScreenFader.FadeState.In; count = 1; }
            if (ScreenFader.Instatnce.fadeState == ScreenFader.FadeState.InEnd)
            { count = 0; return true; }
            else return false;

        }

    }

}


