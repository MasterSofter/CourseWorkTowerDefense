using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace Level1
{
    public class EnemyDeathState : GameState
    {
        private float _time = 0;
        private float _timeDeath = 2;

        public override void Init()
        {
            base.Init();

        }


        public override void Do(Enemy enemy)
        {
            if (!running)
            {
                var description = enemy.GameObj.GetComponent<EnemyDescription>();
                description.CurentSatate = this;

                if (enemy.Finished == false)
                {
                    description.costDeath.active = true;
                    description.textCostDeath.text = $"+{description.fCostDeath}";
                    enemy.GameObj.GetComponent<BangEffectScript>().Play();
                }
                else
                {
                    enemy.GameObj.GetComponent<BangEffectScript>().PlayFinish();
                    description.audioSource.volume = 0.1f;
                    description.audioSource.PlayOneShot(description.soundFinished);
                }

                enemy.GameObj.GetComponent<HealthComponent>().Visible(false);
                enemy.GameObj.GetComponent<NavMeshAgent>().enabled = false;
                enemy.GameObj.GetComponent<MeshRenderer>().enabled = false;
                enemy.GameObj.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;

                running = true;
            }
            else
            {
                if (_time >= _timeDeath)
                    enemy.MoveToState<EnemyDestroyState>();
                else
                {
                    _time += Time.deltaTime;
                    var description = enemy.GameObj.GetComponent<EnemyDescription>();
                    if (description.costDeath.active)
                    {
                        description.costDeath.transform.position += new Vector3(0, 0.2f * _time, 0);
                        description.costDeath.transform.localScale += new Vector3(0.01f * _time, 0.01f * _time, 0.01f * _time);
                    }
                }
                    
            }
        }
    }
}

