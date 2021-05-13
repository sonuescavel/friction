using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Friction
{
    public class HundredKGBoxMove : MonoBehaviour
    {
        public static HundredKGBoxMove instance;

        public GameObject boxMouseOverMessg;

        public GameObject hundredKgBoxObject;
        public GameObject hundredBoxStartPos;

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
                    boxAnim.SetBool("HBoxMove", false);
                    boxAnim.SetBool("HBoxMoveBack", true);
                    HandMove.instance.resetBoxButton.SetActive(false);
                    FiftyKGBOxMove.instance.fiftyKgBoxObject.GetComponent<BoxCollider>().enabled = true;
                    TenKGBoxMove.instance.tenKgBoxObject.GetComponent<BoxCollider>().enabled = true;

                }

                else
                {
                    boxAnim.SetBool("HBoxMove", true);
                    boxAnim.SetBool("HBoxMoveBack", false);

                    FiftyKGBOxMove.instance.fiftyKgBoxObject.GetComponent<BoxCollider>().enabled = false;
                    TenKGBoxMove.instance.tenKgBoxObject.GetComponent<BoxCollider>().enabled = false;

                    Time.timeScale = 1f;
                    HandMove.instance.resetBoxButton.SetActive(false);
                    UIManager.instance.playPauseButton.GetComponent<Button>().interactable = true;
                    UIManager.instance.slowButton.interactable = true;

                    if (FiftyKGBOxMove.instance.isBoxOtherDesk)
                    {
                        FiftyKGBOxMove.instance.OnMouseDown();
                    }
                    if (TenKGBoxMove.instance.isBoxOtherDesk)
                    {
                        TenKGBoxMove.instance.OnMouseDown();
                    }

                    ContextualHelpSystem.instance.StopIfShowingAndMoveToShowNext(0);
                }
            }
            else
            {
                boxAnim.enabled = true;
                isBoxInitialPos = false;
                isBoxOtherDesk = false;
                rb.isKinematic = false;
                HandMove.instance.resetBoxButton.SetActive(false);
                boxAnim.SetBool("HBoxMove", false);
                boxAnim.SetBool("HBoxMoveBack", true);
               // HandMove.instance.handObject.GetComponent<BoxCollider>().enabled = true;
                FiftyKGBOxMove.instance.fiftyKgBoxObject.GetComponent<BoxCollider>().enabled = true;
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
                FiftyKGBOxMove.instance.fiftyKgBoxObject.GetComponent<BoxCollider>().enabled = true;
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
                hundredKgBoxObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        }

      
    }
}
