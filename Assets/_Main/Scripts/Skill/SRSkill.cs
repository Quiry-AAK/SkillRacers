using _Main.Scripts.InGameUI;
using UnityEngine;

namespace _Main.Scripts.Skill
{
    public abstract class SRSkill : MonoBehaviour
    {
        public virtual void OnEnable()
        {
            InGameUIManager.Instance.SkillUIManager.UseSkillBtn.onClick.AddListener(UseSkill);
        }
        
        public virtual void OnDisable()
        {
            InGameUIManager.Instance.SkillUIManager.UseSkillBtn.onClick.RemoveListener(UseSkill);
        }

        protected abstract void UseSkill();
    }
}