using System;
using _Main.Scripts.SRCarController;
using _Main.Scripts.Track;
using UnityEngine;

namespace _Main.Scripts.Lap
{
    [Serializable]
    public class Standing
    {
        [SerializeField] private CarController myCarController;
        [SerializeField] private CarLapManager myCarLapManager;
        
        public float MyStandingScore()
        {
            return myCarController.CurrentWaypointIndex + myCarLapManager.CurrentLap * TrackWaypointsManager.Instance.Waypoints.Count;
        }
    }
}