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
            ID = 256 + i;
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
        public static Item[] itemsList = new Item[32000];
        public static Item IRON_SPADE = (new ItemSpade(0, EnumToolMaterial.IRON)).SetIconCoord(2, 5).SetItemName("shovelIron");
        public static Item IRON_PICKAXE = (new ItemPickaxe(1, EnumToolMaterial.IRON)).SetIconCoord(2, 6).SetItemName("pickaxeIron");
        public static Item IRON_AXE = (new ItemAxe(2, EnumToolMaterial.IRON)).SetIconCoord(2, 7).SetItemName("hatchetIron");
        public static Item FLINT_AND_STEEL = (new ItemFlintAndSteel(3)).SetIconCoord(5, 0).SetItemName("flintAndSteel");
        public static Item APPLE = (new ItemFood(4, 4, false)).SetIconCoord(10, 0).SetItemName("apple");
        public static Item BOW = (new ItemBow(5)).SetIconCoord(5, 1).SetItemName("bow");
        public static Item ARROW = (new Item(6)).SetIconCoord(5, 2).SetItemName("arrow");
        public static Item COAL = (new ItemCoal(7)).SetIconCoord(7, 0).SetItemName("coal");
        public static Item DIAMOND = (new Item(8)).SetIconCoord(7, 3).SetItemName("emerald");
        public static Item IRON_INGOT = (new Item(9)).SetIconCoord(7, 1).SetItemName("ingotIron");
        public static Item GOLD_INGOT = (new Item(10)).SetIconCoord(7, 2).SetItemName("ingotGold");
        public static Item IRON_SWORD = (new ItemSword(11, EnumToolMaterial.IRON)).SetIconCoord(2, 4).SetItemName("swordIron");
        public static Item WOOD_SWORD = (new ItemSword(12, EnumToolMaterial.WOOD)).SetIconCoord(0, 4).SetItemName("swordWood");
        public static Item WOOD_SPADE = (new ItemSpade(13, EnumToolMaterial.WOOD)).SetIconCoord(0, 5).SetItemName("shovelWood");
        public static Item WOOD_PICKAXE = (new ItemPickaxe(14, EnumToolMaterial.WOOD)).SetIconCoord(0, 6).SetItemName("pickaxeWood");
        public static Item WOOD_AXE = (new ItemAxe(15, EnumToolMaterial.WOOD)).SetIconCoord(0, 7).SetItemName("hatchetWood");
        public static Item STONE_SWORD = (new ItemSword(16, EnumToolMaterial.STONE)).SetIconCoord(1, 4).SetItemName("swordStone");
        public static Item STONE_SPADE = (new ItemSpade(17, EnumToolMaterial.STONE)).SetIconCoord(1, 5).SetItemName("shovelStone");
        public static Item STONE_PICKAXE = (new ItemPickaxe(18, EnumToolMaterial.STONE)).SetIconCoord(1, 6).SetItemName("pickaxeStone");
        public static Item STONE_AXE = (new ItemAxe(19, EnumToolMaterial.STONE)).SetIconCoord(1, 7).SetItemName("hatchetStone");
        public static Item DIAMOND_SWORD = (new ItemSword(20, EnumToolMaterial.EMERALD)).SetIconCoord(3, 4).SetItemName("swordDiamond");
        public static Item DIAMOND_SPADE = (new ItemSpade(21, EnumToolMaterial.EMERALD)).SetIconCoord(3, 5).SetItemName("shovelDiamond");
        public static Item DIAMOND_PICKAXE = (new ItemPickaxe(22, EnumToolMaterial.EMERALD)).SetIconCoord(3, 6).SetItemName("pickaxeDiamond");
        public static Item DIAMOND_AXE = (new ItemAxe(23, EnumToolMaterial.EMERALD)).SetIconCoord(3, 7).SetItemName("hatchetDiamond");
        public static Item STICK = (new Item(24)).SetIconCoord(5, 3).SetFull3D().SetItemName("stick");
        public static Item BOWL = (new Item(25)).SetIconCoord(7, 4).SetItemName("bowl");
        public static Item MUSHROOM_SOUP = (new ItemSoup(26, 10)).SetIconCoord(8, 4).SetItemName("mushroomStew");
        public static Item GOLD_SWORD = (new ItemSword(27, EnumToolMaterial.GOLD)).SetIconCoord(4, 4).SetItemName("swordGold");
        public static Item GOLD_SHOVEL = (new ItemSpade(28, EnumToolMaterial.GOLD)).SetIconCoord(4, 5).SetItemName("shovelGold");
        public static Item GOLD_PICKAXE = (new ItemPickaxe(29, EnumToolMaterial.GOLD)).SetIconCoord(4, 6).SetItemName("pickaxeGold");
        public static Item GOLD_AXE = (new ItemAxe(30, EnumToolMaterial.GOLD)).SetIconCoord(4, 7).SetItemName("hatchetGold");
        public static Item STRING = (new Item(31)).SetIconCoord(8, 0).SetItemName("string");
        public static Item FEATHER = (new Item(32)).SetIconCoord(8, 1).SetItemName("feather");
        public static Item SULPHUR = (new Item(33)).SetIconCoord(8, 2).SetItemName("sulphur");
        public static Item WOOD_HOE = (new ItemHoe(34, EnumToolMaterial.WOOD)).SetIconCoord(0, 8).SetItemName("hoeWood");
        public static Item STONE_HOE = (new ItemHoe(35, EnumToolMaterial.STONE)).SetIconCoord(1, 8).SetItemName("hoeStone");
        public static Item IRON_HOE = (new ItemHoe(36, EnumToolMaterial.IRON)).SetIconCoord(2, 8).SetItemName("hoeIron");
        public static Item DIAMOND_HOE = (new ItemHoe(37, EnumToolMaterial.EMERALD)).SetIconCoord(3, 8).SetItemName("hoeDiamond");
        public static Item GOLD_HOE = (new ItemHoe(38, EnumToolMaterial.GOLD)).SetIconCoord(4, 8).SetItemName("hoeGold");
        public static Item SEEDS = (new ItemSeeds(39, Block.CROPS.ID)).SetIconCoord(9, 0).SetItemName("seeds");
        public static Item WHEAT = (new Item(40)).SetIconCoord(9, 1).SetItemName("wheat");
        public static Item BREAD = (new ItemFood(41, 5, false)).SetIconCoord(9, 2).SetItemName("bread");
        public static Item LEATHER_HELMET = (new ItemArmor(42, 0, 0, 0)).SetIconCoord(0, 0).SetItemName("helmetCloth");
        public static Item LEATHER_CHESTPLATE = (new ItemArmor(43, 0, 0, 1)).SetIconCoord(0, 1).SetItemName("chestplateCloth");
        public static Item LEATHER_LEGGINGS = (new ItemArmor(44, 0, 0, 2)).SetIconCoord(0, 2).SetItemName("leggingsCloth");
        public static Item LEATHER_BOOTS = (new ItemArmor(45, 0, 0, 3)).SetIconCoord(0, 3).SetItemName("bootsCloth");
        public static Item CHAINMAIL_HELMET = (new ItemArmor(46, 1, 1, 0)).SetIconCoord(1, 0).SetItemName("helmetChain");
        public static Item CHAINMAIL_CHESTPLATE = (new ItemArmor(47, 1, 1, 1)).SetIconCoord(1, 1).SetItemName("chestplateChain");
        public static Item CHAINMAIL_LEGGINGS = (new ItemArmor(48, 1, 1, 2)).SetIconCoord(1, 2).SetItemName("leggingsChain");
        public static Item CHAINMAIL_BOOTS = (new ItemArmor(49, 1, 1, 3)).SetIconCoord(1, 3).SetItemName("bootsChain");
        public static Item IRON_HELMET = (new ItemArmor(50, 2, 2, 0)).SetIconCoord(2, 0).SetItemName("helmetIron");
        public static Item IRON_CHESTPLATE = (new ItemArmor(51, 2, 2, 1)).SetIconCoord(2, 1).SetItemName("chestplateIron");
        public static Item IRON_LEGGINGS = (new ItemArmor(52, 2, 2, 2)).SetIconCoord(2, 2).SetItemName("leggingsIron");
        public static Item IRON_BOOTS = (new ItemArmor(53, 2, 2, 3)).SetIconCoord(2, 3).SetItemName("bootsIron");
        public static Item DIAMOND_HELMET = (new ItemArmor(54, 3, 3, 0)).SetIconCoord(3, 0).SetItemName("helmetDiamond");
        public static Item DIAMOND_CHESTPLATE = (new ItemArmor(55, 3, 3, 1)).SetIconCoord(3, 1).SetItemName("chestplateDiamond");
        public static Item DIAMOND_LEGGINGS = (new ItemArmor(56, 3, 3, 2)).SetIconCoord(3, 2).SetItemName("leggingsDiamond");
        public static Item DIAMOND_BOOTS = (new ItemArmor(57, 3, 3, 3)).SetIconCoord(3, 3).SetItemName("bootsDiamond");
        public static Item GOLD_HELMET = (new ItemArmor(58, 1, 4, 0)).SetIconCoord(4, 0).SetItemName("helmetGold");
        public static Item GOLD_CHESTPLATE = (new ItemArmor(59, 1, 4, 1)).SetIconCoord(4, 1).SetItemName("chestplateGold");
        public static Item GOLD_LEGGINGS = (new ItemArmor(60, 1, 4, 2)).SetIconCoord(4, 2).SetItemName("leggingsGold");
        public static Item GOLD_BOOTS = (new ItemArmor(61, 1, 4, 3)).SetIconCoord(4, 3).SetItemName("bootsGold");
        public static Item FLINT = (new Item(62)).SetIconCoord(6, 0).SetItemName("flint");
        public static Item PORK = (new ItemFood(63, 3, true)).SetIconCoord(7, 5).SetItemName("porkchopRaw");
        public static Item GRILLED_PORK = (new ItemFood(64, 8, true)).SetIconCoord(8, 5).SetItemName("porkchopCooked");
        public static Item PAINTING = (new ItemPainting(65)).SetIconCoord(10, 1).SetItemName("painting");
        public static Item GOLDEN_APPLE = (new ItemFood(66, 42, false)).SetIconCoord(11, 0).SetItemName("appleGold");
        public static Item SIGN = (new ItemSign(67)).SetIconCoord(10, 2).SetItemName("sign");
        public static Item WOOD_DOOR = (new ItemDoor(68, Material.wood)).SetIconCoord(11, 2).SetItemName("doorWood");
        public static Item BUCKET = (new ItemBucket(69, 0)).SetIconCoord(10, 4).SetItemName("bucket");
        public static Item WATER_BUCKET = (new ItemBucket(70, Block.WATER.ID)).SetIconCoord(11, 4).SetItemName("bucketWater").SetContainerItem(BUCKET);
        public static Item LAVA_BUCKET = (new ItemBucket(71, Block.LAVA.ID)).SetIconCoord(12, 4).SetItemName("bucketLava").SetContainerItem(BUCKET);
        public static Item MINECART = (new ItemMinecart(72, 0)).SetIconCoord(7, 8).SetItemName("minecart");
        public static Item SADDLE = (new ItemSaddle(73)).SetIconCoord(8, 6).SetItemName("saddle");
        public static Item IRON_DOOR = (new ItemDoor(74, Material.iron)).SetIconCoord(12, 2).SetItemName("doorIron");
        public static Item REDSTONE = (new ItemRedstone(75)).SetIconCoord(8, 3).SetItemName("redstone");
        public static Item SNOW_BALL = (new ItemSnowball(76)).SetIconCoord(14, 0).SetItemName("snowball");
        public static Item BOAT = (new ItemBoat(77)).SetIconCoord(8, 8).SetItemName("boat");
        public static Item LEATHER = (new Item(78)).SetIconCoord(7, 6).SetItemName("leather");
        public static Item MILK_BUCKET = (new ItemBucket(79, -1)).SetIconCoord(13, 4).SetItemName("milk").SetContainerItem(BUCKET);
        public static Item CLAY_BRICK = (new Item(80)).SetIconCoord(6, 1).SetItemName("brick");
        public static Item CLAY_BALL = (new Item(81)).SetIconCoord(9, 3).SetItemName("clay");
        public static Item SUGAR_CANE = (new ItemReed(82, Block.SUGAR_CANE_BLOCK)).SetIconCoord(11, 1).SetItemName("reeds");
        public static Item PAPER = (new Item(83)).SetIconCoord(10, 3).SetItemName("paper");
        public static Item BOOK = (new Item(84)).SetIconCoord(11, 3).SetItemName("book");
        public static Item SLIME_BALL = (new Item(85)).SetIconCoord(14, 1).SetItemName("slimeball");
        public static Item STORAGE_MINECART = (new ItemMinecart(86, 1)).SetIconCoord(7, 9).SetItemName("minecartChest");
        public static Item POWERED_MINECART = (new ItemMinecart(87, 2)).SetIconCoord(7, 10).SetItemName("minecartFurnace");
        public static Item EGG = (new ItemEgg(88)).SetIconCoord(12, 0).SetItemName("egg");
        public static Item COMPASS = (new Item(89)).SetIconCoord(6, 3).SetItemName("compass");
        public static Item FISHING_ROD = (new ItemFishingRod(90)).SetIconCoord(5, 4).SetItemName("fishingRod");
        public static Item WATCH = (new Item(91)).SetIconCoord(6, 4).SetItemName("clock");
        public static Item GLOWSTONE_DUST = (new Item(92)).SetIconCoord(9, 4).SetItemName("yellowDust");
        public static Item RAW_FISH = (new ItemFood(93, 2, false)).SetIconCoord(9, 5).SetItemName("fishRaw");
        public static Item COOKED_FISH = (new ItemFood(94, 5, false)).SetIconCoord(10, 5).SetItemName("fishCooked");
        public static Item INK_SACK = (new ItemDye(95)).SetIconCoord(14, 4).SetItemName("dyePowder");
        public static Item BONE = (new Item(96)).SetIconCoord(12, 1).SetItemName("bone").SetFull3D();
        public static Item SUGAR = (new Item(97)).SetIconCoord(13, 0).SetItemName("sugar").SetFull3D();
        public static Item CAKE = (new ItemReed(98, Block.CAKE_BLOCK)).SetMaxStackSize(1).SetIconCoord(13, 1).SetItemName("cake");
        public static Item BED = (new ItemBed(99)).SetMaxStackSize(1).SetIconCoord(13, 2).SetItemName("bed");
        public static Item DIODE = (new ItemReed(100, Block.DIODE_OFF)).SetIconCoord(6, 5).SetItemName("diode");
        public static Item COOKIE = (new ItemCookie(101, 1, false, 8)).SetIconCoord(12, 5).SetItemName("cookie");
        public static ItemMap MAP = (ItemMap)(new ItemMap(102)).SetIconCoord(12, 3).SetItemName("map");
        public static ItemShears SHEARS = (ItemShears)(new ItemShears(103)).SetIconCoord(13, 5).SetItemName("shears");
        public static Item GOLD_RECORD = (new ItemRecord(2000, "13")).SetIconCoord(0, 15).SetItemName("record");
        public static Item GREEN_RECORD = (new ItemRecord(2001, "cat")).SetIconCoord(1, 15).SetItemName("record");

        public readonly int ID;

        protected internal int maxStackSize;

        private int maxDamage;

        protected internal int iconIndex;

        protected internal bool bFull3D;

        protected internal bool hasSubtypes;

        private Item containerItem;

        private string itemName;

        static Item()
        {
            net.minecraft.src.StatList.Func_25086_b();
        }
    }
}
