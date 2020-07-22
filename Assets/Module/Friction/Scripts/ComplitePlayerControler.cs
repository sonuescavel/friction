using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace Friction
{
    public class ComplitePlayerControler : MonoBehaviour
    {
        public float smoothSpeed = 0.125f;
        public Transform target;
        public Vector3 offset;

        void Start()
        {
            Debug.Log("move Camera");
        }

        void LateUpdate()
        {
            transform.position = target.position + offset;
        }
    }
}