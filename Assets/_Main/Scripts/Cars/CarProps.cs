using UnityEngine;

namespace _Main.Scripts.Cars
{
    [CreateAssetMenu(fileName = "New Car", menuName = "Cars/New Car", order = 0)]
    public class CarProps : ScriptableObject
    {
        [Header("Power")] [SerializeField] private float maxSpeed;
        [SerializeField] private float motorPower;
        [SerializeField] private float brakePower;
        
        public float MaxSpeed => maxSpeed;

        public float MotorPower => motorPower;

        public float BrakePower => brakePower;
    }
}