using System;
using System.Collections.Generic;

using UnityEngine;

using GameLogic;

public class Spawner : MonoBehaviour
{
  void Awake()
  {
    GameEvents.ControlledCreated += this.OnControlledCreated;
    GameEvents.DummyCreated += this.OnDummyCreated;
    //GameEvents.MimicCreated += this.OnMimicCreated;
  }

  private void OnControlledCreated(ControlledEntity entity)
  {
    GameObject go = 
      ArchetypeLibrary.Instance.Instantiate(
        entity.State.ArchetypeId);

    ControlledEntityBehaviour obj = 
      go.GetComponent<ControlledEntityBehaviour>();
    obj.Entity = entity;
  }

  private void OnDummyCreated(DummyEntity entity)
  {
    GameObject go =
      ArchetypeLibrary.Instance.Instantiate(
        entity.State.ArchetypeId);

    DummyEntityBehaviour obj = 
      go.GetComponent<DummyEntityBehaviour>();
    obj.Entity = entity;
  }

  //private void OnMimicCreated(GameMimic entity)
  //{
  //  GameObject go =
  //    ArchetypeLibrary.Instance.Instantiate(
  //      entity.State.ArchetypeId);

  //  GameEntityMimic obj = go.GetComponent<GameEntityMimic>();
  //  obj.Entity = entity;
  //}
}
