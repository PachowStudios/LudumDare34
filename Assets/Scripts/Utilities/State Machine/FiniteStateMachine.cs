﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace LudumDare34
{
  public sealed class FiniteStateMachine<T> : ITickable
    where T : class
  {
    public event Action StateChanged;

    private readonly Dictionary<Type, FiniteState<T>> states = new Dictionary<Type, FiniteState<T>>();
    private readonly T context;

    public FiniteState<T> CurrentState { get; private set; }
    public FiniteState<T> PreviousState { get; private set; }
    public float TimeInCurrentState { get; private set; }

    public FiniteStateMachine(T context)
    {
      this.context = context;
    }

    public FiniteStateMachine<T> Add<TState>()
      where TState : FiniteState<T>
    {
      this.states[typeof(TState)] = ReflectionHelper.Create<TState>(this, this.context);

      if (CurrentState != null)
        return this;

      CurrentState = this.states[typeof(TState)];
      CurrentState.Begin();

      return this;
    }

    public TState GoTo<TState>()
      where TState : FiniteState<T>
    {
      if (CurrentState is TState)
        return (TState)CurrentState;

      CurrentState?.End();

      Assert.IsTrue(this.states.ContainsKey(typeof(TState)), $"{GetType()} : state {typeof(TState)} doesn't exist!");

      PreviousState = CurrentState;
      CurrentState = this.states[typeof(TState)];

      CurrentState.Begin();
      TimeInCurrentState = 0f;
      StateChanged?.Invoke();

      return (TState)CurrentState;
    }

    public bool IsIn<TState>()
      where TState : FiniteState<T>
      => CurrentState is TState; 

    public bool CameFrom<TState>()
      where TState : FiniteState<T>
      => PreviousState is TState;

    public void Tick()
    {
      TimeInCurrentState += Time.deltaTime;
      CurrentState.Reason();
      CurrentState.Tick();
    }
  }
}