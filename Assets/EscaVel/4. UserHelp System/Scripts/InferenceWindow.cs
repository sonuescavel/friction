using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InferenceWindow : MonoBehaviour
{
    [SerializeField] Animator containerAnimator;
    [SerializeField] TextMeshProUGUI headingText;
    [SerializeField] TextMeshProUGUI bodyText;
    [Space(10)]
    [SerializeField] Button showBtn;
    [SerializeField] Button hideBtn;

    string lastPlayedAnimClip = "";
    bool trueAppearedFalseDisappeared;

    //-----------------------------------
    const string appearClip = "InferenceWindow_In";
    const string disappearClip = "InferenceWindow_Out";

    //---------------------------------------------------------------------------------------------------------------
    private void Start()
    {
        showBtn.onClick.AddListener(AppearInferenceWindow);
        hideBtn.onClick.AddListener(DisappearInferenceWindow);
    }
    //---------------------------------------------------------------------------------------------------------------

    public void SetInferenceWindowTexts(string headingTextValue_, string messageToShow_)
    {
        headingText.text = headingTextValue_;
        bodyText.text = messageToShow_;
    }


    public void AppearInferenceWindow()
    {
        if (trueAppearedFalseDisappeared == false)
        {
            if (!gameObject.activeInHierarchy)
                this.gameObject.SetActive(true);

            PlayAnimation(appearClip);

            showBtn.gameObject.SetActive(false);
            hideBtn.gameObject.SetActive(true);

            trueAppearedFalseDisappeared = true;
        }

    }
    public void DisappearInferenceWindow()
    {
        if (trueAppearedFalseDisappeared == true)
        {
            PlayAnimation(disappearClip);

            //if (IsInvoking("DeavtivateAfterTime")) CancelInvoke("DeavtivateAfterTime");
            //Invoke("DeavtivateAfterTime", 1f);

            showBtn.gameObject.SetActive(true);
            hideBtn.gameObject.SetActive(false);

            trueAppearedFalseDisappeared = false;
        }
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
