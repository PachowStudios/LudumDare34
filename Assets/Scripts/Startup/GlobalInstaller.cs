using UnityEngine;
using Zenject;

namespace LudumDare34
{
  [AddComponentMenu("Ludum Dare 34/Startup/Global Installer")]
  public class GlobalInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindAllInterfacesToSingle<Bootystrapper>();
    }
  }
}