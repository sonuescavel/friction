using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Friction
{
    public class RedBalloonController : MonoBehaviour
    {
        //public Texture2D cursor;
        //public Texture2D cursor_1;
        //public GameObject _obj_Canvas_balloon;
        //public string myString;
        //public Text myText;
        public float fadeTime;
        public bool displayInfo;
        public GameObject imageText;


        // Start is called before the first frame update
        void Start()
        {
            //myText = GameObject.Find("Text").GetComponent<Text>();
            //myText.color = Color.clear;
        }

        // Update is called once per frame
        void Update()
        {
            FadeText();
            // Debug.Log(GetClosestObject().name);
        }
        void OnMouseOver()
        {
            displayInfo = true;
            //imageText.SetActive(true);

        }
        //void OnMouseEnter()
        //{

        //    Cursor.SetCursor(cursor_1, Vector2.zero, CursorMode.Auto);
        //   // _obj_Canvas_balloon.SetActive(true);
        //}

        void OnMouseExit()
        {
            displayInfo = false;
            // imageText.SetActive(false);
            // Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            // _obj_Canvas_balloon.SetActive(false);
        }
        void FadeText()
        {
            if (displayInfo)
            {
                //myText.text = myString;
                imageText.SetActive(true);
                //myText.color = Color.Lerp(myText.color, Color.white, fadeTime * Time.deltaTime);
                //imagereset.SetActive(true);
            }
            else
            {
                imageText.SetActive(false);
                //myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
                //imagereset.SetActive(false);
            }
        }

        /*private void OnMouseDown()
        {
            Cursor.SetCursor(cursor_1, Vector2.zero, CursorMode.Auto);
        }

        private void OnMouseUp()
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }*/
    }
}