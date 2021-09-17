using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logo
{
    public class SoundManager : MonoBehaviour
    {
        private static SoundManager _instance;
        public static SoundManager Instance => _instance;
        private void Start()
        {
            _instance = this;
        }

        public bool hideSound(AudioSource audioSource)
        {
            audioSource.volume -= 0.01f;
            if (audioSource.volume <= 0.01f)
            {
                audioSource.volume = 0;
                return true;
            }
            else
                return false;
                
        }
    }
}

