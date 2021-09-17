using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform UpLeftPoint;
    public Transform DownRightPoint;

    private float velocity = 1f;
    Vector3 directDown = new Vector3(0,1,0);
    Vector3 directUp;
    Vector3 directLeft;
    Vector3 directRight;
    // Update is called once per frame
    private void Start()
    {
        directUp = gameObject.transform.forward;
        directDown = -gameObject.transform.forward;
        directLeft = -gameObject.transform.right;
        directRight = gameObject.transform.right;
    }

    void Update()
    {

        if (Input.mousePosition.y <= 0)
        {
            if(gameObject.transform.position.z < DownRightPoint.position.z)
                GetComponent<Transform>().position -= directUp * velocity;
        }

        if (Input.mousePosition.y >= Screen.height)
        {
            if (gameObject.transform.position.z > UpLeftPoint.position.z)
                GetComponent<Transform>().position -= directDown * velocity;
        }

        if (Input.mousePosition.x <= 0)
        {
            if (gameObject.transform.position.x < UpLeftPoint.position.x)
                GetComponent<Transform>().position += directLeft * velocity;
        }

        if (Input.mousePosition.x >= Screen.width)
        {
            if (gameObject.transform.position.x > DownRightPoint.position.x)
                GetComponent<Transform>().position += directRight * velocity;
        }


    }
}
