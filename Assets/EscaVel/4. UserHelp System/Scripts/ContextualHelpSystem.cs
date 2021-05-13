using System;
using System.Collections;
using System.Collections.Generic;
using cakeslice;
using Coffee.UIEffects;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContextualHelpSystem : MonoBehaviour
{
    public static ContextualHelpSystem instance;

    [Header("Hierarachy References")]
    [SerializeField] Button backButton;
    [SerializeField] Button instructionButton;

    [Space(20)]
    [SerializeField] bool isShowContextualHelp = true;
    [SerializeField] int indexCounter;

    int tempSentIndexCounter;
    bool trueObjectFalseUI;

    //Inference Text
    //Boolean For everything - GuidanceText, Highlighting, Outline, Inference
    //Get Tabs index directly from tabs manager - keep as per if is null

    [SerializeField] List<ShortenHighlightingData> highlightingDataDisplay_List = new List<ShortenHighlightingData>();
    List<HighlightingData> highlightingData_List = new List<HighlightingData>();
    [SerializeField] List<MainTabs> mainTabs;

    [Header("For Restarting : Should Start Where it was")]
    [SerializeField] Button[] casesButtons;
    [SerializeField] int lastButtonIndexClickToRestartFromWhereLeft;
    string lastToStartAgainKey = "LastToStartAgain";

    [Header("Childs References")]
    [Space(20)]
    [SerializeField] GamePlanWindow gamePlanWindow;
    //[SerializeField] GuidanceWindow guidanceWindow;
    [SerializeField] GuidanceSideHintWindow sideHintWindow;
    [SerializeField] InferenceWindow inferenceWindow;
    [SerializeField] ToastMessage toastMessage;
    [Space(20)]
    [SerializeField] Transform currentSelectableHighlighting;
    [SerializeField] Transform currentTransformHighlighting;

    [Header("Data")]
    [SerializeField] Color meshHighlightColor; //74FF00
    [SerializeField] Color uiHighlightColor;

    [Header("Runtime Use")]
    [SerializeField] bool isHighlighting;
    [SerializeField] HighlightType highlightObjectType;

    //MeshOutlineHighlight meshOutlineHighlighterComp;
    //SelectableHighlighter uiHighlighterComp;
    //OutlineTests outlineTests;

    bool isHighlightingUI;
    bool isSceneReload;

    TabSpecificData tempTabSpecificData;
    Button lastSelectableButton;

    public bool isWaitingForNext;

    bool tempIsStopHereWithoutShowingInference;
    bool tempIsToShowInference;
    string tempInferenceString;
    float tempInferenceDelay = 5f;

    int showOrNotGamPlanWindow = 1;

    Coroutine highlightObjects_Coroutine;
    Coroutine highlightObject_Single_Coroutine;

    //HILIGHTING UI RELATED
    UIEffect tempUIEffect;
    UIShadow tempUIShadow;
    float tempAlpha;

    //Mesh Highlighting Related
    Camera mainCam;

    //Toast message related
    Coroutine showToastMessage_Coroutine;

    //----------------------------------------------------------------------------------------------------------------------------
    private void Awake()
    {
        instance = this;

        mainCam = Camera.main;
    }

    private void Start()
    {
        SetNumberedDetail();

        if (PlayerPrefs.HasKey("showOrNotGamPlanWindow"))
        {
            showOrNotGamPlanWindow = PlayerPrefs.GetInt("showOrNotGamPlanWindow");
        }

        if (showOrNotGamPlanWindow == 1)
        {
            gamePlanWindow.AppearGuidanceWindow();
            PlayerPrefs.SetInt("showOrNotGamPlanWindow", 0);
        }
        else
        {
            StopIfShowingAndMoveToShowNext(-1);
        }

        //---------------------------------------------------
        //Go from last saved state
        SetInStartAsPerSavedLastStateThenStart();
        //AddButtonsListenersOnStart();

        //MeshHighlighting Setup
        DoInitialSetupForMeshHighlighting();

        //---------------
        if (backButton != null) backButton.onClick.AddListener(ResetToShowGamePlan);
        if (instructionButton != null) instructionButton.onClick.AddListener(KillShowingContextualHelp);
    }


    private void Update()
    {
        UIHighlighting_inUpdate();

        //For testing
        if (Input.GetKeyDown(KeyCode.N))
        {
            StopIfShowingAndMoveToShowNext(indexCounter);
        }
    }

    private void OnApplicationQuit()
    {
        ResetLastToStartKey();
    }

    //-----------------------------------------------------------------------------------------------------------------------------
    private void DoInitialSetupForMeshHighlighting()
    {
        if (mainCam.GetComponent<OutlineEffect>() == null)
            mainCam.gameObject.AddComponent<OutlineEffect>();

        if (mainCam.GetComponent<OutlineAnimation>() == null)
            mainCam.gameObject.AddComponent<OutlineAnimation>();

        mainCam.GetComponent<OutlineEffect>().lineColor0 = meshHighlightColor;
        mainCam.GetComponent<OutlineEffect>().lineIntensity = 1f;
        mainCam.GetComponent<OutlineEffect>().fillAmount = 0.3f;
    }

    //-----------------------------------------------------------------------------------------------------------------------------

    IEnumerator HighlightObject_Single_Enum()
    {
        yield return new WaitForEndOfFrame();

        if (indexCounter < highlightingData_List.Count)
        {
            yield return new WaitForSeconds(highlightingData_List[indexCounter].waitTime);

            if (highlightingData_List[indexCounter].highlightUI != null)
            {
                bool isUIBlack = highlightingData_List[indexCounter].isUIBlack;
                StartHighlightingGivenUI(highlightingData_List[indexCounter].highlightUI.transform, highlightingData_List[indexCounter].uiHighlightWidth, isUIBlack);
                currentSelectableHighlighting = highlightingData_List[indexCounter].highlightUI;
            }

            if (highlightingData_List[indexCounter].highlightObject != null)
            {
                if (highlightingData_List[indexCounter].highlightObject.GetComponent<MeshRenderer>() != null)
                {
                    if (highlightingData_List[indexCounter].highlightObject.GetComponent<cakeslice.Outline>() == null)
                    {
                        highlightingData_List[indexCounter].highlightObject.gameObject.AddComponent<cakeslice.Outline>();
                    }
                }
                currentTransformHighlighting = highlightingData_List[indexCounter].highlightObject;
            }

            //Show Side Hint Text
            sideHintWindow.AppearHintWindow(highlightingData_List[indexCounter].sideHintText, highlightingData_List[indexCounter].hintAppearType, 4f);

            tempIsStopHereWithoutShowingInference = highlightingData_List[indexCounter].stopHereWithoutShowingInference;
            //For Inference window
            tempIsToShowInference = highlightingData_List[indexCounter].showInferenceAfterIt;
            tempInferenceString = highlightingData_List[indexCounter].inferenceDetail.inferenceText;
            tempInferenceDelay = highlightingData_List[indexCounter].inferenceDetail.delayToShowAfter;
        }

        ////If need to show Inference -----------------------------------------------------------------------------------
        //if (tempIsToShowInference)
        //{
        //    //Auto appear inference window
        //    yield return new WaitForSeconds(5f);
        //    inferenceWindow.SetInferenceWindowTexts("<b>Inference</b>", tempInferenceString);
        //    inferenceWindow.AppearInferenceWindow();
        //}

        if (highlightObject_Single_Coroutine != null)
            StopCoroutine(highlightObject_Single_Coroutine);
    }

    //-----------------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// This method is called from -
    /// 1. Other scripts (with current index)
    /// 2. Some buttons (with current index)
    /// </summary>
    /// <param name="index_"></param>
    public void StopIfShowingAndMoveToShowNext(int index_)
    {
        //Stop previous things -----------------------------------------------
        if (highlightObject_Single_Coroutine != null)
            StopCoroutine(highlightObject_Single_Coroutine);

        ResetPreviousThings();

        //Proceed for next ---------------------------------------------------
        if (index_ >= indexCounter - 1)
            indexCounter = index_ + 1;

        //If need to show Inference -----------------------------------------------------------------------------------
        if (tempIsToShowInference && !tempIsStopHereWithoutShowingInference)
        {
            Invoke(nameof(ShowInference), tempInferenceDelay);
        }

        if (isShowContextualHelp && !tempIsToShowInference && !tempIsStopHereWithoutShowingInference)
            highlightObject_Single_Coroutine = StartCoroutine(HighlightObject_Single_Enum());

        tempIsStopHereWithoutShowingInference = false; //to proceed from next time
    }

    private void ShowInference()
    {
        inferenceWindow.SetInferenceWindowTexts("<b>Inference</b>", tempInferenceString);
        inferenceWindow.AppearInferenceWindow();
        tempIsToShowInference = false;
    }

    /// <summary>
    /// By Tab buttons (with previous index, index - 1)
    /// </summary>
    /// <param name="indexOnePreviousThanCurrent_"></param>
    public void StopAndShowByTabButtons(int indexOnePreviousThanCurrent_)
    {
        tempIsToShowInference = false;

        StopIfShowingAndMoveToShowNext(indexOnePreviousThanCurrent_);

        if (IsInvoking(nameof(ShowInference)))
            CancelInvoke(nameof(ShowInference));

        inferenceWindow.DisappearInferenceWindow();
    }

    //-----------------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// 1. Stop Coroutine
    /// 2. Hide Guidance Window
    /// 3. Stop Highlighting Previous UI
    /// 4. Stop Highlighting Previous Transform
    /// </summary>
    public void ResetPreviousThings()
    {
        //Stop previous things -----------------------------------------------
        if (highlightObject_Single_Coroutine != null)
            StopCoroutine(highlightObject_Single_Coroutine);

        //Hide Guidance Text
        sideHintWindow.DisappearSideHintWindow();

        //Stop Highlighting Previous UI
        if (currentSelectableHighlighting != null)
        {
            ResetPreviousUIHighligtings();
        }

        ////Stop if showing previous inference
        //if (IsInvoking(nameof(ShowInference)))
        //    CancelInvoke(nameof(ShowInference));

        //Stop Highlighting Previous Transform Meshes/child meshes
        if (currentTransformHighlighting != null)
        {
            if (currentTransformHighlighting.GetComponent<cakeslice.Outline>() != null)
                Destroy(currentTransformHighlighting.GetComponent<cakeslice.Outline>());
        }
    }

    public void ToggleShowContextualHelp()
    {
        if (isShowContextualHelp == true)//Already true, so stop and make state to false
        {
            KillShowingContextualHelp();
            return;
        }

        if (isShowContextualHelp == false)
        {
            isSceneReload = true;
            toastMessage.ShowToastMessage("Contextual Help is turned ON – We are restarting the experience");
            //Restart Scene with last use case
            Invoke(nameof(Invoke_RestartScene), 3f);

            isShowContextualHelp = true;
            return;
        }
    }

    private void KillShowingContextualHelp()
    {
        isSceneReload = false;
        toastMessage.ShowToastMessage("Contextual Help is turned OFF – You will not see any step-by-step guidance going forward");

        //Restart Scene with last use case
        Invoke(nameof(Invoke_RestartScene), 3f);

        //Stop Showing
        ResetPreviousThings();
        isShowContextualHelp = false;
    }

    void Invoke_RestartScene()
    {
        if (isSceneReload)
            SceneManager.LoadScene(0);
    }


    //This method is called by back button of the use case
    public void ResetToShowGamePlan()
    {
        if (PlayerPrefs.HasKey("showOrNotGamPlanWindow"))
        {
            PlayerPrefs.SetInt("showOrNotGamPlanWindow", 1);
        }
        else
        {
            Debug.Log("Key Not Found.");
        }
        //

        ResetLastToStartKey();
    }

    private void ResetLastToStartKey()
    {
        if (PlayerPrefs.HasKey(lastToStartAgainKey))
        {
            PlayerPrefs.SetInt(lastToStartAgainKey, 0);
        }
    }

    //---------------------------------------------------------------------------------------------------------------------------------
    //Called by context menu
    [ContextMenu("Set Numbered Detail")]
    public void SetNumberedDetail()
    {
        int counter = 0;
        highlightingData_List.Clear();
        highlightingDataDisplay_List.Clear();

        ShortenHighlightingData tempShortenHighlightingData = null;

        for (int i = 0; i < mainTabs.Count; i++)
        {
            for (int j = 0; j < mainTabs[i].tabSpecificData.highlightingData.Count; j++)
            {
                mainTabs[i].tabSpecificData.highlightingData[j].name = counter.ToString() + ". " + mainTabs[i].tabSpecificData.highlightingData[j].objectName;
                mainTabs[i].tabSpecificData.highlightingData[j].indexValue = counter;
                counter++;

                highlightingData_List.Add(mainTabs[i].tabSpecificData.highlightingData[j]);

                tempShortenHighlightingData = new ShortenHighlightingData();
                tempShortenHighlightingData.name = mainTabs[i].tabSpecificData.highlightingData[j].name;
                highlightingDataDisplay_List.Add(tempShortenHighlightingData);
            }

            for (int j = 0; j < mainTabs[i].childs.Count; j++)
            {
                for (int k = 0; k < mainTabs[i].childs[j].tabSpecificData.highlightingData.Count; k++)
                {
                    mainTabs[i].childs[j].tabSpecificData.highlightingData[k].name = counter.ToString() + ". " + mainTabs[i].childs[j].tabSpecificData.highlightingData[k].objectName;
                    mainTabs[i].childs[j].tabSpecificData.highlightingData[k].indexValue = counter;
                    counter++;

                    highlightingData_List.Add(mainTabs[i].childs[j].tabSpecificData.highlightingData[k]);

                    tempShortenHighlightingData = new ShortenHighlightingData();
                    tempShortenHighlightingData.name = mainTabs[i].childs[j].tabSpecificData.highlightingData[k].name;
                    highlightingDataDisplay_List.Add(tempShortenHighlightingData);
                }
            }
        }

    }


    //---------------------------------------------------------------------------------------------------------------------------------
    //HILIGHTING UI RELATED

    void UIHighlighting_inUpdate()
    {
        if (tempUIShadow != null)
        {
            tempAlpha = Mathf.PingPong(Time.time, 1f);
            tempUIShadow.effectColor = new Color(uiHighlightColor.r, uiHighlightColor.g, uiHighlightColor.b, tempAlpha);
        }
    }

    private void StartHighlightingGivenUI(Transform seletableToHighlight_, float uiHighlightWidth_, bool isUIBlack_)
    {
        if (tempUIEffect != null)
            Destroy(tempUIEffect);

        if (tempUIShadow != null)
            Destroy(tempUIShadow);

        tempUIEffect = seletableToHighlight_.gameObject.AddComponent<UIEffect>();

        tempUIEffect.colorMode = ColorMode.Fill;
        if (isUIBlack_)
        {
            tempUIEffect.colorFactor = 1f;
        }
        else
        {
            tempUIEffect.colorFactor = 0f;
        }


        tempUIShadow = seletableToHighlight_.gameObject.AddComponent<UIShadow>();
        tempUIShadow.style = ShadowStyle.Outline;
        tempUIShadow.effectDistance = new Vector2(uiHighlightWidth_, uiHighlightWidth_);
    }

    void ResetPreviousUIHighligtings()
    {
        if (tempUIEffect != null)
            Destroy(tempUIEffect);

        if (tempUIShadow != null)
            Destroy(tempUIShadow);
    }

    //---------------------------------------------------------------------------------------------------------------------------------------
    //For restarting from where it was left
    public void SetIndexToBeRestartedFromHere(int index_)
    {
        lastButtonIndexClickToRestartFromWhereLeft = index_;

        PlayerPrefs.SetInt(lastToStartAgainKey, lastButtonIndexClickToRestartFromWhereLeft);
    }


    void SetInStartAsPerSavedLastStateThenStart()
    {
        if (PlayerPrefs.HasKey(lastToStartAgainKey))
        {
            lastButtonIndexClickToRestartFromWhereLeft = PlayerPrefs.GetInt(lastToStartAgainKey);
            Invoke(nameof(InvokeLastABitDelayed), 0.1f);
        }
    }

    private void InvokeLastABitDelayed()
    {
        casesButtons[lastButtonIndexClickToRestartFromWhereLeft].onClick.Invoke();
    }

    //---------------------------------------------------------------------------------------------------------------------------------------
    //Toast message Related
    public void ShowToastMessage(float showAfterSecs = 0f, string messageToShow_ = "Toast Message", float forDuration_ = 3f, Action callBack_ = null)
    {
        showToastMessage_Coroutine = StartCoroutine(ShowToastMessage_Enum(showAfterSecs, messageToShow_, forDuration_, callBack_));

    }

    IEnumerator ShowToastMessage_Enum(float showAfterSecs_, string messageToShow_, float forDuration_, Action callBack_)
    {
        yield return new WaitForSeconds(showAfterSecs_);
        toastMessage.ShowToastMessage(messageToShow_, forDuration_, callBack_);

        if (showToastMessage_Coroutine != null)
            StopCoroutine(showToastMessage_Coroutine);

    }

    //---------------------------------------------------------------------------------------------------------------------------------------
    //Reset and Restart ferom begining
    public void ResetAndRestartFromBegining()
    {
        indexCounter = -1;
        tempIsToShowInference = false;
        StopIfShowingAndMoveToShowNext(-1);
    }

    public void SetCanvasOrder(int orderToSet_ = 2)
    {
        GetComponentInParent<Canvas>().sortingOrder = 2;
    }

}



//---------------------------------------------------------------------------------------------------------------------------------------
//---------------------------------------------------------------------------------------------------------------------------------------
//---------------------------------------------------------------------------------------------------------------------------------------
//OUTSIDE OF MAIN CLASS

[System.Serializable]
public class MainTabs   //Main Tabs
{
    public string tabName;
    public TabSpecificData tabSpecificData;
    public List<SecondaryTabs> childs;
}

[System.Serializable]
public class SecondaryTabs  //Child Tabs of Main Tabs
{
    public string tabName;
    public TabSpecificData tabSpecificData;
}

[System.Serializable]
public class TabSpecificData    //Specific to a tab, will have highlighting data list as well
{
    public List<HighlightingData> highlightingData = new List<HighlightingData>();
    //[Header("-----------------------------------------------------")]
    //[Space(20)]
    //public bool showInferenceText;
    //[TextArea(7, 10)]
    //public string inferenceText;
}

[System.Serializable]
public class HighlightingData
{
    [HideInInspector] public string name;
    [HideInInspector] public int indexValue;
    [Space(5)]
    public string objectName;
    public float waitTime;
    [Space(5)]
    public Transform highlightUI;
    public Transform highlightObject;
    [Space(2)]
    public bool isUIBlack;
    public float uiHighlightWidth = 15f;
    [TextArea(7, 10)]
    public string sideHintText;
    public AppearHintWindowType hintAppearType = AppearHintWindowType.TopRight;
    [Space(5)]
    public bool stopHereWithoutShowingInference;
    [Header("Inference")]
    public bool showInferenceAfterIt;
    public InferenceDetail inferenceDetail;
    [Space(5)]
    public bool autoContinueToNextHighlightingAfterInference;
}

[System.Serializable]
public class ShortenHighlightingData
{
    [HideInInspector] public string name;
    [HideInInspector] public int indexValue;
}

[System.Serializable]
public class InferenceDetail
{
    public float delayToShowAfter = 5f;
    [TextArea(7, 10)]
    public string inferenceText;
}


//---------------------------------------

public enum HighlightType
{
    UI_Object,
    Mesh_Object
}

public enum AppearHintWindowType
{
    TopRight,
    TopLeft,
    BottomRight,
    BottomLeft
}


