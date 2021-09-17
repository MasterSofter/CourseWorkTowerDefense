using UnityEngine;
using System.Collections;

namespace Level1
{
    public class ColdTower1 : WarTower
    {
        public ColdTower1() : base(TypeofTowers.ColdTower)
        {
            _level = 1;
            _bullet = ResourceManager.Instance.prefubColdBullet;
            _typeOfBullet = (int)GameManager.TypeOfAmmo.ColdBullet;
        }

        protected ColdTower1(TypeofTowers type) : base(type)
        {
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
            var descriptTower = GameObj.GetComponent<DescriptionTower>();

            if (descriptTower != null && descriptTower.enemy != null && (descriptTower.enemy.GetComponent<EnemyDescription>().CurentSatate is EnemyMoveState || descriptTower.enemy.GetComponent<EnemyDescription>().CurentSatate is EnemyColdState))
            {
                Vector3 direct = new Vector3();
                direct = descriptTower.enemy.transform.position - GameObj.transform.position;
                direct += new Vector3(0, 1f, 0);

                var Bullet = GameManager.Instance.CreateAmmo(_bullet, descriptTower.gun.transform.position, _typeOfBullet);
                Bullet.GameObj.GetComponent<DescriptionColdBullet>().cold = 50;
                Bullet.GameObj.GetComponent<Rigidbody>().AddForce(direct.normalized * 180, ForceMode.Force);
                descriptTower.audioSource.volume = 0.1f;
                descriptTower.audioSource.PlayOneShot(descriptTower.suondShoot);


                return true;
            }
            return false;
        }


    }

}
