using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//replace Friction with the name of Use-case which is provided to you.
namespace  Friction
{
public class UIManagerA : MonoBehaviour
{
    public MouseMovementA mouseMovement;
    public Slider ZoomBar;
    public GameObject _PlayPause;
    public Sprite _Play_Button;
    public Sprite _Pause_Button;
    // write all the code regarding interaction with UI and all the click events in screen canvas.

    public void CloseMe()
    {
        Debug.Log("this function use to close the application");
        Application.Quit();
    }

    public void PlayPause()
    {
        if (AppConfig.isPauseApp)
        {
            _PlayPause.GetComponent<Image>().sprite = _Pause_Button;
            AppConfig.isPauseApp = false;
            Time.timeScale = 1;
        }
        else
        {
            _PlayPause.GetComponent<Image>().sprite = _Play_Button;
            AppConfig.isPauseApp = true;
            Time.timeScale = 0;
        }
        Debug.Log("this function use to play pause the game");
    }

    public void Reset()
    {
        Debug.Log("this function use to reset the use-case");
    }
    public void OnSliderChangeValues()
    {
        mouseMovement.OnSliderChangeValues();
    }

    public void OnCameraInOut(Button button)
    {
        if (button.name.Equals("BtnPlus"))
        {
            mouseMovement.OnCameraForward();
        }
        else if (button.name.Equals("BtnMinus"))
        {
            mouseMovement.OnCameraBack();
        }
    }


    public void OnClick(Button button)
    {
        if (button.name.Equals("CloseButton"))
        {
            Application.Quit();

        }

    }
}
}
