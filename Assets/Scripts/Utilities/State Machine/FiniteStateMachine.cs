using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace LudumDare34
{
  public sealed class FiniteStateMachine<T>
    where T : class
  {
    public event Action StateChanged;

    private readonly Dictionary<Type, FiniteState<T>> states = new Dictionary<Type, FiniteState<T>>();
    private readonly T context;

    public FiniteState<T> CurrentState { get; private set; }
    public FiniteState<T> PreviousState { get; private set; }
    public float ElapsedTimeInState { get; private set; }

    public FiniteStateMachine(T context)
    {
      this.context = context;
    }

    public FiniteStateMachine<T> AddState<TState>()
      where TState : FiniteState<T>, new()
    {
      this.states[typeof(TState)] = ReflectionHelper.Create<TState>(this, this.context);

      if (CurrentState != null)
        return this;

      CurrentState = this.states[typeof(TState)];
      CurrentState.Begin();

      return this;
    }

    public TState GoToState<TState>()
      where TState : FiniteState<T>
    {
      if (CurrentState is TState)
        return (TState)CurrentState;

      CurrentState?.End();

      Assert.IsTrue(this.states.ContainsKey(typeof(TState)), $"{GetType()} : state {typeof(TState)} doesn't exist!");

      PreviousState = CurrentState;
      CurrentState = this.states[typeof(TState)];

      CurrentState.Begin();
      ElapsedTimeInState = 0f;
      StateChanged?.Invoke();

      return (TState)CurrentState;
    }

    public bool CameFromState<TState>()
      where TState : FiniteState<T>
      => PreviousState is TState;

    public void Update(float deltaTime)
    {
      ElapsedTimeInState += deltaTime;
      CurrentState.Reason();
      CurrentState.Update(deltaTime);
    }
  }
}