using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MightyAdventures.StatSystem.UI
{
    public class VitalStatView : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private TMP_Text statValueText;
        [SerializeField] private TMP_Text regenValueText;

        private VitalityStat _vitalStat;

        public void Initialize(VitalityStat vitalStat)
        {
            UnregisterFromEvents();
            _vitalStat = vitalStat;
            SetStatView();
            RegisterToEvents();
        }

        private void SetStatView()
        {
            slider.maxValue = _vitalStat.MaxValue;
            slider.value = _vitalStat.Value;
            statValueText.text = _vitalStat.GetValueText();
            regenValueText.text = $"+{_vitalStat.RegenRage}/s";
            regenValueText.gameObject.SetActive(!_vitalStat.IsFull);
        }

        private void RegisterToEvents()
        {
            if (_vitalStat == null) return;
            _vitalStat.OnStatChanged += SetStatView;
        }

        private void UnregisterFromEvents()
        {
            if (_vitalStat == null) return;
            _vitalStat.OnStatChanged -= SetStatView;
        }

        #region MonoBehaviour Methods

        private void OnDestroy()
        {
            UnregisterFromEvents();
        }

        #endregion
    }
}