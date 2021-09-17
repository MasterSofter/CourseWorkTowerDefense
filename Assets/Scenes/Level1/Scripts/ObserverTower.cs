using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Level1
{
    public class ObserverTower : MonoBehaviour
    {
        [SerializeField]
        private DescriptionTower description;

        private List<int> enemiesId = new List<int>();
        private List<int> deletedEnemiesId = new List<int>();
        private List<GameObject> enemies = new List<GameObject>();


        private void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Enemy")
                enemiesId.Add(collider.gameObject.GetComponent<EnemyDescription>().Id);
        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.tag == "Enemy")
                deletedEnemiesId.Add(collider.gameObject.GetComponent<EnemyDescription>().Id);
        }


        private GameObject findNearestEnemy(List<GameObject> list)
        {
            float dist,minDist = float.MaxValue;
            GameObject minDistEnemy = null;
            Vector3 direct = new Vector3();
            Vector3 directXZ = new Vector3();
            foreach (GameObject enemy in list)
            {
                direct = enemy.transform.position - gameObject.transform.position;
                directXZ = new Vector3(direct.x, 0, direct.z);
                dist = Mathf.Abs(directXZ.magnitude);
                if (dist < minDist)
                {
                    minDist = dist;
                    minDistEnemy = enemy;
                }
            }
            return minDistEnemy;
        }

        private void Update()
        {
            foreach(int it in deletedEnemiesId)
                enemiesId.Remove(it);

            deletedEnemiesId.Clear();
            enemies.Clear();

            foreach (int it in enemiesId)
            {
                var enemy = GameObject.FindGameObjectsWithTag("Enemy").Where(i => i.GetComponent<EnemyDescription>().Id == it).ToList();
                if (enemy.Count == 1)
                    enemies.Add(enemy[0]);
            }

            description.enemy = findNearestEnemy(enemies);
        }
    }

}
