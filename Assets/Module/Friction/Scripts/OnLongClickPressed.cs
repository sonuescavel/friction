using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Friction
{
    public class OnLongClickPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool pointerDown;
        private float pointerDownTimer;
        public float requiredHoldTime;
        public UnityEvent onLongClick;

        [SerializeField]
        public GameObject forceArrow;
        public GameObject forceText;
        //internal int clickedCount = 1;
        public float currCountdownValue;


        public void OnPointerDown(PointerEventData eventDada)
        {
            pointerDown = true;
            Debug.Log("OnPointerDown");
        }

        public void OnPointerUp(PointerEventData eventDada)
        {
            StartCoroutine(StartCountdown());
            //Reset();
            Debug.Log("OnPointerUp");
        }
        // Update is called once per frame
        private void Update()
        {
            if (pointerDown)
            {
                pointerDownTimer += Time.deltaTime;
                if (pointerDownTimer > requiredHoldTime)
                {

                    if (onLongClick != null)
                        onLongClick.Invoke();

                }
                forceArrow.SetActive(true);
                forceText.SetActive(true);
                //StartCoroutine(StartCountdown());
            }
        }
        private void Reset()
        {
            pointerDown = false;
            pointerDownTimer = 0;
            forceArrow.SetActive(false);
            forceText.SetActive(false);

        }

        public IEnumerator StartCountdown()
        {
            if (currCountdownValue > 0)
            {
                Debug.Log("Countdown: " + currCountdownValue);
                yield return new WaitForSeconds(0.5f);
                currCountdownValue++;
                forceArrow.SetActive(false);
                forceText.SetActive(false);
                Reset();
                //CanvasDesk.SetActive(false);
                // Hands.SetActive(false);

            }
        }
    }
}