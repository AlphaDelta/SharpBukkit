// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class Material
	{
		public Material(net.minecraft.src.MapColor mapcolor)
		{
			// Referenced classes of package net.minecraft.src:
			//            MaterialTransparent, MapColor, MaterialLiquid, MaterialLogic, 
			//            MaterialPortal
			field_31061_G = true;
			field_28131_A = mapcolor;
		}

		public virtual bool GetIsLiquid()
		{
			return false;
		}

		public virtual bool IsSolid()
		{
			return true;
		}

		public virtual bool GetCanBlockGrass()
		{
			return true;
		}

		public virtual bool GetIsSolid()
		{
			return true;
		}

		private net.minecraft.src.Material Func_28129_i()
		{
			isTranslucent = true;
			return this;
		}

		private net.minecraft.src.Material Func_31058_n()
		{
			field_31061_G = false;
			return this;
		}

		private net.minecraft.src.Material SetBurning()
		{
			canBurn = true;
			return this;
		}

		public virtual bool GetBurning()
		{
			return canBurn;
		}

		public virtual net.minecraft.src.Material Func_27089_f()
		{
			field_27091_A = true;
			return this;
		}

		public virtual bool Func_27090_g()
		{
			return field_27091_A;
		}

		public virtual bool GetIsOpaque()
		{
			if (isTranslucent)
			{
				return false;
			}
			else
			{
				return GetIsSolid();
			}
		}

		public virtual bool Func_31055_i()
		{
			return field_31061_G;
		}

		public virtual int GetMaterialMobility()
		{
			return mobilityFlag;
		}

		protected internal virtual net.minecraft.src.Material SetNoPushMobility()
		{
			mobilityFlag = 1;
			return this;
		}

		protected internal virtual net.minecraft.src.Material SetImmovableMobility()
		{
			mobilityFlag = 2;
			return this;
		}

		public static readonly net.minecraft.src.Material air;

		public static readonly net.minecraft.src.Material grass;

		public static readonly net.minecraft.src.Material ground;

		public static readonly net.minecraft.src.Material wood;

		public static readonly net.minecraft.src.Material rock;

		public static readonly net.minecraft.src.Material iron;

		public static readonly net.minecraft.src.Material water;

		public static readonly net.minecraft.src.Material lava;

		public static readonly net.minecraft.src.Material leaves;

		public static readonly net.minecraft.src.Material plants;

		public static readonly net.minecraft.src.Material sponge;

		public static readonly net.minecraft.src.Material cloth;

		public static readonly net.minecraft.src.Material fire;

		public static readonly net.minecraft.src.Material sand;

		public static readonly net.minecraft.src.Material circuits;

		public static readonly net.minecraft.src.Material glass;

		public static readonly net.minecraft.src.Material tnt;

		public static readonly net.minecraft.src.Material wug;

		public static readonly net.minecraft.src.Material ice;

		public static readonly net.minecraft.src.Material snow;

		public static readonly net.minecraft.src.Material builtSnow;

		public static readonly net.minecraft.src.Material cactus;

		public static readonly net.minecraft.src.Material clay;

		public static readonly net.minecraft.src.Material pumpkin;

		public static readonly net.minecraft.src.Material portal;

		public static readonly net.minecraft.src.Material cakeMaterial;

		public static readonly net.minecraft.src.Material web;

		public static readonly net.minecraft.src.Material piston;

		private bool canBurn;

		private bool field_27091_A;

		private bool isTranslucent;

		public readonly net.minecraft.src.MapColor field_28131_A;

		private bool field_31061_G;

		private int mobilityFlag;

		static Material()
		{
			air = new net.minecraft.src.MaterialTransparent(net.minecraft.src.MapColor.field_28199_b
				);
			grass = new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28198_c);
			ground = new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28189_l);
			wood = (new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28186_o))
				.SetBurning();
			rock = (new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28188_m))
				.Func_31058_n();
			iron = (new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28193_h))
				.Func_31058_n();
			water = (new net.minecraft.src.MaterialLiquid(net.minecraft.src.MapColor.field_28187_n
				)).SetNoPushMobility();
			lava = (new net.minecraft.src.MaterialLiquid(net.minecraft.src.MapColor.field_28195_f
				)).SetNoPushMobility();
			leaves = (new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28192_i
				)).SetBurning().Func_28129_i().SetNoPushMobility();
			plants = (new net.minecraft.src.MaterialLogic(net.minecraft.src.MapColor.field_28192_i
				)).SetNoPushMobility();
			sponge = new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28196_e);
			cloth = (new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28196_e)
				).SetBurning();
			fire = (new net.minecraft.src.MaterialTransparent(net.minecraft.src.MapColor.field_28199_b
				)).SetNoPushMobility();
			sand = new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28197_d);
			circuits = (new net.minecraft.src.MaterialLogic(net.minecraft.src.MapColor.field_28199_b
				)).SetNoPushMobility();
			glass = (new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28199_b)
				).Func_28129_i();
			tnt = (new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28195_f)).
				SetBurning().Func_28129_i();
			wug = (new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28192_i)).
				SetNoPushMobility();
			ice = (new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28194_g)).
				Func_28129_i();
			snow = (new net.minecraft.src.MaterialLogic(net.minecraft.src.MapColor.field_28191_j
				)).Func_27089_f().Func_28129_i().Func_31058_n().SetNoPushMobility();
			builtSnow = (new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28191_j
				)).Func_31058_n();
			cactus = (new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28192_i
				)).Func_28129_i().SetNoPushMobility();
			clay = new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28190_k);
			pumpkin = (new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28192_i
				)).SetNoPushMobility();
			portal = (new net.minecraft.src.MaterialPortal(net.minecraft.src.MapColor.field_28199_b
				)).SetImmovableMobility();
			cakeMaterial = (new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28199_b
				)).SetNoPushMobility();
			web = (new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28196_e)).
				Func_31058_n().SetNoPushMobility();
			piston = (new net.minecraft.src.Material(net.minecraft.src.MapColor.field_28188_m
				)).SetImmovableMobility();
		}
	}
}
