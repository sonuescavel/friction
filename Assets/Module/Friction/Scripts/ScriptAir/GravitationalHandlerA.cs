using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Friction
{
public class GravitationalHandlerA : MonoBehaviour
{
    public GameObject _feather;
    public GameObject _ball;
    public GameObject breakpoint;
    public GameObject Cylinder;
    //public GameObject DustParticles;
    public Slider AirBar;
    //public GameObject SpotLight;
    public GameObject AddAir;
    public Button Fall, ok1, slow;
    //public Button WithoutAir,Fall;
    public Rigidbody _ball_rigidbody;
    public Rigidbody _feather_rigidbody;

    //public GameObject frictionArrow;
    public GameObject forceArrow100;
    public GameObject forceArrow50;
    public GameObject frictionArrow;
    public TimerSpeedA timerspeed;
    public UIManagerA uIManager;


    public Vector3 initialPosition;
    // public BoxCollider boxcolider, boxcolider1, boxcolider2;

    // Start is called before the first frame update

    void Start()
    {

        AirBar.GetComponent<Slider>();

        // boxcolider.GetComponent<BoxCollider>();

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick(Button button)
    {
        //SetSelectedButton(WithAir, new Color32(0, 0, 0, 255));
        //SetSelectedButton(WithoutAir, new Color32(0, 0, 0, 255));    

        if (button.name.Equals("Reset"))
        {
            // Application.LoadLevel(0);
            _ball.transform.localPosition = new Vector3(1.484f, 27.05f, 0.25f);
            _feather.transform.localPosition = new Vector3(3.84f, 7.370002f, 0f);
            _feather.transform.localScale = new Vector3(1f, 1.672882f, 1.167188f);
            _feather.transform.rotation = Quaternion.Euler(-11.223f, 90.00001f, 0f);
            _ball_rigidbody.isKinematic = true;
            _feather_rigidbody.isKinematic = true;
            AirBar.value = 0;
            breakpoint.SetActive(false);
            forceArrow100.SetActive(false);
            forceArrow50.SetActive(false);
            frictionArrow.SetActive(false);
            timerspeed.playing = false;
            timerspeed.TextTimer.text = "00:00:00";
            timerspeed.thetimer = Time.time;
            uIManager.ZoomBar.value = 50;



        }

        else if (button.name.Equals("ok1"))
        {
            AddAir.SetActive(false);
        }
        else if (button.name.Equals(Fall.name))
        {
            if (AirBar.value == 0 || AirBar.value == 2 || AirBar.value == 1)
            {
                if (AirBar.value == 0)
                {

                    timerspeed.playing = true;
                    forceArrow100.SetActive(false);
                    forceArrow50.SetActive(false);
                    frictionArrow.SetActive(true);

                    //forceArrow.transform.localScale += new Vector3(0, 1, 0) * Time.deltaTime * ((AirBar.value) / 100) * 0;
                    _ball_rigidbody.isKinematic = false;
                    _feather_rigidbody.isKinematic = false;
                    _feather_rigidbody.drag = 0;
                    _ball_rigidbody.drag = 0;
                    //boxcolider.center = new Vector3(-8.302379f, 54.87083f, 2.460505f);
                    //boxcolider.size = new Vector3(-8.302379f, 54.87083f, 2.460505f);
                    //boxcolider1.center = new Vector3(-7.898092f, 42.54999f, 1.207362f);
                    //boxcolider1.size = new Vector3(-30.85236f, 86.56105f, 7.107771f);
                    //boxcolider2.center = new Vector3(-3.110695f, 38.73349f, -0.002040978f);
                    //boxcolider2.size = new Vector3(-11.0767f, 89.82424f, 1.468597f);
                    //SetSelectedButton(WithoutAir, new Color32(0, 70, 57, 255));
                    //DustParticles.SetActive(false);
                }
                else if (AirBar.value == 2)
                {
                    timerspeed.playing = true;
                    // ForceValue.text = "100%";
                    forceArrow100.SetActive(true);

                    forceArrow50.SetActive(false);

                    frictionArrow.SetActive(true);

                    _ball_rigidbody.isKinematic = false;
                    _feather_rigidbody.isKinematic = false;
                    _feather_rigidbody.drag = 1;
                    _ball_rigidbody.drag = 0;

                    //SetSelectedButton(WithAir, new Color32(0, 70, 57, 255));
                }
                else if (AirBar.value == 1)
                {
                    timerspeed.playing = true;
                    forceArrow100.SetActive(false);

                    forceArrow50.SetActive(true);

                    frictionArrow.SetActive(true);

                    _ball_rigidbody.isKinematic = false;
                    _feather_rigidbody.isKinematic = false;
                    _feather_rigidbody.drag = 3;
                    _ball_rigidbody.drag = 2;


                }

            }
            else
            {
                AddAir.SetActive(true);
            }
        }
    }

    //public IEnumerator ArrowScaling()
    //{
    //    float Fvalue = breakpoint.GetComponent<Collider>().material.staticFriction;
    //    while (forceArrow.transform.localScale.x <= ((AirBar.value) / 100) * 4 /*|| frictionArrow.transform.localScale.x <= ((AirBar.value / Fvalue) / 100) * 2*/)
    //    {
    //        forceArrow.transform.localScale += new Vector3(1, 0, 0) * Time.deltaTime * ((AirBar.value) / 100) * 4;
    //        //frictionArrow.transform.localScale += new Vector3(1, 0, 0) * Time.deltaTime * ((AirBar.value / Fvalue) / 100) * 2;
    //        yield return null;
    //    }
    //}

    public void SetSelectedButton(Button button, Color color)
    {
        button.GetComponent<Image>().color = color;
    }

    public void Speedfall()
    {
        if (AirBar.value == 2)
        {
            _ball_rigidbody.isKinematic = false;
            _feather_rigidbody.isKinematic = false;
            _feather_rigidbody.drag = 8;
            _ball_rigidbody.drag = 5;
            forceArrow100.SetActive(true);
            forceArrow50.SetActive(false);
            frictionArrow.SetActive(true);
        }
        else if (AirBar.value == 0)
        {
            forceArrow100.SetActive(false);
            forceArrow50.SetActive(false);
            frictionArrow.SetActive(true);
            _ball_rigidbody.isKinematic = false;
            _feather_rigidbody.isKinematic = false;
            _feather_rigidbody.drag = 7;
            _ball_rigidbody.drag = 7;

        }
        else if (AirBar.value == 1)
        {
            _ball_rigidbody.isKinematic = false;
            _feather_rigidbody.isKinematic = false;
            _feather_rigidbody.drag = 9;
            _ball_rigidbody.drag = 8;
            forceArrow100.SetActive(false);

            forceArrow50.SetActive(true);

            frictionArrow.SetActive(true);
        }

    }
}
}
