using System;
using UnityEngine;

namespace _Main.Scripts.SRInput
{
    public class InputManager : MonoBehaviour
    {
        private float gasInput, steeringInput;
        private bool isBraking;

        public float GasInput => gasInput;

        public float SteeringInput => steeringInput;

        public bool IsBraking => isBraking;

        private void Update()
        {
            GetInputs();
        }
        private void GetInputs()
        {
            gasInput = Input.GetAxis("Vertical");
            steeringInput = Input.GetAxis("Horizontal");

            isBraking = Input.GetKey(KeyCode.Space);
        }
    }
}