using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace Friction
{
    public class InstructionDataScriptFriction : MonoBehaviour
    {
        public static InstructionDataScriptFriction instance;

        [Header("UI Properties")]
        public GameObject instructionImage;
        public GameObject instructionButton;
        public GameObject exitInstructionMode;
        public GameObject objectivePanel;
        public RectTransform objectiveTrans;
        public GameObject camZoomI;
        public GameObject camOrbitI;
        public GameObject fiftyBoxClickI;
        public GameObject forceSliderI;
        public GameObject pauseGameI;
        public GameObject palyGameI;
        public GameObject resetBoxPosI;
        public GameObject slowMotionI;
        public GameObject surfaceEnableI;
        public GameObject greesySurfaceI;
        public GameObject handClickI;
        public GameObject resetClickI;
        public GameObject airClickI;
        public GameObject leftCamI;
        public GameObject frontCamI;
        public GameObject assumptionI;
        public GameObject increaseAirI;
        public GameObject objectDropI;
        public GameObject observeDropI;
        public GameObject slowMotionDropI;
        public GameObject instructionDoneM;

        public bool isInstructionClick;
        public bool isScrollInstr;
        public bool isorbitInstr;

        public GameObject postProcessing;
        public PostProcessProfile instructionModeProfile;

        public void Awake()
        {
            instance = this;
        }


        public void InstructionClick()
        {
            UIManager.instance.Reset();
            SolidAirMediumSelection.instance.SolidMediumSelect();
            isInstructionClick = true;

            instructionButton.SetActive(false);
            exitInstructionMode.SetActive(true);
            objectiveTrans.DOAnchorPos(new Vector2(0f, -1200f), 1f);
            postProcessing.GetComponent<PostProcessVolume>().profile = instructionModeProfile;

            //disable all buttons interactablity
            CameraSwitchFriction.instance.mainCam.GetComponent<MouseMovement>().enabled = false;
            UIManager.instance.resetButton.interactable = false;
            UIManager.instance.backButton.interactable = false;
            UIManager.instance.slowButton.interactable = false;
            UIManager.instance.playPauseButton.GetComponent<Button>().interactable = false;
            MouseMovement.instance.cameraZoomInOutSlider.interactable = false;
            MouseMovement.instance.cameraZoomOutButton.interactable = false;
            MouseMovement.instance.cameraZoomInButton.interactable = false;

            HundredKGBoxMove.instance.hundredKgBoxObject.GetComponent<BoxCollider>().enabled = false;
            TenKGBoxMove.instance.tenKgBoxObject.GetComponent<BoxCollider>().enabled = false;
            FiftyKGBOxMove.instance.fiftyKgBoxObject.GetComponent<BoxCollider>().enabled = false;

            SolidAirMediumSelection.instance.solidButton.GetComponent<Button>().interactable = false;
            SolidAirMediumSelection.instance.airButton.GetComponent<Button>().interactable = false;
            SolidMediumController.instance.forceSlider.interactable = false;
            SolidMediumController.instance.forceIncreaseButton.interactable = false;
            SolidMediumController.instance.forceDecreaseButton.interactable = false;
            FrictionHandler.instance.dropArrowButton.interactable = false;

            for (int i = 0; i < FrictionHandler.instance.surfaceButton.Length; i++)
            {
                FrictionHandler.instance.surfaceButton[i].interactable = false;
            }
           
        }

        public void ObjectiveClick()
        {
            objectivePanel.SetActive(false);
            CameraSwitchFriction.instance.mainCam.GetComponent<MouseMovement>().enabled = true;
            camZoomI.SetActive(true);
        }

        public void CameraZoomInOut()
        {
            isScrollInstr = true;
            camZoomI.SetActive(false);
            camOrbitI.SetActive(true);
            Camera.main.fieldOfView = 50f;
            MouseMovement.instance.cameraZoomInOutSlider.value = 50f;
        }

        public void CameraOrbit()
        {
            camOrbitI.SetActive(false);
            CameraSwitchFriction.instance.mainCam.GetComponent<MouseMovement>().enabled = false;
            CameraSwitchFriction.instance.FrontView();
            fiftyBoxClickI.SetActive(true);
            FiftyKGBOxMove.instance.fiftyKgBoxObject.GetComponent<BoxCollider>().enabled = true;
            Camera.main.fieldOfView = 60f;
            MouseMovement.instance.cameraZoomInOutSlider.value = 60f;
        }

        public void ResetSceneI()
        {
              SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}