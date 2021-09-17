using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace MainMenu
{
    public class VideoPlayerScript : MonoBehaviour
    {
        public RawImage rawImage;
        public VideoPlayer videoPlayer;
        public AudioSource audioSource;

        private bool onLoad = false;
        // Use this for initialization
        public bool Init()
        {
            StartCoroutine(PlayVideo());
            return onLoad;
        }
        IEnumerator PlayVideo()
        {
            videoPlayer.Prepare();
            WaitForSeconds waitForSeconds = new WaitForSeconds(1);
            while (!videoPlayer.isPrepared)
            {
                yield return waitForSeconds;
                break;
            }
            rawImage.texture = videoPlayer.texture;
            onLoad = true;

            if (videoPlayer != null)
                videoPlayer.Play();
            if (audioSource != null)
                audioSource.Play();
        }
    }
}

