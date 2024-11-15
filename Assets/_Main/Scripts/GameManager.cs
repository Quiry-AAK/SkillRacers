using System;
using System.Collections.Generic;
using _Main.Scripts.Cars;
using _Main.Scripts.Lap;
using _Main.Scripts.SRGameSettings;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Main.Scripts
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private GlobalLapManager globalLapManager;
        [SerializeField] private List<Transform> spawnPositions;
        [SerializeField] private List<CarProps> cars;
        
        
        public GlobalLapManager GlobalLapManager => globalLapManager;

        private void Start()
        {
            SpawnCars();
        }

        private void SpawnCars()
        {
            var playerSpawnIndex = Random.Range(0, spawnPositions.Count);

            for (int i = 0; i < spawnPositions.Count; i++)
            {
                if (i == playerSpawnIndex)
                {
                    Instantiate(GameSettingsManager.Instance.GameSettings.PlayerCar.PlayerPrefab, spawnPositions[i].position,
                        spawnPositions[i].rotation);
                }

                else
                {
                    var randomIndex = Random.Range(0, cars.Count);
                    Instantiate(cars[randomIndex].AiPrefab, spawnPositions[i].position,
                        spawnPositions[i].rotation);
                }
            }
        }
    }
}