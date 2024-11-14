using System;
using _Main.Scripts.CarAI;
using _Main.Scripts.InGameUI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Main.Scripts.Skill
{
    public abstract class SRSkill : MonoBehaviour
    {
        protected CarSkillManager CarSkillManager;
        public virtual void OnEnable()
        {
            CarSkillManager = transform.parent.GetComponent<CarSkillManager>();

            switch (CarSkillManager.CasterType)
            {
                case CasterType.AI:
                    var aiProps = CarSkillManager.gameObject.GetComponent<AIPropertiesManager>().AiProperties;
                    var useTime = Random.Range(aiProps.AiUseSkillMinTime, aiProps.AiUseSkillMaxTime);
                    Invoke("UseSkill", useTime);
                    break;
                case CasterType.Human:
                    InGameUIManager.Instance.SkillUIManager.UseSkillBtn.onClick.AddListener(UseSkill);
                    break;
            }
            
        }
        
        public virtual void OnDisable()
        {
            switch (CarSkillManager.CasterType)
            {
                case CasterType.AI:
                    break;
                case CasterType.Human:
                    InGameUIManager.Instance.SkillUIManager.UseSkillBtn.onClick.RemoveListener(UseSkill);
                    break;
            }
        }

        protected abstract void UseSkill();
    }
}