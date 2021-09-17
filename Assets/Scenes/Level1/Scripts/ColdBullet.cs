using UnityEngine;
using System.Collections;


namespace Level1
{
    public class ColdBullet : BaseGameObject
    {
        public override void InitCaracteristics()
        {
            GameObj.GetComponent<Rigidbody>().mass = GameObj.GetComponent<DescriptionColdBullet>().mass;
        }

        protected override void InitStates()
        {
            base.InitStates();
            AddState(new ExistingColdBulletState());
            AddState(new DestroyedBulletState());


            foreach (GameState it in States)
                it.Init();

            MoveToState<ExistingColdBulletState>();

        }
    }
}

