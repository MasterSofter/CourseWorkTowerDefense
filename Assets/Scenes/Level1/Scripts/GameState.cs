using UnityEngine;
using System.Collections;

namespace Level1
{
    public class GameState
    {
        public bool running = false;
        public virtual void Do() { }
        public virtual void Do(Enemy enemy) { }
        public virtual void Do(WarTower warTower) { }
        public virtual void Do(BaseGameObject gameObj) { }
        public virtual void Init() { running = false; }
    }

}
