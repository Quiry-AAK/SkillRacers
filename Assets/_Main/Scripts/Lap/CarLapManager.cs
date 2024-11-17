using System;
using System.Collections.Generic;
using System.Linq;
using _Main.Scripts.SRCarController;
using _Main.Scripts.Track;
using UnityEngine;

namespace _Main.Scripts.Lap
{
    public class CarLapManager : MonoBehaviour
    {
        [SerializeField] private Standing standing;
        private int currentLap;
        private int currentLapPassedCheckpointCount;
        private int standingScore;

        private Dictionary<int, bool> passedCheckpointsDictionary;

        public int CurrentLap => currentLap;

        public Standing Standing => standing;

        private void Start()
        {
            currentLap = 0;
            currentLapPassedCheckpointCount = 0;
            ResetPassedCheckpointsDictionary();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Checkpoint"))
            {
                PassCheckpoint(GameManager.Instance.GlobalLapManager.Checkpoints.IndexOf(other.gameObject));
            }

            if (other.CompareTag("Finish") && CheckLapFinished())
            {
                currentLap++;
                ResetPassedCheckpointsDictionary();
            }
        }

        private void ResetPassedCheckpointsDictionary()
        {
            passedCheckpointsDictionary = new Dictionary<int, bool>();
            for (int i = 0; i < GameManager.Instance.GlobalLapManager.Checkpoints.Count; i++)
            {
                passedCheckpointsDictionary.Add(i, false);
            }
        }


        private bool CheckLapFinished()
        {
            return !(passedCheckpointsDictionary.Count(x => x.Value == false) > 0);
        }

        private void PassCheckpoint(int checkpointCount)
        {
            passedCheckpointsDictionary[checkpointCount] = true;
        }

        
    }
}