using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJoint : MonoBehaviour
{
    private SliderJoint2D slider;
    public JointMotor2D aux;
    public float velocidade_mexer = 0.4f;

    void Start()
    {
        slider = GetComponent<SliderJoint2D>();
        aux = slider.motor;
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.limitState == JointLimitState2D.LowerLimit) {
            aux.motorSpeed = velocidade_mexer;
            slider.motor = aux;
        }    

        if(slider.limitState == JointLimitState2D.UpperLimit) {
            aux.motorSpeed = (velocidade_mexer * -1);
            slider.motor = aux;
        }       
    }
}
