using UnityEngine;
using System.Collections;
using TMPro;

namespace Level1
{
    public class ButtonSaleTower : MonoBehaviour
    {
        public GameObject _tower;

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
            if(GetComponentInChildren<TextMeshPro>().enabled)
                GetComponentInChildren<TextMeshPro>().text = GetComponentInParent<DescriptionTower>().CostSaledTower.ToString();
        }

        public void Do()
        {
            
            GameManager.Instance.SaleTower(GetComponentInParent<DescriptionTower>().Id);
            GetComponentInParent<TowerController>().IsActive = false;
        }
    }

}
