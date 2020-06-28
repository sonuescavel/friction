using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//replace use_case_name with the name of Use-case which is provided to you.
namespace  use_case_name
{
    // this class is attached with Canvas object of scene.
    public class UIManager : MonoBehaviour
    {
        // write all the code regarding interaction with UI and all the click events in screen canvas.

        public void CloseMe()
        {
            Debug.Log("this function use to close the application");
            Application.Quit();
        }

        public void PlayPause()
        {
            Debug.Log("this function use to play pause the game");
        }

        public void Reset() 
        {
            Debug.Log("this function use to reset the use-case");
        }

    }
}


