using InControl;
using Zenject;

namespace LudumDare34
{
  public class AiInputControl : IInputControl, ITickable
  {
    private bool thisState;
    private bool lastState;

    public bool HasChanged => this.thisState ^ this.lastState;
    public bool IsPressed => this.thisState;
    public bool WasPressed => this.thisState && !this.lastState;
    public bool WasReleased => !this.thisState && this.lastState;

    public void Press()
      => this.thisState = true;

    public void Tick()
    {
      this.lastState = this.thisState;
      this.thisState = false;
    }

    public void ClearInputState()
      => this.lastState = this.thisState = false;
  }
}