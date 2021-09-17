using UnityEngine;
using System.Collections;

namespace Level1
{
    public class DeployementButtonState : GameState
    {
        public override void Do(BaseGameObject gameObj)
        {
            base.Do(gameObj);
            gameObj.MoveToState<ExistingButtonState>();
        }
    }

}
