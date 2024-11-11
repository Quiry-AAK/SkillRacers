using System;
using System.Collections.Generic;
using _Main.Scripts.InGameUI;
using _Main.Scripts.SRCarController.Gear;
using UnityEngine;

namespace _Main.Scripts.SRCarController
{
    public class CarController : MonoBehaviour
    {
        [Header("Comps")] [SerializeField] private Rigidbody carRb;
        [SerializeField] private Vector3 centerOfMass;
        [Header("Wheels")] [SerializeField] private WheelColliders wheelColliders;
        [SerializeField] private WheelMeshes wheelMeshes;

        [Header("Power")] [SerializeField] private float maxSpeed;
        [SerializeField] private float motorPower;
        [SerializeField] private float brakePower;
        [SerializeField] [Range(0f, 1f)] private float acceleration;
        [Header("Steering")] [SerializeField] private float ackermanSteeringTurnRadiusConstant = 6;

        [Header("Down Force")] [SerializeField]
        private float downForce;
        [Header("Gear")] [SerializeField] private List<GearProperties> gears;
        [SerializeField] private float shiftSpeedThreshold;


        [HideInInspector] public float gasInput;
        [HideInInspector] public float steeringInput;

        private Transform tr;
        
        private bool _isBraking = false;
        private int currentGear;
        private float speed;

        private void Start()
        {
            carRb.centerOfMass = centerOfMass;
            tr = transform;
        }

        private void Update()
        {
            CheckInput();
            UpdateWheels();
            UpdateUI();

            var vel = carRb.velocity;
            vel.y = 0f;
            speed = vel.magnitude * 3.6f;
        }

        private void FixedUpdate()
        {
            ApplyMotorTorque();
            ApplyBrake();
            ApplySteering();
            ShiftGears();
            
            carRb.AddForce(-tr.up * (downForce * carRb.velocity.magnitude));
        }

        private void CheckInput()
        {
            gasInput = Input.GetAxis("Vertical");
            steeringInput = Input.GetAxis("Horizontal");

            _isBraking = Input.GetKey(KeyCode.Space);
        }

        private void ApplySteering()
        {
            var steerAngle = 0f;
            if (steeringInput > 0)
            {
                wheelColliders.fRWheel.steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (ackermanSteeringTurnRadiusConstant + (1.5f/2))) * steeringInput;
                wheelColliders.fLWheel.steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (ackermanSteeringTurnRadiusConstant - (1.5f/2))) * steeringInput;
            }
            else if (steeringInput < 0)
            {
                wheelColliders.fRWheel.steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (ackermanSteeringTurnRadiusConstant - (1.5f/2))) * steeringInput;
                wheelColliders.fLWheel.steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (ackermanSteeringTurnRadiusConstant + (1.5f/2))) * steeringInput;
            }
            else
            {
                wheelColliders.fRWheel.steerAngle = 0f;
                wheelColliders.fLWheel.steerAngle = 0f;
            }
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
            var speedFactor = Mathf.Pow(1 - (speed / maxSpeed), 1 - acceleration);
            var appliedMotorPower = motorPower * gears[currentGear].GearTorqueRatio * Time.deltaTime * gasInput *
                                    speedFactor;
            wheelColliders.rRWheel.motorTorque =
                appliedMotorPower;
            wheelColliders.rLWheel.motorTorque = appliedMotorPower;
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

        private void ShiftGears()
        {
            if (currentGear < gears.Count - 1 && speed > gears[currentGear].GearSpeedLimit + shiftSpeedThreshold)
            {
                currentGear++;
            }
            else if (currentGear > 0 && speed < gears[currentGear - 1].GearSpeedLimit - shiftSpeedThreshold)
            {
                currentGear--;
            }
        }

        private void UpdateUI()
        {
            InGameUIManager.Instance.SpeedTxt.text = Mathf.RoundToInt(speed) + "km/h";
            InGameUIManager.Instance.GearTxt.text = (currentGear + 1).ToString();
        }
    }
}