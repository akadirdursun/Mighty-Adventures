using MightyAdventures.PowerUps.UI;
using UnityEngine;

namespace MightyAdventures.UIScreens
{
    public class LevelUpScreen : AbstractUIScreen
    {
        [SerializeField] private PowerUpCardArea powerUpCardArea;

        #region AbstractUIScreen Overrides

        public override void Show()
        {
            base.Show();
            powerUpCardArea.Initialize();
        }

        #endregion
    }
}