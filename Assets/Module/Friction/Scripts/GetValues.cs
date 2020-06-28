using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Friction
{
    public class GetValues : MonoBehaviour
    {
        public static GetValues instance;
        public TextMeshProUGUI forceValue;
        public Slider sliderForApplyForce;
        public GameObject Surfaces;
        public bool isSelectSurfaceDown;
        public GameObject ArrowC, Arrow;
        // Start is called before the first frame update
        void Start()
        {
            instance = this;
        }

        // Update is called once per frame
        void Update()
        {
            forceValue.text = sliderForApplyForce.value.ToString();
        }

        public void SelectSUrfaces()
        {
            ArrowC.SetActive(false);
            isSelectSurfaceDown = !isSelectSurfaceDown;
            isSelectSurfaceDown = false;
            if (!isSelectSurfaceDown)
            {
                Surfaces.SetActive(true);
                isSelectSurfaceDown = true;

                if (InstructionDataScriptFriction.instance.isInstructionClick)
                {
                    ArrowC.GetComponent<Button>().interactable = false;
                    Arrow.GetComponent<Button>().interactable = false;
                    InstructionDataScriptFriction.instance.surfaceEnableI.SetActive(false);
                    FrictionHandler.instance.surfaceButton[0].interactable = true;
                    InstructionDataScriptFriction.instance.greesySurfaceI.SetActive(true);
                }
        }
            else
            {
                Surfaces.SetActive(false);
            }
        }

        public void goneSerface()
        {
            Surfaces.SetActive(false);
            ArrowC.SetActive(true);
        }

    }
}
