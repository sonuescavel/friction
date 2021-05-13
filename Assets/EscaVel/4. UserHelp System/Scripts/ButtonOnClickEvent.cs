using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonOnClickEvent : MonoBehaviour
{
    [SerializeField] bool getImageCompInChild;
    [Space(5)]
    [SerializeField] Sprite firstSprite;
    [SerializeField] Sprite secondSprite;
    [Space(5)]
    [SerializeField] UnityEvent onFirstClickEvent;
    [SerializeField] UnityEvent onSecondClickEvent;

    Button buttonComp;
    [SerializeField] Image buttonImageComp;

    private void Start()
    {
        GetInitially();
        RemoveOldListeners();

        buttonComp.onClick.AddListener(OnFirstTimeClick);
    }

    //--------------------------------------------------------------------------------

    void GetInitially()
    {
        if (buttonComp == null)
            buttonComp = GetComponent<Button>();

        //if (buttonImageComp == null)
        //{
        //    if (!getImageCompInChild)
        //        buttonImageComp = GetComponent<Image>();
        //    else
        //        buttonImageComp = transform.GetChild(0).GetComponent<Image>();
        //}
    }

    void RemoveOldListeners()
    {
        buttonComp.onClick.RemoveAllListeners();
    }

    void OnFirstTimeClick()
    {
        onFirstClickEvent?.Invoke();
        if (firstSprite != null) buttonImageComp.sprite = firstSprite;

        RemoveOldListeners();
        buttonComp.onClick.AddListener(OnSecondTimeClick);
    }

    void OnSecondTimeClick()
    {
        onSecondClickEvent?.Invoke();
        if (secondSprite != null) buttonImageComp.sprite = secondSprite;

        RemoveOldListeners();
        buttonComp.onClick.AddListener(OnFirstTimeClick);
    }
}


