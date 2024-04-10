using FPGame.UI.HUD.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace FPGame.UI.HUD
{
    public class HPBarView : MonoBehaviour, IHPBarView
    {

        [SerializeField] private Image _hpBar;
        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void SetPlayerCurrentHP(int currentHP)
        {
            _hpBar.fillAmount = currentHP;
        }

        public void SetPlayerMaxHP(int maxHP)
        {
            _hpBar.fillAmount = maxHP;
        }
    }
}