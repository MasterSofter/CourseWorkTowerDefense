using UnityEngine;
using System.Collections;

namespace Level1
{
    public class EnemySetDamageState : GameState
    {
        public override void Do(Enemy enemy)
        {
            enemy.GameObj.GetComponent<EnemyDescription>().CurentSatate = this;
        }
    }

}
