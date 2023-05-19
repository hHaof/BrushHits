using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubber : MonoBehaviour
{
    [SerializeField] private GameObject rubber;
    [SerializeField] private GameObject colorSwitchRubber;
    [SerializeField] private GameObject exploseRubber;
    


    void Start() { 
    }
       

    void FixedUpdate()
    {
        if (rubber.transform.eulerAngles != Vector3.zero)
        {
            SwitchColor();
            ParticleOnHit();
   
            
        }
    }
    public void SwitchColor()
    {
        colorSwitchRubber.SetActive(true);
    }

    public void ParticleOnHit()
    {
        exploseRubber.SetActive(true);
    }
}
