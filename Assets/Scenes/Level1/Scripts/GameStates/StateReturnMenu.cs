using UnityEngine;
using System.Collections;

namespace Level1
{
    public class StateReturnMenu : GameState
    {
        public override void Init()
        {
            running = false;
        }
        public override void Do()
        {
            if (!running)
                running = Viewer.Instance.hideScreen();
            else
                UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
    }
}