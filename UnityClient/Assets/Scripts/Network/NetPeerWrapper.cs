using System;
using System.Collections.Generic;

using Railgun;
using MiniUDP;

internal class NetPeerWrapper : IRailNetPeer
{
  public event RailNetPeerEvent PayloadReceived;

  public object PlayerData { get; set; }

  private NetPeer peer;

  public NetPeerWrapper(NetPeer peer)
  {
    this.peer = peer;
    peer.UserData = this;
    this.peer.PayloadReceived += this.OnPayloadReceived;
  }

  private void OnPayloadReceived(NetPeer peer, byte[] data, int length)
  {
    if (peer != this.peer)
      throw new InvalidOperationException("Peer wrapper mismatch");
    if (this.PayloadReceived != null)
      this.PayloadReceived.Invoke(this, data, length);
  }

  public void SendPayload(byte[] buffer, int length)
  {
    this.peer.SendPayload(buffer, length);
  }
}
