using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Level1
{
    public class InputManager : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && Main.Instance.CurrentState is StateRunningGame)
                SceneManager.Instance.moveToStatePause();
            else
            if (Input.GetKeyDown(KeyCode.Escape) && Main.Instance.CurrentState is StatePause)
                SceneManager.Instance.moveToStateRunningGame();

            List<RaycastHit> hitsByTagButtonSaleTower = RaycastScript.Instance.GetHitsByTag("ButtonSaleTower");
            List<RaycastHit> hitsByTagButtonUpgradeTower = RaycastScript.Instance.GetHitsByTag("ButtonUpgradeTower");
            List<RaycastHit> hitsByTagTower = RaycastScript.Instance.GetHitsByTag("Tower");


            if (hitsByTagButtonUpgradeTower.Count == 1 && Input.GetMouseButtonDown(0))
            {
                hitsByTagButtonUpgradeTower[0].collider.gameObject.GetComponent<ButtonUpgradeTower>().Do();
                return;
            }
            else if (hitsByTagButtonSaleTower.Count == 1 && Input.GetMouseButtonDown(0))
            {
                hitsByTagButtonSaleTower[0].collider.gameObject.GetComponent<ButtonSaleTower>().Do();
                return;
            }
            else if (hitsByTagTower.Count > 0 && Input.GetMouseButtonDown(0))
            {
                var listTowers = GameManager.Instance.Towers.Where(i=> i.GameObj != null).ToList();
                foreach (WarTower it in listTowers)
                    it.GameObj.GetComponent<TowerController>().IsActive = false;

                var towerDeployement = listTowers.Where(i => i.CurrentState is WarTowerDeployementState).ToList();

                var activeTower = GameObject.FindObjectsOfType<TowerController>().Where(i => i.IsActive == true).ToList();

                if (towerDeployement.Count == 0 && activeTower.Count < 1 && hitsByTagTower[0].collider.gameObject.GetComponent<TowerController>() != null)
                    hitsByTagTower[0].collider.gameObject.GetComponent<TowerController>().IsActive = true;
                return;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                var towers = GameManager.Instance.Towers;
                foreach (WarTower it in towers.Where(i => i.GameObj != null))
                    it.GameObj.GetComponent<TowerController>().IsActive = false;
            }
        }


   
    }
}


