using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Level1
{
    public class StateLoadLevel : GameState
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
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");

        }
    }

}
