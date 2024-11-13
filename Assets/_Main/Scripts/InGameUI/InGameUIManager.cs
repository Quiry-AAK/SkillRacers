﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.InGameUI
{
    public class InGameUIManager : MonoSingleton<InGameUIManager>
    {
        [SerializeField] private SkillUIManager skillUIManager;
        [SerializeField] private TextMeshProUGUI speedTxt;
        [SerializeField] private TextMeshProUGUI gearTxt;
        [SerializeField] private GameObject wrongDirectionImage;

        public TextMeshProUGUI SpeedTxt => speedTxt;
        public SkillUIManager SkillUIManager => skillUIManager;
        public TextMeshProUGUI GearTxt => gearTxt;

        public GameObject WrongDirectionImage => wrongDirectionImage;
    }
}