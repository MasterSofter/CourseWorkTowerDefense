/*
using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
    public virtual void Do() { }
  

    public void Update()
    {
        var list = GameObject.FindObjectOfType<RaycastScript>().GetHitsByTag("Button");
        if (list.Count == 1 && Input.GetMouseButton(0))
            Debug.Log("Есть нажатие!");
    }
}
*/