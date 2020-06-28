using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUi : MonoBehaviour
{
    public string myString;
    public Text myText;
    public float fadeTime;
    public bool displayInfo;
    public GameObject imagereset;
    public GameObject imageTextR;
    public GameObject slowB;


    // Start is called before the first frame update
    void Start()
    {
        myText = GameObject.Find("Text").GetComponent<Text>();
        myText.color = Color.clear;


    }

    // Update is called once per frame
    void Update()
    {
        FadeText();
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            Screen.lockCursor = false;

        }*/

    }
    void OnMouseOver()
    {
        displayInfo = true;

    }
    void OnMouseExit()
    {
        displayInfo = false;
    }

    void FadeText()
    {
        if (displayInfo)
        {
            imageTextR.SetActive(true);
            myText.text = myString;
            myText.color = Color.Lerp(myText.color, Color.black, fadeTime * Time.deltaTime);
            //imagereset.SetActive(true);
        }
        else
        {
            imageTextR.SetActive(false);
            myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
            //imagereset.SetActive(false);
        }
    }
}