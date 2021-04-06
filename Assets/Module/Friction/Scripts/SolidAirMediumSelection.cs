using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Friction
{
    public class SolidAirMediumSelection : MonoBehaviour
    {
        public static SolidAirMediumSelection instance;

        [Header("UI preperties")]
        public GameObject solidButton;
        public GameObject airButton;
        public GameObject solidPanel;
        public GameObject airPanel;
     

        public GameObject solidObject;
        public GameObject airObject;

        public bool isSolidSelected;
        public bool isAirSelected;
        public void Awake()
        {
            instance = this;
        }

        public void SolidMediumSelect()
        {
            MediumCommonClick();
            isSolidSelected = true;
            isAirSelected = false;
            solidButton.GetComponent<Image>().color = UIManager.instance.buttonClickColor;
            solidObject.SetActive(true);
            solidPanel.SetActive(true);
            airObject.SetActive(false);
            MouseMovement.instance.cameraSliderContainer.SetActive(true);
            CameraSwitchFriction.instance.FrontView();
           // CameraSwitchFriction.instance.mainCam.GetComponent<MouseMovement>().enabled = true;
        }

        public void AirMediumSelect()
        {
            MediumCommonClick();
            isSolidSelected = false;
            isAirSelected = true;
            airButton.GetComponent<Image>().color = UIManager.instance.buttonClickColor;
            solidObject.SetActive(false);
            airPanel.SetActive(true);
            airObject.SetActive(true);
            MouseMovement.instance.cameraSliderContainer.SetActive(false);
            CameraSwitchFriction.instance.FrontView();
          //  CameraSwitchFriction.instance.mainCam.GetComponent<MouseMovement>().enabled = false;

            if (InstructionDataScriptFriction.instance.isInstructionClick)
            {
                InstructionDataScriptFriction.instance.airClickI.SetActive(false);
                airButton.GetComponent<Button>().interactable = false;
                GravitationalHandler.instance.slowMotionButton.interactable = false;
                GravitationalHandler.instance.assumptionButton.interactable = false;
                GravitationalHandler.instance.playPauseButton.GetComponent<Button>().interactable = false;
                CameraSwitchFriction.instance.frontButton.interactable =false;
                InstructionDataScriptFriction.instance.leftCamI.SetActive(true);
                CameraSwitchFriction.instance.leftButton.interactable =true;
                CameraSwitchFriction.instance.rightButton.interactable = false;
                CameraSwitchFriction.instance.topButton.interactable = false;
                GravitationalHandler.instance.airBarSlider.interactable = false;
                GravitationalHandler.instance.increaseAirButton.interactable = false;
                GravitationalHandler.instance.decreaseAirButton.interactable = false;
                GravitationalHandler.instance.fallButton.interactable = false;

            }
        }

        public void MediumCommonClick()
        {
            UIManager.instance.Reset();
            solidButton.GetComponent<Image>().color = UIManager.instance.buttonUnClickColor;
            airButton.GetComponent<Image>().color = UIManager.instance.buttonUnClickColor;
            solidPanel.SetActive(false);
            airPanel.SetActive(false);
        }
    }
}
