using net.minecraft.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharpBukkitLive.SharpBukkit.TypeConverters
{
    public class MinecraftItemConverter : TypeConverter
    {
        public static Dictionary<string, int> ItemDict = new Dictionary<string, int>();
        static MinecraftItemConverter()
        {
            //TODO: Add item IDs
            ItemDict["cobble"] = Block.COBBLESTONE.ID;
            ItemDict["planks"] = Block.WOOD.ID;
            ItemDict["woodplanks"] = Block.WOOD.ID;
            ItemDict["waterflowing"] = Block.WATER.ID;
            ItemDict["waterstationary"] = Block.STATIONARY_WATER.ID;
            ItemDict["lavaflowing"] = Block.LAVA.ID;
            ItemDict["lavastationary"] = Block.STATIONARY_LAVA.ID;
            ItemDict["woodlog"] = Block.LOG.ID;
            ItemDict["lapislazuliore"] = Block.LAPIS_ORE.ID;
            ItemDict["lapislazuliblock"] = Block.LAPIS_BLOCK.ID;
            ItemDict["musicblock"] = Block.NOTE_BLOCK.ID;
            ItemDict["poweredrail"] = Block.GOLDEN_RAIL.ID;
            ItemDict["stickypiston"] = Block.PISTON_STICKY.ID;
            ItemDict["cobwebs"] = Block.WEB.ID;
            ItemDict["cobweb"] = Block.WEB.ID;
            ItemDict["tallgrass"] = Block.LONG_GRASS.ID;
            ItemDict["cloth"] = Block.WOOL.ID;
            ItemDict["daisy"] = Block.YELLOW_FLOWER.ID;
            ItemDict["yellowplant"] = Block.YELLOW_FLOWER.ID;
            ItemDict["rose"] = Block.RED_ROSE.ID;
            ItemDict["redplant"] = Block.RED_ROSE.ID;
            ItemDict["redflower"] = Block.RED_ROSE.ID;
            ItemDict["stackedslab"] = Block.DOUBLE_STEP.ID;
            ItemDict["doubleslab"] = Block.DOUBLE_STEP.ID;
            ItemDict["slab"] = Block.STEP.ID;
            ItemDict["bricks"] = Block.BRICK.ID;
            ItemDict["explosive"] = Block.TNT.ID;
            ItemDict["bookcase"] = Block.BOOKSHELF.ID;
            ItemDict["mossy"] = Block.MOSSY_COBBLESTONE.ID;
            ItemDict["mossycobble"] = Block.MOSSY_COBBLESTONE.ID;
            ItemDict["spawner"] = Block.MOB_SPAWNER.ID;
            ItemDict["woodstair"] = Block.WOOD_STAIRS.ID;
            ItemDict["plankstairs"] = Block.WOOD_STAIRS.ID;
            ItemDict["plankstair"] = Block.WOOD_STAIRS.ID;
            ItemDict["craftingtable"] = Block.WORKBENCH.ID;
            ItemDict["oven"] = Block.FURNACE.ID;
            ItemDict["rail"] = Block.RAILS.ID;
            ItemDict["track"] = Block.RAILS.ID;
            ItemDict["tracks"] = Block.RAILS.ID;
            ItemDict["stonestairs"] = Block.COBBLESTONE_STAIRS.ID;
            ItemDict["cobblestairs"] = Block.COBBLESTONE_STAIRS.ID;
            ItemDict["stonestair"] = Block.COBBLESTONE_STAIRS.ID;
            ItemDict["cobblestair"] = Block.COBBLESTONE_STAIRS.ID;
            ItemDict["cobblestonestair"] = Block.COBBLESTONE_STAIRS.ID;
            ItemDict["stonepressureplate"] = Block.STONE_PLATE.ID;
            ItemDict["woodpressureplate"] = Block.WOOD_PLATE.ID;
            ItemDict["pressureplate"] = Block.WOOD_PLATE.ID;
            ItemDict["plate"] = Block.WOOD_PLATE.ID;
            ItemDict["activeredstoneore"] = Block.REDSTONE_ORE.ID;
            ItemDict["redstonetorch"] = Block.REDSTONE_TORCH_ON.ID;
            ItemDict["button"] = Block.STONE_BUTTON.ID;
            ItemDict["iceblock"] = Block.ICE.ID;
            ItemDict["snowblock"] = Block.SNOW_BLOCK.ID;
            ItemDict["cactus"] = Block.CACTUS.ID;
            ItemDict["clayblock"] = Block.CLAY.ID;
            ItemDict["recordplayer"] = Block.JUKEBOX.ID;
            ItemDict["glowstoneblock"] = Block.GLOWSTONE.ID;
            ItemDict["lantern"] = Block.JACK_O_LANTERN.ID;

            /* Block refl */
            IEnumerable<FieldInfo> info =
                typeof(Block).GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.IsInitOnly && p.FieldType.IsAssignableTo(typeof(Block)));

            foreach (FieldInfo fi in info)
                AddFieldInfoBlock(fi);

            /* Item refl */
            info =
                typeof(Item).GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.FieldType.IsAssignableTo(typeof(Item)));

            foreach (FieldInfo fi in info)
                AddFieldInfoItem(fi);
        }

        static void AddFieldInfoBlock(FieldInfo fi)
        {
            ItemDict[fi.Name.ToLower()] = ((Block)fi.GetValue(null)).ID;

            if (fi.Name.Contains("_"))
                ItemDict[fi.Name.Replace("_", "").ToLower()] = ((Block)fi.GetValue(null)).ID;
        }

        static void AddFieldInfoItem(FieldInfo fi)
        {
            ItemDict[fi.Name.ToLower()] = ((Item)fi.GetValue(null)).ID;

            if (fi.Name.Contains("_"))
                ItemDict[fi.Name.Replace("_", "").ToLower()] = ((Item)fi.GetValue(null)).ID;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override bool IsValid(ITypeDescriptorContext context, object value)
        {
            if (!(value is string)) return false;

            return ItemDict.ContainsKey((string)value);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            //TODO: FIX
            return new ItemStack(ItemDict[(string)value], 1, 0);
        }
    }
}
