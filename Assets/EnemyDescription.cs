using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Level1
{
    public class EnemyDescription : MonoBehaviour
    {
        public GameState CurentSatate = null;
        public int Id = -1;
        public float fCostDeath;
        public GameObject costDeath;
        public TextMeshPro textCostDeath;
        public float speed;

        public AudioClip soundFrosen;
        public AudioClip soundFinished;
        public AudioSource audioSource;

        public float currentColdTime = 0;

        public bool IsBoss = false;
    }

}
