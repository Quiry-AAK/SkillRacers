using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.InGameUI
{
    public class InGameUIManager : MonoSingleton<InGameUIManager>
    {
        [SerializeField] private TextMeshProUGUI speedTxt;
        [SerializeField] private TextMeshProUGUI gearTxt;

        public TextMeshProUGUI SpeedTxt => speedTxt;

        public TextMeshProUGUI GearTxt => gearTxt;
    }
}