using UnityEngine;
using System.Collections;


namespace Level1
{
    public class TowerLaser3 : SuperWarTowerTwoGuns
    {
        public TowerLaser3() : base(TypeofTowers.TowerLaser)
        {
            _level = 3;
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