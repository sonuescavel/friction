using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerDrag : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject EnlargedObj;
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            EnlargedObj.SetActive(true);
        }
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            EnlargedObj.SetActive(false);
        }
    }
}
