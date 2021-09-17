using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{
    private float _rayDistance = 1000000;
    private static RaycastScript _instance;
    private void Start()
    {
        _instance = this;
    }

    public static RaycastScript Instance
    {
        get { return _instance; }
    }

    public RaycastHit[] Hits { get; private set; }
    public List<RaycastHit> GetHitsByTag(string tag)
    {
        if (Hits == null) return new List<RaycastHit>();
        return Hits.Where(i => i.transform != null && string.Equals(i.transform.tag, tag)).ToList();
    }


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, ray.direction * _rayDistance);
        Hits = Physics.RaycastAll(ray, _rayDistance);
    }
}
