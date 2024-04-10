using FPGame.UI.HUD;
using FPGame.UI.HUD.Interfaces;
using UnityEngine;

public class Manager : MonoBehaviour
{
  private static IHPBarView _hpBarView;
  private static HPBarModel _hpBarModel;
  private static HPBarPresenter _hpBarPresenter;

  public static IHPBarView GetHPBarView()
  {
    if(_hpBarView == null)
    {
        var prefab = Resources.Load<HPBarView>("UI View/HealthBar");
        _hpBarView = Object.Instantiate<HPBarView>(prefab,Vector3.zero,Quaternion.identity);
    }

    return _hpBarView;
  }

  public static HPBarModel GetHPBarModel()
  {
    if(_hpBarModel == null)
    {
        _hpBarModel = new HPBarModel(25,10);
    }

    return _hpBarModel;
  }

  public static HPBarPresenter GetHPBarPresenter()
  {
    if(_hpBarPresenter == null)
    {
        _hpBarPresenter = new HPBarPresenter();
    }

    return _hpBarPresenter;
  }
}
