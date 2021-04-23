using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Networking;
using System;
using EscaVel.DataAccess;

public class SSOAuth : MonoBehaviour
{
    public static SSOAuth instance;
    public GameObject appExpiryBox;
    public TextMeshProUGUI appExpiryText;
    public bool isSSOAuthEnable = false;
    string validateUrl;
    void OnEnable()
    {
#if UNITY_EDITOR
        DeserializeAuth("GENCBSE,cbse@escavin");
#endif
        isSSOAuthEnable = true;
        instance = this;
    }
  
    void DeserializeAuth(string json)
    {
        string[] userDetails = json.Split(',');
        Validate(userDetails[0], userDetails[1]);
    }

    public void Validate(string uid, string userName)
    {
        validateUrl = "Account/IsSchoolUserExists?schoolName=" + uid + "&MACAddress=" + SystemInfo.deviceUniqueIdentifier + "&userName=" + userName + "";
        StartCoroutine(ValidateSubscription(validateUrl));
    }

    IEnumerator ValidateSubscription(string actionUrl)
    {
        string finalUrl = APIUrlHelper.GetBaseAPIUrl(APIUrlHelper.secureURL) + actionUrl;
        UnityWebRequest www = UnityWebRequest.Get(finalUrl);
        yield return www.SendWebRequest();
        Debug.Log(finalUrl);
        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string schoolUserResult = www.downloadHandler.text;
            SchoolClass schoolArr = JsonUtility.FromJson<SchoolClass>(schoolUserResult);
            Debug.Log("Json Utility School Arr ::" + schoolArr.Name);

            if (schoolArr.Message != null)
            {
                Debug.Log("validation failed");
                appExpiryText.text = "We are not able to authenticate you! Please try contacting your admin or hello@scholarlab.in";
                appExpiryBox.SetActive(true);
                gameObject.SetActive(true);
                isSSOAuthEnable = true;
            }
            else
            {
                Debug.Log("validation success");
                gameObject.SetActive(false);
                isSSOAuthEnable = false;
            }
        }
    }

    public void SavingAuthValues(string getuid, string getemail)
    {       
        if (!PlayerPrefs.HasKey("uid"))
        { 
            PlayerPrefs.SetString("uid", getuid);
        }
        if (!PlayerPrefs.HasKey("emailid"))
        {
            PlayerPrefs.SetString("emailid", getemail);
        }
        Debug.LogError("uid id :: " + getuid);
        Debug.LogError("email id :: " + getemail);
    }
    public void RetryAuth()
    {
        Validate(PlayerPrefs.GetString("uid"), PlayerPrefs.GetString("emailid"));
    }
    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}

[Serializable]
public class SchoolClass
{
    public string Name;
    public string Description;
    public bool IsSchool;
    public string Board;
    public string Message;
    public int SchoolUserCount;
    public int AllocatedMACAddressCount;
    public int UsedMACAddressCount;
    public int Id;
    public bool IsDeleted;
    public string PerformedBy;
    public string PerformedOn;
}