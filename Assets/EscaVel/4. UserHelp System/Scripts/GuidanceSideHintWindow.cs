using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuidanceSideHintWindow : MonoBehaviour
{
    [SerializeField] Animator containerAnimator;
    [SerializeField] TextMeshProUGUI hintText;

    //-----------------------------------
    const string appearTopRightClip = "SideHintWindow_Appear_TopRight";
    const string disAppearTopRightClip = "SideHintWindow_Disappear_TopRight";

    const string appearTopLeftClip = "SideHintWindow_Appear_TopLeft";
    const string disAppearTopLeftLeft = "SideHintWindow_Disappear_TopLeft";

    const string appearBottomRightClip = "SideHintWindow_Appear_BottomRight";
    const string disAppearBottomRightClip = "SideHintWindow_Disappear_BottomRight";

    const string appearBottomLeftClip = "SideHintWindow_Appear_BottomLeft";
    const string disAppearBottomLeftClip = "SideHintWindow_Disappear_BottomLeft";

    string lastPlayedAnimClip = "";
    //-----------------------------------

    string hintWindoTextValue = "";
    AppearHintWindowType appearType;

    Coroutine showSideHint_Coroutine;

    bool isAppeared;
    //-------------------------------------------------------------------------------------------------------------
    //private void OnEnable()
    //{
    //    AppearHintWindowType ap = (AppearHintWindowType)Random.Range(0, 4);
    //    AppearHintWindow("Somthing", ap, 5f);
    //}

    //-------------------------------------------------------------------------------------------------------------

    public void AppearHintWindow(string messageToShow_, AppearHintWindowType appearanceType_ = AppearHintWindowType.TopRight, float forDuration_ = 5f)
    {
        if (!gameObject.activeInHierarchy)
            this.gameObject.SetActive(true);

        hintWindoTextValue = messageToShow_;
        appearType = appearanceType_;

        if(showSideHint_Coroutine != null)
        {
            StopCoroutine(showSideHint_Coroutine);
        }
        showSideHint_Coroutine = StartCoroutine(ShowSideHint_Enum());
    }

    //-------------------------------------------------------------------------------------------------------------
    IEnumerator ShowSideHint_Enum()
    {
        yield return new WaitForEndOfFrame();

        hintText.text = hintWindoTextValue;

        if (!isAppeared)
        {
            switch (appearType)
            {
                case AppearHintWindowType.TopRight:
                    PlayAnimation(appearTopRightClip);
                    break;
                case AppearHintWindowType.BottomRight:
                    PlayAnimation(appearBottomRightClip);
                    break;
                case AppearHintWindowType.TopLeft:
                    PlayAnimation(appearTopLeftClip);
                    break;
                case AppearHintWindowType.BottomLeft:
                    PlayAnimation(appearBottomLeftClip);
                    break;
                default:
                    break;
            }

            isAppeared = true;

        }
        if (showSideHint_Coroutine != null)
        {
            StopCoroutine(showSideHint_Coroutine);
        }
    }


    //---------------------------------------------------------------------------------------------------------------------------
    public void DisappearSideHintWindow()
    {
        if (isAppeared)
        {
            switch (appearType)
            {
                case AppearHintWindowType.TopRight:
                    PlayAnimation(disAppearTopRightClip);
                    break;
                case AppearHintWindowType.BottomRight:
                    PlayAnimation(disAppearBottomRightClip);
                    break;
                case AppearHintWindowType.TopLeft:
                    PlayAnimation(disAppearTopLeftLeft);
                    break;
                case AppearHintWindowType.BottomLeft:
                    PlayAnimation(disAppearBottomLeftClip);
                    break;
                default:
                    break;
            }

            isAppeared = false;
        }

    }


    //---------------------------------------------------------------------------------------------------------------------------

    void PlayAnimation(string clipName_)
    {
        if (string.Equals(clipName_, lastPlayedAnimClip))
            return;

        containerAnimator.Play(clipName_);
        lastPlayedAnimClip = clipName_;
    }

}
