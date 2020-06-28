using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueIcnDec : MonoBehaviour
{
    public Slider force;
    //public ParticleSystem myParticleSystem;
    //private EmissionModule emissionModule;
    private RawImage AireBarIncrease;
    private RawImage AireBarDecrease;
    //public Text ForceValue0, ForceValue50, ForceValue100;



    void Start()
    {

        //ForceValue0.GetComponent<Text>();
        //ForceValue50.GetComponent<Text>();
        //ForceValue100.GetComponent<Text>();


    }
    void Update()
    {
        //if (force.value == 0)
        //{
        //    ForceValue0.text = "0%";
        //}
        //else if (force.value == 1)
        //{
        //    ForceValue0.text = "50%";
        //}
        //else if (force.value == 2)
        //{
        //    ForceValue0.text = "100%";
        //}
        //ForceValue.text = AirBar.value.ToString();
    }

    //public void OnValueChanged(float value)
    //{
    //    emissionModule.rateOverTime = value;
    //}

    public void AireBarIncreasefun()
    {
        force.value = force.value + 1;
        //emissionModule.rateOverTime = AirBar.value;
    }

    public void AireBarDecreasefun()
    {
        force.value = force.value - 1;
        //emissionModule.rateOverTime = AirBar.value;
    }
}
