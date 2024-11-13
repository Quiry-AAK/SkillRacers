using System;
using _Main.Scripts.SRInput;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace _Main.Scripts.CarAI
{
    public class CarAIInputManager : InputManager
    {
        [SerializeField] private Transform testTarget;
        [SerializeField] private NavMeshAgent navmeshAgent;

        [SerializeField] private float angleThreshold;

        private Transform tr;
        
        private Vector3 navmeshLocalPos;

        private void Start()
        {
            AdjustNavmesh();
            tr = transform;
        }

        private void AdjustNavmesh()
        {
            navmeshAgent.isStopped = true;
            navmeshLocalPos = navmeshAgent.transform.localPosition;
            navmeshAgent.transform.SetParent(null);
        }

        private void MakeNavmeshFollowToCar()
        {
            var pos = transform.position;
            pos += navmeshLocalPos;
            navmeshAgent.transform.position = pos;
            
            navmeshAgent.SetDestination(testTarget.position);
        }

        protected override void Update()
        {
            base.Update();
            MakeNavmeshFollowToCar();
        }

        protected override void GetInputs()
        {
            if (navmeshAgent.path.corners.Length < 2)
            {
                return;
            }
            
            var dir = (navmeshAgent.path.corners[1] - tr.position).normalized;
            var angle = Vector3.SignedAngle(tr.forward, dir, Vector3.up);
            
            if (Mathf.Abs(angle) < angleThreshold)
            {
                steeringInput = 0f;
            }
            else
            {
                steeringInput = angle < 0f ? steeringInput = -1f : steeringInput = 1f;
            }
        }
    }
}