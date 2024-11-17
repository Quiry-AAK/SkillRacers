using System;
using Cinemachine;
using UnityEngine;

namespace _Main.Scripts.SRCamera
{
    public class PlayerCameraManager : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera raceCam;
        [SerializeField] private CinemachineVirtualCamera endCam;

        private void Start()
        {
            ChangeCamToRaceCam();
        }

        private void ChangeCamToRaceCam()
        {
            raceCam.Priority = 10;
            endCam.Priority = 0;
        }
        
        public void ChangeCamToEndCam()
        {
            raceCam.Priority = 0;
            endCam.Priority = 10;
        }
    }
}