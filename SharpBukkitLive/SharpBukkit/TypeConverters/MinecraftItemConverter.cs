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
            ItemDict["cobble"] = Block.COBBLESTONE.blockID;
            ItemDict["planks"] = Block.WOOD.blockID;
            ItemDict["woodplanks"] = Block.WOOD.blockID;
            ItemDict["waterflowing"] = Block.WATER.blockID;
            ItemDict["waterstationary"] = Block.STATIONARY_WATER.blockID;
            ItemDict["lavaflowing"] = Block.LAVA.blockID;
            ItemDict["lavastationary"] = Block.STATIONARY_LAVA.blockID;
            ItemDict["woodlog"] = Block.LOG.blockID;
            ItemDict["lapislazuliore"] = Block.LAPIS_ORE.blockID;
            ItemDict["lapislazuliblock"] = Block.LAPIS_BLOCK.blockID;
            ItemDict["musicblock"] = Block.NOTE_BLOCK.blockID;
            ItemDict["poweredrail"] = Block.GOLDEN_RAIL.blockID;
            ItemDict["stickypiston"] = Block.PISTON_STICKY.blockID;
            ItemDict["cobwebs"] = Block.WEB.blockID;
            ItemDict["cobweb"] = Block.WEB.blockID;
            ItemDict["tallgrass"] = Block.LONG_GRASS.blockID;
            ItemDict["cloth"] = Block.WOOL.blockID;
            ItemDict["daisy"] = Block.YELLOW_FLOWER.blockID;
            ItemDict["yellowplant"] = Block.YELLOW_FLOWER.blockID;
            ItemDict["rose"] = Block.RED_ROSE.blockID;
            ItemDict["redplant"] = Block.RED_ROSE.blockID;
            ItemDict["redflower"] = Block.RED_ROSE.blockID;
            ItemDict["stackedslab"] = Block.DOUBLE_STEP.blockID;
            ItemDict["doubleslab"] = Block.DOUBLE_STEP.blockID;
            ItemDict["slab"] = Block.STEP.blockID;
            ItemDict["bricks"] = Block.BRICK.blockID;
            ItemDict["explosive"] = Block.TNT.blockID;
            ItemDict["bookcase"] = Block.BOOKSHELF.blockID;
            ItemDict["mossy"] = Block.MOSSY_COBBLESTONE.blockID;
            ItemDict["mossycobble"] = Block.MOSSY_COBBLESTONE.blockID;
            ItemDict["spawner"] = Block.MOB_SPAWNER.blockID;
            ItemDict["woodstair"] = Block.WOOD_STAIRS.blockID;
            ItemDict["plankstairs"] = Block.WOOD_STAIRS.blockID;
            ItemDict["plankstair"] = Block.WOOD_STAIRS.blockID;
            ItemDict["craftingtable"] = Block.WORKBENCH.blockID;
            ItemDict["oven"] = Block.FURNACE.blockID;
            ItemDict["rail"] = Block.RAILS.blockID;
            ItemDict["track"] = Block.RAILS.blockID;
            ItemDict["tracks"] = Block.RAILS.blockID;
            ItemDict["stonestairs"] = Block.COBBLESTONE_STAIRS.blockID;
            ItemDict["cobblestairs"] = Block.COBBLESTONE_STAIRS.blockID;
            ItemDict["stonestair"] = Block.COBBLESTONE_STAIRS.blockID;
            ItemDict["cobblestair"] = Block.COBBLESTONE_STAIRS.blockID;
            ItemDict["cobblestonestair"] = Block.COBBLESTONE_STAIRS.blockID;
            ItemDict["stonepressureplate"] = Block.STONE_PLATE.blockID;
            ItemDict["woodpressureplate"] = Block.WOOD_PLATE.blockID;
            ItemDict["pressureplate"] = Block.WOOD_PLATE.blockID;
            ItemDict["plate"] = Block.WOOD_PLATE.blockID;
            ItemDict["activeredstoneore"] = Block.REDSTONE_ORE.blockID;
            ItemDict["redstonetorch"] = Block.REDSTONE_TORCH_ON.blockID;
            ItemDict["button"] = Block.STONE_BUTTON.blockID;
            ItemDict["iceblock"] = Block.ICE.blockID;
            ItemDict["snowblock"] = Block.SNOW_BLOCK.blockID;
            ItemDict["cactus"] = Block.CACTUS.blockID;
            ItemDict["clayblock"] = Block.CLAY.blockID;
            ItemDict["recordplayer"] = Block.JUKEBOX.blockID;
            ItemDict["glowstoneblock"] = Block.GLOWSTONE.blockID;
            ItemDict["lantern"] = Block.JACK_O_LANTERN.blockID;

            /* Block refl */
            IEnumerable<FieldInfo> info =
                typeof(Block).GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.IsInitOnly && p.FieldType.IsAssignableTo(typeof(Block)))
                ;

            foreach (FieldInfo fi in info)
            {
                ItemDict[fi.Name.ToLower()] = ((Block)fi.GetValue(null)).blockID;

                if(fi.Name.Contains("_"))
                    ItemDict[fi.Name.Replace("_", "").ToLower()] = ((Block)fi.GetValue(null)).blockID;
            }
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
