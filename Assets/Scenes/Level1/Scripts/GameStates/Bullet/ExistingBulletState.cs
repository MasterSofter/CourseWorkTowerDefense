using UnityEngine;
using System.Collections;
using System.Linq;

namespace Level1
{
    public class ExistingBulletState : GameState
    {
        private float timeAlive = 2;
        private float currentTime = 0;
        public override void Do(BaseGameObject gameObj)
        {
            var enemies = GameManager.Instance.Enemies;
            var description = gameObj.GameObj.GetComponent<DescriptionLaserBullet>();


            if (enemies.Count > 0)
            {
                float dist = float.MaxValue;
                Vector3 direct = new Vector3();
                foreach (Enemy enemy in GameManager.Instance.Enemies.Where(i=> i.GameObj != null))
                {
                    direct = enemy.GameObj.transform.position - gameObj.GameObj.transform.position;
                    dist = Mathf.Abs(direct.magnitude);
                    if (dist < 2.5f)
                    {
                        enemy.SetDamage(description.damage);
                        gameObj.MoveToState<DestroyedBulletState>();
                    }
                        
                }
            }

            if (currentTime >= timeAlive)
                gameObj.MoveToState<DestroyedBulletState>();
            else
                currentTime += Time.deltaTime;

        }
    }
}

