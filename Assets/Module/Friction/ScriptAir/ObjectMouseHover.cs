using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Friction
{
    public class ObjectMouseHover : MonoBehaviour
    {
        public static ObjectMouseHover instance;
        public GameObject objectInfo;

        public GameObject boxWithFracture;
        public GameObject boxWithoutFracture;


        public void Awake()
        {
            instance = this;
        }
        public void OnMouseOver()
        {
            if (!GravitationalHandler.instance.isExperimentDone)
            {
                objectInfo.SetActive(true);
            }
            else
            {
                 objectInfo.SetActive(false);
            }
           
        }

        public void OnMouseExit()
        {
            objectInfo.SetActive(false);
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "BallTrig")
            {
                Debug.Log("Trigg");
                // GravitationalHandler.instance.isObjectDrop = false;
                GravitationalHandler.instance.isExperimentDone = true;
                CameraSwitchFriction.instance.mainCam.transform.parent = null;
              
                //CameraSwitchFriction.instance.mainCam.transform.localPosition = CameraSwitchFriction.instance.airLastPos.transform.localPosition;
                //CameraSwitchFriction.instance.mainCam.transform.localEulerAngles = CameraSwitchFriction.instance.airLastPos.transform.localEulerAngles;
                GravitationalHandler.instance._ball_rigidbody.isKinematic = false;
                GravitationalHandler.instance._feather_rigidbody.isKinematic = false;
                boxWithoutFracture.SetActive(false);
                boxWithFracture.SetActive(true);
                GravitationalHandler.instance.playPauseButton.GetComponent<Button>().interactable = false;
                GravitationalHandler.instance.pauseButton.GetComponent<Button>().interactable = false;
                GravitationalHandler.instance.fetherWithBall.SetActive(false);
                GravitationalHandler.instance.fetherWithouthBall.SetActive(true);
                //for (int i = 0; i < GravitationalHandler.instance.boxFractorCs.Length-1; i++)
                //{
                //    GravitationalHandler.instance.boxFractorCs[i].GetComponent<Rigidbody>().isKinematic =false;

                //}
            }

            if (other.gameObject.tag == "FeatherTrig")
            {
                GravitationalHandler.instance.isObjectDrop = false;
                iTween.MoveTo(CameraSwitchFriction.instance.mainCam.gameObject, CameraSwitchFriction.instance.airCloseViewPos.transform.localPosition, 10f);
                iTween.RotateTo(CameraSwitchFriction.instance.mainCam.gameObject, CameraSwitchFriction.instance.airCloseViewPos.transform.localEulerAngles, 10f);
                if (InstructionDataScriptFriction.instance.isInstructionClick)
                {
                    if (!GravitationalHandler.instance.isSlowMotion)
                    {
                        InstructionDataScriptFriction.instance.observeDropI.SetActive(false);
                        InstructionDataScriptFriction.instance.resetClickI.SetActive(true);
                        UIManager.instance.resetButton.interactable = true;
                    }
                    else
                    {
                        InstructionDataScriptFriction.instance.observeDropI.SetActive(false);
                        InstructionDataScriptFriction.instance.instructionDoneM.SetActive(true);
                    }
                    
                }
            }
        }
    }
}