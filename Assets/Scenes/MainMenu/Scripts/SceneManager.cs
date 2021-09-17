using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace MainMenu
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

        public void loadLevel1()
        {
            Main.Instance.MoveToState<StateLoadLevel>();
        }

        public void moveToStateQuit()
        {
            Main.Instance.MoveToState<StateQuit>();
        }

        public void moveToStateMainMenu()
        {
            Main.Instance.MoveToState<StateMainMenu>();
        }

    }
}

