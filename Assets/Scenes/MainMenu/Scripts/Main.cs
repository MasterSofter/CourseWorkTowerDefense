using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

/****************************************************
 *  Базовый класс, в нем реализуется машина состояний
 *  и переход между сценами.
 * *************************************************/
namespace MainMenu
{
    public class Main : MonoBehaviour
    {

        private static Main _instance;
        public static Main Instance => _instance;
        private GameState _currentState;
        private List<GameState> _states = new List<GameState>();

        public Button ButtonPlay;
        public Button ButtonQuit;



        protected void AddState(GameState gameState)
        {
            _states.Add(gameState);
        }
        public void MoveToState<T>() where T : GameState
        {
            _currentState.running = false;
            _currentState = _states.Find(i => i is T);
        }


        void Start()
        {
            _instance = this;
            _states.Add(new StateMainMenu());
            _states.Add(new StateQuit());
            _states.Add(new StateLoadLevel());

            foreach (GameState it in _states)
                it.Init();

            _currentState = _states[0];

        }

        void Update()
        {
            if (_currentState != null)
                _currentState.Do();
        }
    }
}

