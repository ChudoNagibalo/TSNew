using UnityEngine;

namespace FPGame.UI
{
    public class Starter : MonoBehaviour
    {
        private void Awake()
        {
            CreateHpBarPresenter();
        }

        private void CreateHpBarPresenter()
        {
            var hpBarPresenter = Manager.GetHPBarPresenter(); 
        }
    }

}