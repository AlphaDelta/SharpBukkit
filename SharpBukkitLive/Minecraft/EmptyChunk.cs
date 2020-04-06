// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class EmptyChunk : net.minecraft.src.Chunk
	{
		public EmptyChunk(net.minecraft.src.World world, int i, int j)
			: base(world, i, j)
		{
			// Referenced classes of package net.minecraft.src:
			//            Chunk, World, EnumSkyBlock, Entity, 
			//            TileEntity, AxisAlignedBB
			neverSave = true;
		}

		public EmptyChunk(net.minecraft.src.World world, byte[] abyte0, int i, int j)
			: base(world, abyte0, i, j)
		{
			neverSave = true;
		}

		public override bool IsAtLocation(int i, int j)
		{
			return i == xPosition && j == zPosition;
		}

		public override int GetHeightValue(int i, int j)
		{
			return 0;
		}

		public override void Func_348_a()
		{
		}

		public override void Func_353_b()
		{
		}

		public override void Func_4053_c()
		{
		}

		public override int GetBlockID(int i, int j, int k)
		{
			return 0;
		}

		public override bool SetBlockIDWithMetadata(int i, int j, int k, int l, int i1)
		{
			return true;
		}

		public override bool SetBlockID(int i, int j, int k, int l)
		{
			return true;
		}

		public override int GetBlockMetadata(int i, int j, int k)
		{
			return 0;
		}

		public override void SetBlockMetadata(int i, int j, int k, int l)
		{
		}

		public override int GetSavedLightValue(net.minecraft.src.EnumSkyBlock enumskyblock
			, int i, int j, int k)
		{
			return 0;
		}

		public override void SetLightValue(net.minecraft.src.EnumSkyBlock enumskyblock, int
			 i, int j, int k, int l)
		{
		}

		public override int GetBlockLightValue(int i, int j, int k, int l)
		{
			return 0;
		}

		public override void AddEntity(net.minecraft.src.Entity entity)
		{
		}

		public override void RemoveEntity(net.minecraft.src.Entity entity)
		{
		}

		public override void RemoveEntityAtIndex(net.minecraft.src.Entity entity, int i)
		{
		}

		public override bool CanBlockSeeTheSky(int i, int j, int k)
		{
			return false;
		}

		public override net.minecraft.src.TileEntity GetChunkBlockTileEntity(int i, int j
			, int k)
		{
			return null;
		}

		public override void AddTileEntity(net.minecraft.src.TileEntity tileentity)
		{
		}

		public override void SetChunkBlockTileEntity(int i, int j, int k, net.minecraft.src.TileEntity
			 tileentity)
		{
		}

		public override void RemoveChunkBlockTileEntity(int i, int j, int k)
		{
		}

		public override void OnChunkLoad()
		{
		}

		public override void OnChunkUnload()
		{
		}

		public override void SetChunkModified()
		{
		}

		public override void GetEntitiesWithinAABBForEntity(net.minecraft.src.Entity entity
			, net.minecraft.src.AxisAlignedBB axisalignedbb, System.Collections.IList list)
		{
		}

		public override void GetEntitiesOfTypeWithinAAAB(System.Type class1, net.minecraft.src.AxisAlignedBB
			 axisalignedbb, System.Collections.IList list)
		{
		}

		public override bool NeedsSaving(bool flag)
		{
			return false;
		}

		public override int GetChunkData(byte[] abyte0, int i, int j, int k, int l, int i1
			, int j1, int k1)
		{
			int l1 = l - i;
			int i2 = i1 - j;
			int j2 = j1 - k;
			int k2 = l1 * i2 * j2;
			int l2 = k2 + (k2 / 2) * 3;
			for (int ii = k1; ii < k1 + l2; ii++)
				abyte0[0] = 0;
			//java.util.Arrays.Fill(abyte0, k1, k1 + l2, unchecked((byte)0));
			return l2;
		}

		public override SharpBukkitLive.SharpBukkit.SharpRandom Func_334_a(long l)
		{
			return new SharpBukkitLive.SharpBukkit.SharpRandom(worldObj.GetRandomSeed() + (long)(xPosition * xPosition
				 * unchecked((int)(0x4c1906))) + (long)(xPosition * unchecked((int)(0x5ac0db))) 
				+ (long)(zPosition * zPosition) * unchecked((long)(0x4307a7L)) + (long)(zPosition
				 * unchecked((int)(0x5f24f))) ^ l);
		}

		public override bool Func_21101_g()
		{
			return true;
		}
	}
}
