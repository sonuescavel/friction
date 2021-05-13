using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlanWindow : MonoBehaviour
{
    [SerializeField] Animator containerAnimator;

    ContextualHelpSystem userHelpSystem;

    //-----------------------------------
    const string appearClip = "GamePlanAppear";
    const string disappearClip = "GamePlanDisappear";

    string lastPlayedAnimClip = "";
    //---------------------------------------------------------------------------------------------------------------
    private void Start()
    {
        userHelpSystem = GetComponentInParent<ContextualHelpSystem>();
    }

    public void AppearGuidanceWindow()
    {
        if (!gameObject.activeInHierarchy)
            this.gameObject.SetActive(true);

        PlayAnimation(appearClip);
    }

    public void DisappearGuidanceWidow()
    {
        PlayAnimation(disappearClip);
    }

    void PlayAnimation(string clipName_)
    {
        if (string.Equals(clipName_, lastPlayedAnimClip))
            return;

        containerAnimator.Play(clipName_);
        lastPlayedAnimClip = clipName_;
    }

    //--------------------------------------------------------------------------------------------------------------
    public void OnClick_CloseGamePlanWindow()
    {
        DisappearGuidanceWidow();
        userHelpSystem.StopIfShowingAndMoveToShowNext(-1);
    }

}
