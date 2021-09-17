using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace Level1
{
    public class EnemyMoveState : GameState
    {
        public override void Init()
        {
            base.Init();
        }

        public override void Do(Enemy enemy)
        {
            if (!running)
            {
                enemy.GameObj.GetComponent<EnemyDescription>().CurentSatate = this;
                enemy.GameObj.GetComponent<HealthComponent>().enabled = true;
                enemy.GameObj.GetComponent<NavMeshAgent>().enabled = true;

                enemy.GameObj.GetComponent<NavMeshAgent>().speed = enemy.Speed;
                enemy.GameObj.GetComponent<NavMeshAgent>().SetDestination(enemy.TargetPosition);
                running = true;
            }
            else
            {
                if (!(Main.Instance.CurrentState is StatePause))
                {
                    enemy.GameObj.GetComponent<NavMeshAgent>().enabled = true;

                    enemy.GameObj.GetComponent<NavMeshAgent>().speed = enemy.Speed;
                    enemy.GameObj.GetComponent<NavMeshAgent>().SetDestination(enemy.TargetPosition);
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

}
