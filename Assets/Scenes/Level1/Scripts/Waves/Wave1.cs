﻿using UnityEngine;
using System.Collections;


namespace Level1
{
    public class Wave1 : Wave
    {
        public override void Init()
        {
            _time = 0;
            _timeSpawn = 2;
            _countMonstres = 12;
            _currentCountMonstres = 0;
        }

        public override void Do()
        {
            if (_currentCountMonstres < _countMonstres)
            {
                if (_time >= _timeSpawn)
                {
                    _currentCountMonstres++;
                    _time = 0;
                    GameManager.Instance.SpawnEnemy(ResourceManager.Instance.prefubMonster, (int)GameManager.TypeOfEnemy.Monster, 100, 12, 12);
                }
                else
                {
                    _time += Time.deltaTime;
                }
            }
            base.Do();

        }
    }

}
