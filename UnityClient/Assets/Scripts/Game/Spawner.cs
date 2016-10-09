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
    GameEvents.MimicCreated += this.OnMimicCreated;
  }

  private void OnControlledCreated(GameControlled entity)
  {
    GameObject go = 
      ArchetypeLibrary.Instance.Instantiate(
        entity.State.ArchetypeId);

    GameEntityControlled obj = go.GetComponent<GameEntityControlled>();
    obj.Entity = entity;
  }

  private void OnDummyCreated(GameDummy entity)
  {
    GameObject go =
      ArchetypeLibrary.Instance.Instantiate(
        entity.State.ArchetypeId);

    GameEntityDummy obj = go.GetComponent<GameEntityDummy>();
    obj.Entity = entity;
  }

  private void OnMimicCreated(GameMimic entity)
  {
    GameObject go =
      ArchetypeLibrary.Instance.Instantiate(
        entity.State.ArchetypeId);

    GameEntityMimic obj = go.GetComponent<GameEntityMimic>();
    obj.Entity = entity;
  }
}
