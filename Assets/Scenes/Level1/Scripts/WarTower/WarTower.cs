using UnityEngine;
using System.Collections;

namespace Level1
{
    public class WarTower : BaseGameObject
    {
        private float _radiusShoot = 8;
        private float _speedRotation = 0.5f;

        protected float timeReload;
        protected float currentTime;

        protected int _level;
       
        protected GameObject _bullet;
        protected int _typeOfBullet;

        public int Level => _level;
        public float SpeedRotation => _speedRotation;

        public float RadiusShoot => _radiusShoot;

        protected readonly TypeofTowers _typeOfTower;
        public TypeofTowers TypeOfTower => _typeOfTower;

        public WarTower(TypeofTowers type)
        {
            _typeOfTower = type;
        }

        public override void InitCaracteristics()
        {
            timeReload = 0.5f;
        }

        protected override void InitStates()
        {
            AddState(new WarTowerDeployementState());
            AddState(new WarTowerIdleState());
            AddState(new WarTowerAttackState());
            AddState(new WarTowerReloadState());
            AddState(new WarTowerDestroyState());
        }

        public virtual bool attack()
        {
            var descriptTower = GameObj.GetComponent<DescriptionTower>();
            if (descriptTower != null && descriptTower.enemy != null && (descriptTower.enemy.GetComponent<EnemyDescription>().CurentSatate is EnemyMoveState || descriptTower.enemy.GetComponent<EnemyDescription>().CurentSatate is EnemyColdState))
            {
                Vector3 direct = new Vector3();
                direct = descriptTower.enemy.transform.position - GameObj.transform.position;
                direct += new Vector3(0, 1f, 0);
               
                var Bullet = GameManager.Instance.CreateAmmo(_bullet, descriptTower.gun.transform.position, _typeOfBullet);
                Bullet.GameObj.GetComponent<Rigidbody>().AddForce(direct.normalized * 180, ForceMode.Force);
                descriptTower.audioSource.volume = 0.1f;
                descriptTower.audioSource.PlayOneShot(descriptTower.suondShoot);

                return true;
            }
            return false;
        }
        public virtual bool reload()
        {
            if (currentTime >= timeReload)
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
    }
}

