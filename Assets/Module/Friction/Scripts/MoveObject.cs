
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

namespace Friction
{
    public class MoveObject : MonoBehaviour
    {
        // Start is called before the first frame update
        Vector3 newPostion;
        public GameObject boxMouseHoverPanel;
        public GameObject frictionArrow;
        public GameObject forceArrow;
        public GameObject frictionText;
        public GameObject forceText;
        Vector3 initialScaleForce;
        Vector3 initialScaleFriction;
        public Button ok, Reset, Resetimage, Slow;
        //  public use_case_name.MouseMovement mouseMovement;
        public SceneHandler sceneHandler;

        // public Button  yes, no;
        GameObject objectToTouched;
        public GameObject targetObject;
        public Vector3[] initialPosition;
       // public TextUi textui;
       // public RedBalloonController redBalloonController;
        public TimeManager timeManager;
        internal int clickedCount = 1;
        private bool canclickObjects = false;
        public GameObject Messageb;
        //public GameObject Messagebyesno;
        bool initialPositionSet = false;
        //public Material[] materialToCompare;
        public GameObject[] Objects;
        public Slider slider;
        public float animTime;
        // public GameObject ObjectToDetectCollision;
        GameObject collideOnObject;
        public GameObject Hands;
        // public Collider TenKg, FiftyKg,HundredKg;
        public GameObject TenKg1, FiftyKg1, HundredKg1;
        public PhysicMaterial[] phyMaterial;
        //SwapTecture swapTexture;
        public FrictionHandler frictionHandler;
        //public Renderer rendererMaterial;
        //public float speed = 200f;
        //private float startTime;
        //private float journeyLength;
        public GameObject ArrowC;
        public float currCountdownValue;
        float newSpeed;
        public GameObject Surfaces;
        public GameObject ObjectWoodenResetText, ObjectStoneResetText, ObjectMetalResetText;
        public GameObject ForceValue, ForceValue1, ForceValue2, ForceValue3;
        public Rigidbody rb;
      //  public OnLongClickPressed onLongClickPressed;
     //   public GameObject CanvasDesk;
        private void Awake()
        {
            //swapTexture = SwapTecture.instance;
            newPostion = targetObject.transform.position;
            initialScaleForce = forceArrow.transform.localScale;
            initialScaleFriction = frictionArrow.transform.localScale;
            for (int i = 0; i < Objects.Length; i++)
            {
                initialPosition[i] = Objects[i].transform.position;
            }

        }
        void Start()
        {
           // textui = GetComponent<TextUi>();
          //  redBalloonController = GetComponent<RedBalloonController>();

          //  onLongClickPressed = GetComponent<OnLongClickPressed>();
            rb = GetComponent<Rigidbody>();


        }

        public void OnMouseOver()
        {
            boxMouseHoverPanel.SetActive(true);
        }

        public void OnMouseExit()
        {
            boxMouseHoverPanel.SetActive(false);
        }
        private void Update()
        {

            for (int i = 0; i < Objects.Length; i++)
            {
                if (clickedCount == 3 && gameObject.transform.position == initialPosition[i])
                {
                    clickedCount = 1;
                }
            }
            if (slider.value == 0)
            {
                ForceValue.SetActive(true);
                ForceValue1.SetActive(false);
                ForceValue2.SetActive(false);
                ForceValue3.SetActive(false);
            }
            if (slider.value == 1)
            {
                ForceValue1.SetActive(true);
                ForceValue.SetActive(false);
                ForceValue2.SetActive(false);
                ForceValue3.SetActive(false);
                Messageb.SetActive(false);
            }
            if (slider.value == 2)
            {
                ForceValue2.SetActive(true);
                ForceValue1.SetActive(false);
                ForceValue.SetActive(false);
                ForceValue3.SetActive(false);
                Messageb.SetActive(false);
            }
            if (slider.value == 3)
            {
                ForceValue3.SetActive(true);
                ForceValue.SetActive(false);
                ForceValue2.SetActive(false);
                ForceValue1.SetActive(false);
                Messageb.SetActive(false);
            }
        }

        private void OnEnable()
        {

        }
        private void OnDisable()
        {
            StopAllCoroutines();
        }
        // Update is called once per frame

        public void OnTriggerEnter(Collider collision)
        {
            // gameObject.GetComponent<Rigidbody>().isKinematic = true;
            for (int i = 0; i < Objects.Length; i++)
            {
                Objects[i].GetComponent<Collider>().enabled = true;
            }
            // ObjectToDetectCollision.GetComponent<Collider>().enabled = false;
            slider.GetComponent<Slider>().interactable = true;
        }

        public void OnMouseDown()
        {
            canclickObjects = true;
            initialPositionSet = true;
            if (initialPositionSet == true)
            {
                for (int i = 0; i < Objects.Length; i++)
                {
                    if (gameObject != Objects[i])
                    {
                        Objects[i].transform.position = initialPosition[i];
                        Objects[i].GetComponent<Rigidbody>().useGravity = false;
                        //Objects[i].GetComponent<Animator>().enabled = true;
                    }
                }
            }
            objectToTouched = gameObject;
            newSpeed = slider.value;
            Debug.Log("Name:" + gameObject);

            if (clickedCount == 1)
            {
                //gameObject.transform.position = new Vector3(-0.44f, 2.25f, -1.06f);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<Animator>().enabled = true;
                Hands.GetComponent<Animator>().enabled = false;
                // CanvasDesk.SetActive(true);
                Hands.transform.localPosition = new Vector3(-1.68f, 2.01f, -1.14f);
                Hands.transform.localRotation = Quaternion.Euler(0.528f, -178.519f, -44.498f);
                Hands.transform.localScale = new Vector3(0.563f, 0.7354602f, 0.4762138f);
                Hands.SetActive(true);
                // redBalloonController.enabled = true;
                ObjectWoodenResetText.SetActive(false);
                ObjectStoneResetText.SetActive(false);
                ObjectMetalResetText.SetActive(false);
                //onLongClickPressed.enabled = false;

                //textui.slowB.SetActive(true);                          


                clickedCount++;
                for (int i = 0; i < Objects.Length; i++)
                {
                    if (gameObject != Objects[i])
                    {
                        Objects[i].GetComponent<Collider>().enabled = false;
                    }
                }

            }
            else if (clickedCount == 2)
            {

                if (slider.value == 0)
                {

                    Messageb.SetActive(true);

                }
                else
                 if (slider.value == 1)
                {
                    Hands.GetComponent<Animator>().enabled = true;
                    Messageb.SetActive(false);
                  //  timeManager.DoFastmotion();
                    // CanvasDesk.SetActive(false);
                    //onLongClickPressed.enabled = true;
                    ObjectWoodenResetText.SetActive(true);
                    ObjectStoneResetText.SetActive(true);
                    ObjectMetalResetText.SetActive(true);
                    forceArrow.SetActive(true);
                    frictionArrow.SetActive(true);
                    forceText.SetActive(true);
                    //redBalloonController.enabled = false;
                    Slow.interactable = false;
                    frictionText.SetActive(true);
                    // textui.enabled = true;
                    // textui.imagereset.SetActive(true);
                    // redBalloonController.imageText.SetActive(false);
                    canclickObjects = false;
                    gameObject.GetComponent<Animator>().enabled = false;
                    gameObject.GetComponent<Rigidbody>().useGravity = true;
                    gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    //Hands.transform.localPosition = new Vector3(0.48f, 2.460001f, -1.17f);
                    //Hands.transform.localRotation = Quaternion.Euler(0.366f, -178.471f, -38.362f);
                    //Hands.transform.localScale = new Vector3(0.563f, 0.7354602f, 0.4762138f);

                    gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * 40;

                    String matName = frictionHandler.Desk.GetComponent<MeshCollider>().sharedMaterial.name;
                    Debug.Log(matName);
                    if (matName == "Greasy")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.1f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 1f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 2f;
                        //rb.drag = 0.3f;
                        Debug.Log(" Greasy ");
                    }
                    if (matName == "Oily")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.2f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 1.05f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 2f;
                        // rb.drag = 0.4f;
                        Debug.Log(" oily ");
                    }
                    if (matName == "smooth")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.3f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 1.66f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 4f;
                        //  rb.drag = 0.5f;
                        Debug.Log(" Smooth ");
                    }
                    if (matName == "Slightly Rough")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.6f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 2.22f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 5f;
                        // rb.drag = 0.6f;                   
                        Debug.Log(" slightruf ");
                    }
                    if (matName == "Very Rough")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.8f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 4f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 11f;
                        // rb.drag = 0.7f;
                        Debug.Log(" veryruf ");
                    }
                    slider.GetComponent<Slider>().interactable = false;
                    Hands.SetActive(true);
                    gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 40);
                    StartCoroutine(ArrowScaling());
                    clickedCount++;
                    StartCoroutine(StartCountdown());
                    StartCoroutine(StartCountdownH());
                }
                else if (slider.value == 2)
                {
                    Hands.GetComponent<Animator>().enabled = true;
                 //   timeManager.DoFastmotion();
                  //  CanvasDesk.SetActive(false);
                  //  onLongClickPressed.enabled = true;
                    ObjectWoodenResetText.SetActive(true);
                    ObjectStoneResetText.SetActive(true);
                    Slow.interactable = false;
                    ObjectMetalResetText.SetActive(true);
                    forceArrow.SetActive(true);
                    frictionArrow.SetActive(true);
                 //   redBalloonController.enabled = false;
                    forceText.SetActive(true);
                    frictionText.SetActive(true);
                  //  textui.enabled = true;
                  //  textui.imagereset.SetActive(true);
                    canclickObjects = false;
                 //   redBalloonController.imageText.SetActive(false);
                    Hands.SetActive(true);
                    gameObject.GetComponent<Animator>().enabled = false;
                    Messageb.SetActive(false);

                    gameObject.GetComponent<Rigidbody>().useGravity = true;
                    gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    //Hands.transform.localPosition = new Vector3(0.48f, 2.460001f, -1.17f);
                    //Hands.transform.localRotation = Quaternion.Euler(0.366f, -178.471f, -38.362f);
                    //Hands.transform.localScale = new Vector3(0.563f, 0.7354602f, 0.4762138f);

                    gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * 50;

                    String matName = frictionHandler.Desk.GetComponent<MeshCollider>().sharedMaterial.name;
                    Debug.Log(matName);
                    if (matName == "Greasy")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.1f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 0.5f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 0.8f;
                        //rb.drag = 0.3f;
                        Debug.Log(" Greasy ");
                    }
                    if (matName == "Oily")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.2f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 0.7f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 1f;
                        // rb.drag = 0.4f;
                        Debug.Log(" oily ");
                    }
                    if (matName == "smooth")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.5f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 1f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 2f;
                        //  rb.drag = 0.5f;
                        Debug.Log(" Smooth ");
                    }
                    if (matName == "Slightly Rough")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.8f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 2f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 4f;
                        // rb.drag = 0.6f;                   
                        Debug.Log(" slightruf ");
                    }
                    if (matName == "Very Rough")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.9f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 3f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 6f;
                        // rb.drag = 0.7f;
                        Debug.Log(" veryruf ");
                    }

                    slider.GetComponent<Slider>().interactable = false;
                    gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 50);
                    StartCoroutine(ArrowScaling());
                    clickedCount++;
                    StartCoroutine(StartCountdown());
                    StartCoroutine(StartCountdownH());
                }
                else if (slider.value == 3)
                {
                    Hands.GetComponent<Animator>().enabled = true;
                   // timeManager.DoFastmotion();
                  //  CanvasDesk.SetActive(false);
                    Slow.interactable = false;
                 //   onLongClickPressed.enabled = true;
                    ObjectWoodenResetText.SetActive(true);
                    ObjectStoneResetText.SetActive(true);
                    ObjectMetalResetText.SetActive(true);
                    forceArrow.SetActive(true);
                    Hands.SetActive(true);
                    frictionArrow.SetActive(true);
                    forceText.SetActive(true);
                    frictionText.SetActive(true);
                   // textui.enabled = true;
                 //   redBalloonController.enabled = false;
                  //  textui.imagereset.SetActive(true);
                    canclickObjects = false;
                  //  redBalloonController.imageText.SetActive(false);
                    Messageb.SetActive(false);
                    gameObject.GetComponent<Animator>().enabled = false;
                    gameObject.GetComponent<Rigidbody>().useGravity = true;
                    gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    //Hands.transform.localPosition = new Vector3(0.48f, 2.460001f, -1.17f);
                    //Hands.transform.localRotation = Quaternion.Euler(0.366f, -178.471f, -38.362f);
                    //Hands.transform.localScale = new Vector3(0.563f, 0.7354602f, 0.4762138f);

                    gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * 100;
                    String matName = frictionHandler.Desk.GetComponent<MeshCollider>().sharedMaterial.name;
                    Debug.Log(matName);
                    if (matName == "Greasy")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.1f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 0.5f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 0.8f;
                        //rb.drag = 0.3f;
                        Debug.Log(" Greasy ");
                    }
                    if (matName == "Oily")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.2f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 0.7f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 1f;
                        // rb.drag = 0.4f;
                        Debug.Log(" oily ");
                    }
                    if (matName == "smooth")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.3f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 1f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 2f;
                        //  rb.drag = 0.5f;
                        Debug.Log(" Smooth ");
                    }
                    if (matName == "Slightly Rough")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.6f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 2f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 4f;
                        // rb.drag = 0.6f;                   
                        Debug.Log(" slightruf ");
                    }
                    if (matName == "Very Rough")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.8f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 3f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 6f;
                        // rb.drag = 0.7f;
                        Debug.Log(" veryruf ");
                    }
                    slider.GetComponent<Slider>().interactable = false;
                    gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 100);
                    StartCoroutine(ArrowScaling());
                    clickedCount++;
                    StartCoroutine(StartCountdown());
                    StartCoroutine(StartCountdownH());
                }

            }

            else if (clickedCount >= 3)
            {
              //  timeManager.DoFastmotion();
                //CanvasDesk.SetActive(false);
                Hands.SetActive(false);
                Slow.interactable = true;
                //textui.imagereset.SetActive(false);
             //  redBalloonController.imageText.SetActive(false);
               // textui.slowB.SetActive(false);
                forceArrow.SetActive(false);
                frictionArrow.SetActive(false);
                forceText.SetActive(false);
              //  onLongClickPressed.enabled = false;
                frictionText.SetActive(false);
             //   redBalloonController.enabled = false;
                Hands.GetComponent<Animator>().enabled = false;

                for (int i = 0; i < Objects.Length; i++)
                {
                    Objects[i].GetComponent<Collider>().enabled = true;
                    if (gameObject == Objects[i])
                    {
                        gameObject.transform.position = initialPosition[i];
                        gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    }
                }
                clickedCount = 1;
                currCountdownValue = 5;
                slider.GetComponent<Slider>().interactable = true;
              //  textui.enabled = true;
                ObjectWoodenResetText.SetActive(false);
                ObjectStoneResetText.SetActive(false);
                ObjectMetalResetText.SetActive(false);


                forceArrow.transform.localScale = initialScaleForce;
                frictionArrow.transform.localScale = initialScaleFriction;


                //Messagebyesno.SetActive(true);
            }
        }
        public IEnumerator StartCountdown()
        {
            if (currCountdownValue > 0)
            {
                Debug.Log("Countdown: " + currCountdownValue);
                yield return new WaitForSeconds(1.99f);
                currCountdownValue--;
                frictionArrow.SetActive(false);
                frictionText.SetActive(false);
                //CanvasDesk.SetActive(false);
                // Hands.SetActive(false);

            }
        }
        public IEnumerator StartCountdownH()
        {
            if (currCountdownValue > 0)
            {
                Debug.Log("Countdown: " + currCountdownValue);
                yield return new WaitForSeconds(0.1f);
                currCountdownValue--;
                forceArrow.SetActive(false);
                forceText.SetActive(false);
                //CanvasDesk.SetActive(false);
                // Hands.SetActive(false);

            }
        }
        public IEnumerator StartCountdownslow()
        {
            if (currCountdownValue > 0)
            {
                Debug.Log("Countdown: " + currCountdownValue);
                yield return new WaitForSeconds(0.1f);

                currCountdownValue--;
                //forceArrow.SetActive(false);
                //Slow.interactable = false;
                forceArrow.SetActive(false);
                //Slow.interactable = false;

                //frictionArrow.SetActive(false);
                forceText.SetActive(false);
                //CanvasDesk.SetActive(false);
                // Hands.SetActive(false);

            }
        }
        public IEnumerator StartCountdownslowH()
        {
            if (currCountdownValue > 0)
            {
                Debug.Log("Countdown: " + currCountdownValue);
                yield return new WaitForSeconds(0.5f);

                currCountdownValue--;
                frictionArrow.SetActive(false);
                frictionText.SetActive(false);
                //frictionText.SetActive(false);
                //CanvasDesk.SetActive(false);
                // Hands.SetActive(false);

            }
        }
        IEnumerator ArrowScaling()
        {
            float Fvalue = frictionHandler.Desk.GetComponent<Collider>().material.staticFriction;
            if (slider.value == 1)
            {
                while (forceArrow.transform.localScale.x <= 40 / 100 * 5 || frictionArrow.transform.localScale.x <= 40 / Fvalue / 100 * 3)
                {
                    forceArrow.transform.localScale += new Vector3(1, 0, 0) * Time.deltaTime * 40 / 100 * 5;
                    frictionArrow.transform.localScale += new Vector3(1, 0, 0) * Time.deltaTime * 40 / Fvalue / 100 * 3;
                }
            }
            else if (slider.value == 2)
            {
                while (forceArrow.transform.localScale.x <= 50 / 100 * 5 || frictionArrow.transform.localScale.x <= 50 / Fvalue / 100 * 3)
                {
                    forceArrow.transform.localScale += new Vector3(1, 0, 0) * Time.deltaTime * 50 / 100 * 5;
                    frictionArrow.transform.localScale += new Vector3(1, 0, 0) * Time.deltaTime * 50 / Fvalue / 100 * 3;
                }
            }
            else if (slider.value == 3)
            {
                while (forceArrow.transform.localScale.x <= 100 / 100 * 5 || frictionArrow.transform.localScale.x <= 100 / Fvalue / 100 * 2)
                {
                    forceArrow.transform.localScale += new Vector3(1, 0, 0) * Time.deltaTime * 100 / 100 * 5;
                    frictionArrow.transform.localScale += new Vector3(1, 0, 0) * Time.deltaTime * 100 / Fvalue / 100 * 2;
                }
            }
            yield return null;
        }




        public void DisableAnimator()
        {
            gameObject.GetComponent<Animator>().enabled = false;
        }

        public void OnClick(Button button)
        {
            // if (button.name.Equals(ok.name))
            // {
            //     Messageb.SetActive(false);
            // }
            //else
            if (button.name.Equals(Reset.name))
            {
              //  timeManager.DoFastmotion();
               // CanvasDesk.SetActive(false);
                Hands.SetActive(false);
                Slow.interactable = true;
              //  textui.imagereset.SetActive(false);
              //  redBalloonController.imageText.SetActive(false);
              //  textui.slowB.SetActive(false);
                forceArrow.SetActive(false);
                frictionArrow.SetActive(false);
                forceText.SetActive(false);
                frictionText.SetActive(false);
               // redBalloonController.enabled = false;
                Hands.GetComponent<Animator>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = false;
             //   onLongClickPressed.enabled = false;
              //  onLongClickPressed.currCountdownValue = 0.1f;

                for (int i = 0; i < Objects.Length; i++)
                {
                    Objects[i].GetComponent<Collider>().enabled = true;
                    if (gameObject == Objects[i])
                    {
                        gameObject.transform.position = initialPosition[i];
                        gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    }
                }
                clickedCount = 1;
                currCountdownValue = 5;
                slider.GetComponent<Slider>().interactable = true;
              //  textui.enabled = true;
                ObjectWoodenResetText.SetActive(false);
                ObjectStoneResetText.SetActive(false);
                ObjectMetalResetText.SetActive(false);


                forceArrow.transform.localScale = initialScaleForce;
                frictionArrow.transform.localScale = initialScaleFriction;


                slider.value = 0;
                ArrowC.SetActive(true);
                Surfaces.SetActive(false);
                Messageb.SetActive(false);
                frictionHandler.SurfaceName.text = "Smooth Surface";

                if (clickedCount >= 1)
                {
                    TenKg1.transform.localPosition = new Vector3(-5.89f, 2.471f, -1.0369f);
                    TenKg1.transform.localScale = new Vector3(0.42845f, 0.4496344f, 0.440625f);

                    FiftyKg1.transform.localPosition = new Vector3(-7.81f, 2.61f, -0.96124f);
                    FiftyKg1.transform.localScale = new Vector3(0.628125f, 0.5775f, 0.5985001f);

                    HundredKg1.transform.localPosition = new Vector3(-10.1f, 2.8f, -0.8804f);
                    HundredKg1.transform.localScale = new Vector3(0.751366f, 0.7278677f, 0.7f);
                }

                TenKg1.transform.localPosition = new Vector3(-5.89f, 2.471f, -1.0369f);
                TenKg1.transform.localScale = new Vector3(0.42845f, 0.4496344f, 0.440625f);

                FiftyKg1.transform.localPosition = new Vector3(-7.81f, 2.61f, -0.96124f);
                FiftyKg1.transform.localScale = new Vector3(0.628125f, 0.5775f, 0.5985001f);

                HundredKg1.transform.localPosition = new Vector3(-10.1f, 2.8f, -0.8804f);
                HundredKg1.transform.localScale = new Vector3(0.751366f, 0.7278677f, 0.7f);

                frictionHandler._renderer.material = frictionHandler.materials[2];
                frictionHandler.Desk.GetComponent<Collider>().sharedMaterial = frictionHandler.pMaterials[2];

                // mouseMovement.target = sceneHandler.target._target;

                // iTween.MoveTo(Camera.main.gameObject, sceneHandler.target._front.transform.localPosition,uIManager. camMoveSpeed);
                // iTween.RotateTo(Camera.main.gameObject, sceneHandler.target._front.transform.localEulerAngles, uIManager.camMoveSpeed);
                //uIManager. _CameraViewText.text = "Front View";
            }
            else if (button.name.Equals(Resetimage.name))
            {
                // gameObject.transform.position = new Vector3(-0.44f, 2.25f, -1.06f);
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<Animator>().enabled = true;
                Hands.GetComponent<Animator>().enabled = false;
                Hands.GetComponent<Animator>().Play("Hand", 0, 0f);
              //  CanvasDesk.SetActive(true);
               // onLongClickPressed.currCountdownValue = 0.1f;
              //  textui.imagereset.SetActive(false);
               // onLongClickPressed.enabled = false;
                Slow.interactable = true;
             //   redBalloonController.imageText.SetActive(false);
              //  textui.slowB.SetActive(true);
              //  redBalloonController.enabled = true;
                clickedCount++;
                for (int i = 0; i < Objects.Length; i++)
                {
                    if (gameObject != Objects[i])
                    {
                        Objects[i].GetComponent<Collider>().enabled = false;

                    }
                }
                currCountdownValue = 5;
                forceArrow.SetActive(false);
                frictionArrow.SetActive(false);
                forceText.SetActive(false);
                frictionText.SetActive(false);
                Hands.SetActive(true);
                clickedCount = 2;

                slider.GetComponent<Slider>().interactable = true;
             //   textui.enabled = true;
                ObjectWoodenResetText.SetActive(false);
                ObjectStoneResetText.SetActive(false);
                ObjectMetalResetText.SetActive(false);

                forceArrow.transform.localScale = initialScaleForce;
                frictionArrow.transform.localScale = initialScaleFriction;
            }
            else if (button.name.Equals(Slow.name))
            {

                if (slider.value == 0)
                {

                    Messageb.SetActive(true);
                }
                else
                 if (slider.value == 1)
                {
                    Hands.GetComponent<Animator>().enabled = true;
                    Messageb.SetActive(false);
                  //  timeManager.DoSlowmotion();
                  //  CanvasDesk.SetActive(false);
                 //   onLongClickPressed.enabled = true;
                    ObjectWoodenResetText.SetActive(true);
                    ObjectStoneResetText.SetActive(true);
                    ObjectMetalResetText.SetActive(true);
                    forceArrow.SetActive(true);
                    Slow.interactable = false;
                    frictionArrow.SetActive(true);
                    forceText.SetActive(true);
                    frictionText.SetActive(true);
                  //  textui.enabled = true;
                  //  textui.imagereset.SetActive(true);
                  //  redBalloonController.imageText.SetActive(false);
                  //  redBalloonController.enabled = false;
                    canclickObjects = false;
                    gameObject.GetComponent<Animator>().enabled = false;

                    gameObject.GetComponent<Rigidbody>().useGravity = true;
                    gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    //Hands.transform.localPosition = new Vector3(0.48f, 2.460001f, -1.17f);
                    //Hands.transform.localRotation = Quaternion.Euler(0.366f, -178.471f, -38.362f);
                    //Hands.transform.localScale = new Vector3(0.563f, 0.7354602f, 0.4762138f);

                    gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * 40;

                    String matName = frictionHandler.Desk.GetComponent<MeshCollider>().sharedMaterial.name;
                    Debug.Log(matName);
                    if (matName == "Greasy")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.1f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 1f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 2f;
                        //rb.drag = 0.3f;
                        Debug.Log(" Greasy ");
                    }
                    if (matName == "Oily")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.2f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 1.05f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 2f;
                        // rb.drag = 0.4f;
                        Debug.Log(" oily ");
                    }
                    if (matName == "smooth")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.3f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 1.66f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 4f;
                        //  rb.drag = 0.5f;
                        Debug.Log(" Smooth ");
                    }
                    if (matName == "Slightly Rough")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.6f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 2.22f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 5f;
                        // rb.drag = 0.6f;                   
                        Debug.Log(" slightruf ");
                    }
                    if (matName == "Very Rough")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.8f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 4f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 11f;
                        // rb.drag = 0.7f;
                        Debug.Log(" veryruf ");
                    }
                    slider.GetComponent<Slider>().interactable = false;
                    gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 40);
                    StartCoroutine(ArrowScaling());
                    clickedCount++;
                    StartCoroutine(StartCountdown());
                    StartCoroutine(StartCountdownslow());
                    StartCoroutine(StartCountdownslowH());
                }
                else if (slider.value == 2)
                {
                    Hands.GetComponent<Animator>().enabled = true;
                  //  timeManager.DoSlowmotion();
                  //  CanvasDesk.SetActive(false);
                  //  onLongClickPressed.enabled = true;
                    ObjectWoodenResetText.SetActive(true);
                    ObjectStoneResetText.SetActive(true);
                    ObjectMetalResetText.SetActive(true);
                    forceArrow.SetActive(true);
                    frictionArrow.SetActive(true);
                    forceText.SetActive(true);
                    frictionText.SetActive(true);
                    Slow.interactable = false;
                    Messageb.SetActive(false);
                  //  textui.enabled = true;
                  //  redBalloonController.enabled = false;
                  //  textui.imagereset.SetActive(true);
                    canclickObjects = false;
                  //  redBalloonController.imageText.SetActive(false);
                    gameObject.GetComponent<Animator>().enabled = false;
                    gameObject.GetComponent<Rigidbody>().useGravity = true;
                    gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    //Hands.transform.localPosition = new Vector3(0.48f, 2.460001f, -1.17f);
                    //Hands.transform.localRotation = Quaternion.Euler(0.366f, -178.471f, -38.362f);
                    //Hands.transform.localScale = new Vector3(0.563f, 0.7354602f, 0.4762138f);

                    gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * 47;

                    String matName = frictionHandler.Desk.GetComponent<MeshCollider>().sharedMaterial.name;
                    Debug.Log(matName);
                    if (matName == "Greasy")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.1f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 0.5f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 0.8f;
                        //rb.drag = 0.3f;
                        Debug.Log(" Greasy ");
                    }
                    if (matName == "Oily")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.2f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 0.7f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 1f;
                        // rb.drag = 0.4f;
                        Debug.Log(" oily ");
                    }
                    if (matName == "smooth")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.5f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 1f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 2f;
                        //  rb.drag = 0.5f;
                        Debug.Log(" Smooth ");
                    }
                    if (matName == "Slightly Rough")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.8f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 2f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 4f;
                        // rb.drag = 0.6f;                   
                        Debug.Log(" slightruf ");
                    }
                    if (matName == "Very Rough")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.9f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 3f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 6f;
                        // rb.drag = 0.7f;
                        Debug.Log(" veryruf ");
                    }

                    slider.GetComponent<Slider>().interactable = false;
                    gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 47);
                    StartCoroutine(ArrowScaling());
                    clickedCount++;
                    StartCoroutine(StartCountdown());
                    StartCoroutine(StartCountdownslow());
                    StartCoroutine(StartCountdownslowH());
                }
                else if (slider.value == 3)
                {
                    Hands.GetComponent<Animator>().enabled = true;
                    //Hands.GetComponent<Animator>().SetBool("Hands",true);
                    //Hands.GetComponent<Animator>().Play("Hands");
                  //  timeManager.DoSlowmotion();
                  //  CanvasDesk.SetActive(false);
                   // onLongClickPressed.enabled = true;
                    ObjectWoodenResetText.SetActive(true);
                    ObjectStoneResetText.SetActive(true);
                    ObjectMetalResetText.SetActive(true);
                    forceArrow.SetActive(true);
                    frictionArrow.SetActive(true);
                    forceText.SetActive(true);
                    frictionText.SetActive(true);
                    forceText.SetActive(true);
                    frictionText.SetActive(true);
                    Messageb.SetActive(false);
                  //  textui.enabled = true;
                  //  redBalloonController.enabled = false;
                  //  textui.imagereset.SetActive(true);
                    canclickObjects = false;
                 //   redBalloonController.imageText.SetActive(false);
                    gameObject.GetComponent<Animator>().enabled = false;
                    gameObject.GetComponent<Rigidbody>().useGravity = true;
                    gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    //Hands.transform.localPosition = new Vector3(0.48f, 2.460001f, -1.17f);
                    //Hands.transform.localRotation = Quaternion.Euler(0.366f, -178.471f, -38.362f);
                    //Hands.transform.localScale = new Vector3(0.563f, 0.7354602f, 0.4762138f);
                    Slow.interactable = false;

                    gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * 100;
                    String matName = frictionHandler.Desk.GetComponent<MeshCollider>().sharedMaterial.name;
                    Debug.Log(matName);
                    if (matName == "Greasy")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.1f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 0.5f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 0.8f;
                        //rb.drag = 0.3f;
                        Debug.Log(" Greasy ");
                    }
                    if (matName == "Oily")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.2f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 0.7f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 1f;
                        // rb.drag = 0.4f;
                        Debug.Log(" oily ");
                    }
                    if (matName == "smooth")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.3f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 1f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 2f;
                        //  rb.drag = 0.5f;
                        Debug.Log(" Smooth ");
                    }
                    if (matName == "Slightly Rough")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.6f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 2f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 4f;
                        // rb.drag = 0.6f;                   
                        Debug.Log(" slightruf ");
                    }
                    if (matName == "Very Rough")
                    {
                        TenKg1.GetComponent<Rigidbody>().drag = 0.8f;
                        FiftyKg1.GetComponent<Rigidbody>().drag = 3f;
                        HundredKg1.GetComponent<Rigidbody>().drag = 6f;
                        // rb.drag = 0.7f;
                        Debug.Log(" veryruf ");
                    }
                    slider.GetComponent<Slider>().interactable = false;
                    gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 100);
                    StartCoroutine(ArrowScaling());
                    clickedCount++;
                    StartCoroutine(StartCountdown());
                    StartCoroutine(StartCountdownslow());
                    StartCoroutine(StartCountdownslowH());
                }

            }

        }


    }
}
