using UnityEngine;
using System.Collections;

namespace Level1
{
    public class WarTowerDeployementState : GameState
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

            var cells = GameObject.FindGameObjectsWithTag("Cell");
            foreach (GameObject it in cells)
                it.GetComponent<SpriteRenderer>().enabled = true;


            var hits = RaycastScript.Instance.GetHitsByTag("Terrain");
            if (hits.Count == 1)
            {
                warTower.GameObj.GetComponent<DescriptionTower>().build.transform.position = hits[0].point;
                warTower.GameObj.GetComponent<TowerController>().IsActive = true;
                if (Input.GetMouseButtonDown(0) && warTower.GameObj.GetComponent<DescriptionTower>().collisionObject != null && warTower.GameObj.GetComponent<DescriptionTower>().collisionObject.tag == "Cell" && warTower.GameObj.GetComponent<DescriptionTower>().collisionObject.GetComponent<CellDescription>().IsFree)
                {
                    warTower.GameObj.GetComponent<DescriptionTower>().collisionObject.GetComponent<CellDescription>().IsFree = false;

                    cells = GameObject.FindGameObjectsWithTag("Cell");
                    foreach (GameObject it in cells)
                        it.GetComponent<SpriteRenderer>().enabled = false;


                    warTower.MoveToState<WarTowerIdleState>();
                    warTower.GameObj.GetComponent<TowerIndicator>().HideRadiusShoot();
                }
                    
            }
                
        }

        
    }

}
