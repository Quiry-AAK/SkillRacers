using System;
using UnityEngine;

namespace _Main.Scripts.SRInput
{
    public class InputManager : MonoBehaviour
    {
        protected float gasInput = 1f;
        protected float steeringInput;
        private bool isBraking;


        public float GasInput => gasInput;

        public float SteeringInput => steeringInput;

        public bool IsBraking => isBraking;

        private void Start()
        {
            gasInput = 1f;
        }

        protected virtual void Update()
        {
            GetInputs();
        }
        protected virtual void GetInputs()
        {
            steeringInput = Input.GetAxis("Horizontal");

            isBraking = Input.GetKey(KeyCode.Space);
        }
    }
}