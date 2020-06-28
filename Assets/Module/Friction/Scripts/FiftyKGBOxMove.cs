using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Friction
{
    public class FiftyKGBOxMove : MonoBehaviour
    {
        public static FiftyKGBOxMove instance;

        public GameObject boxMouseOverMessg;

        public GameObject fiftyKgBoxObject;
        public GameObject fiftyBoxStartPos;

        public Rigidbody rb;

        public Animator boxAnim;

        public bool isBoxOtherDesk;
        public bool isBoxInitialPos;

        [Header("UI properties")]
        public GameObject redArrowFriction;
        public GameObject blueArrowPushForce;
        public void Awake()
        {
            instance = this;
        }


        public void OnMouseOver()
        {
            boxMouseOverMessg.SetActive(true);
        }

        public void OnMouseExit()
        {
            boxMouseOverMessg.SetActive(false);
        }


        public void OnMouseDown()
        {
            if (!isBoxInitialPos)
            {
                isBoxOtherDesk = !isBoxOtherDesk;
                if (!isBoxOtherDesk)
                {
                    boxAnim.SetBool("FBoxMove", false);
                    boxAnim.SetBool("FBoxMoveBack", true);
                   HandMove.instance.resetBoxButton.SetActive(false);
                    HundredKGBoxMove.instance.hundredKgBoxObject.GetComponent<BoxCollider>().enabled = true;
                    TenKGBoxMove.instance.tenKgBoxObject.GetComponent<BoxCollider>().enabled = true;
                }

                else
                {
                    boxAnim.SetBool("FBoxMove", true);
                    boxAnim.SetBool("FBoxMoveBack", false);

                    HundredKGBoxMove.instance.hundredKgBoxObject.GetComponent<BoxCollider>().enabled = false;
                    TenKGBoxMove.instance.tenKgBoxObject.GetComponent<BoxCollider>().enabled = false;

                    Time.timeScale = 1f;
                    HandMove.instance.resetBoxButton.SetActive(false);

                    UIManager.instance.playPauseButton.GetComponent<Button>().interactable = true;
                    UIManager.instance.slowButton.interactable = true;
       
                    if (TenKGBoxMove.instance.isBoxOtherDesk)
                    {
                        TenKGBoxMove.instance.OnMouseDown();
                    }
                    if (HundredKGBoxMove.instance.isBoxOtherDesk)
                    {
                        HundredKGBoxMove.instance.OnMouseDown();
                    }


                    if (InstructionDataScriptFriction.instance.isInstructionClick)
                    {
                        UIManager.instance.playPauseButton.GetComponent<Button>().interactable = false;
                        UIManager.instance.slowButton.interactable = false;
                        // HandMove.instance.handObject.GetComponent<BoxCollider>().enabled = false;
                        FiftyKGBOxMove.instance.fiftyKgBoxObject.GetComponent<BoxCollider>().enabled = false;
                        InstructionDataScriptFriction.instance.fiftyBoxClickI.SetActive(false);
                        SolidMediumController.instance.forceIncreaseButton.interactable = true;
                        SolidMediumController.instance.forceSlider.interactable = true;
                        InstructionDataScriptFriction.instance.forceSliderI.SetActive(true);

                    }

                }
            }
            else
            {
                boxAnim.enabled = true;
                isBoxInitialPos = false;
                isBoxOtherDesk = false;
                rb.isKinematic = false;
                HandMove.instance.resetBoxButton.SetActive(false);
                boxAnim.SetBool("FBoxMove", false);
                boxAnim.SetBool("FBoxMoveBack", true);
                //HandMove.instance.handObject.GetComponent<BoxCollider>().enabled = true;
                HundredKGBoxMove.instance.hundredKgBoxObject.GetComponent<BoxCollider>().enabled = true;
                TenKGBoxMove.instance.tenKgBoxObject.GetComponent<BoxCollider>().enabled = true;

            }


        }


        public void EnableAnimator()
        {
            boxAnim.enabled = true;
            Invoke("AnimatorBox", 0.1f);
        }


        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "DeskTrig")
            {
                isBoxInitialPos = true;
                HundredKGBoxMove.instance.hundredKgBoxObject.GetComponent<BoxCollider>().enabled = true;
                TenKGBoxMove.instance.tenKgBoxObject.GetComponent<BoxCollider>().enabled = true;

            }
            if (other.gameObject.tag == "TableEnd")
            {
                rb.freezeRotation = false;
            }
            if (other.gameObject.tag == "Wall")
            {
                Debug.Log("h");
                rb.freezeRotation = true;
                fiftyKgBoxObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        }


    }
}

