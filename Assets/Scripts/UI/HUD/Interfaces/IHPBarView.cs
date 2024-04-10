using UnityEngine;

namespace FPGame.UI.HUD.Interfaces
{
    public interface IHPBarView : IView
    {
        public void SetPlayerCurrentHP(int currentHP);
        public void SetPlayerMaxHP(int maxHP);
    }
}
