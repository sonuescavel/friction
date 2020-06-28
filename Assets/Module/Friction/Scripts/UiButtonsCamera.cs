using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UiButtonsCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void OnClick(Button button)
    //{
    //    if (button.name.Equals("Front"))
    //    {
    //        if (_activeScene == 1)
    //        {
    //            iTween.MoveTo(Camera.main.gameObject, sceneHandler.target_1_Push_And_Pull._front.transform.localPosition, camMoveSpeed);
    //            iTween.RotateTo(Camera.main.gameObject, sceneHandler.target_1_Push_And_Pull._front.transform.localEulerAngles, camMoveSpeed);
    //            _CameraViewText.text = "Front View";
    //        }
    //        else if (_activeScene == 2)
    //        {

    //        }
    //        else if (_activeScene == 3)
    //        {

    //        }
    //        else if (_activeScene == 4)
    //        {
    //            iTween.MoveTo(Camera.main.gameObject, sceneHandler.target_4_Magnetic._front.transform.localPosition, camMoveSpeed);
    //            iTween.RotateTo(Camera.main.gameObject, sceneHandler.target_4_Magnetic._front.transform.localEulerAngles, camMoveSpeed);
    //            _CameraViewText.text = "Front View";
    //        }
    //        else if (_activeScene == 5)
    //        {
    //            iTween.MoveTo(Camera.main.gameObject, sceneHandler.target_5_Electrostatic._front.transform.localPosition, camMoveSpeed);
    //            iTween.RotateTo(Camera.main.gameObject, sceneHandler.target_5_Electrostatic._front.transform.localEulerAngles, camMoveSpeed);
    //            _CameraViewText.text = "Front View";
    //        }
    //        else if (_activeScene == 6)
    //        {
    //            iTween.MoveTo(Camera.main.gameObject, sceneHandler.target_6_Gravitation._front.transform.localPosition, camMoveSpeed);
    //            iTween.RotateTo(Camera.main.gameObject, sceneHandler.target_6_Gravitation._front.transform.localEulerAngles, camMoveSpeed);
    //            _CameraViewText.text = "Front View";
    //        }
    //    }
    //    else if (button.name.Equals("Left"))
    //    {
    //        if (_activeScene == 1)
    //        {
    //            iTween.MoveTo(Camera.main.gameObject, sceneHandler.target_1_Push_And_Pull._left.transform.localPosition, camMoveSpeed);
    //            iTween.RotateTo(Camera.main.gameObject, sceneHandler.target_1_Push_And_Pull._left.transform.localEulerAngles, camMoveSpeed);
    //            _CameraViewText.text = "Left View";
    //        }
    //        else if (_activeScene == 2)
    //        {

    //        }
    //        else if (_activeScene == 3)
    //        {

    //        }
    //        else if (_activeScene == 4)
    //        {
    //            iTween.MoveTo(Camera.main.gameObject, sceneHandler.target_4_Magnetic._left.transform.localPosition, camMoveSpeed);
    //            iTween.RotateTo(Camera.main.gameObject, sceneHandler.target_4_Magnetic._left.transform.localEulerAngles, camMoveSpeed);
    //            _CameraViewText.text = "Left View";
    //        }
    //        else if (_activeScene == 5)
    //        {
    //            iTween.MoveTo(Camera.main.gameObject, sceneHandler.target_5_Electrostatic._left.transform.localPosition, camMoveSpeed);
    //            iTween.RotateTo(Camera.main.gameObject, sceneHandler.target_5_Electrostatic._left.transform.localEulerAngles, camMoveSpeed);
    //            _CameraViewText.text = "Left View";
    //        }
    //        else if (_activeScene == 6)
    //        {
    //            iTween.MoveTo(Camera.main.gameObject, sceneHandler.target_6_Gravitation._left.transform.localPosition, camMoveSpeed);
    //            iTween.RotateTo(Camera.main.gameObject, sceneHandler.target_6_Gravitation._left.transform.localEulerAngles, camMoveSpeed);
    //            _CameraViewText.text = "Left View";
    //        }
    //    }
    //    else if (button.name.Equals("Right"))
    //    {
    //        if (_activeScene == 1)
    //        {
    //            iTween.MoveTo(Camera.main.gameObject, sceneHandler.target_1_Push_And_Pull._right.transform.localPosition, camMoveSpeed);
    //            iTween.RotateTo(Camera.main.gameObject, sceneHandler.target_1_Push_And_Pull._right.transform.localEulerAngles, camMoveSpeed);
    //            _CameraViewText.text = "Right View";
    //        }
    //        else if (_activeScene == 2)
    //        {

    //        }
    //        else if (_activeScene == 3)
    //        {

    //        }
    //        else if (_activeScene == 4)
    //        {
    //            iTween.MoveTo(Camera.main.gameObject, sceneHandler.target_4_Magnetic._right.transform.localPosition, camMoveSpeed);
    //            iTween.RotateTo(Camera.main.gameObject, sceneHandler.target_4_Magnetic._right.transform.localEulerAngles, camMoveSpeed);
    //            _CameraViewText.text = "Right View";
    //        }
    //        else if (_activeScene == 5)
    //        {
    //            iTween.MoveTo(Camera.main.gameObject, sceneHandler.target_5_Electrostatic._right.transform.localPosition, camMoveSpeed);
    //            iTween.RotateTo(Camera.main.gameObject, sceneHandler.target_5_Electrostatic._right.transform.localEulerAngles, camMoveSpeed);
    //            _CameraViewText.text = "Right View";
    //        }
    //        else if (_activeScene == 6)
    //        {
    //            iTween.MoveTo(Camera.main.gameObject, sceneHandler.target_6_Gravitation._right.transform.localPosition, camMoveSpeed);
    //            iTween.RotateTo(Camera.main.gameObject, sceneHandler.target_6_Gravitation._right.transform.localEulerAngles, camMoveSpeed);
    //            _CameraViewText.text = "Right View";
    //        }
    //    }
    //    else if (button.name.Equals("Top"))
    //    {
    //        if (_activeScene == 1)
    //        {
    //            iTween.MoveTo(Camera.main.gameObject, sceneHandler.target_1_Push_And_Pull._top.transform.localPosition, camMoveSpeed);
    //            iTween.RotateTo(Camera.main.gameObject, sceneHandler.target_1_Push_And_Pull._top.transform.localEulerAngles, camMoveSpeed);
    //            _CameraViewText.text = "Top View";
    //        }
    //        else if (_activeScene == 2)
    //        {

    //        }
    //        else if (_activeScene == 3)
    //        {

    //        }
    //        else if (_activeScene == 4)
    //        {
    //            iTween.MoveTo(Camera.main.gameObject, sceneHandler.target_4_Magnetic._top.transform.localPosition, camMoveSpeed);
    //            iTween.RotateTo(Camera.main.gameObject, sceneHandler.target_4_Magnetic._top.transform.localEulerAngles, camMoveSpeed);
    //            _CameraViewText.text = "Top View";
    //        }
    //        else if (_activeScene == 5)
    //        {
    //            iTween.MoveTo(Camera.main.gameObject, sceneHandler.target_5_Electrostatic._top.transform.localPosition, camMoveSpeed);
    //            iTween.RotateTo(Camera.main.gameObject, sceneHandler.target_5_Electrostatic._top.transform.localEulerAngles, camMoveSpeed);
    //            _CameraViewText.text = "Top View";
    //        }
    //        else if (_activeScene == 6)
    //        {

    //        }
    //    }
    //}
}
