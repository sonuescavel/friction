using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerColliderA : MonoBehaviour
{
    public GameObject _ball;
    public GameObject breakpoint;
    public TimerSpeed timerspeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (_ball == true)
        {
            timerspeed.playing = false;
            breakpoint.SetActive(true);


        }

    }

}
