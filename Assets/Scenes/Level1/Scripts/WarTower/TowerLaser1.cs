using UnityEngine;
using System.Collections;
using System.Linq;

namespace Level1
{
    public sealed class TowerLaser1 : WarTower
    {
        public TowerLaser1() : base(TypeofTowers.TowerLaser)
        {
            _level = 1;
            _bullet = ResourceManager.Instance.prefubLaserBullet;
            _typeOfBullet = (int)GameManager.TypeOfAmmo.LaserBullet;
        }

        public override void InitCaracteristics()
        {
            base.InitCaracteristics();
            GameObj.GetComponentInChildren<ParticleSystem>().Stop();
        }

        protected override void InitStates()
        {
            base.InitStates();

            foreach (GameState it in States)
                it.Init();

            MoveToState<WarTowerDeployementState>();

        }

        public override bool attack()
        {
            return base.attack();
        }

    }
}
