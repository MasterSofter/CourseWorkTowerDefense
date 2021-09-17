using UnityEngine;
using System.Collections;


namespace MainMenu
{
    public class StateQuit : GameState
    {
        public override void Do()
        {
            if (!running)
            {
                Main.Instance.ButtonPlay.interactable = false;
                Main.Instance.ButtonQuit.interactable = false;
                running = Viewer.Instance.closeDoors() && Viewer.Instance.hideScreen();
            }

            else
            {
                Application.Quit();    // закрыть приложение
            }
               
        }
    }
}

