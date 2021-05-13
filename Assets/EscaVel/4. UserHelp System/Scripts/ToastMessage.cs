using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastMessage : MonoBehaviour
{
    [Header("Child References")]
    [SerializeField] Animator toastMsgAnimator;
    [SerializeField] Text toastText;

    float toastDuration = 2.5f;

    const string appearingAnimClipName = "ToastAppear";
    const string disappearAnimClipName = "ToastDisappear";

    Action callback = null;
    Coroutine disappearToast_Coroutine;

    public void ShowToastMessage(string messageToShow_, float showDuration_ = 2.5f, Action callback_ = null)
    {
        toastText.text = messageToShow_;
        toastDuration = showDuration_;

        callback = callback_;
        toastMsgAnimator.Play(appearingAnimClipName);
        disappearToast_Coroutine = StartCoroutine(DisappearToast_Enum());
    }

    IEnumerator DisappearToast_Enum()
    {
        yield return new WaitForSecondsRealtime(toastDuration / 2f);
        callback?.Invoke();
        yield return new WaitForSecondsRealtime(toastDuration / 2f);
        toastMsgAnimator.Play(disappearAnimClipName);

        Debug.Log("ToastDisappear");

        if (disappearToast_Coroutine != null)
            StopCoroutine(disappearToast_Coroutine);
    }

    public void StopIfShowingToast()
    {
        toastMsgAnimator.StopPlayback();
        toastMsgAnimator.Play(disappearAnimClipName);

        if (disappearToast_Coroutine != null)
            StopCoroutine(disappearToast_Coroutine);
    }
}

