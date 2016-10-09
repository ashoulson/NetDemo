using System.Net.Sockets;

using Railgun;
using MiniUDP;

namespace GameServer
{
  /// <summary>
  /// Responsible for interpreting events from the socket and communicating
  /// them to the Railgun server.
  /// </summary>
  internal class NetServerWrapper
  {
    private NetCore network;
    private RailServer server;

    public NetServerWrapper(NetCore network, RailServer server)
    {
      this.server = server;

      this.network = network;
      network.PeerConnected += OnPeerConnected;
      network.PeerClosed += OnPeerClosed;
    }

    private void OnPeerClosed(
      NetPeer peer, 
      NetCloseReason reason, 
      byte userKickReason, 
      SocketError error)
    {
      NetPeerWrapper wrapper = (NetPeerWrapper)peer.UserData;
      this.server.RemovePeer(wrapper);
    }

    private void OnPeerConnected(NetPeer peer, string token)
    {
      NetPeerWrapper wrapper = new NetPeerWrapper(peer);
      peer.UserData = wrapper;
      this.server.AddPeer(wrapper);
    }
  }
}
