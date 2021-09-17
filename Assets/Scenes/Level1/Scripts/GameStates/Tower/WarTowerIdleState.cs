using UnityEngine;
using System.Collections;
using System.Linq;

namespace Level1
{
    public class WarTowerIdleState : GameState
    {
        private bool playedBang = false;
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

            if (!playedBang)
            {
                warTower.GameObj.GetComponent<TowerController>().IsActive = false;
                playedBang = true;
            } 
            else
            {
                var descriptTower = warTower.GameObj.GetComponent<DescriptionTower>();

                if (descriptTower != null && descriptTower.enemy != null)
                        warTower.MoveToState<WarTowerReloadState>();
            }
        }
    }
}

