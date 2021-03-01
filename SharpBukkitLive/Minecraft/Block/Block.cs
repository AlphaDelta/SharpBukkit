// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;
using System;
using System.Collections.Generic;

namespace net.minecraft.src
{
    public class Block
    {

        public static readonly net.minecraft.src.StepSound soundPowderFootstep = new StepSound("stone", 1.0F, 1.0F);
        public static readonly net.minecraft.src.StepSound soundWoodFootstep = new StepSound("wood", 1.0F, 1.0F);
        public static readonly net.minecraft.src.StepSound soundGravelFootstep = new StepSound("gravel", 1.0F, 1.0F);
        public static readonly net.minecraft.src.StepSound soundGrassFootstep = new StepSound("grass", 1.0F, 1.0F);
        public static readonly net.minecraft.src.StepSound soundStoneFootstep = new StepSound("stone", 1.0F, 1.0F);
        public static readonly net.minecraft.src.StepSound soundMetalFootstep = new StepSound("stone", 1.0F, 1.5F);
        public static readonly net.minecraft.src.StepSound soundGlassFootstep = new StepSoundStone("stone", 1.0F, 1.0F);
        public static readonly net.minecraft.src.StepSound soundClothFootstep = new StepSound("cloth", 1.0F, 1.0F);
        public static readonly net.minecraft.src.StepSound soundSandFootstep = new StepSoundSand("sand", 1.0F, 1.0F);
        public static readonly net.minecraft.src.Block[] blocksList = new Block[256];
        public static readonly bool[] tickOnLoad = new bool[256];
        public static readonly bool[] opaqueCubeLookup = new bool[256];
        public static readonly bool[] isBlockContainer = new bool[256];
        public static readonly int[] lightOpacity = new int[256];
        public static readonly bool[] canBlockGrass = new bool[256];
        public static readonly int[] lightValue = new int[256];
        public static readonly bool[] requiresSelfNotify = new bool[256];

        public static readonly Block STONE = (new BlockStone(1, 1)).SetHardness(1.5F).SetResistance(10F).SetStepSound(soundStoneFootstep).SetBlockName("stone");
        public static readonly BlockGrass GRASS = (BlockGrass)(new BlockGrass(2)).SetHardness(0.6F).SetStepSound(soundGrassFootstep).SetBlockName("grass");
        public static readonly Block DIRT = (new BlockDirt(3, 2)).SetHardness(0.5F).SetStepSound(soundGravelFootstep).SetBlockName("dirt");
        public static readonly Block COBBLESTONE = (new Block(4, 16, Material.rock)).SetHardness(2.0F).SetResistance(10F).SetStepSound(soundStoneFootstep).SetBlockName("stonebrick");
        public static readonly Block WOOD = (new Block(5, 4, Material.wood)).SetHardness(2.0F).SetResistance(5F).SetStepSound(soundWoodFootstep).SetBlockName("wood").SetRequiresSelfNotify();
        public static readonly Block SAPLING = (new BlockSapling(6, 15)).SetHardness(0.0F).SetStepSound(soundGrassFootstep).SetBlockName("sapling").SetRequiresSelfNotify();
        public static readonly Block BEDROCK = (new Block(7, 17, Material.rock)).SetBlockUnbreakable().SetResistance(6000000F).SetStepSound(soundStoneFootstep).SetBlockName("bedrock").DisableStats();
        public static readonly Block WATER = (new BlockFlowing(8, Material.water)).SetHardness(100F).SetLightOpacity(3).SetBlockName("water").DisableStats().SetRequiresSelfNotify();
        public static readonly Block STATIONARY_WATER = (new BlockStationary(9, Material.water)).SetHardness(100F).SetLightOpacity(3).SetBlockName("water").DisableStats().SetRequiresSelfNotify();
        public static readonly Block LAVA = (new BlockFlowing(10, Material.lava)).SetHardness(0.0F).SetLightValue(1.0F).SetLightOpacity(255).SetBlockName("lava").DisableStats().SetRequiresSelfNotify();
        public static readonly Block STATIONARY_LAVA = (new BlockStationary(11, Material.lava)).SetHardness(100F).SetLightValue(1.0F).SetLightOpacity(255).SetBlockName("lava").DisableStats().SetRequiresSelfNotify();
        public static readonly Block SAND = (new BlockSand(12, 18)).SetHardness(0.5F).SetStepSound(soundSandFootstep).SetBlockName("sand");
        public static readonly Block GRAVEL = (new BlockGravel(13, 19)).SetHardness(0.6F).SetStepSound(soundGravelFootstep).SetBlockName("gravel");
        public static readonly Block GOLD_ORE = (new BlockOre(14, 32)).SetHardness(3F).SetResistance(5F).SetStepSound(soundStoneFootstep).SetBlockName("oreGold");
        public static readonly Block IRON_ORE = (new BlockOre(15, 33)).SetHardness(3F).SetResistance(5F).SetStepSound(soundStoneFootstep).SetBlockName("oreIron");
        public static readonly Block COAL_ORE = (new BlockOre(16, 34)).SetHardness(3F).SetResistance(5F).SetStepSound(soundStoneFootstep).SetBlockName("oreCoal");
        public static readonly Block LOG = (new BlockLog(17)).SetHardness(2.0F).SetStepSound(soundWoodFootstep).SetBlockName("log").SetRequiresSelfNotify();
        public static readonly BlockLeaves LEAVES = (BlockLeaves)(new BlockLeaves(18, 52)).SetHardness(0.2F).SetLightOpacity(1).SetStepSound(soundGrassFootstep).SetBlockName("leaves").DisableStats().SetRequiresSelfNotify();
        public static readonly Block SPONGE = (new BlockSponge(19)).SetHardness(0.6F).SetStepSound(soundGrassFootstep).SetBlockName("sponge");
        public static readonly Block GLASS = (new BlockGlass(20, 49, Material.glass, false)).SetHardness(0.3F).SetStepSound(soundGlassFootstep).SetBlockName("glass");
        public static readonly Block LAPIS_ORE = (new BlockOre(21, 160)).SetHardness(3F).SetResistance(5F).SetStepSound(soundStoneFootstep).SetBlockName("oreLapis");
        public static readonly Block LAPIS_BLOCK = (new Block(22, 144, Material.rock)).SetHardness(3F).SetResistance(5F).SetStepSound(soundStoneFootstep).SetBlockName("blockLapis");
        public static readonly Block DISPENSER = (new BlockDispenser(23)).SetHardness(3.5F).SetStepSound(soundStoneFootstep).SetBlockName("dispenser").SetRequiresSelfNotify();
        public static readonly Block SANDSTONE = (new BlockSandStone(24)).SetStepSound(soundStoneFootstep).SetHardness(0.8F).SetBlockName("sandStone");
        public static readonly Block NOTE_BLOCK = (new BlockNote(25)).SetHardness(0.8F).SetBlockName("musicBlock").SetRequiresSelfNotify();
        public static readonly Block BED = (new BlockBed(26)).SetHardness(0.2F).SetBlockName("bed").DisableStats().SetRequiresSelfNotify();
        public static readonly Block GOLDEN_RAIL = (new BlockRail(27, 179, true)).SetHardness(0.7F).SetStepSound(soundMetalFootstep).SetBlockName("goldenRail").SetRequiresSelfNotify();
        public static readonly Block DETECTOR_RAIL = (new BlockDetectorRail(28, 195)).SetHardness(0.7F).SetStepSound(soundMetalFootstep).SetBlockName("detectorRail").SetRequiresSelfNotify();
        public static readonly Block PISTON_STICKY = (new BlockPistonBase(29, 106, true)).SetBlockName("pistonStickyBase").SetRequiresSelfNotify();
        public static readonly Block WEB = (new BlockWeb(30, 11)).SetLightOpacity(1).SetHardness(4F).SetBlockName("web");
        public static readonly BlockTallGrass LONG_GRASS = (BlockTallGrass)(new BlockTallGrass(31, 39)).SetHardness(0.0F).SetStepSound(soundGrassFootstep).SetBlockName("tallgrass");
        public static readonly BlockDeadBush DEAD_BUSH = (BlockDeadBush)(new BlockDeadBush(32, 55)).SetHardness(0.0F).SetStepSound(soundGrassFootstep).SetBlockName("deadbush");
        public static readonly Block PISTON = (new BlockPistonBase(33, 107, false)).SetBlockName("pistonBase").SetRequiresSelfNotify();
        public static readonly BlockPistonExtension PISTON_EXTENSION = (BlockPistonExtension)(new BlockPistonExtension(34, 107)).SetRequiresSelfNotify();
        public static readonly Block WOOL = (new BlockCloth()).SetHardness(0.8F).SetStepSound(soundClothFootstep).SetBlockName("cloth").SetRequiresSelfNotify();
        public static readonly BlockPistonMoving PISTON_MOVING = new BlockPistonMoving(36);
        public static readonly BlockFlower YELLOW_FLOWER = (BlockFlower)(new BlockFlower(37, 13)).SetHardness(0.0F).SetStepSound(soundGrassFootstep).SetBlockName("flower");
        public static readonly BlockFlower RED_ROSE = (BlockFlower)(new BlockFlower(38, 12)).SetHardness(0.0F).SetStepSound(soundGrassFootstep).SetBlockName("rose");
        public static readonly BlockFlower BROWN_MUSHROOM = (BlockFlower)(new BlockMushroom(39, 29)).SetHardness(0.0F).SetStepSound(soundGrassFootstep).SetLightValue(0.125F).SetBlockName("mushroom");
        public static readonly BlockFlower RED_MUSHROOM = (BlockFlower)(new BlockMushroom(40, 28)).SetHardness(0.0F).SetStepSound(soundGrassFootstep).SetBlockName("mushroom");
        public static readonly Block GOLD_BLOCK = (new BlockOreStorage(41, 23)).SetHardness(3F).SetResistance(10F).SetStepSound(soundMetalFootstep).SetBlockName("blockGold");
        public static readonly Block IRON_BLOCK = (new BlockOreStorage(42, 22)).SetHardness(5F).SetResistance(10F).SetStepSound(soundMetalFootstep).SetBlockName("blockIron");
        public static readonly Block DOUBLE_STEP = (new BlockStep(43, true)).SetHardness(2.0F).SetResistance(10F).SetStepSound(soundStoneFootstep).SetBlockName("stoneSlab");
        public static readonly Block STEP = (new BlockStep(44, false)).SetHardness(2.0F).SetResistance(10F).SetStepSound(soundStoneFootstep).SetBlockName("stoneSlab");
        public static readonly Block BRICK = (new Block(45, 7, Material.rock)).SetHardness(2.0F).SetResistance(10F).SetStepSound(soundStoneFootstep).SetBlockName("brick");
        public static readonly Block TNT = (new BlockTNT(46, 8)).SetHardness(0.0F).SetStepSound(soundGrassFootstep).SetBlockName("tnt");
        public static readonly Block BOOKSHELF = (new BlockBookshelf(47, 35)).SetHardness(1.5F).SetStepSound(soundWoodFootstep).SetBlockName("bookshelf");
        public static readonly Block MOSSY_COBBLESTONE = (new Block(48, 36, Material.rock)).SetHardness(2.0F).SetResistance(10F).SetStepSound(soundStoneFootstep).SetBlockName("stoneMoss");
        public static readonly Block OBSISIAN = (new BlockObsidian(49, 37)).SetHardness(10F).SetResistance(2000F).SetStepSound(soundStoneFootstep).SetBlockName("obsidian");
        public static readonly Block TORCH = (new BlockTorch(50, 80)).SetHardness(0.0F).SetLightValue(0.9375F).SetStepSound(soundWoodFootstep).SetBlockName("torch").SetRequiresSelfNotify();
        public static readonly BlockFire FIRE = (BlockFire)(new BlockFire(51, 31)).SetHardness(0.0F).SetLightValue(1.0F).SetStepSound(soundWoodFootstep).SetBlockName("fire").DisableStats().SetRequiresSelfNotify();
        public static readonly Block MOB_SPAWNER = (new BlockMobSpawner(52, 65)).SetHardness(5F).SetStepSound(soundMetalFootstep).SetBlockName("mobSpawner").DisableStats();
        public static readonly Block WOOD_STAIRS = (new BlockStairs(53, WOOD)).SetBlockName("stairsWood").SetRequiresSelfNotify();
        public static readonly Block CHEST = (new BlockChest(54)).SetHardness(2.5F).SetStepSound(soundWoodFootstep).SetBlockName("chest").SetRequiresSelfNotify();
        public static readonly Block REDSTONE_WIRE = (new BlockRedstoneWire(55, 164)).SetHardness(0.0F).SetStepSound(soundPowderFootstep).SetBlockName("redstoneDust").DisableStats().SetRequiresSelfNotify();
        public static readonly Block DIAMOND_ORE = (new BlockOre(56, 50)).SetHardness(3F).SetResistance(5F).SetStepSound(soundStoneFootstep).SetBlockName("oreDiamond");
        public static readonly Block DIAMOND_BLOCK = (new BlockOreStorage(57, 24)).SetHardness(5F).SetResistance(10F).SetStepSound(soundMetalFootstep).SetBlockName("blockDiamond");
        public static readonly Block WORKBENCH = (new BlockWorkbench(58)).SetHardness(2.5F).SetStepSound(soundWoodFootstep).SetBlockName("workbench");
        public static readonly Block CROPS = (new BlockCrops(59, 88)).SetHardness(0.0F).SetStepSound(soundGrassFootstep).SetBlockName("crops").DisableStats().SetRequiresSelfNotify();
        public static readonly Block SOIL = (new BlockFarmland(60)).SetHardness(0.6F).SetStepSound(soundGravelFootstep).SetBlockName("farmland");
        public static readonly Block FURNACE = (new BlockFurnace(61, false)).SetHardness(3.5F).SetStepSound(soundStoneFootstep).SetBlockName("furnace").SetRequiresSelfNotify();
        public static readonly Block BURNING_FURNACE = (new BlockFurnace(62, true)).SetHardness(3.5F).SetStepSound(soundStoneFootstep).SetLightValue(0.875F).SetBlockName("furnace").SetRequiresSelfNotify();
        public static readonly Block SIGN_POST = (new BlockSign(63, Sharpen.Runtime.GetClassForType(typeof(TileEntitySign)), true)).SetHardness(1.0F).SetStepSound(soundWoodFootstep).SetBlockName("sign").DisableStats().SetRequiresSelfNotify();
        public static readonly Block WOODEN_DOOR = (new BlockDoor(64, Material.wood)).SetHardness(3F).SetStepSound(soundWoodFootstep).SetBlockName("doorWood").DisableStats().SetRequiresSelfNotify();
        public static readonly Block LADDER = (new BlockLadder(65, 83)).SetHardness(0.4F).SetStepSound(soundWoodFootstep).SetBlockName("ladder").SetRequiresSelfNotify();
        public static readonly Block RAILS = (new BlockRail(66, 128, false)).SetHardness(0.7F).SetStepSound(soundMetalFootstep).SetBlockName("rail").SetRequiresSelfNotify();
        public static readonly Block COBBLESTONE_STAIRS = (new BlockStairs(67, COBBLESTONE)).SetBlockName("stairsStone").SetRequiresSelfNotify();
        public static readonly Block WALL_SIGN = (new BlockSign(68, Sharpen.Runtime.GetClassForType(typeof(TileEntitySign)), false)).SetHardness(1.0F).SetStepSound(soundWoodFootstep).SetBlockName("sign").DisableStats().SetRequiresSelfNotify();
        public static readonly Block LEVEL = (new BlockLever(69, 96)).SetHardness(0.5F).SetStepSound(soundWoodFootstep).SetBlockName("lever").SetRequiresSelfNotify();
        public static readonly Block STONE_PLATE = (new BlockPressurePlate(70, STONE.blockIndexInTexture, EnumMobType.mobs, Material.rock)).SetHardness(0.5F).SetStepSound(soundStoneFootstep).SetBlockName("pressurePlate").SetRequiresSelfNotify();
        public static readonly Block IRON_DOOR_BLOCK = (new BlockDoor(71, Material.iron)).SetHardness(5F).SetStepSound(soundMetalFootstep).SetBlockName("doorIron").DisableStats().SetRequiresSelfNotify();
        public static readonly Block WOOD_PLATE = (new BlockPressurePlate(72, WOOD.blockIndexInTexture, EnumMobType.everything, Material.wood)).SetHardness(0.5F).SetStepSound(soundWoodFootstep).SetBlockName("pressurePlate").SetRequiresSelfNotify();
        public static readonly Block REDSTONE_ORE = (new BlockRedstoneOre(73, 51, false)).SetHardness(3F).SetResistance(5F).SetStepSound(soundStoneFootstep).SetBlockName("oreRedstone").SetRequiresSelfNotify();
        public static readonly Block GLOWING_REDSTONE_ORE = (new BlockRedstoneOre(74, 51, true)).SetLightValue(0.625F).SetHardness(3F).SetResistance(5F).SetStepSound(soundStoneFootstep).SetBlockName("oreRedstone").SetRequiresSelfNotify();
        public static readonly Block REDSTONE_TORCH_OFF = (new BlockRedstoneTorch(75, 115, false)).SetHardness(0.0F).SetStepSound(soundWoodFootstep).SetBlockName("notGate").SetRequiresSelfNotify();
        public static readonly Block REDSTONE_TORCH_ON = (new BlockRedstoneTorch(76, 99, true)).SetHardness(0.0F).SetLightValue(0.5F).SetStepSound(soundWoodFootstep).SetBlockName("notGate").SetRequiresSelfNotify();
        public static readonly Block STONE_BUTTON = (new BlockButton(77, STONE.blockIndexInTexture)).SetHardness(0.5F).SetStepSound(soundStoneFootstep).SetBlockName("button").SetRequiresSelfNotify();
        public static readonly Block SNOW = (new BlockSnow(78, 66)).SetHardness(0.1F).SetStepSound(soundClothFootstep).SetBlockName("snow");
        public static readonly Block ICE = (new BlockIce(79, 67)).SetHardness(0.5F).SetLightOpacity(3).SetStepSound(soundGlassFootstep).SetBlockName("ice");
        public static readonly Block SNOW_BLOCK = (new BlockSnowBlock(80, 66)).SetHardness(0.2F).SetStepSound(soundClothFootstep).SetBlockName("snow");
        public static readonly Block CACTUS = (new BlockCactus(81, 70)).SetHardness(0.4F).SetStepSound(soundClothFootstep).SetBlockName("cactus");
        public static readonly Block CLAY = (new BlockClay(82, 72)).SetHardness(0.6F).SetStepSound(soundGravelFootstep).SetBlockName("clay");
        public static readonly Block SUGAR_CANE_BLOCK = (new BlockReed(83, 73)).SetHardness(0.0F).SetStepSound(soundGrassFootstep).SetBlockName("reeds").DisableStats();
        public static readonly Block JUKEBOX = (new BlockJukeBox(84, 74)).SetHardness(2.0F).SetResistance(10F).SetStepSound(soundStoneFootstep).SetBlockName("jukebox").SetRequiresSelfNotify();
        public static readonly Block FENCE = (new BlockFence(85, 4)).SetHardness(2.0F).SetResistance(5F).SetStepSound(soundWoodFootstep).SetBlockName("fence").SetRequiresSelfNotify();
        public static readonly Block PUMPKIN = (new BlockPumpkin(86, 102, false)).SetHardness(1.0F).SetStepSound(soundWoodFootstep).SetBlockName("pumpkin").SetRequiresSelfNotify();
        public static readonly Block NETHERRACK = (new BlockNetherrack(87, 103)).SetHardness(0.4F).SetStepSound(soundStoneFootstep).SetBlockName("hellrock");
        public static readonly Block SOUL_SAND = (new BlockSoulSand(88, 104)).SetHardness(0.5F).SetStepSound(soundSandFootstep).SetBlockName("hellsand");
        public static readonly Block GLOWSTONE = (new BlockGlowStone(89, 105, Material.rock)).SetHardness(0.3F).SetStepSound(soundGlassFootstep).SetLightValue(1.0F).SetBlockName("lightgem");
        public static readonly BlockPortal PORTAL = (BlockPortal)(new BlockPortal(90, 14)).SetHardness(-1F).SetStepSound(soundGlassFootstep).SetLightValue(0.75F).SetBlockName("portal");
        public static readonly Block JACK_O_LANTERN = (new BlockPumpkin(91, 102, true)).SetHardness(1.0F).SetStepSound(soundWoodFootstep).SetLightValue(1.0F).SetBlockName("litpumpkin").SetRequiresSelfNotify();
        public static readonly Block CAKE_BLOCK = (new BlockCake(92, 121)).SetHardness(0.5F).SetStepSound(soundClothFootstep).SetBlockName("cake").DisableStats().SetRequiresSelfNotify();
        public static readonly Block DIODE_OFF = (new BlockRedstoneRepeater(93, false)).SetHardness(0.0F).SetStepSound(soundWoodFootstep).SetBlockName("diode").DisableStats().SetRequiresSelfNotify();
        public static readonly Block DIODE_ON = (new BlockRedstoneRepeater(94, true)).SetHardness(0.0F).SetLightValue(0.625F).SetStepSound(soundWoodFootstep).SetBlockName("diode").DisableStats().SetRequiresSelfNotify();
        public static readonly Block LOCKED_CHEST = (new BlockLockedChest(95)).SetHardness(0.0F).SetLightValue(1.0F).SetStepSound(soundWoodFootstep).SetBlockName("lockedchest").SetTickOnLoad(true).SetRequiresSelfNotify();
        public static readonly Block TRAP_DOOR = (new BlockTrapDoor(96, Material.wood)).SetHardness(3F).SetStepSound(soundWoodFootstep).SetBlockName("trapdoor").DisableStats().SetRequiresSelfNotify();

        public int blockIndexInTexture;
        public readonly int blockID;
        protected internal float blockHardness;
        protected internal float blockResistance;
        protected internal bool blockConstructorCalled;
        protected internal bool enableStats;
        public double minX;
        public double minY;
        public double minZ;
        public double maxX;
        public double maxY;
        public double maxZ;
        public net.minecraft.src.StepSound stepSound;
        public float blockParticleGravity;
        public readonly net.minecraft.src.Material blockMaterial;
        public float slipperiness;
        private string blockName;

        static Block()
        {
            Item.itemsList[WOOL.blockID] = (new ItemCloth(WOOL.blockID - 256)).SetItemName("cloth");
            Item.itemsList[LOG.blockID] = (new ItemLog(LOG.blockID - 256)).SetItemName("log");
            Item.itemsList[STEP.blockID] = (new ItemSlab(STEP.blockID - 256)).SetItemName("stoneSlab");
            Item.itemsList[SAPLING.blockID] = (new ItemSapling(SAPLING.blockID - 256)).SetItemName("sapling");
            Item.itemsList[LEAVES.blockID] = (new ItemLeaves(LEAVES.blockID - 256)).SetItemName("leaves");
            Item.itemsList[PISTON.blockID] = new ItemPiston(PISTON.blockID - 256);
            Item.itemsList[PISTON_STICKY.blockID] = new ItemPiston(PISTON_STICKY.blockID - 256);

            for (int i = 0; i < 256; i++)
            {
                if (blocksList[i] != null && Item.itemsList[i] == null)
                {
                    Item.itemsList[i] = new ItemBlock(i - 256);
                    blocksList[i].SetFireBurnRates();
                }
            }
            canBlockGrass[0] = true;
            StatList.Func_25088_a();
        }

        protected internal Block(int i, net.minecraft.src.Material material)
        {
            // Referenced classes of package net.minecraft.src:
            //            Material, IBlockAccess, AxisAlignedBB, EntityPlayer, 
            //            World, ItemStack, EntityItem, Vec3D, 
            //            MovingObjectPosition, StatList, StatCollector, StepSound, 
            //            StepSoundStone, StepSoundSand, BlockStone, BlockGrass, 
            //            BlockDirt, BlockSapling, BlockFlowing, BlockStationary, 
            //            BlockSand, BlockGravel, BlockOre, BlockLog, 
            //            BlockLeaves, BlockSponge, BlockGlass, BlockDispenser, 
            //            BlockSandStone, BlockNote, BlockBed, BlockRail, 
            //            BlockDetectorRail, BlockPistonBase, BlockWeb, BlockTallGrass, 
            //            BlockDeadBush, BlockPistonExtension, BlockCloth, BlockPistonMoving, 
            //            BlockFlower, BlockMushroom, BlockOreStorage, BlockStep, 
            //            BlockTNT, BlockBookshelf, BlockObsidian, BlockTorch, 
            //            BlockFire, BlockMobSpawner, BlockStairs, BlockChest, 
            //            BlockRedstoneWire, BlockWorkbench, BlockCrops, BlockFarmland, 
            //            BlockFurnace, BlockSign, TileEntitySign, BlockDoor, 
            //            BlockLadder, BlockLever, BlockPressurePlate, EnumMobType, 
            //            BlockRedstoneOre, BlockRedstoneTorch, BlockButton, BlockSnow, 
            //            BlockIce, BlockSnowBlock, BlockCactus, BlockClay, 
            //            BlockReed, BlockJukeBox, BlockFence, BlockPumpkin, 
            //            BlockNetherrack, BlockSoulSand, BlockGlowStone, BlockPortal, 
            //            BlockCake, BlockRedstoneRepeater, BlockLockedChest, BlockTrapDoor, 
            //            Item, ItemCloth, ItemLog, ItemSlab, 
            //            ItemSapling, ItemLeaves, ItemPiston, ItemBlock, 
            //            Entity, EntityLiving
            blockConstructorCalled = true;
            enableStats = true;
            stepSound = soundPowderFootstep;
            blockParticleGravity = 1.0F;
            slipperiness = 0.6F;
            if (blocksList[i] != null)
            {
                throw new System.ArgumentException((new java.lang.StringBuilder()).Append("Slot "
                    ).Append(i).Append(" is already occupied by ").Append(blocksList[i]).Append(" when adding "
                    ).Append(this).ToString());
            }
            else
            {
                blockMaterial = material;
                blocksList[i] = this;
                blockID = i;
                SetBlockBounds(0.0F, 0.0F, 0.0F, 1.0F, 1.0F, 1.0F);
                opaqueCubeLookup[i] = IsOpaqueCube();
                lightOpacity[i] = IsOpaqueCube() ? 255 : 0;
                canBlockGrass[i] = !material.GetCanBlockGrass();
                isBlockContainer[i] = false;
                return;
            }
        }

        protected internal virtual net.minecraft.src.Block SetRequiresSelfNotify()
        {
            requiresSelfNotify[blockID] = true;
            return this;
        }

        protected internal virtual void SetFireBurnRates()
        {
        }

        protected internal Block(int i, int j, net.minecraft.src.Material material)
            : this(i, material)
        {
            blockIndexInTexture = j;
        }

        protected internal virtual net.minecraft.src.Block SetStepSound(net.minecraft.src.StepSound
             stepsound)
        {
            stepSound = stepsound;
            return this;
        }

        protected internal virtual net.minecraft.src.Block SetLightOpacity(int i)
        {
            lightOpacity[blockID] = i;
            return this;
        }

        protected internal virtual net.minecraft.src.Block SetLightValue(float f)
        {
            lightValue[blockID] = (int)(15F * f);
            return this;
        }

        protected internal virtual net.minecraft.src.Block SetResistance(float f)
        {
            blockResistance = f * 3F;
            return this;
        }

        public virtual bool IsACube()
        {
            return true;
        }

        protected internal virtual net.minecraft.src.Block SetHardness(float f)
        {
            blockHardness = f;
            if (blockResistance < f * 5F)
            {
                blockResistance = f * 5F;
            }
            return this;
        }

        protected internal virtual net.minecraft.src.Block SetBlockUnbreakable()
        {
            SetHardness(-1F);
            return this;
        }

        public virtual float GetHardness()
        {
            return blockHardness;
        }

        protected internal virtual net.minecraft.src.Block SetTickOnLoad(bool flag)
        {
            tickOnLoad[blockID] = flag;
            return this;
        }

        public virtual void SetBlockBounds(float f, float f1, float f2, float f3, float f4
            , float f5)
        {
            minX = f;
            minY = f1;
            minZ = f2;
            maxX = f3;
            maxY = f4;
            maxZ = f5;
        }

        public virtual bool ShouldSideBeRendered(net.minecraft.src.IBlockAccess iblockaccess
            , int i, int j, int k, int l)
        {
            return iblockaccess.GetBlockMaterial(i, j, k).IsSolid();
        }

        public virtual int GetBlockTextureFromSideAndMetadata(int i, int j)
        {
            return GetBlockTextureFromSide(i);
        }

        public virtual int GetBlockTextureFromSide(int i)
        {
            return blockIndexInTexture;
        }

        public virtual void GetCollidingBoundingBoxes(net.minecraft.src.World world, int i, int j, int k, net.minecraft.src.AxisAlignedBB axisalignedbb, List<AxisAlignedBB> arraylist)
        {
            net.minecraft.src.AxisAlignedBB axisalignedbb1 = GetCollisionBoundingBoxFromPool(
                world, i, j, k);
            if (axisalignedbb1 != null && axisalignedbb.IntersectsWith(axisalignedbb1))
            {
                arraylist.Add(axisalignedbb1);
            }
        }

        public virtual net.minecraft.src.AxisAlignedBB GetCollisionBoundingBoxFromPool(net.minecraft.src.World
             world, int i, int j, int k)
        {
            return net.minecraft.src.AxisAlignedBB.GetBoundingBoxFromPool((double)i + minX, (
                double)j + minY, (double)k + minZ, (double)i + maxX, (double)j + maxY, (double)k
                 + maxZ);
        }

        public virtual bool IsOpaqueCube()
        {
            return true;
        }

        public virtual bool CanCollideCheck(int i, bool flag)
        {
            return IsCollidable();
        }

        public virtual bool IsCollidable()
        {
            return true;
        }

        public virtual void UpdateTick(net.minecraft.src.World world, int i, int j, int k
            , SharpRandom random)
        {
        }

        public virtual void OnBlockDestroyedByPlayer(net.minecraft.src.World world, int i
            , int j, int k, int l)
        {
        }

        public virtual void OnNeighborBlockChange(net.minecraft.src.World world, int i, int
             j, int k, int l)
        {
        }

        public virtual int TickRate()
        {
            return 10;
        }

        public virtual void OnBlockAdded(net.minecraft.src.World world, int i, int j, int
             k)
        {
        }

        public virtual void OnBlockRemoval(net.minecraft.src.World world, int i, int j, int
             k)
        {
        }

        public virtual int QuantityDropped(SharpRandom random)
        {
            return 1;
        }

        public virtual int IdDropped(int i, SharpRandom random)
        {
            return blockID;
        }

        public virtual float BlockStrength(net.minecraft.src.EntityPlayer entityplayer)
        {
            if (blockHardness < 0.0F)
            {
                return 0.0F;
            }
            if (!entityplayer.CanHarvestBlock(this))
            {
                return 1.0F / blockHardness / 100F;
            }
            else
            {
                return entityplayer.GetCurrentPlayerStrVsBlock(this) / blockHardness / 30F;
            }
        }

        public void DropBlockAsItem(net.minecraft.src.World world, int i, int j, int k, int
             l)
        {
            DropBlockAsItemWithChance(world, i, j, k, l, 1.0F);
        }

        public virtual void DropBlockAsItemWithChance(net.minecraft.src.World world, int
            i, int j, int k, int l, float f)
        {
            if (world.singleplayerWorld)
            {
                return;
            }
            int i1 = QuantityDropped(world.rand);
            for (int j1 = 0; j1 < i1; j1++)
            {
                if (world.rand.NextFloat() > f)
                {
                    continue;
                }
                int k1 = IdDropped(l, world.rand);
                if (k1 > 0)
                {
                    DropBlockAsItem_do(world, i, j, k, new net.minecraft.src.ItemStack(k1, 1, DamageDropped
                        (l)));
                }
            }
        }

        protected internal virtual void DropBlockAsItem_do(net.minecraft.src.World world,
            int i, int j, int k, net.minecraft.src.ItemStack itemstack)
        {
            if (world.singleplayerWorld)
            {
                return;
            }
            else
            {
                float f = 0.7F;
                double d = (double)(world.rand.NextFloat() * f) + (double)(1.0F - f) * 0.5D;
                double d1 = (double)(world.rand.NextFloat() * f) + (double)(1.0F - f) * 0.5D;
                double d2 = (double)(world.rand.NextFloat() * f) + (double)(1.0F - f) * 0.5D;
                net.minecraft.src.EntityItem entityitem = new net.minecraft.src.EntityItem(world,
                    (double)i + d, (double)j + d1, (double)k + d2, itemstack);
                entityitem.delayBeforeCanPickup = 10;
                world.AddEntity(entityitem);
                return;
            }
        }

        protected internal virtual int DamageDropped(int i)
        {
            return 0;
        }

        public virtual float GetExplosionResistance(net.minecraft.src.Entity entity)
        {
            return blockResistance / 5F;
        }

        public virtual net.minecraft.src.MovingObjectPosition CollisionRayTrace(net.minecraft.src.World
             world, int i, int j, int k, net.minecraft.src.Vec3D vec3d, net.minecraft.src.Vec3D
             vec3d1)
        {
            SetBlockBoundsBasedOnState(world, i, j, k);
            vec3d = vec3d.AddVector(-i, -j, -k);
            vec3d1 = vec3d1.AddVector(-i, -j, -k);
            net.minecraft.src.Vec3D vec3d2 = vec3d.GetIntermediateWithXValue(vec3d1, minX);
            net.minecraft.src.Vec3D vec3d3 = vec3d.GetIntermediateWithXValue(vec3d1, maxX);
            net.minecraft.src.Vec3D vec3d4 = vec3d.GetIntermediateWithYValue(vec3d1, minY);
            net.minecraft.src.Vec3D vec3d5 = vec3d.GetIntermediateWithYValue(vec3d1, maxY);
            net.minecraft.src.Vec3D vec3d6 = vec3d.GetIntermediateWithZValue(vec3d1, minZ);
            net.minecraft.src.Vec3D vec3d7 = vec3d.GetIntermediateWithZValue(vec3d1, maxZ);
            if (!IsVecInsideYZBounds(vec3d2))
            {
                vec3d2 = null;
            }
            if (!IsVecInsideYZBounds(vec3d3))
            {
                vec3d3 = null;
            }
            if (!IsVecInsideXZBounds(vec3d4))
            {
                vec3d4 = null;
            }
            if (!IsVecInsideXZBounds(vec3d5))
            {
                vec3d5 = null;
            }
            if (!IsVecInsideXYBounds(vec3d6))
            {
                vec3d6 = null;
            }
            if (!IsVecInsideXYBounds(vec3d7))
            {
                vec3d7 = null;
            }
            net.minecraft.src.Vec3D vec3d8 = null;
            if (vec3d2 != null && (vec3d8 == null || vec3d.DistanceTo(vec3d2) < vec3d.DistanceTo
                (vec3d8)))
            {
                vec3d8 = vec3d2;
            }
            if (vec3d3 != null && (vec3d8 == null || vec3d.DistanceTo(vec3d3) < vec3d.DistanceTo
                (vec3d8)))
            {
                vec3d8 = vec3d3;
            }
            if (vec3d4 != null && (vec3d8 == null || vec3d.DistanceTo(vec3d4) < vec3d.DistanceTo
                (vec3d8)))
            {
                vec3d8 = vec3d4;
            }
            if (vec3d5 != null && (vec3d8 == null || vec3d.DistanceTo(vec3d5) < vec3d.DistanceTo
                (vec3d8)))
            {
                vec3d8 = vec3d5;
            }
            if (vec3d6 != null && (vec3d8 == null || vec3d.DistanceTo(vec3d6) < vec3d.DistanceTo
                (vec3d8)))
            {
                vec3d8 = vec3d6;
            }
            if (vec3d7 != null && (vec3d8 == null || vec3d.DistanceTo(vec3d7) < vec3d.DistanceTo
                (vec3d8)))
            {
                vec3d8 = vec3d7;
            }
            if (vec3d8 == null)
            {
                return null;
            }
            byte byte0 = unchecked((byte)(-1));
            if (vec3d8 == vec3d2)
            {
                byte0 = 4;
            }
            if (vec3d8 == vec3d3)
            {
                byte0 = 5;
            }
            if (vec3d8 == vec3d4)
            {
                byte0 = 0;
            }
            if (vec3d8 == vec3d5)
            {
                byte0 = 1;
            }
            if (vec3d8 == vec3d6)
            {
                byte0 = 2;
            }
            if (vec3d8 == vec3d7)
            {
                byte0 = 3;
            }
            return new net.minecraft.src.MovingObjectPosition(i, j, k, byte0, vec3d8.AddVector
                (i, j, k));
        }

        private bool IsVecInsideYZBounds(net.minecraft.src.Vec3D vec3d)
        {
            if (vec3d == null)
            {
                return false;
            }
            else
            {
                return vec3d.yCoord >= minY && vec3d.yCoord <= maxY && vec3d.zCoord >= minZ && vec3d
                    .zCoord <= maxZ;
            }
        }

        private bool IsVecInsideXZBounds(net.minecraft.src.Vec3D vec3d)
        {
            if (vec3d == null)
            {
                return false;
            }
            else
            {
                return vec3d.xCoord >= minX && vec3d.xCoord <= maxX && vec3d.zCoord >= minZ && vec3d
                    .zCoord <= maxZ;
            }
        }

        private bool IsVecInsideXYBounds(net.minecraft.src.Vec3D vec3d)
        {
            if (vec3d == null)
            {
                return false;
            }
            else
            {
                return vec3d.xCoord >= minX && vec3d.xCoord <= maxX && vec3d.yCoord >= minY && vec3d
                    .yCoord <= maxY;
            }
        }

        public virtual void OnBlockDestroyedByExplosion(net.minecraft.src.World world, int i, int j, int k)
        {
        }

        public virtual bool CanPlaceBlockOnSide(net.minecraft.src.World world, int x, int y, int z, int l)
        {
            return CanPlaceBlockAt(world, x, y, z);
        }

        public virtual bool CanPlaceBlockAt(net.minecraft.src.World world, int x, int y, int z)
        {
            int l = world.GetBlockId(x, y, z);
            return l == 0 || blocksList[l].blockMaterial.Func_27090_g();
        }

        public virtual bool BlockActivated(net.minecraft.src.World world, int i, int j, int k, net.minecraft.src.EntityPlayer entityplayer)
        {
            return false;
        }

        public virtual void OnEntityWalking(net.minecraft.src.World world, int i, int j,
            int k, net.minecraft.src.Entity entity)
        {
        }

        public virtual void OnBlockPlaced(net.minecraft.src.World world, int i, int j, int
             k, int l)
        {
        }

        public virtual void OnBlockClicked(net.minecraft.src.World world, int i, int j, int
             k, net.minecraft.src.EntityPlayer entityplayer)
        {
        }

        public virtual void VelocityToAddToEntity(net.minecraft.src.World world, int i, int
             j, int k, net.minecraft.src.Entity entity, net.minecraft.src.Vec3D vec3d)
        {
        }

        public virtual void SetBlockBoundsBasedOnState(net.minecraft.src.IBlockAccess iblockaccess
            , int i, int j, int k)
        {
        }

        public virtual bool IsPoweringTo(net.minecraft.src.IBlockAccess iblockaccess, int
             i, int j, int k, int l)
        {
            return false;
        }

        public virtual bool CanProvidePower()
        {
            return false;
        }

        public virtual void OnEntityCollidedWithBlock(net.minecraft.src.World world, int
            i, int j, int k, net.minecraft.src.Entity entity)
        {
        }

        public virtual bool IsIndirectlyPoweringTo(net.minecraft.src.World world, int i,
            int j, int k, int l)
        {
            return false;
        }

        public virtual void HarvestBlock(net.minecraft.src.World world, net.minecraft.src.EntityPlayer
             entityplayer, int i, int j, int k, int l)
        {
            entityplayer.AddStat(net.minecraft.src.StatList.StatMinedBlocks[blockID], 1);
            DropBlockAsItem(world, i, j, k, l);
        }

        public virtual bool CanBlockStay(net.minecraft.src.World world, int i, int j, int
             k)
        {
            return true;
        }

        public virtual void OnBlockPlacedBy(net.minecraft.src.World world, int i, int j,
            int k, net.minecraft.src.EntityLiving entityliving)
        {
        }

        public virtual net.minecraft.src.Block SetBlockName(string s)
        {
            blockName = (new java.lang.StringBuilder()).Append("tile.").Append(s).ToString();
            return this;
        }

        public virtual string GetNameLocalizedForStats()
        {
            return net.minecraft.src.StatCollector.TranslateToLocal((new java.lang.StringBuilder
                ()).Append(GetBlockName()).Append(".name").ToString());
        }

        public virtual string GetBlockName()
        {
            return blockName;
        }

        public virtual void PlayBlock(net.minecraft.src.World world, int i, int j, int k,
            int l, int i1)
        {
        }

        public virtual bool GetEnableStats()
        {
            return enableStats;
        }

        protected internal virtual net.minecraft.src.Block DisableStats()
        {
            enableStats = false;
            return this;
        }

        public virtual int GetMobilityFlag()
        {
            return blockMaterial.GetMaterialMobility();
        }

        //internal static Type _mthclass(string s)
        //{
        //    try
        //    {
        //        return System.Type.ForName(s);
        //    }
        //    catch (System.TypeNotFoundException classnotfoundexception)
        //    {
        //        throw new java.lang.NoClassDefFoundError(classnotfoundexception.Message);
        //    }
        //}
    }
}
