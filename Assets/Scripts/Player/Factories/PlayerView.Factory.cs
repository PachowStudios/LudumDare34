using System;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace LudumDare34
{
  public partial class PlayerView
  {
    public class Factory : IFactory<PlayerView>
    {
      [Serializable]
      public class Settings
      {
        [UsedImplicitly] public GameObject Player1Prefab;
        [UsedImplicitly] public GameObject Player2Prefab;

        [UsedImplicitly] public Transform Player1Start;
        [UsedImplicitly] public Transform Player2Start;
      }

      [Inject] private Settings Config { get; set; }
      [Inject] private IInstantiator Instantiator { get; set; }
      [Inject] private PlayerRegistration PlayerRegistration { get; set; }

      public PlayerView Create()
      {
        return PlayerRegistration.Id == PlayerId.Player1
          ? Create(Config.Player1Prefab, Config.Player1Start.position)
          : Create(Config.Player2Prefab, Config.Player2Start.position);
      }

      private PlayerView Create(GameObject prefab, Vector3 position)
      {
        var player = Instantiator.InstantiatePrefabForComponent<PlayerView>(prefab);

        player.Transform.position = position;

        return player;
      }
    }
  }
}