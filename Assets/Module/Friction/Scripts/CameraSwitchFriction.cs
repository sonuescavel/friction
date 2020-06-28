using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Friction
{
    public class CameraSwitchFriction : MonoBehaviour
    {
        public static CameraSwitchFriction instance;

        public GameObject mainCam;
        public GameObject frontPosSolid;
        public GameObject frontPosAir;
        public GameObject leftPosAir;
        public GameObject rightPosAir;
        public GameObject topPosAir;
        public GameObject airStartPos;
        public GameObject airLastPos;
        public GameObject airCloseViewPos;

        [Header("UI Preoperties")]
        public Button frontButton;
        public Button rightButton;
        public Button leftButton;
        public Button topButton;
        

        public float camMoveSpeed = 1f;
        public bool isLeft;

        public Text cameraViewText;
        public void Awake()
        {
            instance = this;
        }

        public void FrontView()
        {
            cameraViewText.text = "Front View";
           
            if (SolidAirMediumSelection.instance.isSolidSelected)
            {
                iTween.MoveTo(mainCam.gameObject, frontPosSolid.transform.localPosition, camMoveSpeed);
                iTween.RotateTo(mainCam.gameObject, frontPosSolid.transform.localEulerAngles, camMoveSpeed);
            }

            if (SolidAirMediumSelection.instance.isAirSelected)
            {
                iTween.MoveTo(mainCam.gameObject, frontPosAir.transform.localPosition, camMoveSpeed);
                iTween.RotateTo(mainCam.gameObject, frontPosAir.transform.localEulerAngles, camMoveSpeed);

                if (InstructionDataScriptFriction.instance.isInstructionClick && isLeft)
                {
                    isLeft = false;
                    InstructionDataScriptFriction.instance.frontCamI.SetActive(false);
                    frontButton.interactable = false;
                    GravitationalHandler.instance.assumptionButton.interactable = true;
                    InstructionDataScriptFriction.instance.assumptionI.SetActive(true);
                }
            }
        }

        public void LeftView()
        {
            cameraViewText.text = "Left View";
          
            iTween.MoveTo(mainCam.gameObject, leftPosAir.transform.localPosition, camMoveSpeed);
            iTween.RotateTo(mainCam.gameObject, leftPosAir.transform.localEulerAngles, camMoveSpeed);

            if (InstructionDataScriptFriction.instance.isInstructionClick)
            {
                isLeft = true;
                InstructionDataScriptFriction.instance.leftCamI.SetActive(false);
                leftButton.interactable = false;
                frontButton.interactable = true;
                InstructionDataScriptFriction.instance.frontCamI.SetActive(true);
            }
        }
          public void RightView()
        {
            cameraViewText.text = "Right View";
           
            iTween.MoveTo(mainCam.gameObject, rightPosAir.transform.localPosition, camMoveSpeed);
            iTween.RotateTo(mainCam.gameObject, rightPosAir.transform.localEulerAngles, camMoveSpeed);
        }
        public void TopView()
        {
            cameraViewText.text = "Top View";
            
            iTween.MoveTo(mainCam.gameObject, topPosAir.transform.localPosition, camMoveSpeed);
            iTween.RotateTo(mainCam.gameObject, topPosAir.transform.localEulerAngles, camMoveSpeed);
        }
    }
}