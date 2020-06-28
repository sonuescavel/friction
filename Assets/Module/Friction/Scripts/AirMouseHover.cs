using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Friction
{
    public class AirMouseHover : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
    {
        public static AirMouseHover instance;

        public GameObject hoverUI;

        public void Awake()
        {
            instance = this;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            hoverUI.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            hoverUI.SetActive(false);
        }
    }
}
