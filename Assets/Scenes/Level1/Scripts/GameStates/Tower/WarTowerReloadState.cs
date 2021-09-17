using UnityEngine;
using System.Collections;

namespace Level1
{
    public class WarTowerReloadState : GameState
    {
        private bool reloaded = false;
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
           
            if (descriptTower.enemy != null)
            {
                var direct = descriptTower.enemy.transform.position - warTower.GameObj.transform.position;
                descriptTower.head.rotation = Quaternion.Slerp(descriptTower.head.rotation, Quaternion.LookRotation(direct), warTower.SpeedRotation);

                if (!reloaded)
                    reloaded = warTower.reload();
                else
                {
                    reloaded = false;
                    warTower.MoveToState<WarTowerAttackState>();
                }
            }
            else
                warTower.MoveToState<WarTowerIdleState>();
        }
    }
}