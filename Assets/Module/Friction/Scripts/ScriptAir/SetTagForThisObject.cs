using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTagForThisObject : MonoBehaviour
{
    public string tagName;

    void Start()
    {
        gameObject.tag = tagName;
    }
}

