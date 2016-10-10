/*
 *  NetDemo - A Unity client/standalone server demo using Railgun and MiniUDP
 *  Copyright (c) 2016 - Alexander Shoulson - http://ashoulson.com
 *
 *  This software is provided 'as-is', without any express or implied
 *  warranty. In no event will the authors be held liable for any damages
 *  arising from the use of this software.
 *  Permission is granted to anyone to use this software for any purpose,
 *  including commercial applications, and to alter it and redistribute it
 *  freely, subject to the following restrictions:
 *  
 *  1. The origin of this software must not be misrepresented; you must not
 *     claim that you wrote the original software. If you use this software
 *     in a product, an acknowledgment in the product documentation would be
 *     appreciated but is not required.
 *  2. Altered source versions must be plainly marked as such, and must not be
 *     misrepresented as being the original software.
 *  3. This notice may not be removed or altered from any source distribution.
*/

using System;

#if SERVER
using UnityStandalone;
#else
using UnityEngine;
#endif

using Railgun;

namespace GameLogic
{
  public class ControlledEntity : RailEntity<EntityState, GameCommand>, IHasPosition
  {
    public event Action Shutdown;
    public event Action Frozen;
    public event Action Unfrozen;

    public Vector2 Position
    {
      get { return new Vector2(this.State.X, this.State.Y); }
    }

    //int actionCount = 0;

    protected override void OnStart()
    {
      GameEvents.OnControlledAdded(this);
    }

    protected override void OnReset()
    {
      //this.actionCount = 0;
    }

    protected override void UpdateControl(GameCommand toPopulate)
    {
#if CLIENT
    toPopulate.SetData(
      Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W),
      Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S),
      Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A),
      Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D),
      Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.T));
#endif
    }

    protected override void ApplyControl(GameCommand toApply)
    {
      if (toApply.Up)
        this.State.Y += 5.0f * Time.fixedDeltaTime;
      if (toApply.Down)
        this.State.Y -= 5.0f * Time.fixedDeltaTime;
      if (toApply.Left)
        this.State.X -= 5.0f * Time.fixedDeltaTime;
      if (toApply.Right)
        this.State.X += 5.0f * Time.fixedDeltaTime;

      //if (RailConnection.IsServer && toApply.Action)
      //{
      //  GameActionEvent evnt = RailEvent.Create<GameActionEvent>(this);
      //  evnt.Key = this.actionCount++;
      //  this.Controller.QueueEvent(evnt, 2);
      //}
    }

    protected override void OnShutdown()
    {
      if (this.Shutdown != null)
        this.Shutdown.Invoke();
    }

    protected override void OnFrozen()
    {
      if (this.Frozen != null)
        this.Frozen.Invoke();
    }

    protected override void OnUnfrozen()
    {
      if (this.Unfrozen != null)
        this.Unfrozen.Invoke();
    }
  }
}