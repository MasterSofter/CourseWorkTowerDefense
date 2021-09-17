using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

namespace Level1
{
    public class Viewer : MonoBehaviour
    {
        private static Viewer _instance;
        public static Viewer Instance => _instance;

        public TextMeshProUGUI textMeshCurrentWave;
        public TextMeshProUGUI textMeshCountWaves;

        private Transform _leftDoor;
        private Transform _rightDoor;
        private Transform _menuPause;
        private GameObject _menuGameover;

        private Transform _leftDoorOpenedPosition;
        private Transform _leftDoorClosedPosition;


        private Transform _rightDoorOpenedPosition;
        private Transform _rightDoorClosedPosition;

        private Transform _menuPauseBackScreenPosition;
        private Transform _menuPauseScreenPosition;

        private Transform _menuGameoverBackScreenPosition;
        private Transform _menuGameoverScreenPosition;

        private float timeWorkingDoors = 0;
        private float timeShowingMenuPause = 0;
        private float timeShowingMenuGameover = 0;

        bool _leftDoorOpened = false;
        bool _rightDoorOpened = false;
        bool _showedMenuPause = false;
        bool _showedMenuGameover = false;
        private int count = 0;


        [SerializeField]
        private AudioClip soundLose;
        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private AudioClip soundWin;


        void Start()
        {
            _instance = this;
            var mng = ResourceManager.Instance;

            _menuPause = mng.menuPause.transform;
            _menuGameover = mng.menuGameover;
            _menuPauseScreenPosition = mng.menuPauseScreenPosition.transform;
            _menuPauseBackScreenPosition = mng.menuPauseBackScreenPosition.transform;

            _menuGameoverBackScreenPosition = _menuPauseBackScreenPosition;
            _menuGameoverScreenPosition = _menuPauseScreenPosition;
            count = 0;
        }

        private void Update()
        {
            if (Main.Instance.CurrentState is StateRunningGame)
            {
                textMeshCurrentWave.text = (Game.Instance.CurrentWaveId + 1).ToString();
                textMeshCountWaves.text = Game.Instance.CountWaves.ToString();
            }
            
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

        public bool hideMenuPause()
        {
            var dist = Mathf.Abs((_menuPause.position - _menuPauseBackScreenPosition.position).magnitude);
            if (dist >= 1 && (_menuPause.position - _menuPauseBackScreenPosition.position).y < 0)
            {
                var dir = (_menuPause.position - _menuPauseBackScreenPosition.position).normalized;
                _menuPause.position = _menuPause.position - dir * (timeShowingMenuPause += 2f);
            }
            else { _menuPause.position = _menuPauseBackScreenPosition.position; _showedMenuPause = false; };

            if (!_showedMenuPause) timeShowingMenuPause = 0;
            return !_showedMenuPause;
        }

        public bool showMenuPause()
        {
            var dist = Mathf.Abs((_menuPause.position - _menuPauseScreenPosition.position).magnitude);
            if (dist >= 1f && (_menuPause.position - _menuPauseScreenPosition.position).y > 0)
            {
                var dir = (_menuPause.position - _menuPauseScreenPosition.position).normalized;
                _menuPause.position = _menuPause.position - dir * (timeShowingMenuPause += 2f);
            }
            else { _menuPause.position = _menuPauseScreenPosition.position; _showedMenuPause = true; };

            if (_showedMenuPause)
                timeShowingMenuPause = 0;

            return _showedMenuPause; 
        }

        public bool showMenuGameOver(int code)
        {
            if (code == 0)
            {
                audioSource.volume = 0.2f;
                audioSource.clip = soundLose;
                audioSource.Play();
                _menuGameover.GetComponent<TextHeader>().SetText("GameOver");
                _menuGameover.GetComponent<TextHeader>().SetColor(Color.red);
            }
            else if (code == 1)
            {
                audioSource.volume = 0.2f;
                audioSource.clip = soundWin;
                audioSource.Play();
                _menuGameover.GetComponent<TextHeader>().SetText("You won!");
                _menuGameover.GetComponent<TextHeader>().SetColor(Color.white);
            }


            var dist = Mathf.Abs((_menuGameover.transform.position - _menuGameoverScreenPosition.position).magnitude);
            if (dist >= 1f && (_menuGameover.transform.position - _menuGameoverScreenPosition.position).y > 0)
            {
                var dir = (_menuGameover.transform.position - _menuGameoverScreenPosition.position).normalized;
                _menuGameover.transform.position = _menuGameover.transform.position - dir * (timeShowingMenuGameover += 2f);
            }
            else { _menuGameover.transform.position = _menuGameoverScreenPosition.position; _showedMenuGameover = true; };

            if (_showedMenuGameover)
                timeShowingMenuGameover = 0;

            return _showedMenuGameover;
        }


    }
}




