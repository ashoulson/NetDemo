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
  public class MimicEntity : RailEntity<EntityState>, IHasPosition
  {
    public event Action Shutdown;
    public event Action Frozen;
    public event Action Unfrozen;

    public Vector2 Position
    {
      get { return new Vector2(this.State.X, this.State.Y); }
    }

    private ControlledEntity controlled;
    private float xOffset;
    private float yOffset;

    public void Bind(
      ControlledEntity controlled,
      float xOffset,
      float yOffset)
    {
      this.controlled = controlled;
      this.xOffset = xOffset;
      this.yOffset = yOffset;
    }

    protected override void OnReset()
    {
      this.controlled = null;
      this.xOffset = 0.0f;
      this.yOffset = 0.0f;
    }

    protected override void OnStart()
    {
      GameEvents.OnMimicAdded(this);
    }

    protected override void UpdateAuth()
    {
      this.State.X = this.controlled.State.X + this.xOffset;
      this.State.Y = this.controlled.State.Y + this.yOffset;
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