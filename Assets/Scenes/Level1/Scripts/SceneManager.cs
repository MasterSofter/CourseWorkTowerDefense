using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Level1
{
    public class SceneManager : MonoBehaviour
    {
        private static SceneManager _instance;
        public static SceneManager Instance => _instance;

        private bool running = false;

        private void Start()
        {
            _instance = this;

        }

        public void moveToStateRunningGame()
        {
            Main.Instance.MoveToState<StateRunningGame>();
        }

        public void moveToStatePause()
        {
            Main.Instance.MoveToState<StatePause>();
        }

        public void loadMainMenuScene()
        {
            Main.Instance.MoveToState<StateReturnMenu>();
        }

        public void loadLevel()
        {
            Main.Instance.MoveToState<StateLoadLevel>();
        }

    }
}
