using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountRubber : MonoBehaviour
{

    public Slider slider;
    private int HitRubberCounter;


    // Update is called once per frame
    void FixedUpdate()
    {
        HitRubberCounter = GameObject.FindGameObjectsWithTag("HitRubber").Length;
       
        SetPoint(HitRubberCounter);

        if (HitRubberCounter == slider.maxValue){
            GameManager.Instance.wrapWinPanel();
        }
        
    }

    public void SetPoint(int point){
        slider.value = point;
    }
}
