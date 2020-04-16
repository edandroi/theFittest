using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform targetObj;
    private Transform m_Transform;
    private Vector3 dir;
    void Start()
    {
        m_Transform = gameObject.transform;
    }

    void Update()
    {
        dir = targetObj.position - transform.position;
       var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
       transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
