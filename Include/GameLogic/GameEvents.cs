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

namespace GameLogic
{
  public class GameEvents
  {
    public static event Action<ControlledEntity> ControlledCreated;
    public static event Action<DummyEntity> DummyCreated;
    public static event Action<MimicEntity> MimicCreated;

    //public static event Action<GameActionEvent> GameActionEvent;

    public static void OnControlledAdded(ControlledEntity entity)
    {
      if (GameEvents.ControlledCreated != null)
        GameEvents.ControlledCreated.Invoke(entity);
    }

    public static void OnDummyAdded(DummyEntity entity)
    {
      if (GameEvents.DummyCreated != null)
        GameEvents.DummyCreated.Invoke(entity);
    }

    public static void OnMimicAdded(MimicEntity entity)
    {
      if (GameEvents.MimicCreated != null)
        GameEvents.MimicCreated.Invoke(entity);
    }

    //public static void OnGameActionEvent(GameActionEvent evnt)
    //{
    //  if (GameEvents.GameActionEvent != null)
    //    GameEvents.GameActionEvent.Invoke(evnt);
    //}
  }
}