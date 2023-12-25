using System.Collections.Generic;
using Project.Scripts.Consume;
using Project.Scripts.Menu.UI;
using UnityEngine;
using VContainer;

namespace Project.Scripts.Menu.Services
{
    public class ShopService : MonoBehaviour
    {
        [SerializeField] private List<WeaponShopButton> _buttons ;
        
        [Inject]
        public void Construct(CoinsHandleService coinsHandleService)
        {
            foreach (var button in _buttons)
                button.Construct(coinsHandleService);
        }
    }
}