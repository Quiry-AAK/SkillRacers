using UnityEngine;

namespace _Main.Scripts.CarAI
{
    public class AIPropertiesManager : MonoBehaviour
    {
        [SerializeField] private AIProperties aiProperties;

        public AIProperties AiProperties => aiProperties;
    }
}