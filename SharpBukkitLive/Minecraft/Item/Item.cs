// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    public class Item
    {
        protected internal Item(int i)
        {
            // Referenced classes of package net.minecraft.src:
            //            StatCollector, ItemSpade, EnumToolMaterial, ItemPickaxe, 
            //            ItemAxe, ItemFlintAndSteel, ItemFood, ItemBow, 
            //            ItemCoal, ItemSword, ItemSoup, ItemHoe, 
            //            ItemSeeds, Block, ItemArmor, ItemPainting, 
            //            ItemSign, ItemDoor, Material, ItemBucket, 
            //            ItemMinecart, ItemSaddle, ItemRedstone, ItemSnowball, 
            //            ItemBoat, ItemReed, ItemEgg, ItemFishingRod, 
            //            ItemDye, ItemBed, ItemCookie, ItemMap, 
            //            ItemShears, ItemRecord, StatList, ItemStack, 
            //            EntityPlayer, World, EntityLiving, Entity
            maxStackSize = 64;
            maxDamage = 0;
            bFull3D = false;
            hasSubtypes = false;
            containerItem = null;
            shiftedIndex = 256 + i;
            if (itemsList[256 + i] != null)
            {
                System.Console.Out.WriteLine((new java.lang.StringBuilder()).Append("CONFLICT @ "
                    ).Append(i).ToString());
            }
            itemsList[256 + i] = this;
        }

        public virtual net.minecraft.src.Item SetIconIndex(int i)
        {
            iconIndex = i;
            return this;
        }

        public virtual net.minecraft.src.Item SetMaxStackSize(int i)
        {
            maxStackSize = i;
            return this;
        }

        public virtual net.minecraft.src.Item SetIconCoord(int i, int j)
        {
            iconIndex = i + j * 16;
            return this;
        }

        public virtual bool OnItemUse(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityPlayer
             entityplayer, net.minecraft.src.World world, int i, int j, int k, int l)
        {
            return false;
        }

        public virtual float GetStrVsBlock(net.minecraft.src.ItemStack itemstack, net.minecraft.src.Block
             block)
        {
            return 1.0F;
        }

        public virtual net.minecraft.src.ItemStack OnItemRightClick(net.minecraft.src.ItemStack
             itemstack, net.minecraft.src.World world, net.minecraft.src.EntityPlayer entityplayer
            )
        {
            return itemstack;
        }

        public virtual int GetItemStackLimit()
        {
            return maxStackSize;
        }

        public virtual int GetMetadata(int i)
        {
            return 0;
        }

        public virtual bool GetHasSubtypes()
        {
            return hasSubtypes;
        }

        protected internal virtual net.minecraft.src.Item SetHasSubtypes(bool flag)
        {
            hasSubtypes = flag;
            return this;
        }

        public virtual int GetMaxDamage()
        {
            return maxDamage;
        }

        protected internal virtual net.minecraft.src.Item SetMaxDamage(int i)
        {
            maxDamage = i;
            return this;
        }

        public virtual bool Func_25005_e()
        {
            return maxDamage > 0 && !hasSubtypes;
        }

        public virtual bool HitEntity(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityLiving
             entityliving, net.minecraft.src.EntityLiving entityliving1)
        {
            return false;
        }

        public virtual bool Func_25007_a(net.minecraft.src.ItemStack itemstack, int i, int
             j, int k, int l, net.minecraft.src.EntityLiving entityliving)
        {
            return false;
        }

        public virtual int GetDamageVsEntity(net.minecraft.src.Entity entity)
        {
            return 1;
        }

        public virtual bool CanHarvestBlock(net.minecraft.src.Block block)
        {
            return false;
        }

        public virtual void SaddleEntity(net.minecraft.src.ItemStack itemstack, net.minecraft.src.EntityLiving
             entityliving)
        {
        }

        public virtual net.minecraft.src.Item SetFull3D()
        {
            bFull3D = true;
            return this;
        }

        public virtual net.minecraft.src.Item SetItemName(string s)
        {
            itemName = (new java.lang.StringBuilder()).Append("item.").Append(s).ToString();
            return this;
        }

        public virtual string GetItemName()
        {
            return itemName;
        }

        public virtual net.minecraft.src.Item SetContainerItem(net.minecraft.src.Item item
            )
        {
            if (maxStackSize > 1)
            {
                throw new System.ArgumentException("Max stack size must be 1 for items with crafting results"
                    );
            }
            else
            {
                containerItem = item;
                return this;
            }
        }

        public virtual net.minecraft.src.Item GetContainerItem()
        {
            return containerItem;
        }

        public virtual bool HasContainerItem()
        {
            return containerItem != null;
        }

        public virtual string Func_25006_i()
        {
            return net.minecraft.src.StatCollector.TranslateToLocal((new java.lang.StringBuilder
                ()).Append(GetItemName()).Append(".name").ToString());
        }

        public virtual void Func_28018_a(net.minecraft.src.ItemStack itemstack, net.minecraft.src.World
             world, net.minecraft.src.Entity entity, int i, bool flag)
        {
        }

        public virtual void Func_28020_c(net.minecraft.src.ItemStack itemstack, net.minecraft.src.World
             world, net.minecraft.src.EntityPlayer entityplayer)
        {
        }

        public virtual bool Func_28019_b()
        {
            return false;
        }

        internal static SharpBukkitLive.SharpBukkit.SharpRandom itemRand = new SharpBukkitLive.SharpBukkit.SharpRandom();

        public static net.minecraft.src.Item[] itemsList = new net.minecraft.src.Item[32000];

        public static net.minecraft.src.Item shovelSteel;

        public static net.minecraft.src.Item pickaxeSteel;

        public static net.minecraft.src.Item axeSteel;

        public static net.minecraft.src.Item flintAndSteel = (new net.minecraft.src.ItemFlintAndSteel(3)).SetIconCoord(5, 0).SetItemName("flintAndSteel");

        public static net.minecraft.src.Item appleRed = (new net.minecraft.src.ItemFood(4, 4, false)).SetIconCoord(10, 0).SetItemName("apple");

        public static net.minecraft.src.Item bow = (new net.minecraft.src.ItemBow(5)).SetIconCoord(5, 1).SetItemName("bow");

        public static net.minecraft.src.Item arrow = (new net.minecraft.src.Item(6)).SetIconCoord(5, 2).SetItemName("arrow");

        public static net.minecraft.src.Item coal = (new net.minecraft.src.ItemCoal(7)).SetIconCoord(7, 0).SetItemName("coal");

        public static net.minecraft.src.Item diamond = (new net.minecraft.src.Item(8)).SetIconCoord(7, 3).SetItemName("emerald");

        public static net.minecraft.src.Item ingotIron = (new net.minecraft.src.Item(9)).SetIconCoord(7, 1).SetItemName("ingotIron");

        public static net.minecraft.src.Item ingotGold = (new net.minecraft.src.Item(10)).SetIconCoord(7, 2).SetItemName("ingotGold");

        public static net.minecraft.src.Item swordSteel;

        public static net.minecraft.src.Item swordWood;

        public static net.minecraft.src.Item shovelWood;

        public static net.minecraft.src.Item pickaxeWood;

        public static net.minecraft.src.Item axeWood;

        public static net.minecraft.src.Item swordStone;

        public static net.minecraft.src.Item shovelStone;

        public static net.minecraft.src.Item pickaxeStone;

        public static net.minecraft.src.Item axeStone;

        public static net.minecraft.src.Item swordDiamond;

        public static net.minecraft.src.Item shovelDiamond;

        public static net.minecraft.src.Item pickaxeDiamond;

        public static net.minecraft.src.Item axeDiamond;

        public static net.minecraft.src.Item stick = (new net.minecraft.src.Item(24)).SetIconCoord(5, 3).SetFull3D().SetItemName("stick");

        public static net.minecraft.src.Item bowlEmpty = (new net.minecraft.src.Item(25)).SetIconCoord(7, 4).SetItemName("bowl");

        public static net.minecraft.src.Item bowlSoup = (new net.minecraft.src.ItemSoup(26, 10)).SetIconCoord(8, 4).SetItemName("mushroomStew");

        public static net.minecraft.src.Item swordGold;

        public static net.minecraft.src.Item shovelGold;

        public static net.minecraft.src.Item pickaxeGold;

        public static net.minecraft.src.Item axeGold;

        public static net.minecraft.src.Item silk = (new net.minecraft.src.Item(31)).SetIconCoord(8, 0).SetItemName("string");

        public static net.minecraft.src.Item feather = (new net.minecraft.src.Item(32)).SetIconCoord(8, 1).SetItemName("feather");

        public static net.minecraft.src.Item gunpowder = (new net.minecraft.src.Item(33)).SetIconCoord(8, 2).SetItemName("sulphur");

        public static net.minecraft.src.Item hoeWood;

        public static net.minecraft.src.Item hoeStone;

        public static net.minecraft.src.Item hoeSteel;

        public static net.minecraft.src.Item hoeDiamond;

        public static net.minecraft.src.Item hoeGold;

        public static net.minecraft.src.Item seeds;

        public static net.minecraft.src.Item wheat = (new net.minecraft.src.Item(40)).SetIconCoord(9, 1).SetItemName("wheat");

        public static net.minecraft.src.Item bread = (new net.minecraft.src.ItemFood(41, 5, false)).SetIconCoord(9, 2).SetItemName("bread");

        public static net.minecraft.src.Item helmetLeather = (new net.minecraft.src.ItemArmor(42, 0, 0, 0)).SetIconCoord(0, 0).SetItemName("helmetCloth");

        public static net.minecraft.src.Item plateLeather = (new net.minecraft.src.ItemArmor(43, 0, 0, 1)).SetIconCoord(0, 1).SetItemName("chestplateCloth");

        public static net.minecraft.src.Item legsLeather = (new net.minecraft.src.ItemArmor(44, 0, 0, 2)).SetIconCoord(0, 2).SetItemName("leggingsCloth");

        public static net.minecraft.src.Item bootsLeather = (new net.minecraft.src.ItemArmor(45, 0, 0, 3)).SetIconCoord(0, 3).SetItemName("bootsCloth");

        public static net.minecraft.src.Item helmetChain = (new net.minecraft.src.ItemArmor(46, 1, 1, 0)).SetIconCoord(1, 0).SetItemName("helmetChain");

        public static net.minecraft.src.Item plateChain = (new net.minecraft.src.ItemArmor(47, 1, 1, 1)).SetIconCoord(1, 1).SetItemName("chestplateChain");

        public static net.minecraft.src.Item legsChain = (new net.minecraft.src.ItemArmor(48, 1, 1, 2)).SetIconCoord(1, 2).SetItemName("leggingsChain");

        public static net.minecraft.src.Item bootsChain = (new net.minecraft.src.ItemArmor(49, 1, 1, 3)).SetIconCoord(1, 3).SetItemName("bootsChain");

        public static net.minecraft.src.Item helmetSteel = (new net.minecraft.src.ItemArmor(50, 2, 2, 0)).SetIconCoord(2, 0).SetItemName("helmetIron");

        public static net.minecraft.src.Item plateSteel = (new net.minecraft.src.ItemArmor(51, 2, 2, 1)).SetIconCoord(2, 1).SetItemName("chestplateIron");

        public static net.minecraft.src.Item legsSteel = (new net.minecraft.src.ItemArmor(52, 2, 2, 2)).SetIconCoord(2, 2).SetItemName("leggingsIron");

        public static net.minecraft.src.Item bootsSteel = (new net.minecraft.src.ItemArmor(53, 2, 2, 3)).SetIconCoord(2, 3).SetItemName("bootsIron");

        public static net.minecraft.src.Item helmetDiamond = (new net.minecraft.src.ItemArmor(54, 3, 3, 0)).SetIconCoord(3, 0).SetItemName("helmetDiamond");

        public static net.minecraft.src.Item plateDiamond = (new net.minecraft.src.ItemArmor(55, 3, 3, 1)).SetIconCoord(3, 1).SetItemName("chestplateDiamond");

        public static net.minecraft.src.Item legsDiamond = (new net.minecraft.src.ItemArmor(56, 3, 3, 2)).SetIconCoord(3, 2).SetItemName("leggingsDiamond");

        public static net.minecraft.src.Item bootsDiamond = (new net.minecraft.src.ItemArmor(57, 3, 3, 3)).SetIconCoord(3, 3).SetItemName("bootsDiamond");

        public static net.minecraft.src.Item helmetGold = (new net.minecraft.src.ItemArmor(58, 1, 4, 0)).SetIconCoord(4, 0).SetItemName("helmetGold");

        public static net.minecraft.src.Item plateGold = (new net.minecraft.src.ItemArmor(59, 1, 4, 1)).SetIconCoord(4, 1).SetItemName("chestplateGold");

        public static net.minecraft.src.Item legsGold = (new net.minecraft.src.ItemArmor(60, 1, 4, 2)).SetIconCoord(4, 2).SetItemName("leggingsGold");

        public static net.minecraft.src.Item bootsGold = (new net.minecraft.src.ItemArmor(61, 1, 4, 3)).SetIconCoord(4, 3).SetItemName("bootsGold");

        public static net.minecraft.src.Item flint = (new net.minecraft.src.Item(62)).SetIconCoord(6, 0).SetItemName("flint");

        public static net.minecraft.src.Item porkRaw = (new net.minecraft.src.ItemFood(63, 3, true)).SetIconCoord(7, 5).SetItemName("porkchopRaw");

        public static net.minecraft.src.Item porkCooked = (new net.minecraft.src.ItemFood(64, 8, true)).SetIconCoord(8, 5).SetItemName("porkchopCooked");

        public static net.minecraft.src.Item painting = (new net.minecraft.src.ItemPainting(65)).SetIconCoord(10, 1).SetItemName("painting");

        public static net.minecraft.src.Item appleGold = (new net.minecraft.src.ItemFood(66, 42, false)).SetIconCoord(11, 0).SetItemName("appleGold");

        public static net.minecraft.src.Item sign = (new net.minecraft.src.ItemSign(67)).SetIconCoord(10, 2).SetItemName("sign");

        public static net.minecraft.src.Item doorWood;

        public static net.minecraft.src.Item bucketEmpty;

        public static net.minecraft.src.Item bucketWater;

        public static net.minecraft.src.Item bucketLava;

        public static net.minecraft.src.Item minecartEmpty = (new net.minecraft.src.ItemMinecart(72, 0)).SetIconCoord(7, 8).SetItemName("minecart");

        public static net.minecraft.src.Item saddle = (new net.minecraft.src.ItemSaddle(73)).SetIconCoord(8, 6).SetItemName("saddle");

        public static net.minecraft.src.Item doorSteel;

        public static net.minecraft.src.Item redstone = (new net.minecraft.src.ItemRedstone(75)).SetIconCoord(8, 3).SetItemName("redstone");

        public static net.minecraft.src.Item snowball = (new net.minecraft.src.ItemSnowball(76)).SetIconCoord(14, 0).SetItemName("snowball");

        public static net.minecraft.src.Item boat = (new net.minecraft.src.ItemBoat(77)).SetIconCoord(8, 8).SetItemName("boat");

        public static net.minecraft.src.Item leather = (new net.minecraft.src.Item(78)).SetIconCoord(7, 6).SetItemName("leather");

        public static net.minecraft.src.Item bucketMilk;

        public static net.minecraft.src.Item brick = (new net.minecraft.src.Item(80)).SetIconCoord(6, 1).SetItemName("brick");

        public static net.minecraft.src.Item clay = (new net.minecraft.src.Item(81)).SetIconCoord(9, 3).SetItemName("clay");

        public static net.minecraft.src.Item reed;

        public static net.minecraft.src.Item paper = (new net.minecraft.src.Item(83)).SetIconCoord(10, 3).SetItemName("paper");

        public static net.minecraft.src.Item book = (new net.minecraft.src.Item(84)).SetIconCoord(11, 3).SetItemName("book");

        public static net.minecraft.src.Item slimeBall = (new net.minecraft.src.Item(85)).SetIconCoord(14, 1).SetItemName("slimeball");

        public static net.minecraft.src.Item minecartCrate = (new net.minecraft.src.ItemMinecart(86, 1)).SetIconCoord(7, 9).SetItemName("minecartChest");

        public static net.minecraft.src.Item minecartPowered = (new net.minecraft.src.ItemMinecart(87, 2)).SetIconCoord(7, 10).SetItemName("minecartFurnace");

        public static net.minecraft.src.Item egg = (new net.minecraft.src.ItemEgg(88)).SetIconCoord(12, 0).SetItemName("egg");

        public static net.minecraft.src.Item compass = (new net.minecraft.src.Item(89)).SetIconCoord(6, 3).SetItemName("compass");

        public static net.minecraft.src.Item fishingRod = (new net.minecraft.src.ItemFishingRod(90)).SetIconCoord(5, 4).SetItemName("fishingRod");

        public static net.minecraft.src.Item pocketSundial = (new net.minecraft.src.Item(91)).SetIconCoord(6, 4).SetItemName("clock");

        public static net.minecraft.src.Item lightStoneDust = (new net.minecraft.src.Item(92)).SetIconCoord(9, 4).SetItemName("yellowDust");

        public static net.minecraft.src.Item fishRaw = (new net.minecraft.src.ItemFood(93, 2, false)).SetIconCoord(9, 5).SetItemName("fishRaw");

        public static net.minecraft.src.Item fishCooked = (new net.minecraft.src.ItemFood(94, 5, false)).SetIconCoord(10, 5).SetItemName("fishCooked");

        public static net.minecraft.src.Item dyePowder = (new net.minecraft.src.ItemDye(95)).SetIconCoord(14, 4).SetItemName("dyePowder");

        public static net.minecraft.src.Item bone = (new net.minecraft.src.Item(96)).SetIconCoord(12, 1).SetItemName("bone").SetFull3D();

        public static net.minecraft.src.Item sugar = (new net.minecraft.src.Item(97)).SetIconCoord(13, 0).SetItemName("sugar").SetFull3D();

        public static net.minecraft.src.Item cake;

        public static net.minecraft.src.Item bed = (new net.minecraft.src.ItemBed(99)).SetMaxStackSize(1).SetIconCoord(13, 2).SetItemName("bed");

        public static net.minecraft.src.Item redstoneRepeater;

        public static net.minecraft.src.Item cookie = (new net.minecraft.src.ItemCookie(101, 1, false, 8)).SetIconCoord(12, 5).SetItemName("cookie");

        public static net.minecraft.src.ItemMap field_28021_bb = (net.minecraft.src.ItemMap)(new net.minecraft.src.ItemMap(102)).SetIconCoord(12, 3).SetItemName("map");

        public static net.minecraft.src.ItemShears field_31022_bc = (net.minecraft.src.ItemShears)(new net.minecraft.src.ItemShears(103)).SetIconCoord(13, 5).SetItemName("shears");

        public static net.minecraft.src.Item record13 = (new net.minecraft.src.ItemRecord(2000, "13")).SetIconCoord(0, 15).SetItemName("record");

        public static net.minecraft.src.Item recordCat = (new net.minecraft.src.ItemRecord(2001, "cat")).SetIconCoord(1, 15).SetItemName("record");

        public readonly int shiftedIndex;

        protected internal int maxStackSize;

        private int maxDamage;

        protected internal int iconIndex;

        protected internal bool bFull3D;

        protected internal bool hasSubtypes;

        private net.minecraft.src.Item containerItem;

        private string itemName;

        static Item()
        {
            shovelSteel = (new net.minecraft.src.ItemSpade(0, net.minecraft.src.EnumToolMaterial.IRON)).SetIconCoord(2, 5).SetItemName("shovelIron");
            pickaxeSteel = (new net.minecraft.src.ItemPickaxe(1, net.minecraft.src.EnumToolMaterial.IRON)).SetIconCoord(2, 6).SetItemName("pickaxeIron");
            axeSteel = (new net.minecraft.src.ItemAxe(2, net.minecraft.src.EnumToolMaterial.IRON)).SetIconCoord(2, 7).SetItemName("hatchetIron");
            swordSteel = (new net.minecraft.src.ItemSword(11, net.minecraft.src.EnumToolMaterial.IRON)).SetIconCoord(2, 4).SetItemName("swordIron");
            swordWood = (new net.minecraft.src.ItemSword(12, net.minecraft.src.EnumToolMaterial.WOOD)).SetIconCoord(0, 4).SetItemName("swordWood");
            shovelWood = (new net.minecraft.src.ItemSpade(13, net.minecraft.src.EnumToolMaterial.WOOD)).SetIconCoord(0, 5).SetItemName("shovelWood");
            pickaxeWood = (new net.minecraft.src.ItemPickaxe(14, net.minecraft.src.EnumToolMaterial.WOOD)).SetIconCoord(0, 6).SetItemName("pickaxeWood");
            axeWood = (new net.minecraft.src.ItemAxe(15, net.minecraft.src.EnumToolMaterial.WOOD)).SetIconCoord(0, 7).SetItemName("hatchetWood");
            swordStone = (new net.minecraft.src.ItemSword(16, net.minecraft.src.EnumToolMaterial.STONE)).SetIconCoord(1, 4).SetItemName("swordStone");
            shovelStone = (new net.minecraft.src.ItemSpade(17, net.minecraft.src.EnumToolMaterial.STONE)).SetIconCoord(1, 5).SetItemName("shovelStone");
            pickaxeStone = (new net.minecraft.src.ItemPickaxe(18, net.minecraft.src.EnumToolMaterial.STONE)).SetIconCoord(1, 6).SetItemName("pickaxeStone");
            axeStone = (new net.minecraft.src.ItemAxe(19, net.minecraft.src.EnumToolMaterial.STONE)).SetIconCoord(1, 7).SetItemName("hatchetStone");
            swordDiamond = (new net.minecraft.src.ItemSword(20, net.minecraft.src.EnumToolMaterial.EMERALD)).SetIconCoord(3, 4).SetItemName("swordDiamond");
            shovelDiamond = (new net.minecraft.src.ItemSpade(21, net.minecraft.src.EnumToolMaterial.EMERALD)).SetIconCoord(3, 5).SetItemName("shovelDiamond");
            pickaxeDiamond = (new net.minecraft.src.ItemPickaxe(22, net.minecraft.src.EnumToolMaterial.EMERALD)).SetIconCoord(3, 6).SetItemName("pickaxeDiamond");
            axeDiamond = (new net.minecraft.src.ItemAxe(23, net.minecraft.src.EnumToolMaterial.EMERALD)).SetIconCoord(3, 7).SetItemName("hatchetDiamond");
            swordGold = (new net.minecraft.src.ItemSword(27, net.minecraft.src.EnumToolMaterial.GOLD)).SetIconCoord(4, 4).SetItemName("swordGold");
            shovelGold = (new net.minecraft.src.ItemSpade(28, net.minecraft.src.EnumToolMaterial.GOLD)).SetIconCoord(4, 5).SetItemName("shovelGold");
            pickaxeGold = (new net.minecraft.src.ItemPickaxe(29, net.minecraft.src.EnumToolMaterial.GOLD)).SetIconCoord(4, 6).SetItemName("pickaxeGold");
            axeGold = (new net.minecraft.src.ItemAxe(30, net.minecraft.src.EnumToolMaterial.GOLD)).SetIconCoord(4, 7).SetItemName("hatchetGold");
            hoeWood = (new net.minecraft.src.ItemHoe(34, net.minecraft.src.EnumToolMaterial.WOOD)).SetIconCoord(0, 8).SetItemName("hoeWood");
            hoeStone = (new net.minecraft.src.ItemHoe(35, net.minecraft.src.EnumToolMaterial.STONE)).SetIconCoord(1, 8).SetItemName("hoeStone");
            hoeSteel = (new net.minecraft.src.ItemHoe(36, net.minecraft.src.EnumToolMaterial.IRON)).SetIconCoord(2, 8).SetItemName("hoeIron");
            hoeDiamond = (new net.minecraft.src.ItemHoe(37, net.minecraft.src.EnumToolMaterial.EMERALD)).SetIconCoord(3, 8).SetItemName("hoeDiamond");
            hoeGold = (new net.minecraft.src.ItemHoe(38, net.minecraft.src.EnumToolMaterial.GOLD)).SetIconCoord(4, 8).SetItemName("hoeGold");
            seeds = (new net.minecraft.src.ItemSeeds(39, net.minecraft.src.Block.CROPS.blockID)).SetIconCoord(9, 0).SetItemName("seeds");
            doorWood = (new net.minecraft.src.ItemDoor(68, net.minecraft.src.Material.wood)).SetIconCoord(11, 2).SetItemName("doorWood");
            bucketEmpty = (new net.minecraft.src.ItemBucket(69, 0)).SetIconCoord(10, 4).SetItemName("bucket");
            bucketWater = (new net.minecraft.src.ItemBucket(70, net.minecraft.src.Block.WATER.blockID)).SetIconCoord(11, 4).SetItemName("bucketWater").SetContainerItem(bucketEmpty);
            bucketLava = (new net.minecraft.src.ItemBucket(71, net.minecraft.src.Block.LAVA.blockID)).SetIconCoord(12, 4).SetItemName("bucketLava").SetContainerItem(bucketEmpty);
            doorSteel = (new net.minecraft.src.ItemDoor(74, net.minecraft.src.Material.iron)).SetIconCoord(12, 2).SetItemName("doorIron");
            bucketMilk = (new net.minecraft.src.ItemBucket(79, -1)).SetIconCoord(13, 4).SetItemName("milk").SetContainerItem(bucketEmpty);
            reed = (new net.minecraft.src.ItemReed(82, net.minecraft.src.Block.SUGAR_CANE_BLOCK)).SetIconCoord(11, 1).SetItemName("reeds");
            cake = (new net.minecraft.src.ItemReed(98, net.minecraft.src.Block.CAKE_BLOCK)).SetMaxStackSize(1).SetIconCoord(13, 1).SetItemName("cake");
            redstoneRepeater = (new net.minecraft.src.ItemReed(100, net.minecraft.src.Block.DIODE_OFF)).SetIconCoord(6, 5).SetItemName("diode");
            net.minecraft.src.StatList.Func_25086_b();
        }
    }
}
