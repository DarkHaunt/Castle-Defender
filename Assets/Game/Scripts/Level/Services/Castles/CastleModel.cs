using Game.Level.Castles;
using Game.Level.Weapons.HandlePoints;
using Game.Level.Enemies;
using Game.Level.Weapons.HandlePoints.MVP;
using System;
using System.Collections.Generic;


namespace Game.Level.Services.Castles
{
    public class CastleModel
    {
        public event Action OnDisabled;
        public event Action OnEnabled;

        private readonly IWeaponPointsContainer _weaponPointsContainer;
        
        private IList<WeaponPointPresenter> _weaponPointPresenters;
        public IAttackTarget PhysicBody;


        public CastleModel(IWeaponPointsContainer weaponPointsContainer)
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