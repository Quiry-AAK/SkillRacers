using System;
using UnityEngine;

namespace _Main.Scripts.SRCarController
{
    public class CarController : MonoBehaviour
    {
        [Header("Comps")]
        [SerializeField] private Rigidbody carRb;
        [Header("Wheels")]
        [SerializeField] private WheelColliders wheelColliders;
        [SerializeField] private WheelMeshes wheelMeshes;
        
        [Space]
        [SerializeField] private float motorPower;
        [SerializeField] private float brakePower;
        [Header("Steering")] [SerializeField] private float maxSteerAngle;
        [SerializeField] private float steerSmoothSpeed;
        [SerializeField] private float counterSteerFactor;

        private bool _isBraking = false;

        public float gasInput;
        public float steeringInput;

        private float _currentSteerAngle;

        private void Update()
        {
            CheckInput();
            UpdateWheels();
        }

        private void FixedUpdate()
        {
            ApplyMotorTorque();
            ApplyBrake();
            ApplySteering();
        }

        private void CheckInput()
        {
            gasInput = Input.GetAxis("Vertical");
            steeringInput = Input.GetAxis("Horizontal");

            _isBraking = Input.GetKey(KeyCode.Space);
        }

        private void ApplySteering()
        {
            float targetSteerAngle = steeringInput * maxSteerAngle;

            float speed = carRb.velocity.magnitude;
            float counterSteer = -steeringInput * counterSteerFactor * speed;

            targetSteerAngle += counterSteer;

            _currentSteerAngle = Mathf.LerpAngle(_currentSteerAngle, targetSteerAngle, Time.deltaTime * steerSmoothSpeed);

            wheelColliders.fRWheel.steerAngle = _currentSteerAngle;
            wheelColliders.fLWheel.steerAngle = _currentSteerAngle;
        }

        private void ApplyBrake()
        {
            var brakeInput = _isBraking ? 1f : 0f;
            
            wheelColliders.fRWheel.brakeTorque = brakeInput * brakePower * .7f * Time.deltaTime;
            wheelColliders.fLWheel.brakeTorque = brakeInput * brakePower * .7f * Time.deltaTime;
            
            wheelColliders.rLWheel.brakeTorque = brakeInput * brakePower * .3f * Time.deltaTime;
            wheelColliders.rRWheel.brakeTorque = brakeInput * brakePower * .3f * Time.deltaTime;
        }

        private void ApplyMotorTorque()
        {
            wheelColliders.rRWheel.motorTorque = motorPower * gasInput * Time.deltaTime;
            wheelColliders.rLWheel.motorTorque = motorPower * gasInput * Time.deltaTime;
        }

        private void UpdateWheels()
        {
            UpdateAWheel(wheelColliders.fLWheel, wheelMeshes.fLWheel);
            UpdateAWheel(wheelColliders.fRWheel, wheelMeshes.fRWheel);
            UpdateAWheel(wheelColliders.rRWheel, wheelMeshes.rRWheel);
            UpdateAWheel(wheelColliders.rLWheel, wheelMeshes.rLWheel);
        }

        private void UpdateAWheel(WheelCollider wheelCol, MeshRenderer wheelMeshRenderer)
        {
            Quaternion rot;
            Vector3 pos;
            wheelCol.GetWorldPose(out pos, out rot);

            var tr = wheelMeshRenderer.transform;
            tr.position = pos;
            tr.rotation = rot;
        }
    }
}