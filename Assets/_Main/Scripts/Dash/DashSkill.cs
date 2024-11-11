using System.Collections;
using _Main.Scripts.Skill;
using UnityEngine;

namespace _Main.Scripts.Dash
{
    public class DashSkill : SRSkill
    {
        [SerializeField] private GameObject rocketThruster;
        [SerializeField] private AnimationCurve rocketThrusterForceCurve;
        [SerializeField] private float rocketThrusterDuration;
        [SerializeField] private float rocketThrusterForce;

        private Rigidbody carRb;

        public override void OnEnable()
        {
            base.OnEnable();
            carRb = transform.parent.GetComponent<Rigidbody>();
        }

        protected override void UseSkill()
        {
            rocketThruster.SetActive(true);
            StartCoroutine(AddForceTilDurationEnds());
        }

        private IEnumerator AddForceTilDurationEnds()
        {
            var startTime = Time.time;
            var timeChecker = startTime + rocketThrusterDuration;
            while (Time.time < timeChecker)
            {
                var curveTime = (Time.time - startTime) / rocketThrusterDuration;

                carRb.AddForce(carRb.transform.forward * (Time.deltaTime * (rocketThrusterForce * rocketThrusterForceCurve.Evaluate(curveTime))));
                yield return null;
            }
        }
    }
}