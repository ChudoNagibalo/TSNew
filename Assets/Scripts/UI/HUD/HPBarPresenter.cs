using FPGame.UI.HUD.Interfaces;
using UnityEngine;

namespace FPGame.UI.HUD
{
    public class HPBarPresenter
    {
        private HPBarModel _hpBarModel;
        private IHPBarView _hpBarView;

        public HPBarPresenter()
        {
            _hpBarModel = Manager.GetHPBarModel();
            _hpBarView = Manager.GetHPBarView();

            _hpBarModel.PlayerCurrentHPChanged += UpdateCurrentHP;
            _hpBarModel.PlayerMaxHPChanged += UpdateMaxHP;

            _hpBarView.SetPlayerCurrentHP(_hpBarModel.CurrentHP);
            _hpBarView.SetPlayerMaxHP(_hpBarModel.MaxPlayerHP);
        }

        private void UpdateCurrentHP()
        {
            _hpBarView.SetPlayerCurrentHP(_hpBarModel.CurrentHP);
        }

        private void UpdateMaxHP()
        {
            _hpBarView.SetPlayerMaxHP(_hpBarModel.MaxPlayerHP);
        }
    }
}