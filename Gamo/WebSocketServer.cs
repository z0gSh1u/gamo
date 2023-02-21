using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Gamo
{
  class WebSocketServer : WebSocketBehavior
  {
    protected override void OnMessage(MessageEventArgs e)
    {
      base.OnMessage(e);

      
      // Send()
    }
  }
}