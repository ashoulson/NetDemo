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

using System;

using MiniUDP;
using Railgun;

namespace GameServer
{
  internal class Server
  {
    private int port;
    private Clock clock;

    private NetCore network;
    private RailServer server;
    private NetServerWrapper wrapper;

    private Arena arena;

    public Server(int port, float updateRate)
    {
      this.port = port;

      this.network = new NetCore("NetDemo1.0", true);
      this.server = new RailServer();

      this.wrapper = new NetServerWrapper(network, server);
      this.arena = new Arena(this.server);

      this.clock = new Clock(updateRate);
      this.clock.OnFixedUpdate += this.FixedUpdate;
    }

    public void Start()
    {
      this.network.Host(this.port);
      this.clock.Start();
    }

    public void Update()
    {
      this.clock.Tick();
    }

    public void Stop()
    {
      this.network.Stop();
    }

    private void FixedUpdate()
    {
      this.network.PollEvents();
      this.server.Update();
    }
  }
}
