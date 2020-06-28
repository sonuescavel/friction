using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class SwapTecture : MonoBehaviour
{
    public Text buttontext;
    public Texture[] textures;
    public Material[] objMaterial;
    public int currentTexture;
    public Renderer _renderer;
    internal static readonly SwapTecture instance;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown (KeyCode.Space))
        {
            currentTexture++;
            currentTexture %= textures.Length;
            _renderer.material = objMaterial[currentTexture];

            //Renderer.Get
        }
    }
     public void Button_click()
     {
        Debug.Log("Slightly Rough Surface");

     }


    public void Button_String(string msg)
    {
        buttontext.text = msg;


    }


}



