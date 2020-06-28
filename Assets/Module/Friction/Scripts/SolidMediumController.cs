using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Friction
{
    public class SolidMediumController : MonoBehaviour
    {
        public static SolidMediumController instance;

        public bool isForceSet;
        public bool isForceInstr;
        public Slider forceSlider;
        public Button forceIncreaseButton;
        public Button forceDecreaseButton;

        public GameObject forceSetMessage;
        public GameObject boxSetMessage;

        public Text forceValue;
        public void Awake()
        {
            instance = this;
        }

       
        public void ChangeForceSlider(int value)
        {
            if (forceSlider.value == 0)
            {
                isForceSet = false;
                forceValue.text = "N";
            }
            if (forceSlider.value == 1)
            {
                isForceSet = true;
                HandMove.instance.boxMoveSpeed =15f;
                SolidMediumController.instance.forceSetMessage.SetActive(false);
                forceValue.text = "20 N";
                if (InstructionDataScriptFriction.instance.isInstructionClick && !isForceInstr)
                {
                    isForceInstr = true;
                    InstructionDataScriptFriction.instance.forceSliderI.SetActive(false);
                    forceSlider.interactable = false;
                    GetValues.instance.ArrowC.GetComponent<Button>().interactable = true;
                    GetValues.instance.Arrow.GetComponent<Button>().interactable = true;
                    InstructionDataScriptFriction.instance.surfaceEnableI.SetActive(true);

                }
                
            }
            if (forceSlider.value == 2)
            {
                isForceSet = true;
                HandMove.instance.boxMoveSpeed =25f;
                SolidMediumController.instance.forceSetMessage.SetActive(false);
                forceValue.text = "40 N";
                if (InstructionDataScriptFriction.instance.isInstructionClick && !isForceInstr)
                {
                    isForceInstr = true;
                    InstructionDataScriptFriction.instance.forceSliderI.SetActive(false);
                    forceSlider.interactable = false;
                    GetValues.instance.ArrowC.GetComponent<Button>().interactable = true;
                    GetValues.instance.Arrow.GetComponent<Button>().interactable = true;
                    InstructionDataScriptFriction.instance.surfaceEnableI.SetActive(true);

                }
            }
            if (forceSlider.value == 3)
            {
                isForceSet = true;
                HandMove.instance.boxMoveSpeed = 35f;
                SolidMediumController.instance.forceSetMessage.SetActive(false);
                forceValue.text = "60 N";
                if (InstructionDataScriptFriction.instance.isInstructionClick && !isForceInstr)
                {
                    isForceInstr = true;
                    InstructionDataScriptFriction.instance.forceSliderI.SetActive(false);
                    forceSlider.interactable = false;
                    GetValues.instance.ArrowC.GetComponent<Button>().interactable = true;
                    GetValues.instance.Arrow.GetComponent<Button>().interactable = true;
                    InstructionDataScriptFriction.instance.surfaceEnableI.SetActive(true);

                }
            }

            if (forceSlider.value == 4)
            {
                isForceSet = true;
                HandMove.instance.boxMoveSpeed = 45f;
                SolidMediumController.instance.forceSetMessage.SetActive(false);
                forceValue.text = "80 N";
                if (InstructionDataScriptFriction.instance.isInstructionClick && !isForceInstr)
                {
                    isForceInstr = true;
                    InstructionDataScriptFriction.instance.forceSliderI.SetActive(false);
                    forceSlider.interactable = false;
                    GetValues.instance.ArrowC.GetComponent<Button>().interactable = true;
                    GetValues.instance.Arrow.GetComponent<Button>().interactable = true;
                    InstructionDataScriptFriction.instance.surfaceEnableI.SetActive(true);

                }
            }

            if (forceSlider.value == 5)
            {
                isForceSet = true;
                HandMove.instance.boxMoveSpeed = 55f;
                SolidMediumController.instance.forceSetMessage.SetActive(false);
                forceValue.text = "100 N";
                if (InstructionDataScriptFriction.instance.isInstructionClick && !isForceInstr)
                {
                    isForceInstr = true;
                    InstructionDataScriptFriction.instance.forceSliderI.SetActive(false);
                    forceSlider.interactable = false;
                    GetValues.instance.ArrowC.GetComponent<Button>().interactable = true;
                    GetValues.instance.Arrow.GetComponent<Button>().interactable = true;
                    InstructionDataScriptFriction.instance.surfaceEnableI.SetActive(true);

                }
            }

        }


    }

}
