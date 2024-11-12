using _Main.Scripts.InGameUI;
using UnityEngine;

namespace _Main.Scripts.Skill
{
    public class CarSkillManager : MonoBehaviour
    {
        private SRSkillProperties equippedSkillProperties;

        public bool EquipSkillIfPossible(SRSkillProperties skillProperties)
        {
            if (equippedSkillProperties != null) return false;
            equippedSkillProperties = skillProperties;
            InGameUIManager.Instance.SkillUIManager.HandleUI(skillProperties.SkillIcon, skillProperties.UiColor, skillProperties.UiRotation);
            return true;
        }
    }
}