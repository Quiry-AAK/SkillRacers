using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.InGameUI
{
    public class SkillUIManager : MonoBehaviour
    {
        [SerializeField] private Image img;
        [SerializeField] private Button useSkillBtn;

        private RectTransform tr;

        public Button UseSkillBtn => useSkillBtn;

        private void Start()
        {
            tr = GetComponent<RectTransform>();
        }

        public void HandleUI(Sprite skillIcon, Color color, Vector3 rot)
        {
            img.sprite = skillIcon;
            img.color = color;
            tr.rotation = Quaternion.Euler(rot);
        }
        
        
    }
}