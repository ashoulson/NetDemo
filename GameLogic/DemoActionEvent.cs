using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Railgun;

[RegisterEvent]
public class DemoActionEvent : RailEvent<DemoActionEvent>
{
  public int Key;

  protected override void SetDataFrom(DemoActionEvent other)
  {
    this.Key = other.Key;
  }

  protected override void EncodeData(RailBitBuffer buffer, Tick packetTick)
  {
    buffer.WriteInt(this.Key);
  }

  protected override void DecodeData(RailBitBuffer buffer, Tick packetTick)
  {
    this.Key = buffer.ReadInt();
  }

  protected override void ResetData()
  {
    this.Key = 0;
  }

  protected override void Invoke(RailRoom room, IRailController sender, RailEntity entity)
  {
    DemoEvents.OnDemoActionEvent(this);
  }
}