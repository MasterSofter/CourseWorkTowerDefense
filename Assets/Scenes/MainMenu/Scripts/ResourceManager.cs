using UnityEngine;
using System.Collections;

namespace MainMenu
{
    public class ResourceManager : MonoBehaviour
    {
        private static ResourceManager _instance;
        public static ResourceManager Instance => _instance;
        private void Start()
        {
            _instance = this;
        }

        public GameObject leftDoor;
        public GameObject rightDoor;
        public GameObject buttonsLevels;

        public GameObject closedLeftDoor;
        public GameObject closedRightDoor;
        public GameObject openedLeftDoor;
        public GameObject openedRightDoor;

        public GameObject buttonsLevelsScreenPosition;
        public GameObject buttonsLevelsBackScreenPosition;
    }
}
