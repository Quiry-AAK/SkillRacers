using _Main.Scripts.InGameUI;
using UnityEngine;

namespace _Main.Scripts.Skill
{
    public abstract class SRSkill : MonoBehaviour
    {
        protected CarSkillManager CarSkillManager;
        public virtual void OnEnable()
        {
            InGameUIManager.Instance.SkillUIManager.UseSkillBtn.onClick.AddListener(UseSkill);
            CarSkillManager = transform.parent.GetComponent<CarSkillManager>();
        }
        
        public virtual void OnDisable()
        {
            InGameUIManager.Instance.SkillUIManager.UseSkillBtn.onClick.RemoveListener(UseSkill);
        }

        protected abstract void UseSkill();
    }
}