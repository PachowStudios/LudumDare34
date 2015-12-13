using System;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace LudumDare34
{
  [AddComponentMenu("Ludum Dare 34/Startup/Fight Installer")]
  public class FightInstaller : MonoInstaller
  {
    [Serializable]
    public class Settings
    {
      [UsedImplicitly] public PlayerView.Factory.Settings PlayerViewFactory;
    }

    [SerializeField] private Settings settings = null;

    public override void InstallBindings()
    {
      Container.Bind<GameController>().ToSingle();
      Container.BindAllInterfacesToSingle<GameController>();

      Container.BindFacadeFactory<
        PlayerRegistration,
        PlayerFacade,
        PlayerFacade.Factory>(InstallPlayerFacade);
    }

    private void InstallPlayerFacade(DiContainer container, PlayerRegistration playerRegistration)
    {
      container.BindInstance(playerRegistration);
      container.BindInstance(this.settings.PlayerViewFactory);

      container.BindAllInterfacesToSingle<PlayerMovement>();
      container.BindAllInterfacesToSingle<PlayerHealth>();

      container.Bind<PlayerView.Factory>().ToSingle();
      container.Bind<PlayerView>().ToSingleMethod(
        c => c.Container.Resolve<PlayerView.Factory>().Create());
      container.Bind<IView>().ToLookup<PlayerView>();

      container.Bind<PlayerController.Factory>().ToSingle();
      container.Bind<IPlayerController>().ToSingleMethod(
        c => c.Container.Resolve<PlayerController.Factory>().Create());
      container.Bind<ITickable>().ToLookup<IPlayerController>();
    }
  }
}