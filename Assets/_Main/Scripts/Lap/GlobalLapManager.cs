using System;
using System.Collections.Generic;
using System.Linq;
using _Main.Scripts.SRCarController;
using _Main.Scripts.Track;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Main.Scripts.Lap
{
    public class GlobalLapManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> checkpoints;
        [SerializeField] private List<Standing> standingList;

        public List<GameObject> Checkpoints => checkpoints;

        public List<Standing> StandingList => standingList;

        private void Start()
        {
            standingList = new List<Standing>();
            var arr = FindObjectsOfType<CarController>();
            standingList = arr.Select(x => x.GetComponent<CarLapManager>().Standing).ToList();
        }

        private void Update()
        {
            UpdateRanking();
        }

        private void UpdateRanking()
        {
            standingList = standingList.OrderByDescending(x => x.MyStandingScore()).ToList();
        }
    }
}