using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetObject : MonoBehaviour
{

    public GameObject TenKg, FiftyKg, HundredKg;
    public GameObject FrictionScale, ForceScale, FrictionScale2, ForceScale2, FrictionScale3,ForceScale3;
    public Slider force;
    public GameObject ArrowC;
    public GameObject Surfaces;
  
    Vector3 initialScaleForce;
    Vector3 initialScaleFriction;
 
       
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reserobjects()
    {
        TenKg.transform.localPosition = new Vector3(-6.1442f, 2.471f, -1.0369f);
        TenKg.transform.localScale = new Vector3(0.42845f, 0.4496344f, 0.440625f);

        FiftyKg.transform.localPosition = new Vector3(-7.92f, 2.61f, -0.96124f);
        FiftyKg.transform.localScale = new Vector3(0.628125f, 0.5775f, 0.5985001f);

        HundredKg.transform.localPosition = new Vector3(-10.1f, 2.8f, -0.8804f);
        HundredKg.transform.localScale = new Vector3(0.751366f, 0.7278677f, 0.7f);

        FrictionScale.SetActive(false);
        ForceScale.SetActive(false);
        FrictionScale2.SetActive(false);
        ForceScale2.SetActive(false);
        FrictionScale3.SetActive(false);
        ForceScale3.SetActive(false);

        force.GetComponent<Slider>().interactable = true;

        force.value = 0;
        ArrowC.SetActive(true);
        Surfaces.SetActive(false);

       
     
    }
}
