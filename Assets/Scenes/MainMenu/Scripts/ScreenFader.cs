using UnityEngine;
using System.Collections;

namespace MainMenu
{
    public class ScreenFader : MonoBehaviour
    {

        public enum FadeState
        {
            In = 0,
            Out = 1,
            Stop = 2,
            InEnd = 3,
            OutEnd = 4
        }

        Texture colorTexture;
        Color fadeColor = Color.black;

        [HideInInspector] public float fadeBalance;

        public FadeState fadeState;

        public float fadeSpeed;     // Скорость стремления баланса

        public float fromInDelay;    // Мнимые задержки перед началом процесса затемнение/расцветания
        public float fromOutDelay;

        private static ScreenFader _instance;
        public static ScreenFader Instatnce => _instance;

        void Start()
        {
            _instance = this;
            Texture2D nullTexture = new Texture2D(1, 1) as Texture2D;
            nullTexture.SetPixel(0, 0, Color.black);
            nullTexture.Apply();

            colorTexture = (Texture)nullTexture;

            fadeBalance = (1 + fromInDelay);

        }

        void Update()
        {

            fadeColor.a = fadeBalance;

            if (fadeBalance > (1 + fromInDelay))
            {
                fadeBalance = (1 + fromInDelay);
                fadeState = FadeState.InEnd;
            }

            if (fadeBalance < -(0 + fromOutDelay))
            {
                fadeBalance = -(0 + fromOutDelay);
                fadeState = FadeState.OutEnd;
            }


            switch (fadeState)
            {

                case FadeState.In:
                    fadeBalance += Time.deltaTime * fadeSpeed;
                    break;

                case FadeState.Out:
                    fadeBalance -= Time.deltaTime * fadeSpeed;
                    break;

                case FadeState.Stop:
                    fadeBalance -= 0;
                    break;

                case FadeState.InEnd:
                    fadeBalance = (1 + fromInDelay);
                    break;

                case FadeState.OutEnd:
                    fadeBalance = -(0 + fromOutDelay);
                    break;
            }

        }

        void OnGUI()
        {

            GUI.depth = -2;
            GUI.color = fadeColor;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), colorTexture, ScaleMode.StretchToFill, true);

        }
    }
}


