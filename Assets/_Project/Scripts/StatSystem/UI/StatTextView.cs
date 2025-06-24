using TMPro;
using UnityEngine;

namespace MightyAdventures.StatSystem.UI
{
    public class StatTextView : MonoBehaviour
    {
        [SerializeField] private TMP_Text statText;
        private AbstractStat _stat;
        private string _title;
        private string _suffix;

        public void Initialize(string title, AbstractStat stat, string suffix = "")
        {
            UnregisterFromEvents();
            _title = title;
            _stat = stat;
            _suffix = suffix;
            SetStatText();
            RegisterToEvents();
        }

        private void SetStatText()
        {
            statText.text = $"{_title}: {_stat.GetValueText()}{_suffix}";
        }

        private void RegisterToEvents()
        {
            if (_stat == null) return;
            _stat.OnStatChanged += SetStatText;
        }

        private void UnregisterFromEvents()
        {
            if (_stat == null) return;

            _stat.OnStatChanged -= SetStatText;
        }

        #region MonoBehaviour Methods

        private void OnDestroy()
        {
            UnregisterFromEvents();
        }

        #endregion
    }
}