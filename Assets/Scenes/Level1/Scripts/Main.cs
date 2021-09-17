using UnityEngine;
using System.Collections.Generic;

namespace Level1
{
    public class Main : MonoBehaviour
    {
        private static Main _instance;
        public static Main Instance => _instance;
        private GameState _currentState;
        private List<GameState> _states = new List<GameState>();

        private Wave _currentWave;
        private List<Wave> _waves; 


        protected void AddState(GameState gameState)
        {
            _states.Add(gameState);
        }
        public void MoveToState<T>() where T : GameState
        {
            if(_currentState != null)
                _currentState.running = false;
            _currentState = _states.Find(i => i is T);
        }

        public GameState CurrentState => _currentState;

        void Start()
        {
            _instance = this;
            _states.Add(new StateRunningGame());
            _states.Add(new StatePause());
            _states.Add(new StateGameOver());
            _states.Add(new StateReturnMenu());
            _states.Add(new StateLoadLevel());

            foreach (GameState it in _states)
                it.Init();

            MoveToState<StateRunningGame>();
        }

        void Update()
        {
            if(_currentState != null)
                _currentState.Do();
        }
    }
}


