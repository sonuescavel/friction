using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Friction
{
    public class ParticleBarControler : MonoBehaviour
    {
        // Start is called before the first frame update
        private Slider ParticleBar;
        public GameObject[] Sparks;
        float gap;



        void Start()
        {
            ParticleBar = (Slider)GetComponent(typeof(Slider));
            gap = 1.0f / Sparks.Length;
        }

        // Update is called once per frame
        public void Update()
        {
            /*Debug.Log(ParticleBar.value);*/
            for (int i = 0; i < Sparks.Length; i++)
            {
                if (gap * (i) < ParticleBar.value)
                {
                    Sparks[i].SetActive(true);
                }
                else
                    Sparks[i].SetActive(false);
            }
        }
    }
}