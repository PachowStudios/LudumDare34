﻿using Zenject;

namespace LudumDare34
{
  public interface IFiniteState : ITickable { }

  public abstract class FiniteState<T> : IFiniteState
    where T : class
  {
    protected FiniteStateMachine<T> StateMachine { get; }
    protected T Context { get; }

    protected FiniteState(FiniteStateMachine<T> stateMachine, T context)
    {
      StateMachine = stateMachine;
      Context = context;
    }

    public virtual void Begin() { }

    public virtual void Reason() { }

    public virtual void Tick() { }

    public virtual void End() { }
  }
}