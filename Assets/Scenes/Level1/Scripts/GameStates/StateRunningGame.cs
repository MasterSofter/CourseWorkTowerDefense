using UnityEngine;
using System.Collections;


namespace Level1
{
    public class StateRunningGame : GameState
    {
        private Game game;
        public override void Init()
        {
            running = false;
            game = Game.Instance;

            var cells = GameObject.FindGameObjectsWithTag("Cell");
            foreach (GameObject it in cells)
                it.GetComponent<SpriteRenderer>().enabled = false;

        }
        public override void Do()
        {
            if (!running)
                running = Viewer.Instance.showScreen() && Viewer.Instance.hideMenuPause();
            else
            {
                Game.Instance.Do();
                if (Game.Instance.CurrentNumbWave > Game.Instance.CountWaves || (GameManager.Instance.CurrentCountFinishedEnemies >= GameManager.Instance.CountMaxFinishedEnemies))
                    Main.Instance.MoveToState<StateGameOver>();
            }
        }
    }
}

