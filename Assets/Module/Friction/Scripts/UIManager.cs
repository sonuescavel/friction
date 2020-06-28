using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace  Friction
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        public InstructionsController instructionsController;
      //  public MouseMovement mouseMovement;
        public AppConfig appConfig;
        public GameObject playPauseButton;
        public Sprite playSprite;
        public Sprite pauseSprite;
        public Camera cm;
      
        public MoveObject moveObject;
        public GameObject ExitInstructionMode, ExitInstructionModeAir;

        [Header("UI Properties")]
        public Button resetButton;
        public Button backButton;
        public Button slowButton;


        public SceneHandler sceneHandler;
      
        public Slider Slider;
        public float camMoveSpeed = 5f;

        public bool isPlayInstr;
        private float _speedFactor = 0.5f;

        public Color buttonClickColor = new Color();
        public Color buttonUnClickColor = new Color();

        public bool isSlowInstr;

        public void Awake()
        {
            instance = this;
        }

        public void PlayPauseGame()
        {
            isPlayInstr = !isPlayInstr;

            if (isPlayInstr)
            {
                Time.timeScale = 0f;
                playPauseButton.GetComponent<Image>().sprite = playSprite;
            }
            else
            {
                Time.timeScale = 1f;
                playPauseButton.GetComponent<Image>().sprite = pauseSprite;
            }
        }
        public void Slowspeed()
        {
            Time.timeScale = 0.2f;
            //if (Time.timeScale > (_speedFactor + 0.1f))
            //{
            //    Time.timeScale = Time.timeScale - _speedFactor;
            //    Debug.Log("Slow" + Time.timeScale);
            //}

           
        }

     

       
        public void Reset()
        {
            Time.timeScale = 1f;
            CameraSwitchFriction.instance.mainCam.transform.parent = null;
            CameraSwitchFriction.instance.FrontView();
            Camera.main.fieldOfView = 60f;
            MouseMovement.instance.cameraZoomInOutSlider.value = 60f;
          
            if (SolidAirMediumSelection.instance.isSolidSelected)
            {
                FrictionHandler.instance.ResetSolid();

                if (InstructionDataScriptFriction.instance.isInstructionClick)
                {
                    playPauseButton.GetComponent<Button>().interactable = false;
                    slowButton.interactable = false;
                    InstructionDataScriptFriction.instance.resetClickI.SetActive(false);
                    resetButton.interactable = false;
                    SolidAirMediumSelection.instance.airButton.GetComponent<Button>().interactable = true;
                    InstructionDataScriptFriction.instance.airClickI.SetActive(true);
                    FrictionHandler.instance.SmothSelected();
                }
            }
            if (SolidAirMediumSelection.instance.isAirSelected)
            {
                GravitationalHandler.instance._ball.transform.localPosition = new Vector3(1.484f, 57.23f, -4.316249f);
                GravitationalHandler.instance._ball.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                GravitationalHandler.instance._ball.transform.localScale = new Vector3(1, 1, 1);
                GravitationalHandler.instance._feather.transform.localPosition = new Vector3(3.87f, 37.64f, -4.566249f);
                GravitationalHandler.instance._feather.transform.localScale = new Vector3(1, 1, 1);
                GravitationalHandler.instance._feather.transform.rotation = Quaternion.Euler(-11.223f, 90.00001f, 0f);
                GravitationalHandler.instance._ball_rigidbody.isKinematic = true;
                GravitationalHandler.instance._feather_rigidbody.isKinematic = true;
                GravitationalHandler.instance.airBarSlider.value = 0;

                //uIManager.Slider.value = 70;
                GravitationalHandler.instance.isExperimentDone =false;
                GravitationalHandler.instance.breakpoint.SetActive(false);
                GravitationalHandler.instance.frictionArrowValue = 0f;
                GravitationalHandler.instance.arrowScale = 0f;
                GravitationalHandler.instance.airFrictionArrowRed.GetComponent<RectTransform>().localScale = new Vector3(1, 0, 1);
                GravitationalHandler.instance.weightArrowBlue.SetActive(false);
                GravitationalHandler.instance.airFrictionArrowRed.SetActive(false);
                GravitationalHandler.instance.airFrictionText.SetActive(false);
                //GravitationalHandler.instance.assumptionButton.interactable = true;
                GravitationalHandler.instance.slowMotionButton.interactable = true;
                GravitationalHandler.instance.playPauseButton.SetActive(true);
                GravitationalHandler.instance.pauseButton.SetActive(false);
                GravitationalHandler.instance.isSlowMotion = false;
                GravitationalHandler.instance.playPauseButton.GetComponent<Button>().interactable = true;
                GravitationalHandler.instance.pauseButton.GetComponent<Button>().interactable = true;
                GravitationalHandler.instance.fallButton.interactable = true;
                VaccumeAir.instance.airRemoveSlider.interactable =true;
                GravitationalHandler.instance.increaseAirButton.interactable = true;
                GravitationalHandler.instance.decreaseAirButton.interactable = true;
                ObjectMouseHover.instance.boxWithoutFracture.SetActive(true);
                ObjectMouseHover.instance.boxWithFracture.SetActive(false);
                GravitationalHandler.instance.isObjectDrop = false;
                GravitationalHandler.instance.timerCount = 0;
                GravitationalHandler.instance.timerValue.text = "00" + " : " + "000";
                GravitationalHandler.instance.fetherWithBall.SetActive(true);
                GravitationalHandler.instance.fetherWithouthBall.SetActive(false);
                //for (int i = 0; i < GravitationalHandler.instance.boxFractorCs.Length-1; i++)
                //{
                //    GravitationalHandler.instance.boxFractorCs[i].GetComponent<Rigidbody>().isKinematic = false;
                //    GravitationalHandler.instance.boxFractorCs[i].transform.localPosition = GravitationalHandler.instance.boxFStartG[i].transform.localPosition;
                //    GravitationalHandler.instance.boxFractorCs[i].transform.localEulerAngles = GravitationalHandler.instance.boxFStartG[i].transform.localEulerAngles;
                //}

                if (InstructionDataScriptFriction.instance.isInstructionClick)
                {
                    InstructionDataScriptFriction.instance.resetClickI.SetActive(false);
                    UIManager.instance.resetButton.interactable = false;
                    InstructionDataScriptFriction.instance.slowMotionDropI.SetActive(true);
                    GravitationalHandler.instance.slowMotionButton.interactable =true;
                    GravitationalHandler.instance.playPauseButton.GetComponent<Button>().interactable = false;
                    VaccumeAir.instance.airRemoveSlider.interactable = false;
                    GravitationalHandler.instance.increaseAirButton.interactable = false;
                    GravitationalHandler.instance.decreaseAirButton.interactable = false;
                }

            }

        }

        public void ApplicationQuit()
        {
            Application.Quit();
        }
    }
}


