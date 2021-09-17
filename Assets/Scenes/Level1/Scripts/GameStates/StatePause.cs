using UnityEngine;
using System.Collections;

namespace Level1
{
    public class StatePause : GameState
    {
        public override void Init()
        {
            running = false;
        }

        public override void Do()
        {
            if (!running)
                running = Viewer.Instance.showMenuPause();
            else
            {

            }
        }
    }
}

