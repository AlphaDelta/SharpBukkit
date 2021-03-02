// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class TileEntitySign : net.minecraft.src.TileEntity
	{
		public TileEntitySign()
		{
			// Referenced classes of package net.minecraft.src:
			//            TileEntity, NBTTagCompound, Packet130UpdateSign, Packet
			lineBeingEdited = -1;
			isEditable = true;
		}

		public override void WriteToNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			base.WriteToNBT(nbttagcompound);
			nbttagcompound.SetString("Text1", Lines[0]);
			nbttagcompound.SetString("Text2", Lines[1]);
			nbttagcompound.SetString("Text3", Lines[2]);
			nbttagcompound.SetString("Text4", Lines[3]);
		}

		public override void ReadFromNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			isEditable = false;
			base.ReadFromNBT(nbttagcompound);
			for (int i = 0; i < 4; i++)
			{
				Lines[i] = nbttagcompound.GetString((new java.lang.StringBuilder()).Append("Text"
					).Append(i + 1).ToString());
				if (Lines[i].Length > 15)
				{
					Lines[i] = Lines[i].Substring(0, 15);
				}
			}
		}

		public override net.minecraft.src.Packet GetDescriptionPacket()
		{
			string[] @as = new string[4];
			for (int i = 0; i < 4; i++)
			{
				@as[i] = Lines[i];

				// CRAFTBUKKIT start - limit sign text to 15 chars per line
				if (this.Lines[i].Length > 15)
				{
					@as[i] = this.Lines[i].Substring(0, 15);
				}
				// CRAFTBUKKIT end
			}
			return new net.minecraft.src.Packet130UpdateSign(xCoord, yCoord, zCoord, @as);
		}

		public virtual bool GetEditable()
		{
			return isEditable;
		}

		public virtual void SetEditable(bool flag)
		{
			isEditable = flag;
		}

		public string[] Lines = new string[] { string.Empty, string.Empty, string.Empty, string.Empty };

		public int lineBeingEdited;

		private bool isEditable;
	}
}
