using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Bluetooth;
using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts;

namespace Plugin.BLE.Android
{
    public class Socket : ISocket
    {
        BluetoothSocket nativeSocket;

        public Stream InputStream => nativeSocket.InputStream;
        public Stream OutputStream => nativeSocket.OutputStream;
        public SocketType Type => GetSocketType();
        public bool IsConnected => nativeSocket.IsConnected;

        private SocketType GetSocketType()
        {
            switch (nativeSocket.ConnectionType)
            {
                case BluetoothConnectionType.L2cap: return SocketType.L2cap;
                case BluetoothConnectionType.Rfcomm: return SocketType.Rfcomm;
                default: return SocketType.Unknown;
            }
        }

        public Socket(BluetoothSocket socket)
        {
            nativeSocket = socket;
        }

        public void Close()
        {
            nativeSocket.Close();
        }

        public void Connect()
        {
            nativeSocket.Connect();
        }

        public async Task ConnectAsync()
        {
            await nativeSocket.ConnectAsync();
        }

        public virtual void Dispose()
        {
            nativeSocket.Dispose();
        }
    }
}