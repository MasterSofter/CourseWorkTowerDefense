using UnityEngine;
using System.Collections;

namespace Level1
{
    public abstract class Wave : MonoBehaviour
    {
        protected float _time;
        protected float _timeSpawn;
        protected float _timeToSwitchNextWave = 2;
        protected int _countMonstres;
        protected int _currentCountMonstres;


        public int CurrentCountMonstres { get { return _currentCountMonstres; } set { _currentCountMonstres = value; } }

        public virtual void Init() { }
        public virtual void Do()
        {
            if (GameManager.Instance.Enemies.Count == 0 && _currentCountMonstres == _countMonstres)
            {
                if (Game.Instance.CurrentNumbWave == 1)
                    GameManager.Instance.AddCost(100);
                if (Game.Instance.CurrentNumbWave == 2)
                    GameManager.Instance.AddCost(150);
                if (Game.Instance.CurrentNumbWave == 3)
                    GameManager.Instance.AddCost(450);
                if (Game.Instance.CurrentNumbWave == 4)
                    GameManager.Instance.AddCost(2050);
                GameManager.Instance.NextWave();
            }

        }
    }
}

