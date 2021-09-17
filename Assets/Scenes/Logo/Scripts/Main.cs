using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace Logo
{
    public class Main : MonoBehaviour
    {

        private static Main _instance;
        public static Main Instance => _instance;

        private bool showedScreen = false;
        private bool hidedScreen = false;
        private bool hidedLogo = false;
        private bool showedTextDirectedBy = false;
        private bool hidedTextDirectedBy = false;
        private bool hidedSound = false;


        private bool showedTextDescription = false;
        private bool hidedTextDescription = false;

        private bool hidedTextWinterIsComing = false;

        private float currentTimeShowLogo = 0;
        private float timeShowLogo = 5;

        private float currentTimeShowText;
        private float currentTimeShowTextDescription;
        private float TimeShowText = 3.5f;
        private float TimeShowTextDescription = 5f;


        [SerializeField]
        private AudioClip logoSound;
        public AudioSource audioSource;

        [SerializeField]
        private TextMeshProUGUI textDiretedBy;

        [SerializeField]
        private TextMeshProUGUI textDescription;

        [SerializeField]
        private TextMeshProUGUI textWinterIsComing;

        private void Start()
        {
            _instance = this;
        }



        private void Update()
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = logoSound;
                audioSource.Play();
            }

            if(!showedScreen)
                showedScreen = Viewer.Instance.showScreen();

            if (currentTimeShowLogo >= timeShowLogo)
            {
                if (!hidedLogo && !hidedTextWinterIsComing)
                {
                    hidedLogo = Viewer.Instance.hideLogo();
                    hidedTextWinterIsComing = Viewer.Instance.hideText(textWinterIsComing);
                }
                else
                {
                    if (!showedTextDirectedBy)
                        showedTextDirectedBy = Viewer.Instance.showText(textDiretedBy);

                    if (currentTimeShowText >= TimeShowText)
                    {
                        if (!hidedTextDirectedBy)
                            hidedTextDirectedBy = Viewer.Instance.hideText(textDiretedBy);
                        else
                        {

                            if (!showedTextDescription)
                                showedTextDescription = Viewer.Instance.showText(textDescription);
                            else
                            {
                                if (currentTimeShowTextDescription >= TimeShowTextDescription)
                                {
                                    if (!hidedTextDescription)
                                        hidedTextDescription = Viewer.Instance.hideText(textDescription);
                                    else
                                    {
                                        if (!hidedSound)
                                            hidedSound = SoundManager.Instance.hideSound(audioSource);
                                        else
                                        {
                                            if (!hidedScreen)
                                                hidedScreen = Viewer.Instance.hideScreen();
                                            else
                                                UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
                                        }
                                    }
                                }
                                else
                                    currentTimeShowTextDescription += Time.deltaTime;
                            }
                        }
                    }
                    else
                        currentTimeShowText += Time.deltaTime;
                }
            }
            else
                currentTimeShowLogo += Time.deltaTime;
        }
    }
}

