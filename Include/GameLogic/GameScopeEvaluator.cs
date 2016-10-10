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

#if SERVER
using Railgun;

using UnityStandalone;

namespace GameLogic
{
  public class GameScopeEvaluator : RailScopeEvaluator
  {
    //private float maxDistSqr = 10000.0f;

    private readonly ControlledEntity controlled;

    public GameScopeEvaluator(ControlledEntity controlled)
    {
      this.controlled = controlled;
    }

    protected override bool Evaluate(
      RailEntity entity,
      int ticksSinceSend,
      out float priority)
    {
      priority = 0.0f;
      if (entity == this.controlled)
        return true;

      //if (entity.State is GameState)
      //{
      //  GameState controlledState = this.controlled.State;
      //  GameState state = (GameState)entity.State;

      //  Vector2 origin =
      //    new Vector2(
      //      controlledState.X,
      //      controlledState.Y);

      //  Vector2 point =
      //    new Vector2(
      //      state.X,
      //      state.Y);

      //  float distance = (origin - point).sqrMagnitude;
      //  if (distance > maxDistSqr)
      //    return false;

      //  priority = distance / (float)ticksSinceSend;
      //  return true;
      //}

      return true;
    }
  }
}
#endif