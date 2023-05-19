using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rubber rubber;
    [SerializeField] private GameObject pivotPoint;


    public float swingDir;
    public float rotateSpeed = 100f;
    private Vector3 moveDir;
    private Vector3 lastMove;


    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivotPoint.transform.position, new Vector3(0, swingDir, 0), rotateSpeed * Time.deltaTime);
    }

    

    
}
