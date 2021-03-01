// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class BlockStep : net.minecraft.src.Block
	{
		public BlockStep(int i, bool flag)
			: base(i, 6, net.minecraft.src.Material.rock)
		{
			// Referenced classes of package net.minecraft.src:
			//            Block, Material, World
			blockType = flag;
			if (!flag)
			{
				SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 0.5F, 1.0F);
			}
			SetLightOpacity(255);
		}

		public override int GetBlockTextureFromSideAndMetadata(int i, int j)
		{
			if (j == 0)
			{
				return i > 1 ? 5 : 6;
			}
			if (j == 1)
			{
				if (i == 0)
				{
					return 208;
				}
				return i != 1 ? 192 : 176;
			}
			if (j == 2)
			{
				return 4;
			}
			return j != 3 ? 6 : 16;
		}

		public override int GetBlockTextureFromSide(int i)
		{
			return GetBlockTextureFromSideAndMetadata(i, 0);
		}

		public override bool IsOpaqueCube()
		{
			return blockType;
		}

		public override void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
			 k)
		{
			if (this != net.minecraft.src.Block.STEP)
			{
				base.OnBlockAdded(world, i, j, k);
			}
			int l = world.GetBlockId(i, j - 1, k);
			int i1 = world.GetBlockMetadata(i, j, k);
			int j1 = world.GetBlockMetadata(i, j - 1, k);
			if (i1 != j1)
			{
				return;
			}
			if (l == STEP.blockID)
			{
				world.SetBlockWithNotify(i, j, k, 0);
				world.SetBlockAndMetadataWithNotify(i, j - 1, k, net.minecraft.src.Block.DOUBLE_STEP
					.blockID, i1);
			}
		}

		public override int IdDropped(int i, SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return net.minecraft.src.Block.STEP.blockID;
		}

		public override int QuantityDropped(SharpBukkitLive.SharpBukkit.SharpRandom random)
		{
			return !blockType ? 1 : 2;
		}

		protected internal override int DamageDropped(int i)
		{
			return i;
		}

		public override bool IsACube()
		{
			return blockType;
		}

		public static readonly string[] field_22027_a = new string[] { "stone", "sand", "wood"
			, "cobble" };

		private bool blockType;
	}
}
