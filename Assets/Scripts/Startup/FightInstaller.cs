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
      [UsedImplicitly] public PlayerMovement.Settings PlayerMovement;
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

    private void InstallPlayerFacade(DiContainer subContainer, PlayerRegistration playerRegistration)
    {
      subContainer.BindInstance(playerRegistration);
      subContainer.BindInstance(this.settings.PlayerViewFactory);
      subContainer.BindInstance(this.settings.PlayerMovement);

      subContainer.Bind<IEventAggregator>().ToSingle<EventAggregator>();

      subContainer.Bind<PlayerMovement>().ToSingle();
      subContainer.BindAllInterfacesToSingle<PlayerMovement>();
      subContainer.Bind<PlayerHealth>().ToSingle();
      subContainer.BindAllInterfacesToSingle<PlayerHealth>();

      subContainer.Bind<PlayerView.Factory>().ToSingle();
      subContainer.Bind<PlayerView>().ToSingleMethod(
        c => c.Container.Resolve<PlayerView.Factory>().Create());
      subContainer.Bind<IView>().ToLookup<PlayerView>();

      subContainer.Bind<PlayerController.Factory>().ToSingle();
      subContainer.Bind<IPlayerController>().ToSingleMethod(
        c => c.Container.Resolve<PlayerController.Factory>().Create());
      subContainer.Bind<ITickable>().ToLookup<IPlayerController>();
    }
  }
}