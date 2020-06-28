using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEngine.ParticleSystem;


namespace Friction
{
    public class VaccumeAir : MonoBehaviour
    {
        public static VaccumeAir instance;

        public Slider airRemoveSlider;
        //public ParticleSystem myParticleSystem;
        //private EmissionModule emissionModule;
        private RawImage AireBarIncrease;
        private RawImage AireBarDecrease;
        public Text ForceValue0, ForceValue50, ForceValue100;

        public void Awake()
        {
            instance = this;
        }

        void Start()
        {

            ForceValue0.GetComponent<Text>();
            ForceValue50.GetComponent<Text>();
            ForceValue100.GetComponent<Text>();


        }
        void Update()
        {
            if (airRemoveSlider.value == 0)
            {
                ForceValue0.text = "0%";
            }
            else if (airRemoveSlider.value == 1)
            {
                ForceValue0.text = "50%";
            }
            else if (airRemoveSlider.value == 2)
            {
                ForceValue0.text = "100%";
            }
            //ForceValue.text = AirBar.value.ToString();
        }

        //public void OnValueChanged(float value)
        //{
        //    emissionModule.rateOverTime = value;
        //}

        public void AireBarIncreasefun()
        {
            airRemoveSlider.value = airRemoveSlider.value + 1;
            //emissionModule.rateOverTime = AirBar.value;

            if (InstructionDataScriptFriction.instance.isInstructionClick)
            {
                InstructionDataScriptFriction.instance.increaseAirI.SetActive(false);
                GravitationalHandler.instance.increaseAirButton.interactable = false;
                GravitationalHandler.instance.playPauseButton.GetComponent<Button>().interactable = true;
                InstructionDataScriptFriction.instance.objectDropI.SetActive(true);
                GravitationalHandler.instance.fallButton.interactable = true;
            }
    }

        public void AireBarDecreasefun()
        {
            airRemoveSlider.value = airRemoveSlider.value - 1;
            //emissionModule.rateOverTime = AirBar.value;
        }


    }
}
