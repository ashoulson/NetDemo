/*
 *  RailgunNet - A Client/Server Network State-Synchronization Layer for Games
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

using Railgun;

using GameLogic;

namespace GameServer
{
  public class Arena
  {
    private RailServer server;

    public Arena(RailServer server)
    {
      this.server = server;

      server.ControllerJoined += this.OnControllerAdded;
      server.ControllerLeft += this.OnControllerLeft;

      for (int i = 0; i < 15; i++)
      {
        for (int j = 0; j < 15; j++)
        {
          DummyEntity dummy = this.server.AddNewEntity<DummyEntity>();
          dummy.State.ArchetypeId = 1;
          dummy.State.X = i * 5.0f;
          dummy.State.Y = j * 5.0f;
        }
      }
    }

    private void OnControllerAdded(IRailControllerServer controller)
    {
      //GameControlled controlled = this.server.AddNewEntity<GameControlled>();
      //controlled.State.ArchetypeId = 0;
      //controller.GrantControl(controlled);
      //controller.ScopeEvaluator = new GameScopeEvaluator(controlled);
      //controller.UserData = controlled;

      //DemoMimic mimic = this.server.AddNewEntity<DemoMimic>();
      //mimic.State.ArchetypeId = 2;
      //mimic.Bind(controlled, 3.5f, 0.0f);
    }

    private void OnControllerLeft(IRailControllerServer controller)
    {
      //GameControlled controlled = (GameControlled)controller.UserData;
      //this.server.DestroyEntity(controlled);
    }
  }
}
