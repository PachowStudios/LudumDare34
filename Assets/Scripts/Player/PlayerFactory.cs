using System;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace LudumDare34
{
  public class PlayerFactory : IFactory<PlayerId, Player>
  {
    [Serializable]
    public class Settings
    {
      [UsedImplicitly] public GameObject Player1Prefab;
      [UsedImplicitly] public GameObject Player2Prefab;
    }

    [Inject] private Settings Prefabs { get; }
    [Inject] private IInstantiator Instantiator { get; }
    [Inject] private PlayerControllerFactory PlayerControllerFactory { get; }

    public Player Create(PlayerId playerId)
    {
      var playerObject = Instantiator.InstantiatePrefab(GetPrefabForPlayer(playerId));

      var controller =
        PlayerControllerFactory.Create(
          PlayerType.Human,
          playerObject.GetInterface<IMovable>(),
          playerObject.GetInterface<IHasHealth>());

      return Instantiator.InstantiateComponent<Player>(playerObject, playerId, controller);
    }

    private GameObject GetPrefabForPlayer(PlayerId playerId)
    {
      switch (playerId)
      {
        case PlayerId.Player1:
          return Prefabs.Player1Prefab;
        case PlayerId.Player2:
          return Prefabs.Player2Prefab;
        default:
          throw new ArgumentOutOfRangeException($"No prefab assigned to {playerId}");
      }
    }
  }
}