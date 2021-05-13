using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnImageOnPointerDownUp : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] UnityEvent onPointerDownEvent;
    [SerializeField] UnityEvent onPointerUpEvent;

    
    //------------------------------------------------------------------------------------------------
    public void OnPointerDown(PointerEventData eventData)
    {
        onPointerDownEvent.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onPointerUpEvent.Invoke();
    }

}
