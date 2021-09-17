using UnityEngine;
using System.Collections;

using UnityEngine.AI;

namespace Level1
{
    public class EnemyColdState : GameState
    {
        private float cold;
        public float coldTime;

        private float speed;
 
        public override void Do(Enemy enemy)
        {
            var description = enemy.GameObj.GetComponent<EnemyDescription>();
            if (!running)
            {
                cold = enemy.Cold;
                coldTime = enemy.ColdTime;
                speed = enemy.Speed;
                description.CurentSatate = this;

                enemy.GameObj.GetComponent<EnemyDescription>().CurentSatate = this;
                enemy.GameObj.GetComponent<HealthComponent>().enabled = true;
                enemy.GameObj.GetComponent<NavMeshAgent>().enabled = true;
                running = true;
            }

            if (!(Main.Instance.CurrentState is StatePause))
            {

                if (description.currentColdTime >= coldTime)
                {
                    description.currentColdTime = 0;
                    enemy.SetSpeed(enemy.GameObj.GetComponent<EnemyDescription>().speed);
                    enemy.GameObj.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].color = Color.white;
                    enemy.MoveToState<EnemyMoveState>();
                }
                else
                {
                    enemy.SetSpeed(speed - (speed / 100 * cold));
                    enemy.GameObj.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].color = Color.blue;
                    description.currentColdTime += Time.deltaTime;
                }

                var health = enemy.GameObj.GetComponent<HealthComponent>().Health;
                if (health <= 0)
                {
                    health = 0;
                    enemy.MoveToState<EnemyDeathState>();
                }

                var dist = Mathf.Abs((ResourceManager.Instance.targetForEnemy.transform.position - enemy.GameObj.transform.position).magnitude);

                if (dist <= 2f)
                {
                    enemy.Finished = true;
                    enemy.MoveToState<EnemyDeathState>();
                }
            }
            else
                enemy.GameObj.GetComponent<NavMeshAgent>().enabled = false;


        }
    }
}
