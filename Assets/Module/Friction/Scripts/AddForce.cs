using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    internal int clickedCount = 1;
    //private bool canclickObjects = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void OnMouseDown()
    {
        
            //gameObject.GetComponent<Rigidbody>().useGravity.Equals(0);
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 100);

    }
}
