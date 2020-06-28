using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    Vector3 End_pos;
    Vector3 Start_pos;
   public float fracton_of_way_there;


    // Start is called before the first frame update
    void Start()
    {
        Start_pos = transform.position;
       // End_pos = transform.position + new Vector3(0, 0, 5);


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
            End_pos = transform.position + new Vector3(2, 0, 0);

        fracton_of_way_there += 0.01f;
        transform.position = Vector3.Lerp(Start_pos, End_pos, fracton_of_way_there);

    }
}
