using TMPro;
using UnityEngine;


namespace Project.Scripts.Consume
{
    public class PriceView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _priceText;


        public void Show()
            => gameObject.SetActive(true);

        public void Hide()
            => gameObject.SetActive(false);

        public void UpdatePriceText(int newPrice)
            => _priceText.text = newPrice.ToString();
    }
}