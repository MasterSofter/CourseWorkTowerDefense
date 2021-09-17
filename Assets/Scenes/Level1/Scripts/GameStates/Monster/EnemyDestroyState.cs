using UnityEngine;
using System.Collections;

namespace Level1
{
    public class EnemyDestroyState : GameState
    {
        public override void Do(Enemy enemy)
        {
            enemy.GameObj.GetComponent<EnemyDescription>().CurentSatate = this;
            enemy.GameObj.GetComponent<HealthComponent>().enabled = false;
        }
    }

}
