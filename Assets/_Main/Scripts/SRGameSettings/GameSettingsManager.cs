using UnityEngine;

namespace _Main.Scripts.SRGameSettings
{
    public class GameSettingsManager : MonoSingleton<GameSettingsManager>
    {
        [SerializeField] private GameSettings gameSettings;

        public GameSettings GameSettings => gameSettings;

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
        }
    }
}