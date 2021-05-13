using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TabSpecificGuidance : MonoBehaviour
{
    [SerializeField] Animator containerAnimator;
    [SerializeField] TextMeshProUGUI headingText;
    [SerializeField] TextMeshProUGUI bodyText;

    string lastPlayedAnimClip = "";

    //-----------------------------------
    const string appearClip = "StartingGuidance_Appear";
    const string disappearClip = "StartingGuidance_Disappear";

    Action onDisappearCallback;
    //---------------------------------------------------------------------------------------------------------------

    public void AppearGuidanceWindow(string headingTextValue_, string messageToShow_, Action onDisapperCallback_ = null)
    {
        if (!gameObject.activeInHierarchy)
            this.gameObject.SetActive(true);

        headingText.text = headingTextValue_;
        bodyText.text = messageToShow_;
        PlayAnimation(appearClip);

        onDisappearCallback = onDisapperCallback_;
    }

    public void DisappearGuidanceWidow()
    {
        PlayAnimation(disappearClip);

        if (IsInvoking("DeavtivateAfterTime")) CancelInvoke("DeavtivateAfterTime");
        Invoke("DeavtivateAfterTime", 1f);

        onDisappearCallback?.Invoke();
    }

    void PlayAnimation(string clipName_)
    {
        if (string.Equals(clipName_, lastPlayedAnimClip))
            return;

        containerAnimator.Play(clipName_);
        lastPlayedAnimClip = clipName_;
    }

    void DeavtivateAfterTime()
    {
        gameObject.SetActive(false);
    }
}
