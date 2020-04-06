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
			isEditAble = true;
		}

		public override void WriteToNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			base.WriteToNBT(nbttagcompound);
			nbttagcompound.SetString("Text1", signText[0]);
			nbttagcompound.SetString("Text2", signText[1]);
			nbttagcompound.SetString("Text3", signText[2]);
			nbttagcompound.SetString("Text4", signText[3]);
		}

		public override void ReadFromNBT(net.minecraft.src.NBTTagCompound nbttagcompound)
		{
			isEditAble = false;
			base.ReadFromNBT(nbttagcompound);
			for (int i = 0; i < 4; i++)
			{
				signText[i] = nbttagcompound.GetString((new java.lang.StringBuilder()).Append("Text"
					).Append(i + 1).ToString());
				if (signText[i].Length > 15)
				{
					signText[i] = signText[i].Substring(0, 15);
				}
			}
		}

		public override net.minecraft.src.Packet GetDescriptionPacket()
		{
			string[] @as = new string[4];
			for (int i = 0; i < 4; i++)
			{
				@as[i] = signText[i];
			}
			return new net.minecraft.src.Packet130UpdateSign(xCoord, yCoord, zCoord, @as);
		}

		public virtual bool GetIsEditAble()
		{
			return isEditAble;
		}

		public virtual void Func_32001_a(bool flag)
		{
			isEditAble = flag;
		}

		public string[] signText = new string[] { string.Empty, string.Empty, string.Empty
			, string.Empty };

		public int lineBeingEdited;

		private bool isEditAble;
	}
}
