using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace Friction
{
    public class MouseMovement : MonoBehaviour
    {
        public static MouseMovement instance;

        public GameObject target;
      
        public float xSpeed = 120.0f;
        public float ySpeed = 120.0f;
        public float distance = 5.0f;
        public float distanceMin = .5f;
        public float distanceMax = 15f;
        public float yMinLimit = 0f;
        public float yMaxLimit = 90f;
        float TouchZoomSpeed = 0.1f;
        float ZoomMinBound = 20f;
        float ZoomMaxBound = 80f;

        public float lableShowLimit = 25f;

        Vector3 lastPosition;
        Vector3 negDistance;

        float x = 0.0f;
        float y = 0.0f;

        Vector3 clickedMousePosition, leavedMousePosition;

        public float minZoomV = 20f;
        public float maxZoomV = 70f;
        public float cameraZoomINOutValue;

        public bool isScrolling;
        public bool isOrbiting;

        [Header("UI properties")]
        public GameObject cameraSliderContainer;
        public Slider cameraZoomInOutSlider;
        public Button cameraZoomInButton;
        public Button cameraZoomOutButton;

        public GameObject mobileControlMessage;
        // mobile variables
        Vector2 firstpoint;
        private Vector2 secondpoint;
        private float xAngle; //angle for axes x for rotation
        private float yAngle;
        private float xAngTemp; //temp variablor angle
        private float yAngTemp;

        public void Awake()
        {
            instance = this;
        }
        void Start()
        {
            Vector3 angles = transform.eulerAngles;
            x = angles.y;
            y = angles.x;
            negDistance = new Vector3(0f, 0f, -distance);

#if UNITY_ANDROID
            xAngle = x;
            yAngle = y;
            xSpeed = 60f;
            ySpeed = 60f;
            if (PlayerPrefs.GetInt("seenMobileInputInfo") == 0)
            {
                mobileControlMessage.SetActive(true);
                PlayerPrefs.SetInt("seenMobileInputInfo", 1);
            }
#endif



        }

        void TouchZoom()
        {
            // Pinch to zoom
            if (Input.touchCount >= 2)
            {
                if (InstructionDataScriptFriction.instance.isInstructionClick)
                {
                    isScrolling = true;
                }
                
                // get current touch positions
                Touch tZero = Input.GetTouch(0);
                Touch tOne = Input.GetTouch(1);
                // get touch position from the previous frame
                Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
                Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;

                float oldTouchDistance = Vector2.Distance(tZeroPrevious, tOnePrevious);
                float currentTouchDistance = Vector2.Distance(tZero.position, tOne.position);

                // get offset value
                float deltaDistance = oldTouchDistance - currentTouchDistance;
                Zoom(deltaDistance, TouchZoomSpeed);

                // different 

                if (InstructionDataScriptFriction.instance.isInstructionClick && isScrolling)
                {
                    InstructionDataScriptFriction.instance.camOrbitI.SetActive(true);
                    InstructionDataScriptFriction.instance.camZoomI.SetActive(false);
                    //  isScrolling = false;
                }
            }
            else if (target && Input.touchCount == 1/* && Input.GetTouch(0).position.x > Screen.width / 2*/ && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Orbit(Input.GetTouch(0));

            }

            else if (Input.GetTouch(0).phase == TouchPhase.Ended && Input.touchCount == 1)
            {
                if (InstructionDataScriptFriction.instance.isInstructionClick && !InstructionDataScriptFriction.instance.isScrollInstr)
                {
                    isOrbiting = true;
                    InstructionDataScriptFriction.instance.camOrbitI.SetActive(false);
                    if (isScrolling)
                    {
                        isScrolling = false;
                        CameraSwitchFriction.instance.mainCam.GetComponent<MouseMovement>().enabled = false;
                        CameraSwitchFriction.instance.FrontView();
                        InstructionDataScriptFriction.instance.fiftyBoxClickI.SetActive(true);
                        FiftyKGBOxMove.instance.fiftyKgBoxObject.GetComponent<BoxCollider>().enabled = true;
                    }


                }
            }
        }
        void Orbit(Touch touch)
        {
            if (!MouseCursor.obstacle)
            {
                x += touch.deltaPosition.x * xSpeed * 0.005f /* * distance*/;
                y -= touch.deltaPosition.y * ySpeed * 0.005f /* * distance*/;
                y = ClampAngle(y, yMinLimit, yMaxLimit);

                Quaternion rotation = Quaternion.Euler(y, x, 0);

                //distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

                //RaycastHit hit;

                //if (Physics.Linecast(target.position, transform.position, out hit))
                //{
                //}
                Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
                Vector3 position = rotation * negDistance + target.transform.position;
                transform.rotation = rotation;
                transform.position = position;

            }
        }

        void Zoom(float deltaMagnitudeDiff, float speed)
        {
            Camera.main.fieldOfView += deltaMagnitudeDiff * speed;
            // set min and max value of Clamp function upon your requirement
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, ZoomMinBound, ZoomMaxBound);
            cameraZoomInOutSlider.value = Camera.main.fieldOfView;
        }


        void LateUpdate()
        {
           
            if (Application.platform == RuntimePlatform.Android)
            {
                if (SolidAirMediumSelection.instance.isSolidSelected)
                {
                    TouchZoom();
                }
               
            }
            else
            {
                if (SolidAirMediumSelection.instance.isSolidSelected)
                {
                    if (Input.GetMouseButtonDown(0))
                    {

                        clickedMousePosition = Input.mousePosition;
                    }

                    if (Input.GetMouseButton(0) && !MouseCursor.obstacle)
                    {

                        //Debug.Log("inside mouse movement, why it is not moving?");

                        // if distance is more than 0.1 then mouse is dragged.
                        if (Vector3.Distance(clickedMousePosition, leavedMousePosition) > 0.1f)
                        {
                            // CameraSwitchBellJar.instance.objectLables.SetActive(false);
                            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                            y = ClampAngle(y, yMinLimit, yMaxLimit);

                            Quaternion rotation = Quaternion.Euler(y, x, 0);


                            Vector3 position = target.transform.position + rotation * new Vector3(negDistance.x, 0.0f, negDistance.z);



                            transform.rotation = rotation;
                            transform.position = position;

                            float angleLimit = Mathf.Lerp(-40f, 40, Mathf.InverseLerp(0f, 40f, (transform.localEulerAngles.y)));
                            //Debug.Log(angleNeedle);



                        }
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        if (InstructionDataScriptFriction.instance.isInstructionClick && !InstructionDataScriptFriction.instance.isScrollInstr)
                        {
                            isOrbiting = true;
                            InstructionDataScriptFriction.instance.camOrbitI.SetActive(false);
                            if (isScrolling)
                            {
                                isScrolling = false;
                                CameraSwitchFriction.instance.mainCam.GetComponent<MouseMovement>().enabled = false;
                                CameraSwitchFriction.instance.FrontView();
                                InstructionDataScriptFriction.instance.fiftyBoxClickI.SetActive(true);
                                FiftyKGBOxMove.instance.fiftyKgBoxObject.GetComponent<BoxCollider>().enabled = true;
                            }


                        }
                    }


                }



                if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
                {
                    if (InstructionDataScriptFriction.instance.isInstructionClick)
                    {
                        isScrolling = true;
                    }

                    float value = Camera.main.fieldOfView;
                    value++;
                    float v = Mathf.Clamp(value, minZoomV, maxZoomV);
                    //Debug.Log("value : " + v);
                    Camera.main.fieldOfView = v;
                    cameraZoomInOutSlider.value = v;
                }
                if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
                {
                    if (InstructionDataScriptFriction.instance.isInstructionClick)
                    {
                        isScrolling = true;
                    }
                    float value = Camera.main.fieldOfView;
                    value--;
                    float v = Mathf.Clamp(value, minZoomV, maxZoomV);
                    Camera.main.fieldOfView = v;
                    cameraZoomInOutSlider.value = v;
                }

                if (InstructionDataScriptFriction.instance.isInstructionClick && isScrolling)
                {
                    InstructionDataScriptFriction.instance.camOrbitI.SetActive(true);
                    InstructionDataScriptFriction.instance.camZoomI.SetActive(false);
                    //  isScrolling = false;
                }
            }

            
        }

        public void CameraZoomIn()
        {
            if (Camera.main.fieldOfView > minZoomV)
            {
                if (InstructionDataScriptFriction.instance.isInstructionClick)
                {
                    isScrolling = true;
                }
               
                float value = Camera.main.fieldOfView;
                value = value - 1;
                float v = Mathf.Clamp(value, minZoomV, maxZoomV);
                Camera.main.fieldOfView = value;
                cameraZoomInOutSlider.value = value;
                //if (InstructionDataScript.instance.isInstructionClick)
                //{
                //    InstructionDataScript.instance.cameraZoomINOutI.SetActive(false);
                //    InstructionDataScript.instance.cameraOrbitI.SetActive(true);
                //}
            }

        }

        public void SliderValueCameraChanged(int newValue)
        {
            cameraZoomINOutValue = cameraZoomInOutSlider.value;
            Camera.main.fieldOfView = cameraZoomINOutValue;
        }

        public void CameraZoomOut()
        {
            if (Camera.main.fieldOfView < maxZoomV)
            {
                if (InstructionDataScriptFriction.instance.isInstructionClick)
                {
                    isScrolling = true;
                }
               
                float value = Camera.main.fieldOfView;
                value = value + 1;
                float v = Mathf.Clamp(value, minZoomV, maxZoomV);
                Debug.Log("value : " + v);
                Camera.main.fieldOfView = value;
                cameraZoomInOutSlider.value = value;
            }

        }

        public static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360F)
                angle += 360F;
            if (angle > 360F)
                angle -= 360F;
            return Mathf.Clamp(angle, min, max);
        }
    }
}


