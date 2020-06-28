using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Friction
{

    public class GravitationalHandler : MonoBehaviour
    {

        public static GravitationalHandler instance;

        [Header("UI Properties")]
        public GameObject assumptionPanel;
        public Text timerValue;
        public GameObject weightArrowBlue;
        public GameObject airFrictionArrowRed;
        public GameObject airFrictionText;
        public Button assumptionButton;

        public GameObject _feather;
        public GameObject _ball;
        public GameObject _ballFeatherPa;
        public GameObject breakpoint;
        public Slider airBarSlider;
        public Button increaseAirButton;
        public Button decreaseAirButton;
        public GameObject playPauseButton;
        public GameObject pauseButton;
        public Sprite playSprite;
        public Sprite pauseSprite;
        public Button slowMotionButton;
        //public GameObject AddAir;
        public Button fallButton;
        public Rigidbody _ball_rigidbody;
        public Rigidbody _feather_rigidbody;
       // public Rigi _ballFeatherPa_rigidbody;
        public GameObject Assumption;
        public GameObject fetherWithBall;
        public GameObject fetherWithouthBall;
 
       // public TimerSpeed timerspeed;
       // public UIManager uIManager;
        public AppConfig appConfig;
        public Vector3 initialPosition;

        public bool isAssumptionClick;
        public bool isObjectDrop;
        public bool isFrictionFifty;
        public bool isFrictionHundred;
        public bool isSlowMotion;
        public bool isExperimentDone;

        public GameObject[] boxFractorCs;
        public GameObject[] boxFStartG;

        public float timerCount;
        public string minutes;
        public string secounds;
        public string miliSecounds;

        public float arrowScale;
        public float frictionArrowValue;
        private float _arrowFFifty = 0.0025f;
        private float _arrowFHundred = 0.0025f;
        public void Awake()
        {
            instance = this;
        }

        void Start()
        {
            //for (int i = 0; i < boxFractorCs.Length-1; i++)
            //{
            //    boxFractorCs[i].GetComponent<Rigidbody>().isKinematic = true;
            //    boxFStartG[i].transform.localPosition = boxFractorCs[i].transform.localPosition;
            //    boxFStartG[i].transform.localEulerAngles = boxFractorCs[i].transform.localEulerAngles;
            //}

        }

        public void FixedUpdate()
        {
            if (isObjectDrop)
            {
                timerCount += 1 * Time.fixedDeltaTime;
                minutes = ((int)timerCount / 60).ToString("00");
                secounds = ((int)timerCount % 60).ToString("00");
                miliSecounds = ((int)(timerCount * 1000f) % 1000f).ToString("00");
                timerValue.text = secounds + " : " + miliSecounds;

                if (isFrictionFifty)
                {
                    if (arrowScale <= 0.5f)
                    {
                        arrowScale = arrowScale + frictionArrowValue;
                        airFrictionArrowRed.GetComponent<RectTransform>().localScale = new Vector3(1, arrowScale, 1);
                    }

                }
                if (isFrictionHundred)
                {
                    if (arrowScale <= 0.75f)
                    {
                        arrowScale = arrowScale + frictionArrowValue;
                        airFrictionArrowRed.GetComponent<RectTransform>().localScale = new Vector3(1, arrowScale, 1);
                    }

                }

            }
          
        }

        public void AssumptionClick()
        {
            isAssumptionClick = !isAssumptionClick;
            if (isAssumptionClick)
            {
                assumptionPanel.SetActive(true);

                if (InstructionDataScriptFriction.instance.isInstructionClick)
                {
                    assumptionButton.interactable = false;
                    InstructionDataScriptFriction.instance.assumptionI.SetActive(false);
                    InstructionDataScriptFriction.instance.increaseAirI.SetActive(true);
                    GravitationalHandler.instance.increaseAirButton.interactable = true;
                }
            }
            else
            {

                assumptionPanel.SetActive(false);
            }
           
        }

        public void PauseScene()
        {
            Time.timeScale = 0f;
            playPauseButton.SetActive(true);
            pauseButton.SetActive(false);
        }

        public void PlayPause()
        {
            if (!isSlowMotion)
            {
                Time.timeScale = 1f;
            }
            else
            {

                Time.timeScale = 0.5f;
            }
          
            playPauseButton.SetActive(false);
            pauseButton.SetActive(true);
            isObjectDrop = true;
           // assumptionButton.interactable = false;
            isAssumptionClick= true;
            AssumptionClick();
            slowMotionButton.interactable = false;

            //CameraSwitchFriction.instance.mainCam.transform.SetParent(_ball.transform, true);
            
            CameraSwitchFriction.instance.mainCam.transform.localPosition = CameraSwitchFriction.instance.airStartPos.transform.localPosition;
            CameraSwitchFriction.instance.mainCam.transform.localEulerAngles = CameraSwitchFriction.instance.airStartPos.transform.localEulerAngles;
            iTween.MoveTo(CameraSwitchFriction.instance.mainCam.gameObject, CameraSwitchFriction.instance.airLastPos.transform.localPosition, 10);
            iTween.RotateTo(CameraSwitchFriction.instance.mainCam.gameObject, CameraSwitchFriction.instance.airLastPos.transform.localEulerAngles, 10);
            if (VaccumeAir.instance.airRemoveSlider.value == 0 || VaccumeAir.instance.airRemoveSlider.value == 2 || VaccumeAir.instance.airRemoveSlider.value == 1)
            {
                if (VaccumeAir.instance.airRemoveSlider.value == 0)
                {
                    fetherWithBall.SetActive(true);
                    fetherWithouthBall.SetActive(false);
                    isFrictionFifty = false;
                    isFrictionHundred = false;
                    weightArrowBlue.SetActive(true);
                    airFrictionText.SetActive(false);
                    airFrictionArrowRed.SetActive(true);
                    fallButton.interactable = false;
                   // timerspeed.playing = true;
                  
                    _feather_rigidbody.isKinematic = false;
                    _ball_rigidbody.isKinematic = false;
                    
                    _feather_rigidbody.drag = 0;
                    _ball_rigidbody.drag = 0;
                    float ballSpeed = 2250f;
                    float featherSpeed = 2300f;
                    _feather_rigidbody.velocity = Vector3.down * featherSpeed*Time.fixedDeltaTime;
                    _ball_rigidbody.velocity = Vector3.down * ballSpeed*Time.fixedDeltaTime;
                    frictionArrowValue = 0;
                }
                else if (VaccumeAir.instance.airRemoveSlider.value == 1)
                {
                    fetherWithBall.SetActive(false);
                    fetherWithouthBall.SetActive(true);
                    isFrictionFifty = true;
                    isFrictionHundred = false;
                    weightArrowBlue.SetActive(true);
                    airFrictionText.SetActive(true);
                    airFrictionArrowRed.SetActive(true);
                    fallButton.interactable = false;
                    _ball_rigidbody.isKinematic = false;
                    _feather_rigidbody.isKinematic = false;
                    _ball_rigidbody.drag = 0.4f;
                    _feather_rigidbody.drag = 0.8f;
                    float ballSpeed = 2250f;
                    float featherSpeed = 2250f;
                    _feather_rigidbody.velocity = Vector3.down * featherSpeed * Time.fixedDeltaTime;
                    _ball_rigidbody.velocity = Vector3.down * ballSpeed * Time.fixedDeltaTime;
                    frictionArrowValue = _arrowFFifty;


                }
                else if (VaccumeAir.instance.airRemoveSlider.value == 2)
                {
                    fetherWithBall.SetActive(false);
                    fetherWithouthBall.SetActive(true);
                    isFrictionFifty = false;
                    isFrictionHundred = true;
                    weightArrowBlue.SetActive(true);
                    airFrictionText.SetActive(true);
                    airFrictionArrowRed.SetActive(true);
                    fallButton.interactable = false;
                   _ball_rigidbody.isKinematic = false;
                    _feather_rigidbody.isKinematic = false;
                    _ball_rigidbody.drag = 0.75f;
                    _feather_rigidbody.drag = 1.25f;
                    float ballSpeed = 2250f;
                    float featherSpeed = 2250f;
                    _feather_rigidbody.velocity = Vector3.down * featherSpeed * Time.fixedDeltaTime;
                    _ball_rigidbody.velocity = Vector3.down * ballSpeed * Time.fixedDeltaTime;
                    frictionArrowValue = _arrowFHundred;
                }
            }

            if (InstructionDataScriptFriction.instance.isInstructionClick)
            {
                InstructionDataScriptFriction.instance.objectDropI.SetActive(false);
                pauseButton.GetComponent<Button>().interactable = false;
                InstructionDataScriptFriction.instance.observeDropI.SetActive(true);
            }
            VaccumeAir.instance.airRemoveSlider.interactable = false;
            GravitationalHandler.instance.increaseAirButton.interactable = false;
            GravitationalHandler.instance.decreaseAirButton.interactable= false;

        }

        public void PlaySlowMotion()
        {
            isSlowMotion = true;
            Time.timeScale = 0.5f;
           // Debug.Log(Time.timeScale);
            PlayPause();

            if (InstructionDataScriptFriction.instance.isInstructionClick)
            {
                InstructionDataScriptFriction.instance.slowMotionDropI.SetActive(false);
                slowMotionButton.interactable = false;
                pauseButton.GetComponent<Button>().interactable = false;
            }
          
        }

    public void SetSelectedButton(Button button, Color color)
        {
            button.GetComponent<Image>().color = color;
        }

       
    }
}