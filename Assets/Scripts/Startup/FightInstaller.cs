using System;
using JetBrains.Annotations;
using Managers;
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
      [UsedImplicitly]
      public GameObject PlayerPrefab;
    }

    [SerializeField] private Settings settings;

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
      container.Bind<PlayerRegistration>().ToInstance(playerRegistration);

      container.Bind<PlayerView>().ToSinglePrefab(this.settings.PlayerPrefab);
      container.BindAllInterfacesToSingle<PlayerMovement>();
      container.BindAllInterfacesToSingle<PlayerHealth>();

      container.Bind<PlayerController.Factory>().ToSingle();
      container.Bind<IPlayerController>().ToGetter<PlayerController.Factory>(f => f.Create());
      container.Bind<ITickable>().ToLookup<IPlayerController>();
    }
  }
}