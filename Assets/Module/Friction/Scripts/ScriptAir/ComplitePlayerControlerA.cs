using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Friction
{
    public class ComplitePlayerControlerA : MonoBehaviour
    {
        public float smoothSpeed = 0.125f;
        public Transform target;
        public Vector3 offset;

        void LateUpdate()
        {
            transform.position = target.position + offset;
        }
    }
}