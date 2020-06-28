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
        public Slider cameraZoomInOutSlider;
        public Button cameraZoomInButton;
        public Button cameraZoomOutButton;

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
        }

        void LateUpdate()
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

        public void CameraZoomIn()
        {
            if (Camera.main.fieldOfView > 20f)
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
            if (Camera.main.fieldOfView < 80f)
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


