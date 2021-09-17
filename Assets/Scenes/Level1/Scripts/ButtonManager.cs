using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace Level1
{
    public class ButtonManager : MonoBehaviour
    {

        public Button buttonBuildTowerLaser;
        public Button buttonBuildColdTower;


        public void buildColdTower()
        {
            if (Main.Instance.CurrentState is StateRunningGame)
            {
                var hits = RaycastScript.Instance.GetHitsByTag("Terrain");
                if (hits.Count == 1)
                    GameManager.Instance.BuildTower(ResourceManager.Instance.prefubColdTower, hits[0].point, TypeofTowers.ColdTower, 1);
            }
        }


        public void buildTowerLaser()
        {
            if (Main.Instance.CurrentState is StateRunningGame)
            {
                var hits = RaycastScript.Instance.GetHitsByTag("Terrain");
                if (hits.Count == 1)
                    GameManager.Instance.BuildTower(ResourceManager.Instance.prefubTowerLaser1, hits[0].point, TypeofTowers.TowerLaser, 1);
            }
        }

        private void Update()
        {
            if (GameManager.Instance.fCost < 100)
                buttonBuildTowerLaser.interactable = false;
            else
                buttonBuildTowerLaser.interactable = true;

            if(GameManager.Instance.fCost < 250)
                buttonBuildColdTower.interactable = false;
            else
                buttonBuildColdTower.interactable = true;
        }
    }

}
