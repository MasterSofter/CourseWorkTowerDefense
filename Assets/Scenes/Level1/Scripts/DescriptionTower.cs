using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Level1
{
    public class DescriptionTower : MonoBehaviour
    {
        public Transform head;
        public Transform gun;
        public Transform build;

        public Transform leftGun;
        public Transform rightGun;

       
        public GameObject enemy = null;
        public GameObject collisionObject;
        public GameState CurrentState = null;

        public AudioClip suondShoot;
        public AudioSource audioSource;

        public float CostUpgrade;
        public float CostSaledTower;
        public int Id = -1;
    }

}

