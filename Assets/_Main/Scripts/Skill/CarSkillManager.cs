using _Main.Scripts.InGameUI;
using UnityEngine;

namespace _Main.Scripts.Skill
{
    public class CarSkillManager : MonoBehaviour
    {
        [SerializeField] private GameObject caster;
        [SerializeField] private FXSockets fxSockets;
        private SRSkillProperties equippedSkillProperties;

        private float cooldown;

        public FXSockets FxSockets => fxSockets;

        public GameObject Caster => caster;

        public bool EquipSkillIfPossible(SRSkillProperties skillProperties)
        {
            if (equippedSkillProperties != null) {return false;}
            equippedSkillProperties = skillProperties;
            InGameUIManager.Instance.SkillUIManager.HandleUI(skillProperties.SkillIcon);
            return true;
        }

        public void UnequipSkill()
        {
            equippedSkillProperties = null;
            InGameUIManager.Instance.SkillUIManager.ResetUI();
        }
    }
}