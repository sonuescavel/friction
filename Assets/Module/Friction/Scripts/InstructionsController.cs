using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Friction
{
    public class InstructionsController : MonoBehaviour
    {
        //private static float DelayBetweenObjectAnimations = 0.075f;

        public AppConfig appConfig;
        public UIManager uIManager;
        public MoveObject moveObject;
        public FrictionHandler frictionHandler;
        public GravitationalHandler gravitationalHandler;
        public SliderValueIcnDec sliderValueIcnDec;
        public Button air, solid, btnPlus,BtnMinus, AireBarIncrease, AireBarDecrease;
        public Collider TenKg1, FiftyKg1, HundredKg1;
       
       // public int _activeCase;

        public GameObject _Instructions;
        public GameObject _InstructionsAir;
        public GameObject _1;
        public Button _1Button;
        public GameObject _2;
        public Button _2Button;
        public GameObject _3;
        public Button _3Button;
        public GameObject _4;
        public Button _4Button;
        public GameObject _5;
        public Button _5Button;
        public GameObject _6;
        public Button _6Button;
        public GameObject _7;
        public Button _7Button;
        public GameObject _8;
        public Button _8Button;
        public GameObject _9;
        public Button _9Button;
        public GameObject _10;
        public Button _10Button;
        public GameObject _11;
        public Button _11Button;
        public GameObject _12;
        public Button _12Button;
        public GameObject _13;
        public Button _13Button;
        public GameObject _14;
        public Button _14Button;
        public GameObject _15;
        public Button _15Button;
        public GameObject _16;
        public Button _16Button;
        public GameObject _17;
        public Button _17Button;
       
     
        // Start is called before the first frame update
        void Start()
        {

        }


        // Update is called once per frame
        void Update()
        {

        }

        public void OnClick(Button button)
        {
            //DisableAllUI();
            if (button.name.Equals(_1Button.name))
            {
                _1.SetActive(false);
                _2.SetActive(true);
            }
            else if (button.name.Equals(_2Button.name))
            {
                _2.SetActive(false);
                _3.SetActive(true);
            }
            else if (button.name.Equals(_3Button.name))
            {
                _3.SetActive(false);
                _4.SetActive(true);
            }
            else if (button.name.Equals(_4Button.name))
            {
                _4.SetActive(false);
               moveObject.Surfaces.SetActive(true);
              // frictionHandler._Button_click1();
               _5.SetActive(true);
            }
            else if (button.name.Equals(_5Button.name))
            {
                _5.SetActive(false);
                _6.SetActive(true);
                moveObject.OnMouseDown();

            }
            else if (button.name.Equals(_6Button.name))
            {
                _6.SetActive(false);
                _7.SetActive(true);
                moveObject.slider.value = 2;
            }
            else if (button.name.Equals(_7Button.name))
            {
                _7.SetActive(false);
                _8.SetActive(true);
                moveObject.OnMouseDown();
            }
            else if (button.name.Equals(_8Button.name))
            {
                _8.SetActive(false);
                _9.SetActive(true);
               // moveObject.onLongClickPressed.enabled = true;
            }
            else if (button.name.Equals(_9Button.name))
            {
                _9.SetActive(false);
                moveObject.OnClick(moveObject.Resetimage);              
                _10.SetActive(true);
               
            }
            else if (button.name.Equals(_10Button.name))
            {
                _10.SetActive(false);
                moveObject.OnClick(moveObject.Slow);     
                _17.SetActive(true);
            }
            else if (button.name.Equals(_17Button.name))
            {
                _17.SetActive(false);
                moveObject.OnClick(moveObject.Reset);
                _11.SetActive(true);
            }
            else if (button.name.Equals(_11Button.name))
            {
                _11.SetActive(false);
                appConfig.air.SetActive(true);
                appConfig.solid.SetActive(false);
                appConfig.complitePlayerControler.enabled = true;
                _12.SetActive(true);
            }
            else if (button.name.Equals(_12Button.name))
            {
                _12.SetActive(false);
                gravitationalHandler.airBarSlider.value = 1;
                _13.SetActive(true);
            }
            else if (button.name.Equals(_13Button.name))
            {
                _13.SetActive(false);
              //  gravitationalHandler.OnClick(gravitationalHandler.Fall);  
                _14.SetActive(true);
            }
            else if (button.name.Equals(_14Button.name))
            {
                _14.SetActive(false);
                _15.SetActive(true);
            }
            else if (button.name.Equals(_15Button.name))
            {
                _15.SetActive(false);
               // gravitationalHandler.Speedfall();  
                _16.SetActive(true);
            }
            else if (button.name.Equals(_16Button.name))

            {
               // gravitationalHandler.OnClick(gravitationalHandler.Reset); 
                _16.SetActive(false);
                EnableAllUI();
                
            }
        }
            

        public void DisableAllUI()
        {
            AppConfig.isInstruction = true;

            _1.SetActive(false);
            _2.SetActive(false);
            _3.SetActive(false);
            _4.SetActive(false);
            _5.SetActive(false);
            _6.SetActive(false);
            _7.SetActive(false);
            _8.SetActive(false);
            _9.SetActive(false);
            _10.SetActive(false);
            _11.SetActive(false);
            _12.SetActive(false);
            _13.SetActive(false);
            _14.SetActive(false);
            _15.SetActive(false);
            _16.SetActive(false);
            _17.SetActive(false);

            uIManager.ExitInstructionModeAir.SetActive(true);
            uIManager.ExitInstructionMode.SetActive(true);
            _Instructions.SetActive(true);
            _InstructionsAir.SetActive(true);


            air.enabled = false;
            solid.enabled = false;
            btnPlus.enabled = false;
            BtnMinus.enabled = false;
            uIManager.Slider.enabled = false;
            AireBarIncrease.enabled = false;
            AireBarDecrease.enabled = false;
            sliderValueIcnDec.force.enabled = false;
            TenKg1.GetComponent<Collider>().enabled = false;
            FiftyKg1.GetComponent<Collider>().enabled = false;
            HundredKg1.GetComponent<Collider>().enabled = false;
            gravitationalHandler.fallButton.enabled = false;
        //    gravitationalHandler.Assupmtion.enabled = false;
           // gravitationalHandler.Reset.enabled = false;
            moveObject.Reset.enabled = false;
            moveObject.Resetimage.enabled = false;
            gravitationalHandler.airBarSlider.enabled = false;
            
        }

        public void EnableAllUI()
        {
            AppConfig.isInstruction = false;

            //_1.SetActive(true);
            //_2.SetActive(true);
            //_3.SetActive(true);
            //_4.SetActive(true);
            //_5.SetActive(true);
            //_6.SetActive(true);
            //_7.SetActive(true);
            //_8.SetActive(true);
            //_9.SetActive(true);
            //_10.SetActive(true);
            //_11.SetActive(true);
            //_12.SetActive(true);
            //_13.SetActive(true);
            //_14.SetActive(true);
            //_15.SetActive(true);
            //_16.SetActive(true);
            //_17.SetActive(true);

            uIManager.ExitInstructionModeAir.SetActive(false);
            uIManager.ExitInstructionMode.SetActive(false);
            _Instructions.SetActive(false);
            _InstructionsAir.SetActive(false);

            air.enabled = true;
            solid.enabled = true;
            btnPlus.enabled = true;
            BtnMinus.enabled = true;
            uIManager.Slider.enabled = true;
            AireBarIncrease.enabled = true;
            AireBarDecrease.enabled = true;
            sliderValueIcnDec.force.enabled = true;
            FiftyKg1.GetComponent<Collider>().enabled = true;
            TenKg1.GetComponent<Collider>().enabled = true;
            HundredKg1.GetComponent<Collider>().enabled = true;
            gravitationalHandler.fallButton.enabled = true;
           // gravitationalHandler.Assupmtion.enabled = true;
          //  gravitationalHandler.Reset.enabled = true;
            moveObject.Reset.enabled = true;
            moveObject.Resetimage.enabled = true;
            gravitationalHandler.airBarSlider.enabled = true;
            

        }

        //internal IEnumerator ReSetCameraForInstruction()
        //{
        //    float countdownValue = 2;
        //    while (countdownValue > 0)
        //    {
        //        if (countdownValue == 1)
        //        {
        //            AppConfig.isInstruction = true;
        //            uIManager._slider.value = 60;
        //            //uIManager.OnClick(uIManager._Front);

        //            if (_activeCase == 6)
        //            {
        //                OnClick(_btn_6);
        //            }
        //            else if (_activeCase == 7)
        //            {
        //                OnClick(_btn_7);
        //            }
        //        }
        //        yield return new WaitForSeconds(1.0f);
        //        countdownValue--;
        //    }
        //}

        //public IEnumerator ShowBallonRubbingRedBallon()
        //{
        //    woolenClothHandler.red_ballon_animater.enabled = true;
        //    float countdownValue = 2;

        //    while (countdownValue > 0)
        //    {
        //        if (countdownValue == 1)
        //        {
        //            woolenClothHandler.red_ballon_animater.enabled = false;
        //        }
        //        yield return new WaitForSeconds(1.0f);
        //        countdownValue--;
        //    }
        //}

        //public IEnumerator ShowBallonRubbingYellowBallon()
        //{
        //    woolenClothHandler.yellow_ballon_animater.enabled = true;
        //    float countdownValue = 2;

        //    while (countdownValue > 0)
        //    {
        //        if (countdownValue == 1)
        //        {
        //            woolenClothHandler.yellow_ballon_animater.enabled = false;
        //        }
        //        yield return new WaitForSeconds(1.0f);
        //        countdownValue--;
        //    }
        //}
    }
}
