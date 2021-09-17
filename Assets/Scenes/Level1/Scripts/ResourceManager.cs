using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Level1
{
    public class ResourceManager : MonoBehaviour
    {
        private static ResourceManager _instance;
        public static ResourceManager Instance => _instance;
        private void Start()
        {
            _instance = this;
        }

        public GameObject menuPause;
        public GameObject menuGameover;

        public GameObject menuPauseBackScreenPosition;
        public GameObject menuPauseScreenPosition;

        public GameObject prefubMonster;
        public GameObject prefubMonsterBoss;
        public GameObject spawnEnemy;
        public GameObject targetForEnemy;

        public GameObject prefubTowerLaser1;
        public GameObject prefubColdTower;

        public GameObject prefubLaserBullet;
        public GameObject prefubColdBullet;

        public GameObject trushcan;
        //public GameObject prefubUpgradeButton;

        public Canvas canvas;


    }
}
