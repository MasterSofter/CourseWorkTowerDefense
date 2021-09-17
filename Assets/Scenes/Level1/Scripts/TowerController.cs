using UnityEngine;
using System.Collections;
using TMPro;

namespace Level1
{
    public class TowerController : MonoBehaviour
    {

        private bool _isActive = false;
        public bool IsActive
        {
            set { _isActive = value; }
            get { return _isActive; }
        }
        public ButtonUpgradeTower buttonUpgrade;
        public ButtonSaleTower buttonSaleTower;
        public TowerIndicator indicator;

        void Update()
        {

            var description = GetComponent<DescriptionTower>();
            if (Main.Instance.CurrentState is StateRunningGame)
            {
                if (buttonUpgrade != null && !(description.CurrentState is WarTowerDeployementState))
                    buttonUpgrade.setActive(_isActive);
                else if(buttonUpgrade != null)
                    buttonUpgrade.setActive(false);

                if (buttonSaleTower != null && !(description.CurrentState is WarTowerDeployementState))
                    buttonSaleTower.setActive(_isActive);
                else
                    buttonSaleTower.setActive(false);

                if (indicator != null)
                    indicator.setActive(_isActive);

            }
        }

        private void OnTriggerEnter(Collider collider)
        {
            if(collider.tag == "Cell")
                GetComponent<DescriptionTower>().collisionObject = collider.gameObject;
        }

        private void OnTriggerStay(Collider collider)
        {
            if (collider.tag == "Cell")
                GetComponent<DescriptionTower>().collisionObject = collider.gameObject;
        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.tag == "Cell")
                GetComponent<DescriptionTower>().collisionObject = null;
        }

    }

}
