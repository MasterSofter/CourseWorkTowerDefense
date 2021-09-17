using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

namespace Level1
{
    public class Game : MonoBehaviour
    {
        private int _countWaves;
       

        private Wave[] _waves;
        private int _currentWaveId;

        private static Game _instance;
        public static Game Instance => _instance;

        public int CurrentWaveId { set { _currentWaveId = value; } get { return _currentWaveId; } }

        public int CurrentNumbWave => _currentWaveId + 1;

        public Wave[] Waves => _waves;
        public int CountWaves => _countWaves;

        private void Start()
        {
            _instance = this;
            _countWaves = 5;

            _currentWaveId = 0;
            _waves = new Wave[_countWaves];
            _waves[0] = new Wave1();
            _waves[1] = new Wave2();
            _waves[2] = new Wave3();
            _waves[3] = new Wave4();
            _waves[4] = new Wave5();
            for (int i = 0; i < 5; i++)
                _waves[i].Init();
        }

        public void Do()
        {
            _waves[_currentWaveId].Do();

        }
    }
}

