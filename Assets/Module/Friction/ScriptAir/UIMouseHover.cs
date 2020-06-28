using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Friction
{
    public class UIMouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public GameObject hoverInfo;
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!SolidMediumController.instance.isForceSet)
            {
                Debug.Log("jjjj");
                SolidMediumController.instance.forceSetMessage.SetActive(true);
            }
            else
            {
                SolidMediumController.instance.forceSetMessage.SetActive(false);
            }
            if (HundredKGBoxMove.instance.isBoxOtherDesk || FiftyKGBOxMove.instance.isBoxOtherDesk || TenKGBoxMove.instance.isBoxOtherDesk)
            {
                SolidMediumController.instance.boxSetMessage.SetActive(false);
            }
            else
            {
                SolidMediumController.instance.boxSetMessage.SetActive(true);
            }
            if (SolidMediumController.instance.isForceSet && (HundredKGBoxMove.instance.isBoxOtherDesk || FiftyKGBOxMove.instance.isBoxOtherDesk || TenKGBoxMove.instance.isBoxOtherDesk))
            {
                hoverInfo.SetActive(true);
            }
            else
            {
                hoverInfo.SetActive(false);
            }
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("exit");
            hoverInfo.SetActive(false);
            SolidMediumController.instance.boxSetMessage.SetActive(false);
            SolidMediumController.instance.forceSetMessage.SetActive(false);
        }

    }
}
