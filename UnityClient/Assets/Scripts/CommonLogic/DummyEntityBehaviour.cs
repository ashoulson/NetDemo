using System;
using System.Collections.Generic;

using UnityEngine;

using GameLogic;
using Railgun;

public class DummyEntityBehaviour : MonoBehaviour
{
  public DummyEntity Entity { get; set; }

  public Color color = Color.white;

  private static Vector2 GetCoordinates(RailState state)
  {
    EntityState entityState = (EntityState)state;
    return new Vector2(entityState.X, entityState.Y);
  }

  void Start()
  {
    this.Entity.Frozen += this.OnFrozen;
    this.Entity.Unfrozen += this.OnUnfrozen;
  }

  void Update()
  {
    if (this.Entity != null)
      this.UpdatePosition();
  }

  private void UpdatePosition()
  {
    EntityState state = this.Entity.State;
    if (Client.DoSmoothing)
      this.transform.position = this.GetSmoothedPosition();
    else
      this.transform.position = new Vector2(state.X, state.Y);
  }

  private Vector2 GetSmoothedPosition()
  {
    EntityState current = this.Entity.AuthState;
    Vector2 curPos = new Vector2(current.X, current.Y);

    EntityState next = this.Entity.NextState;
    if (next == null)
      return curPos;
    Vector2 nextPos = new Vector2(next.X, next.Y);

    float t = 
      this.Entity.ComputeInterpolation(
        Time.fixedDeltaTime, 
        Time.time - Time.fixedTime);
    return Vector2.Lerp(curPos, nextPos, t);
  }

  private void OnFrozen()
  {
    this.gameObject.SetActive(false);
  }

  private void OnUnfrozen()
  {
    this.gameObject.SetActive(true);
  }
}
