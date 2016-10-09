﻿using System;
using System.Collections.Generic;

using UnityEngine;

using GameLogic;
using Railgun;

public class GameEntityControlled : MonoBehaviour
{
  public GameControlled Entity { get; set; }

  public bool DoSmoothing = false;
  public Color color = Color.white;

  //private RailSmootherVector2 smoother;

  private static Vector2 GetCoordinates(RailState state)
  {
    GameState demoState = (GameState)state;
    return new Vector2(demoState.X, demoState.Y);
  }

  //void Awake()
  //{
  //  this.smoother = new RailSmootherVector2(
  //    GameEntityControlled.GetCoordinates,
  //    float.MaxValue,
  //    2.0f);
  //}

  void Start()
  {
    this.Entity.Shutdown += this.OnShutdown;
    this.Entity.Frozen += this.OnFrozen;
    this.Entity.Unfrozen += this.OnUnfrozen;
  }

  void Update()
  {
    if (this.Entity != null)
    {
      this.UpdatePosition();
    }

    if (Input.GetKeyDown(KeyCode.Alpha1))
      this.DoSmoothing = true;
    if (Input.GetKeyDown(KeyCode.Alpha2))
      this.DoSmoothing = false;
  }

  private void UpdatePosition()
  {
    GameState state = this.Entity.State;
    //if (Client.DoSmoothing)
    //  state = this.Entity.GetSmoothedState(Time.time - Time.fixedTime);
    this.transform.position =
      new Vector2(state.X, state.Y);
  }

  private void OnShutdown()
  {
    GameObject.Destroy(this.gameObject);
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