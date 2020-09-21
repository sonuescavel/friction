using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Friction
{
    public class HandMove : MonoBehaviour
    {

        public static HandMove instance;

        public GameObject handObject;

        public Animator handAnim;

        public float boxMoveSpeed = 25f;

        public float hundredDrag;
        public float fiftyDrag;
        public float tenDrag;

        public GameObject handMouseHoverInfo;

        public GameObject resetBoxButton;

       // public GameObject playButton;
      //  public GameObject pauseButton;

        public bool isDoubleClick;
        public void Awake()
        {
            instance = this;
        }

       
        public void OnMouseOver()
        {
            if (SolidMediumController.instance.isForceSet && (HundredKGBoxMove.instance.isBoxOtherDesk || FiftyKGBOxMove.instance.isBoxOtherDesk || TenKGBoxMove.instance.isBoxOtherDesk))
            {
                handMouseHoverInfo.SetActive(true);
            }
            else
            {
                handMouseHoverInfo.SetActive(false);
            }
        }

        public void OnMouseExit()
        {
            handMouseHoverInfo.SetActive(false);
        }

        public void PauseClick()
        {
            Time.timeScale = 0f;
         //   pauseButton.SetActive(false);
          //  playButton.SetActive(true);
        }
        public void OnMouseDown()
        {
         
            if (SolidMediumController.instance.isForceSet && ((HundredKGBoxMove.instance.isBoxOtherDesk || FiftyKGBOxMove.instance.isBoxOtherDesk || TenKGBoxMove.instance.isBoxOtherDesk)))
            {
                Time.timeScale = 1f;
                UIManager.instance.playPauseButton.GetComponent<Button>().interactable=false;
                UIManager.instance.slowButton.interactable = false;
                SolidMediumController.instance.ChangeForceSlider((int)SolidMediumController.instance.forceSlider.value);
                if (HundredKGBoxMove.instance.isBoxOtherDesk)
                {
                   // handObject.GetComponent<BoxCollider>().enabled = false;
                    handAnim.SetTrigger("HandMove");
                    HundredKGBoxMove.instance.boxAnim.enabled = false;
                    HundredKGBoxMove.instance.rb.isKinematic = false;
                    HundredKGBoxMove.instance.rb.velocity = Vector3.right * boxMoveSpeed;
                    HundredKGBoxMove.instance.rb.drag = hundredDrag;
                    HundredKGBoxMove.instance.blueArrowPushForce.SetActive(true);
                    Invoke("EnableFrictionArrow", 0.15f);
                    Invoke("DisablePushArrow", 0.05f);
                    Invoke("DisableFrictionArrow", 0.65f);
                }
                if (FiftyKGBOxMove.instance.isBoxOtherDesk)
                {
                   // handObject.GetComponent<BoxCollider>().enabled = false;
                    handAnim.SetTrigger("HandMove");
                    FiftyKGBOxMove.instance.boxAnim.enabled = false;
                    FiftyKGBOxMove.instance.rb.isKinematic = false;
                    FiftyKGBOxMove.instance.rb.velocity = Vector3.right * boxMoveSpeed;
                    FiftyKGBOxMove.instance.rb.drag = fiftyDrag;
                    FiftyKGBOxMove.instance.blueArrowPushForce.SetActive(true);
                    Invoke("EnableFrictionArrow", 0.15f);
                    Invoke("DisablePushArrow", 0.05f);
                    Invoke("DisableFrictionArrow", 0.65f);
                    if (InstructionDataScriptFriction.instance.isInstructionClick && !UIManager.instance.isSlowInstr)
                    {
                        UIManager.instance.isPlayInstr = true;
                        InstructionDataScriptFriction.instance.palyGameI.SetActive(false);
                     
                        FiftyKGBOxMove.instance.fiftyKgBoxObject.GetComponent<BoxCollider>().enabled = true;

                    }
                }

                if (TenKGBoxMove.instance.isBoxOtherDesk)
                {
                   // handObject.GetComponent<BoxCollider>().enabled = false;
                    handAnim.SetTrigger("HandMove");
                    TenKGBoxMove.instance.boxAnim.enabled = false;
                    TenKGBoxMove.instance.rb.isKinematic = false;
                    TenKGBoxMove.instance.rb.velocity = Vector3.right * boxMoveSpeed;
                    TenKGBoxMove.instance.rb.drag = tenDrag;
                    TenKGBoxMove.instance.blueArrowPushForce.SetActive(true);
                    Invoke("EnableFrictionArrow", 0.02f);
                    Invoke("DisablePushArrow", 0.05f);
                    Invoke("DisableFrictionArrow", 0.65f);
                }

            }
        }

        public void SlowMotionPlay()
        {
            if (InstructionDataScriptFriction.instance.isInstructionClick)
            {

                UIManager.instance.isSlowInstr = true;
                InstructionDataScriptFriction.instance.slowMotionI.SetActive(false);
                UIManager.instance.slowButton.interactable = false;
                InstructionDataScriptFriction.instance.resetClickI.SetActive(true);
                UIManager.instance.resetButton.interactable = true;
            }
            OnMouseDown();
            UIManager.instance.Slowspeed();

           

        }

        public void DisablePushArrow()
        {
            if (FiftyKGBOxMove.instance.isBoxOtherDesk)
            {
                FiftyKGBOxMove.instance.blueArrowPushForce.SetActive(false);
            }
            if (HundredKGBoxMove.instance.isBoxOtherDesk)
            {
               HundredKGBoxMove.instance.blueArrowPushForce.SetActive(false);
            }
            if (TenKGBoxMove.instance.isBoxOtherDesk)
            {
               TenKGBoxMove.instance.blueArrowPushForce.SetActive(false);
            }
        }
        public void EnableFrictionArrow()
        {
            if (FiftyKGBOxMove.instance.isBoxOtherDesk)
            {
                FiftyKGBOxMove.instance.redArrowFriction.SetActive(true);
               // FiftyKGBOxMove.instance.blueArrowPushForce.SetActive(false);
            }
            if (HundredKGBoxMove.instance.isBoxOtherDesk)
            {
                HundredKGBoxMove.instance.redArrowFriction.SetActive(true);
              //  HundredKGBoxMove.instance.blueArrowPushForce.SetActive(false);
            }
            if (TenKGBoxMove.instance.isBoxOtherDesk)
            {
                TenKGBoxMove.instance.redArrowFriction.SetActive(true);
               // TenKGBoxMove.instance.blueArrowPushForce.SetActive(false);
            }
        }

        public void DisableFrictionArrow()
        {
            resetBoxButton.SetActive(true);
            if (InstructionDataScriptFriction.instance.isInstructionClick && !UIManager.instance.isSlowInstr)
            {
                InstructionDataScriptFriction.instance.resetBoxPosI.SetActive(true);
            }
            Time.timeScale = 1f;
            if (FiftyKGBOxMove.instance.isBoxOtherDesk)
            {
                FiftyKGBOxMove.instance.redArrowFriction.SetActive(false);
            }
            if (HundredKGBoxMove.instance.isBoxOtherDesk)
            {
                HundredKGBoxMove.instance.redArrowFriction.SetActive(false);
            }
            if (TenKGBoxMove.instance.isBoxOtherDesk)
            {
                TenKGBoxMove.instance.redArrowFriction.SetActive(false);
            }
        }

        public void EnableBoxCollider()
        {
            //handObject.GetComponent<BoxCollider>().enabled = true;
        }

        public void ResetBoxPo()
        {
            Time.timeScale = 1f;
            resetBoxButton.SetActive(false);
            UIManager.instance.playPauseButton.GetComponent<Button>().interactable = true;
            UIManager.instance.slowButton.interactable = true;
       
            if (TenKGBoxMove.instance.isBoxOtherDesk)
            {
                TenKGBoxMove.instance.boxAnim.enabled = true;
                TenKGBoxMove.instance.boxAnim.SetBool("TBoxMove", true);
                TenKGBoxMove.instance.boxAnim.SetBool("TBoxMoveBack", false);
                
                TenKGBoxMove.instance.redArrowFriction.SetActive(false);
            }
            if (FiftyKGBOxMove.instance.isBoxOtherDesk)
            {
                FiftyKGBOxMove.instance.boxAnim.enabled = true;
                FiftyKGBOxMove.instance.boxAnim.SetBool("FBoxMove", true);
                FiftyKGBOxMove.instance.boxAnim.SetBool("FBoxMoveBack", false);
                FiftyKGBOxMove.instance.redArrowFriction.SetActive(false);

                if (InstructionDataScriptFriction.instance.isInstructionClick)
                {
                    InstructionDataScriptFriction.instance.resetBoxPosI.SetActive(false);
                    UIManager.instance.playPauseButton.GetComponent<Button>().interactable = false;
                    InstructionDataScriptFriction.instance.slowMotionI.SetActive(true);
                    UIManager.instance.slowButton.interactable = true;
                }
            }
            if (HundredKGBoxMove.instance.isBoxOtherDesk)
            {
                HundredKGBoxMove.instance.boxAnim.enabled = true;
                HundredKGBoxMove.instance.boxAnim.SetBool("HBoxMove", true);
                HundredKGBoxMove.instance.boxAnim.SetBool("HBoxMoveBack", false);
                TenKGBoxMove.instance.redArrowFriction.SetActive(false);
            }
        }
    }
}