using UnityEngine;
using System.Collections;


namespace Level1
{
    public class ColdTower2 : SuperWarTower
    {
        public ColdTower2() : base(TypeofTowers.ColdTower)
        {
            _level = 2;
            _bullet = ResourceManager.Instance.prefubColdBullet;
            _typeOfBullet = (int)GameManager.TypeOfAmmo.ColdBullet;
        }

        protected ColdTower2(TypeofTowers type) : base(type)
        {
        }

        protected override void InitStates()
        {
            base.InitStates();

            foreach (GameState it in States)
                it.Init();

            MoveToState<WarTowerIdleState>();

        }
   
        public override bool doubleAttack()
        {
            var descriptTower = GameObj.GetComponent<DescriptionTower>();

            if (descriptTower != null && descriptTower.enemy != null && (descriptTower.enemy.GetComponent<EnemyDescription>().CurentSatate is EnemyMoveState || descriptTower.enemy.GetComponent<EnemyDescription>().CurentSatate is EnemyColdState))
            {
                if (shortReloaded)
                {
                    Vector3 direct = new Vector3();
                    direct = descriptTower.enemy.transform.position - GameObj.transform.position;
                    direct += new Vector3(0, 1f, 0);

                    var Bullet = GameManager.Instance.CreateAmmo(_bullet, descriptTower.gun.transform.position, _typeOfBullet);
                    Bullet.GameObj.GetComponent<DescriptionColdBullet>().cold = 80;
                    Bullet.GameObj.GetComponent<Rigidbody>().AddForce(direct.normalized * 180, ForceMode.Force);
                    descriptTower.audioSource.volume = 0.1f;
                    descriptTower.audioSource.PlayOneShot(descriptTower.suondShoot);
                   
                    shortReloaded = false;
                    countShoot++;
                }

                if (!shortReloaded)
                    shortReloaded = shortReload();

                if (countShoot > 1)
                {
                    countShoot = 0;
                    return true;
                }
                else return false;
            }
            return false;
        }


        public override bool attack()
        {
            return doubleAttack();
        }
    }

}
