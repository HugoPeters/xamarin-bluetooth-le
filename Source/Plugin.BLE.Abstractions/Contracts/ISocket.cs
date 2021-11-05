﻿﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Plugin.BLE.Abstractions.Contracts
{
    public enum SocketType
    {
        Rfcomm,
        L2cap,
        Unknown
    }

    /// <summary>
    /// A bluetooth socket.
    /// </summary>
    public interface ISocket : IDisposable
    {
        Stream InputStream { get; }

        Stream OutputStream { get; }

        SocketType Type { get; }

        bool IsConnected { get; }

        void Close();
        void Connect();
        Task ConnectAsync();
    }
}