using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace Level1
{
    public class EnemyIdleState : GameState
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
                enemy.GameObj.GetComponent<EnemyDescription>().costDeath.active = false;
                enemy.GameObj.GetComponent<HealthComponent>().enabled = true;
                enemy.GameObj.GetComponent<NavMeshAgent>().enabled = false;
                running = true;
                
            }
            else
                enemy.MoveToState<EnemyMoveState>();
        }
    }
}

