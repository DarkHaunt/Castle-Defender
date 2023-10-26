

namespace Game.Level.Weapons.HandlePoints.MVP
{
    public class WeaponPointPresenter
    {
        private readonly WeaponPointModel _weaponPointModel;
        private readonly WeaponPointView _weaponPointView;
        
        public WeaponPointPresenter(WeaponPointModel weaponPointModel, WeaponPointView weaponPointView)
        {
            _weaponPointModel = weaponPointModel;
            _weaponPointView = weaponPointView;
        }

        public void Enable()
        {
            _weaponPointView.OnUpdateButtonPressed += _weaponPointModel.NotifySelected;
            _weaponPointView.OnCreateButtonPressed += _weaponPointModel.NotifySelected;
            _weaponPointView.OnDeleteButtonPressed += _weaponPointModel.NotifySelected;

            _weaponPointModel.OnRegisterEnabled += CreateViewEnable;
            _weaponPointModel.OnDeleteEnabled += DeleteViewEnable;
            _weaponPointModel.OnUpdateEnabled += UpdateViewEnable;
        } 
        
        public void Disable()
        {
            _weaponPointView.OnUpdateButtonPressed -= _weaponPointModel.NotifySelected;
            _weaponPointView.OnCreateButtonPressed -= _weaponPointModel.NotifySelected;
            _weaponPointView.OnDeleteButtonPressed -= _weaponPointModel.NotifySelected;

            _weaponPointModel.OnRegisterEnabled -= CreateViewEnable;
            _weaponPointModel.OnDeleteEnabled -= DeleteViewEnable;
            _weaponPointModel.OnUpdateEnabled -= UpdateViewEnable;
        }

        private void CreateViewEnable(bool enable)
            => _weaponPointView.EnableCreateView(enable);
        private void DeleteViewEnable(bool enable)
            => _weaponPointView.EnableDeleteView(enable);   
        private void UpdateViewEnable(bool enable)
            => _weaponPointView.EnableUpdateView(enable);
    }
}