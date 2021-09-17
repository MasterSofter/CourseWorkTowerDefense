using UnityEngine;
using System.Collections;


namespace Level1
{
    public class TowerIndicator : MonoBehaviour
    {
        private Collider _collisionCell = null;

        [SerializeField]
        private SpriteRenderer shootRadiusSprite;
        public void ShowRadiusShoot()
        {
            shootRadiusSprite.enabled = true;
            if (_collisionCell != null && _collisionCell.GetComponent<CellDescription>().IsFree && gameObject.GetComponent<DescriptionTower>().CurrentState is WarTowerDeployementState)
                shootRadiusSprite.color = Color.white;
            else if (_collisionCell != null && !(gameObject.GetComponent<DescriptionTower>().CurrentState is WarTowerDeployementState))
                shootRadiusSprite.color = Color.white;
            else if (_collisionCell == null)
                shootRadiusSprite.color = Color.red;
        }
        public void HideRadiusShoot()
        {
            shootRadiusSprite.enabled = false;
        }

        public void setActive(bool active)
        {
            if (active)
                ShowRadiusShoot();
            else
                HideRadiusShoot();
        }


        private void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Cell")
                _collisionCell = collider;
        }

        private void OnTriggerStay(Collider collider)
        {
            if (collider.tag == "Cell")
                _collisionCell = collider;
        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.tag == "Cell")
                _collisionCell = null;
        }

    }

}
