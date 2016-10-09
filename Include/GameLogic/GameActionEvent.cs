///*
// *  NetDemo - A Unity client/standalone server demo using Railgun and MiniUDP
// *  Copyright (c) 2016 - Alexander Shoulson - http://ashoulson.com
// *
// *  This software is provided 'as-is', without any express or implied
// *  warranty. In no event will the authors be held liable for any damages
// *  arising from the use of this software.
// *  Permission is granted to anyone to use this software for any purpose,
// *  including commercial applications, and to alter it and redistribute it
// *  freely, subject to the following restrictions:
// *  
// *  1. The origin of this software must not be misrepresented; you must not
// *     claim that you wrote the original software. If you use this software
// *     in a product, an acknowledgment in the product documentation would be
// *     appreciated but is not required.
// *  2. Altered source versions must be plainly marked as such, and must not be
// *     misrepresented as being the original software.
// *  3. This notice may not be removed or altered from any source distribution.
//*/

//using Railgun;

//namespace GameLogic
//{
//  [RegisterEvent]
//  public class GameActionEvent : RailEvent<GameActionEvent>
//  {
//    public int Key;

//    protected override void SetDataFrom(GameActionEvent other)
//    {
//      this.Key = other.Key;
//    }

//    protected override void EncodeData(RailBitBuffer buffer, Tick packetTick)
//    {
//      buffer.WriteInt(this.Key);
//    }

//    protected override void DecodeData(RailBitBuffer buffer, Tick packetTick)
//    {
//      this.Key = buffer.ReadInt();
//    }

//    protected override void ResetData()
//    {
//      this.Key = 0;
//    }

//    protected override void Invoke(RailRoom room, IRailController sender, RailEntity entity)
//    {
//      GameEvents.OnGameActionEvent(this);
//    }
//  }
//}