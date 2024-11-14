using _Main.Scripts.Lap;
using UnityEngine;

namespace _Main.Scripts
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private GlobalLapManager globalLapManager;
        public GlobalLapManager GlobalLapManager => globalLapManager;
    }
}