using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Friction
{
    public class MouseOver : MonoBehaviour

    {
        public float fadeTime;
        public bool displayInfo;
        public GameObject imageText;

        void Start()
        {
            //myText = GameObject.Find("Text").GetComponent<Text>();
            //myText.color = Color.clear;


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

        public void PointerEnter()
        {
            displayInfo = true;
        }

        public void PointerExit()
        {
            displayInfo = false;
            Debug.Log("MouseExited");
        }

        void FadeText()
        {
            if (displayInfo)
            {

                imageText.SetActive(true);

            }
            else
            {
                imageText.SetActive(false);

            }
        }
    }
}