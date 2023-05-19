using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeflRotate : MonoBehaviour
{
    public Transform spinner2;

    
    void Update()
    {
        transform.forward = (spinner2.position - transform.position + Vector3.right/5);
    }
}
