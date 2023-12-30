using UnityEngine;
using VContainer;
using TMPro;

namespace Project.Scripts.Level.Common.Crystals
{
    public class CrystalHandleView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _crystalText;
        
        private CrystalHandleService _crystalHandleService;


        [Inject]
        private void Construct(CrystalHandleService crystalHandleService)
        {
            _crystalHandleService = crystalHandleService;
            _crystalHandleService.OnCrystalUpdated += UpdateCrystalText;
        }

        private void UpdateCrystalText(int coinsCount)
            => _crystalText.text = coinsCount.ToString();   
    }
}