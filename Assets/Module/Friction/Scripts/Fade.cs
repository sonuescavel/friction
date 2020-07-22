using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Friction
{
    public class Fade : MonoBehaviour
    {
        public string myStringT;
        public Text myTextT;
        public float fadeTimeT;
        public bool displayInfoT;

        // Start is called before the first frame update
        void Start()
        {
            myTextT = GameObject.Find("Text").GetComponent<Text>();
            myTextT.color = Color.clear;
        }

        // Update is called once per frame
        void Update()
        {
            FadeText();
        }
        void OnMouseOver()
        {
            displayInfoT = true;

        }
        void OnMouseExit()
        {
            displayInfoT = false;
        }

        public void FadeText()
        {
            if (displayInfoT)
            {

                myTextT.text = myStringT;
                myTextT.color = Color.Lerp(myTextT.color, Color.black, fadeTimeT * Time.deltaTime);
                //imagereset.SetActive(true);
            }
            else
            {
                myTextT.color = Color.Lerp(myTextT.color, Color.clear, fadeTimeT * Time.deltaTime);
                //imagereset.SetActive(false);
            }
        }
    }
}