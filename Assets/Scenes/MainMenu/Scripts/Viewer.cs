using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    public class Viewer : MonoBehaviour
    {
        private static Viewer _instance;
        public static Viewer Instance => _instance;

        private Transform _leftDoor;
        private Transform _rightDoor;
        private Transform _buttonsLevels;

        private Transform _leftDoorOpenedPosition;
        private Transform _leftDoorClosedPosition;


        private Transform _rightDoorOpenedPosition;
        private Transform _rightDoorClosedPosition;

        private Transform _buttonsLevelsScreenPosition;
        private Transform _buttonsLevelsBackScreenPosition;



        private float timeWorkingDoors = 0;
        private float timeWorkingButtonsLevels = 0;
        bool _leftDoorOpened = false;
        bool _rightDoorOpened = false;
        bool _buttonsLevelsShowed = false;
        int count = 0;

        void Start()
        {
            _instance = this;
            var mng = GameObject.FindObjectOfType<ResourceManager>();
            _leftDoor = mng.leftDoor.transform;
            _rightDoor = mng.rightDoor.transform;
            _leftDoorOpenedPosition = mng.openedLeftDoor.transform;
            _rightDoorOpenedPosition = mng.openedRightDoor.transform;
            _leftDoorClosedPosition = mng.closedLeftDoor.transform;
            _rightDoorClosedPosition = mng.closedRightDoor.transform;

            _buttonsLevels = mng.buttonsLevels.transform;
            _buttonsLevelsBackScreenPosition = mng.buttonsLevelsBackScreenPosition.transform;
            _buttonsLevelsScreenPosition = mng.buttonsLevelsScreenPosition.transform;

            count = 0;
        }


        public bool showScreen()
        {
            if (count == 0) { ScreenFader.Instatnce.fadeState = ScreenFader.FadeState.Out; count = 1; }
            if (ScreenFader.Instatnce.fadeState == ScreenFader.FadeState.OutEnd)
            { count = 0; return true; }
            else return false;
        }

        public bool hideScreen()
        {
            if (count == 0) { ScreenFader.Instatnce.fadeState = ScreenFader.FadeState.In; count = 1; }
            if (ScreenFader.Instatnce.fadeState == ScreenFader.FadeState.InEnd)
            { count = 0; return true; }
            else return false;

        }


        public bool showLoad()
        {
            return true;
        }

        public bool showLogo()
        {
            return true;
        }

        public bool hideButtonsLevels()
        {
            var dist = Mathf.Abs((_buttonsLevels.position - _buttonsLevelsBackScreenPosition.position).magnitude);
            if (dist >= 0.2)
            {
                var dir = (_buttonsLevels.position - _buttonsLevelsBackScreenPosition.position).normalized;
                _buttonsLevels.position = _buttonsLevels.position - dir * (timeWorkingButtonsLevels += 0.015f);
            }
            else { _buttonsLevels.position = _buttonsLevelsBackScreenPosition.position; _buttonsLevelsShowed = false; };

            if (!_buttonsLevelsShowed) timeWorkingButtonsLevels = 0;

            return !_buttonsLevelsShowed;
        }

        public bool showButtonsLevels()
        {
            var dist = Mathf.Abs((_buttonsLevels.position - _buttonsLevelsScreenPosition.position).magnitude);
            if (dist >= 0.2)
            {
                var dir = (_buttonsLevels.position - _buttonsLevelsScreenPosition.position).normalized;
                _buttonsLevels.position = _buttonsLevels.position - dir * (timeWorkingButtonsLevels += 0.015f);
            }
            else { _buttonsLevels.position = _buttonsLevelsScreenPosition.position; _buttonsLevelsShowed = true; };

            if (_buttonsLevelsShowed) timeWorkingButtonsLevels = 0;
            return _buttonsLevelsShowed;
        }

        public bool openDoors()
        {

            var dist = Mathf.Abs((_leftDoor.position - _leftDoorOpenedPosition.position).magnitude);
            if (dist >= 0.5)
            {
                var dir = (_leftDoor.position - _leftDoorOpenedPosition.position).normalized;
                _leftDoor.position = _leftDoor.position - dir * (timeWorkingDoors += 0.02f);
            }
            else { _leftDoor.position = _leftDoorOpenedPosition.position; _leftDoorOpened = true; };

            dist = Mathf.Abs((_rightDoor.position - _rightDoorOpenedPosition.position).magnitude);
            if (dist >= 0.5)
            {
                var dir = (_rightDoor.position - _rightDoorOpenedPosition.position).normalized;
                _rightDoor.position = _rightDoor.position - dir * (timeWorkingDoors += 0.02f);
            }
            else { _rightDoor.position = _rightDoorOpenedPosition.position; _rightDoorOpened = true; };

            if (_leftDoorOpened && _rightDoorOpened) timeWorkingDoors = 0;

            return (_leftDoorOpened && _rightDoorOpened);


        }

        public bool closeDoors()
        {
            var dist = Mathf.Abs((_leftDoor.position - _leftDoorClosedPosition.position).magnitude);
            if (dist >= 0.5)
            {
                var dir = (_leftDoor.position - _leftDoorClosedPosition.position).normalized;
                _leftDoor.position = _leftDoor.position - dir * (timeWorkingDoors += 0.01f);
            }
            else { _leftDoor.position = _leftDoorClosedPosition.position; _leftDoorOpened = false; };

            dist = Mathf.Abs((_rightDoor.position - _rightDoorClosedPosition.position).magnitude);
            if (dist >= 0.5)
            {
                var dir = (_rightDoor.position - _rightDoorClosedPosition.position).normalized;
                _rightDoor.position = _rightDoor.position - dir * (timeWorkingDoors += 0.01f);
            }
            else { _rightDoor.position = _rightDoorClosedPosition.position; _rightDoorOpened = false; };

            if (!_leftDoorOpened && !_rightDoorOpened) timeWorkingDoors = 0;

            return (!_leftDoorOpened && !_rightDoorOpened);

        }

    }
}

