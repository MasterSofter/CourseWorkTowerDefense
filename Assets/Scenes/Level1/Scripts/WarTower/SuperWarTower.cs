using UnityEngine;
using System.Collections;

namespace Level1
{
    public class SuperWarTower : WarTower
    {
        public override void InitCaracteristics()
        {
            timeReload = 0.5f;
        }

        protected float countShoot = 0;
        protected float shortReloadTime = 0.15f;
        protected bool shortReloaded = true;

        protected SuperWarTower(TypeofTowers type) : base(type)
        {
        }

       

        protected bool shortReload()
        {
            if (currentTime >= shortReloadTime)
            {
                currentTime = 0;
                return true;
            }
            else
            {
                currentTime += Time.deltaTime;
                return false;
            }
        }
        

        public virtual bool doubleAttack()
        {
            var descriptTower = GameObj.GetComponent<DescriptionTower>();

            if (descriptTower != null && descriptTower.enemy != null && (descriptTower.enemy.GetComponent<EnemyDescription>().CurentSatate is EnemyMoveState || descriptTower.enemy.GetComponent<EnemyDescription>().CurentSatate is EnemyColdState))
            {
                if (shortReloaded)
                {
                    base.attack();
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

        public virtual bool tripleAttack()
        {
            var descriptTower = GameObj.GetComponent<DescriptionTower>();

            if (descriptTower != null && descriptTower.enemy != null && (descriptTower.enemy.GetComponent<EnemyDescription>().CurentSatate is EnemyMoveState || descriptTower.enemy.GetComponent<EnemyDescription>().CurentSatate is EnemyColdState))
            {
                if (shortReloaded)
                {

                    base.attack();
                    shortReloaded = false;
                    countShoot++;
                }

                if (!shortReloaded)
                    shortReloaded = shortReload();

                if (countShoot > 2)
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