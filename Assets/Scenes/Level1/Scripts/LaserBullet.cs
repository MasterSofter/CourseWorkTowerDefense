using UnityEngine;
using System.Collections;


namespace Level1
{
    public class LaserBullet : BaseGameObject
    {
        public override void InitCaracteristics()
        {
            GameObj.GetComponent<Rigidbody>().mass = GameObj.GetComponent<DescriptionLaserBullet>().mass;
        }

        protected override void InitStates()
        {
            base.InitStates();
            AddState(new ExistingBulletState());
            AddState(new DestroyedBulletState());
            

            foreach (GameState it in States)
                it.Init();

            MoveToState<ExistingBulletState>();

        }
    }

}
