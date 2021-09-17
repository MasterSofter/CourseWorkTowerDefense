using UnityEngine;
using System.Collections;

namespace Level1
{
    public class SuperWarTowerTwoGuns : SuperWarTower
    {
        protected SuperWarTowerTwoGuns(TypeofTowers type) : base(type)
        {
        }

        public override void InitCaracteristics()
        {
            timeReload = 0.5f;
            
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
                   
                    var Bullet1 = GameManager.Instance.CreateAmmo(_bullet, descriptTower.leftGun.transform.position, _typeOfBullet);
                    var Bullet2 = GameManager.Instance.CreateAmmo(_bullet, descriptTower.rightGun.transform.position, _typeOfBullet);

                    Bullet1.GameObj.GetComponent<Rigidbody>().AddForce(direct.normalized * 180, ForceMode.Force);
                    descriptTower.audioSource.volume = 0.1f;
                    descriptTower.audioSource.PlayOneShot(descriptTower.suondShoot);

                    Bullet2.GameObj.GetComponent<Rigidbody>().AddForce(direct.normalized * 180, ForceMode.Force);
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
    }
}