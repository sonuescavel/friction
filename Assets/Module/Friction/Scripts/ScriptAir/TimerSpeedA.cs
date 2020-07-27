using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Friction
{
    public class TimerSpeedA : MonoBehaviour
    {
        public Text TextTimer;
        public float thetimer;
        public float speed = 1;
        public bool playing;
        // Start is called before the first frame update
        void Start()
        {
            TextTimer = GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            if (playing == true)
            {
                thetimer += Time.deltaTime * speed;
                string hours = Mathf.Floor((thetimer % 216000) / 3600).ToString("00");
                string minutes = Mathf.Floor((thetimer % 3600) / 60).ToString("00");
                string seconds = (thetimer % 60).ToString("00");
                TextTimer.text = hours + ":" + minutes + ":" + seconds;
            }
        }
        void clickplay()
        {
            playing = true;
        }
        void clickStop()
        {
            playing = false;
        }
    }
}
