using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private GameObject _collision = null;
    public GameObject CollisionObj => _collision;

    [SerializeField]
    private AudioClip sound;
    [SerializeField]
    private AudioSource audioSource;

    public void OnCollisionStay(Collision collision)
    {
        _collision = collision.gameObject;
    }

}
