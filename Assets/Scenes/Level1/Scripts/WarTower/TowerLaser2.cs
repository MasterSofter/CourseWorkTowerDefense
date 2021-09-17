using UnityEngine;
using System.Collections;

namespace Level1
{
    public sealed class TowerLaser2 : SuperWarTower
    {
        public TowerLaser2() : base(TypeofTowers.TowerLaser)
        {
            _level = 2;
            _bullet = ResourceManager.Instance.prefubLaserBullet;
            _typeOfBullet = (int)GameManager.TypeOfAmmo.LaserBullet;
        }
        
        protected override void InitStates()
        {
            base.InitStates();

            foreach (GameState it in States)
                it.Init();

            MoveToState<WarTowerIdleState>();

        }

        public override bool attack()
        {
            return doubleAttack();
        }
    }   
}
