using UnityEngine;
using System.Collections;
using TMPro;

namespace Level1
{
    public class ButtonUpgradeTower : MonoBehaviour
    {
        [SerializeField]
        private GameObject _tower;

        [SerializeField]
        private GameObject _newTower;


        public void setActive(bool isActive)
        {
            if (isActive)
            {
                GetComponentInChildren<TextMeshPro>().enabled = true;
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                GetComponentInChildren<TextMeshPro>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
            }
        }

        private void Update()
        {
            GetComponentInChildren<TextMeshPro>().text = _tower.GetComponent<DescriptionTower>().CostUpgrade.ToString();
            if (GameManager.Instance.fCost >= _tower.GetComponent<DescriptionTower>().CostUpgrade)
                GetComponent<SpriteRenderer>().color = Color.white;
            else
               GetComponent<SpriteRenderer>().color = Color.gray;
        }

        public void Do()
        {
            if(GameManager.Instance.fCost >= _tower.GetComponent<DescriptionTower>().CostUpgrade)
                GameManager.Instance.UpgradeTower(_tower, _newTower);
            _tower.GetComponent<TowerController>().IsActive = false;
        }
    }
}

