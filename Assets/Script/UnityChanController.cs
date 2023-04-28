using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Script
{
    public class UnityChanController : MonoBehaviour
    {
        public float rotationSpeed = 360f;   
        public float moveSpeed = 5f;         
        public void Update()
        {
            Vector3 dir = new Vector3(
                Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")
            );
            if (dir.sqrMagnitude > 0.01f)
            {
                Vector3 forward = Vector3.Slerp(transform.forward, dir,
                    rotationSpeed * Time.deltaTime);
            }
        }
    }
}