using Project.Scripts.Level.Common.Damage;
using Project.Scripts.Level.Weapons.Handling.WeaponPoints;
using Project.Scripts.Level.Weapons.Handling.WeaponPoints.MVP;
using System.Collections.Generic;
using System;


namespace Project.Scripts.Level.Castles
{
    public class CastleModel
    {
        public event Action OnDisabled;
        public event Action OnEnabled;

        private readonly WeaponPointsContainer _weaponPointsContainer;
        
        private IList<WeaponPointPresenter> _weaponPointPresenters;
        public IAttackTarget PhysicBody;


        public CastleModel(WeaponPointsContainer weaponPointsContainer)
        {
            _weaponPointsContainer = weaponPointsContainer;
        }
        

        public void Init(Castle castle, float castleMaxHealth)
        {
            PhysicBody = castle.PhysicBody;
            PhysicBody.Init(castleMaxHealth);
            
            var weaponPoints = CreateWeaponPoints(castle.WeaponHandlePoints);
            _weaponPointsContainer.Init(weaponPoints);
        }

        public void Enable()
        {
            OnEnabled?.Invoke();
            PhysicBody.UpdateHealth();

            foreach (var weaponPointPresenter in _weaponPointPresenters) 
                weaponPointPresenter.Enable();
        }

        public void Disable()
        {
            OnDisabled?.Invoke();
            
            foreach (var weaponPointPresenter in _weaponPointPresenters) 
                weaponPointPresenter.Disable();
        }

        private IList<WeaponPointModel> CreateWeaponPoints(ICollection<WeaponPointView> pointViews)
        {
            _weaponPointPresenters = new List<WeaponPointPresenter>(pointViews.Count);
            var weapons = new List<WeaponPointModel>(pointViews.Count);

            foreach (var view in pointViews)
            {
                var model = new WeaponPointModel(view.transform.position);
                var presenter = new WeaponPointPresenter(model, view);
                
                _weaponPointPresenters.Add(presenter);
                weapons.Add(model);
            }

            return weapons;
        }
    }
}