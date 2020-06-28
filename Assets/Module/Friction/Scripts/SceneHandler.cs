using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;

namespace Friction
{
    public class SceneHandler : MonoBehaviour
    {
        //public UIManager uIManager;
        //public MouseMovement mouseMovement;

        //public Text Top;
        //public Text Front;
        //public Text Right;
        //public Text Left;
        //public CameraController target;
        //// Start is called before the first frame update
        //void Start()
        //{
        //    AppConfig.isMouseDrag = false;
        //    AppConfig.isPauseApp = false;
        //    mouseMovement.target = target._target;

        //    //StartCoroutine(SetCamera(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f)));
        //}

        //private IEnumerator SetCamera(Vector3 vector3, Vector3 rotation)
        //{
        //    float distance = Vector3.Distance(Camera.main.transform.position, vector3);
        //    float finalSpeed = (distance / 30f) * 1f;
        //    while (Vector3.Distance(Camera.main.transform.position, vector3) > 0.1f)
        //    {
        //        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, vector3, Time.deltaTime / finalSpeed);
        //        Camera.main.transform.eulerAngles = new Vector3(Mathf.LerpAngle(Camera.main.transform.eulerAngles.x, rotation.x, Time.deltaTime / finalSpeed), Mathf.LerpAngle(Camera.main.transform.eulerAngles.y, rotation.y, Time.deltaTime / finalSpeed), Mathf.LerpAngle(Camera.main.transform.eulerAngles.z, rotation.z, Time.deltaTime / finalSpeed));
        //        Camera.main.fieldOfView = 60;
        //        yield return null;
        //    }
        //}

        //// Update is called once per frame
        //void Update()
        //{

        //}

        //public void OnClick(Button button)
        //{
        //    AppConfig.isMouseDrag = false;
        //    AppConfig.isPauseApp = false;
        //    if (button.name.Equals("Solid"))
        //    {
        //        SceneManager.LoadScene("Solid");
        //    }
        //    else if (button.name.Equals("Liquid"))
        //    {
        //        SceneManager.LoadScene("Liquid");
        //    }
        //    else if (button.name.Equals("Air"))
        //    {
        //        SceneManager.LoadScene("Air");
        //    }



        //}


        //public void Button_String(string msg)
        //{
        //    //  buttontext.text = msg;


        //}


    }
}