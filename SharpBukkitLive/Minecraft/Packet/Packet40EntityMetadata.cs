// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Packet40EntityMetadata : net.minecraft.src.Packet
	{
		public Packet40EntityMetadata()
		{
		}

		public Packet40EntityMetadata(int i, net.minecraft.src.DataWatcher datawatcher)
		{
			// Referenced classes of package net.minecraft.src:
			//            Packet, DataWatcher, NetHandler
			entityId = i;
			field_21018_b = datawatcher.GetChangedObjects();
		}

		/// <exception cref="System.IO.IOException"/>
		public override void ReadPacketData(java.io.DataInputStream datainputstream)
		{
			entityId = datainputstream.ReadInt();
			field_21018_b = net.minecraft.src.DataWatcher.ReadWatchableObjects(datainputstream
				);
		}

		/// <exception cref="System.IO.IOException"/>
		public override void WritePacketData(java.io.DataOutputStream dataoutputstream)
		{
			dataoutputstream.WriteInt(entityId);
			net.minecraft.src.DataWatcher.WriteObjectsInListToStream(field_21018_b, dataoutputstream
				);
		}

		public override void ProcessPacket(net.minecraft.src.NetHandler nethandler)
		{
			nethandler.Func_21002_a(this);
		}

		public override int GetPacketSize()
		{
			return 5;
		}

		public int entityId;

		private System.Collections.IList field_21018_b;
	}
}
