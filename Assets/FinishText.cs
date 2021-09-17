using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Level1
{
    public class FinishText : MonoBehaviour
    {
        int count = 0;
        [SerializeField]
        private TextMeshPro textCurrentContFinishedEnemies;
        [SerializeField]
        private TextMeshPro textMaxContFinishedEnemies;

        private void Update()
        {
            textMaxContFinishedEnemies.text = GameManager.Instance.CountMaxFinishedEnemies.ToString();
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Enemy")
            {
                count++;
                textCurrentContFinishedEnemies.text = count.ToString();
            }
                
        }

    }
}

