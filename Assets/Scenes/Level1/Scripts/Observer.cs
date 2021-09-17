using UnityEngine;
using System.Collections;

namespace Level1
{
    public class Observer : MonoBehaviour
    {
        void Update()
        {
            Vector3 direct = new Vector3();
            Vector3 directZY = new Vector3();
            direct = gameObject.transform.position - Camera.main.transform.position;
            directZY = new Vector3(0, direct.y, direct.z);
            if(directZY.z > 0)
                directZY = new Vector3(0, -direct.y, -direct.z);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.LookRotation(directZY), 1000);

        }
    }

}
