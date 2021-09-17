using UnityEngine;
using System.Collections;

namespace Level1
{
    public class WarTowerDestroyState : GameState
    {
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
        }

        
    }

}
