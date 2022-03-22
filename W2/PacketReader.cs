﻿using System;
using Common.Network;

namespace TBC_8089
{
    public class PacketReader : BasePacketReader
    {
        public PacketReader(byte[] data, bool parse = true) : base(data)
        {
            if (parse)
            {
                Decode(ref data);
                ushort size = BitConverter.ToUInt16(data, 0);
                Size = (ushort)((size >> 8) + ((size & 0xFF) << 8) + 2);
                Opcode = BitConverter.ToUInt32(data, 2);

                Position = 6;
            }
        }
    }
}
