using UnityEngine;
using System.Collections;
using UnityEngine.AI;

namespace Level1
{
    public class Monster : Enemy
    {
        protected override void InitStates()
        {
            base.InitStates();
            AddState(new EnemyColdState());
            AddState(new EnemyIdleState());
            AddState(new EnemyMoveState());
            AddState(new EnemySetDamageState());
            AddState(new EnemyDeathState());
            AddState(new EnemyDestroyState());

            foreach (GameState it in States)
                it.Init();

            MoveToState<EnemyIdleState>();

        }

        public override void InitCaracteristics()
        {
            base.InitCaracteristics();
            GameObj.GetComponent<BangEffectScript>().bangEffect.GetComponent<ParticleSystem>().Stop();
            GameObj.GetComponent<BangEffectScript>().finishEffect.GetComponent<ParticleSystem>().Stop();
        }
    }

}
