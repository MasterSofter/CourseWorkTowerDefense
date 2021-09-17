using UnityEngine;
using System.Collections;

namespace MainMenu
{
    public class StateLoadLevel : GameState
    {

        public override void Init()
        {
            running = false;
            Main.Instance.ButtonPlay.interactable = false;
            Main.Instance.ButtonQuit.interactable = false;
        }
        public override void Do()
        {
            if (!running)
                running = Viewer.Instance.hideScreen();
            else
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        }
    }

}
