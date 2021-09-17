using UnityEngine;
using System.Collections;

namespace MainMenu
{
    public class InputManager : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                SceneManager.Instance.moveToStateMainMenu();
        }
    }
}

