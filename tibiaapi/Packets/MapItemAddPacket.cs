﻿using System;
using System.Collections.Generic;
using Tibia.Objects;
using System.Text;

namespace Tibia.Packets
{
    public class MapItemAddPacket : Packet
    {
        private Location loc;
        private Item item;

        public Location Loc
        {
            get { return loc; }
        }

        public Item Item
        {
            get { return item; }
        }

        public MapItemAddPacket()
        {
            type = PacketType.MapItemAdd;
            destination = PacketDestination.Client;
        }
        public MapItemAddPacket(byte[] data)
            : this()
        {
            ParseData(data);
        }
        public new bool ParseData(byte[] packet)
        {
            if (base.ParseData(packet))
            {
                if (type != PacketType.MapItemAdd) return false;
                int typen;
                Tibia.Packets.PacketBuilder pkt = new Tibia.Packets.PacketBuilder(packet);
                pkt.GetInt();
                pkt.GetByte();
                loc.X = pkt.GetInt();
                loc.Y = pkt.GetInt();
                loc.Z = pkt.GetByte();
                typen = pkt.GetInt();
                if (typen == 0x61)
                {
                    //new creature, all info
                }
                else if (typen == 0x62)
                {
                    //Creature, Known ID
                }
                else if (typen == 0x63)
                {
                    //Creature, known ID
                }
                else
                {
                    item = new Item((uint)typen);
                    try
                    {
                        item.Count = pkt.GetByte();
                    }
                    catch (Exception e) { }
                }
                return true;
            }
            else 
            {
                return false;
            }
        }

        public static MapItemAddPacket Create(Location loc, Item item)
        {
            PacketBuilder pkt = new PacketBuilder();
            pkt.AddInt(9);
            pkt.AddByte((byte)PacketType.MapItemAdd);
            pkt.AddInt(loc.X);
            pkt.AddInt(loc.Y);
            pkt.AddByte((byte)loc.Z);
            pkt.AddInt((int)item.Id);
            if (item.Count >0)
            {
                pkt.AddByte(item.Count);
            }
            MapItemAddPacket p = new MapItemAddPacket(pkt.Data);
            return p;
        }
    }
}