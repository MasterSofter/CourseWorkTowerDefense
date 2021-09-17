using UnityEngine;
using System.Collections;

namespace Level1
{
    public class StateGameOver : GameState
    {
        public override void Init()
        {
            running = false;
        }
        public override void Do()
        {
            if (!running)
            {
                int code;
                if (GameManager.Instance.CurrentCountFinishedEnemies >= GameManager.Instance.CountMaxFinishedEnemies)
                    code = 0;
                else if (GameManager.Instance.BossKilled)
                    code = 1;
                else
                    code = 0;
                running = Viewer.Instance.showMenuGameOver(code);
            }
            //Подводятся итоги игры
        }
    }
}

