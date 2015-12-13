using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace LudumDare34
{
  public partial class PlayerController
  {
    public class Factory : IFactory<IPlayerController>, IValidatable
    {
      [Inject] private DiContainer Container { get; set; }
      [Inject] private PlayerRegistration PlayerRegistration { get; set; }

      public IPlayerController Create()
      {
        if (PlayerRegistration.Type == PlayerType.Human)
          return Container.Instantiate<HumanPlayerController>();

        return Container.Instantiate<AiPlayerController>();
      }

      public IEnumerable<ZenjectResolveException> Validate()
        => Container.ValidateObjectGraph<HumanPlayerController>()
          .Concat(Container.ValidateObjectGraph<AiPlayerController>());
    }
  }
}