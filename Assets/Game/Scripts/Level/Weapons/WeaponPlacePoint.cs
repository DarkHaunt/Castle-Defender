using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using Game.Extra;


namespace Game.Level.Weapons
{
    public class WeaponPlacePoint : MonoBehaviour
    {
        [field: SerializeField] public WorldPoint WeaponPoint;

        [Header("--- Create View ---")]
        [SerializeField] private Button _createWeaponButton;
        [SerializeField] private Canvas _createWeaponView;


        public void RegisterCreateButtonClick(UnityAction listener)
            => _createWeaponButton.onClick.AddListener(listener);
        
        public void UnregisterCreateButtonClick(UnityAction listener)
            => _createWeaponButton.onClick.RemoveListener(listener);
        
        public void EnableCreateUI()
            => _createWeaponView.gameObject.SetActive(true);
				
        public void DisableCreateUI() 
            => _createWeaponView.gameObject.SetActive(false);
    }
}