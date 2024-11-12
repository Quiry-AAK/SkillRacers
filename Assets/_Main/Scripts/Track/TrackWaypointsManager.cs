using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.Track
{
    public class TrackWaypointsManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> waypoints;
        [SerializeField] private float roadThickness;

        [Header("Gizmos")] [SerializeField] private Color gizmoColor;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = gizmoColor;
            foreach (var waypoint in waypoints)
            {
                Gizmos.DrawWireSphere(waypoint.transform.position, roadThickness);
            }
        }
    }
}