using UnityEngine;
using System.Collections;


namespace MainMenu
{
    public class StateMainMenu : GameState
    {

        public override void Init()
        {
            running = false;
        }
        public override void Do()
        {
            if (!running)
            {
                Main.Instance.ButtonPlay.interactable = false;
                Main.Instance.ButtonQuit.interactable = false;
                running = Viewer.Instance.showScreen() && Viewer.Instance.hideButtonsLevels();
            }
            else
            {
                Main.Instance.ButtonPlay.interactable = true;
                Main.Instance.ButtonQuit.interactable = true;
            }

        }
    }

}
