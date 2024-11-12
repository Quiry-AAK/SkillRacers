using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.Skill
{
    [CreateAssetMenu(fileName = "New SR Skill", menuName = "SRSkill/ New SR Skill", order = 0)]
    public class SRSkillProperties : ScriptableObject
    {
        [Header("Icon")]
        [SerializeField] private Sprite skillIcon;
        [Space] [SerializeField] private GameObject skillPrefab;

        public Sprite SkillIcon => skillIcon;

        public GameObject SkillPrefab => skillPrefab;
    }
}