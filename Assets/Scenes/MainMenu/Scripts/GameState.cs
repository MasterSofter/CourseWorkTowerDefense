using UnityEngine;
using System.Collections;

namespace MainMenu
{
    public class GameState
    {
        public bool running = false;
        public virtual void Do() { }
        public virtual void Init() { }
    }
}

