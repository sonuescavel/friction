using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppConfig : MonoBehaviour
{
    public static bool isMouseDragForGravitation;
    public static bool isMouseDrag;
    public static bool isPauseApp;
    public static bool isInstruction;
    public static int Gravitation;

    public GameObject air;
    public GameObject solid;
    public ComplitePlayerControler complitePlayerControler;
    // Start is called before the first frame update
    void Start()
    {
        //complitePlayerControler=GetComponent<ComplitePlayerControler>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick(Button button)
    {
        if (button.name.Equals("Air"))
        {
            air.SetActive(true);
            solid.SetActive(false);
            complitePlayerControler.enabled = true;
        }
        else if (button.name.Equals("Solid"))
        {
            solid.SetActive(true);
            air.SetActive(false);
            complitePlayerControler.enabled = false;
            
        }
    }
}
