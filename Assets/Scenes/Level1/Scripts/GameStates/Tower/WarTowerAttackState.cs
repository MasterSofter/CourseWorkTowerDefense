using UnityEngine;
using System.Collections;

namespace Level1
{
    public class WarTowerAttackState: GameState
    {
        private bool attacked = false;
        public override void Init()
        {
            base.Init();
        }

        public override void Do(WarTower warTower)
        {
            if (!running)
            {
                warTower.GameObj.GetComponent<DescriptionTower>().CurrentState = this;
                running = true;
            }
                

            var descriptTower = warTower.GameObj.GetComponent<DescriptionTower>();

            if (descriptTower != null && descriptTower.enemy != null)
            {
                var direct = descriptTower.enemy.transform.position - warTower.GameObj.transform.position;
                descriptTower.head.rotation = Quaternion.Slerp(descriptTower.head.rotation, Quaternion.LookRotation(direct), warTower.SpeedRotation);

                if (!attacked)
                    attacked = warTower.attack();
                else
                {
                    attacked = false;
                    warTower.MoveToState<WarTowerIdleState>();
                }

            }
            else if(descriptTower != null && descriptTower.enemy == null)
                warTower.MoveToState<WarTowerIdleState>();
        }
    }
}