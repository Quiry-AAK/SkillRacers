using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.Skill
{
    [CreateAssetMenu(fileName = "New SR Skill", menuName = "SRSkill/ New SR Skill", order = 0)]
    public class SRSkillProperties : ScriptableObject
    {
        [Header("Icon")]
        [SerializeField] private Sprite skillIcon;
        [SerializeField] private Vector3 uiRotation;
        [SerializeField] private Color uiColor;
        [Space] [SerializeField] private GameObject skillPrefab;

        public Sprite SkillIcon => skillIcon;

        public Vector3 UiRotation => uiRotation;

        public Color UiColor => uiColor;

        public GameObject SkillPrefab => skillPrefab;
    }
}