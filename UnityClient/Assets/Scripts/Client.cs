using System;
using System.Collections.Generic;

using UnityEngine;

using MiniUDP;
using Railgun;

public class Client : MonoBehaviour
{
  private const int BANDWIDTH_WINDOW_SIZE = 60;

  public static Client Instance { get; private set; }

  public static bool DoSmoothing = true;

  public string address;
  private NetCore network;
  private RailClient client;

  public float KBps = 0.0f;

  private int receivedThisFrame = 0;
  private int framesActive = 0;
  private int[] bandwidthWindow = new int[BANDWIDTH_WINDOW_SIZE];

  void Awake()
  {
    Client.Instance = this;

    this.network = new NetCore("NetDemo1.0", false);
    this.network.PeerConnected += Network_PeerConnected;
    this.network.PeerClosed += Network_PeerClosed;

    this.client = new RailClient();
  }

  private void Network_PeerClosed(NetPeer peer, NetCloseReason reason, byte userKickReason, System.Net.Sockets.SocketError error)
  {
    Debug.Log("Disconnected: " + peer.EndPoint.ToString());
  }

  private void Network_PeerConnected(NetPeer peer, string token)
  {
    Debug.Log("Connected: " + peer.EndPoint.ToString());
    this.client.SetPeer(new NetPeerWrapper(peer));
  }

  void Start()
  {
    this.network.Connect(
      NetUtil.StringToEndPoint(this.address), 
      "SampleAuthToken");
  }

  void OnDisable()
  {
    this.network.Stop();
  }

  void FixedUpdate()
  {
    this.network.PollEvents();
    this.client.Update();

    this.UpdateBandwidth();

    if (Input.GetKey(KeyCode.Alpha1))
      Client.DoSmoothing = true;
    if (Input.GetKey(KeyCode.Alpha2))
      Client.DoSmoothing = false;
  }

  private void UpdateBandwidth()
  {
    this.bandwidthWindow[this.framesActive % BANDWIDTH_WINDOW_SIZE] =
      this.receivedThisFrame;
    this.framesActive++;
    this.receivedThisFrame = 0;

    int sum = 0;
    foreach (int bytes in this.bandwidthWindow)
      sum += bytes;
    float average = (float)sum / (float)BANDWIDTH_WINDOW_SIZE;
    this.KBps = (average / Time.fixedDeltaTime) / 1024.0f;
  }
}
