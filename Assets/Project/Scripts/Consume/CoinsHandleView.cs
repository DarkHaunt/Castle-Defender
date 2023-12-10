using UnityEngine;
using VContainer;
using TMPro;


namespace Project.Scripts.Consume
{
    public class CoinsHandleView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsText;
        
        private CoinsHandleService _coinsHandleService;

        
        [Inject]
        private void Construct(CoinsHandleService coinsHandleService)
        {
            _coinsHandleService = coinsHandleService;
            _coinsHandleService.OnCoinsUpdated += UpdateCoinsText;
        }

        private void UpdateCoinsText(int coinsCount)
            => _coinsText.text = coinsCount.ToString();
    }
}