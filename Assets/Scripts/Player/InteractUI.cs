using UnityEngine;
using UnityEngine.UI;

namespace FPGame
{
    public class InteractUI : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject _gameObject;
        public void Hide()
        {
            _gameObject.SetActive(false);
        }

        public void Show()
        {
            _gameObject.SetActive(true);
        }
    }
}

