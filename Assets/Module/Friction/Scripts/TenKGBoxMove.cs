using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Friction
{
    public class TenKGBoxMove : MonoBehaviour
    {
        public static TenKGBoxMove instance;

        public GameObject boxMouseOverMessg;

        public GameObject tenKgBoxObject;
        public GameObject tenBoxStartPos;

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
                    boxAnim.SetBool("TBoxMove", false);
                    boxAnim.SetBool("TBoxMoveBack", true);
                    HandMove.instance.resetBoxButton.SetActive(false);
                    HundredKGBoxMove.instance.hundredKgBoxObject.GetComponent<BoxCollider>().enabled = true;
                    FiftyKGBOxMove.instance.fiftyKgBoxObject.GetComponent<BoxCollider>().enabled = true;
                }

                else
                {
                    boxAnim.SetBool("TBoxMove", true);
                    boxAnim.SetBool("TBoxMoveBack", false);

                    HundredKGBoxMove.instance.hundredKgBoxObject.GetComponent<BoxCollider>().enabled = false;
                    FiftyKGBOxMove.instance.fiftyKgBoxObject.GetComponent<BoxCollider>().enabled = false;
                    Time.timeScale = 1f;
                    HandMove.instance.resetBoxButton.SetActive(false);
                    UIManager.instance.playPauseButton.GetComponent<Button>().interactable = true;
                    UIManager.instance.slowButton.interactable = true;

                    if (HundredKGBoxMove.instance.isBoxOtherDesk)
                    {
                        HundredKGBoxMove.instance.OnMouseDown();
                    }
                    if (FiftyKGBOxMove.instance.isBoxOtherDesk)
                    {
                        FiftyKGBOxMove.instance.OnMouseDown();
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
                boxAnim.SetBool("TBoxMove", false);
                boxAnim.SetBool("TBoxMoveBack", true);
               // HandMove.instance.handObject.GetComponent<BoxCollider>().enabled = true;
               // HundredKGBoxMove.instance.hundredKgBoxObject.GetComponent<BoxCollider>().enabled = true;
               // FiftyKGBOxMove.instance.fiftyKgBoxObject.GetComponent<BoxCollider>().enabled = true;
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
                FiftyKGBOxMove.instance.fiftyKgBoxObject.GetComponent<BoxCollider>().enabled = true;
            }
            if (other.gameObject.tag == "TableEnd")
            {
                rb.freezeRotation=false;
            }
            if (other.gameObject.tag == "Wall")
            {
                Debug.Log("h");
                rb.freezeRotation = true;
                tenKgBoxObject.transform.eulerAngles =new Vector3(0f,0f,0f);
            }
        }


    }
}

