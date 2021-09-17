using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Logo
{
    public class InputManager : MonoBehaviour
    {
        private bool keyPressed = false;
        private bool hidedSound = false;
        private bool hidedScreen = false;

        void Update()
        {
            if (Input.anyKey)
                keyPressed = true;

            if (keyPressed)
            {
                if (!hidedSound)
                    hidedSound = SoundManager.Instance.hideSound(Main.Instance.audioSource);
                else
                {
                    if (!hidedScreen)
                        hidedScreen = Viewer.Instance.hideScreen();
                    else
                        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
                }
            }

        }
    }

}
