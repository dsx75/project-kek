﻿using Common.Constants;
using Common.Interfaces;
using Common.Interfaces.Handlers;

namespace TaidanaKage
{
    public class SandboxHost : ISandbox
    {
        private readonly ISandbox _instance;

        public SandboxHost(ISandbox sandbox)
        {
            _instance = sandbox;
        }

        public string RealmName => _instance.RealmName;
        public Expansions Expansion => _instance.Expansion;
        public int Build => _instance.Build;
        public int RealmPort => _instance.RealmPort;
        public int RedirectPort => _instance.RedirectPort;
        public int WorldPort => _instance.WorldPort;

        public IOpcodes Opcodes => _instance.Opcodes;

        public IAuthHandler AuthHandler => _instance.AuthHandler;
        public ICharHandler CharHandler => _instance.CharHandler;
        public IWorldHandler WorldHandler => _instance.WorldHandler;

        public IPacketReader ReadPacket(byte[] data, bool parse = true) => _instance.ReadPacket(data, parse);

        public override string ToString() => _instance.RealmName;
    }
}
