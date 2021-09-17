using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level1
{
    public class BangEffectScript : MonoBehaviour
    {
        public GameObject bangEffect;
        public GameObject finishEffect;


        public void Play()
        {
            bangEffect.GetComponent<ParticleSystem>().Play(true);
        }

        public void PlayFinish()
        {
            finishEffect.GetComponent<ParticleSystem>().Play(true);
        }

        private void Update()
        {
            if (!bangEffect.GetComponent<ParticleSystem>().isPlaying)
                bangEffect.GetComponent<ParticleSystem>().Stop();
        }
    }
}

