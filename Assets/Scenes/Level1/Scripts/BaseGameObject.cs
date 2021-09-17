using UnityEngine;
using System.Collections.Generic;

namespace Level1
{
    public class BaseGameObject : MonoBehaviour
    {

        protected GameObject _gameObject;
        public GameObject GameObj => _gameObject;

        protected List<GameState> States = new List<GameState>();
        private GameState _currentState;

        public void Init(GameObject gameObject)
        {
            _gameObject = gameObject;

            CreateComponents();
            InitStates();
            InitCaracteristics();
        }

        
        public virtual void Destroy()
        {
            DestroyObject(_gameObject);
            _gameObject = null;

            States.Clear();
            _currentState = null;
        }

        protected virtual void CreateComponents() { }
        protected virtual void InitStates() { }
        public virtual void InitCaracteristics() { }

        public GameState CurrentState => _currentState;
        protected void AddState(GameState gameState)
        {
            States.Add(gameState);
        }

        public void MoveToState<T>() where T : GameState
        {
            if(_currentState != null)
                _currentState.running = false;
            _currentState = States.Find(i => i is T);
        }

    }
}


