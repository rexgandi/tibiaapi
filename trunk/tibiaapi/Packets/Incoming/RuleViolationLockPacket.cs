﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tibia.Packets.Incoming
{
    public class RuleViolationLockPacket : IncomingPacket
    {

        public RuleViolationLockPacket(Objects.Client c)
            : base(c)
        {
            Type = IncomingPacketType_t.RULE_VIOLATION_CANCEL;
            Destination = PacketDestination_t.CLIENT;
        }

        public override bool ParseMessage(NetworkMessage msg, PacketDestination_t destination, Objects.Location pos)
        {
            if (msg.GetByte() != (byte)IncomingPacketType_t.RULE_VIOLATION_CANCEL)
                throw new Exception();

            Destination = destination;
            Type = IncomingPacketType_t.RULE_VIOLATION_CANCEL;

            return true;
        }

        public override byte[] ToByteArray()
        {
            NetworkMessage msg = new NetworkMessage(0);
            msg.AddByte((byte)Type);

            return msg.Packet;
        }
    }
}