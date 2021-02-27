using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
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
            ItemDict["stone"] = net.minecraft.src.Block.stone.blockID;
            ItemDict["grass"] = net.minecraft.src.Block.grass.blockID;
            ItemDict["dirt"] = net.minecraft.src.Block.dirt.blockID;
            ItemDict["cobble"] = net.minecraft.src.Block.cobblestone.blockID;
            ItemDict["cobblestone"] = net.minecraft.src.Block.cobblestone.blockID;
            ItemDict["planks"] = net.minecraft.src.Block.planks.blockID;
            ItemDict["woodplanks"] = net.minecraft.src.Block.planks.blockID;
            ItemDict["sappling"] = net.minecraft.src.Block.sapling.blockID;
            ItemDict["bedrock"] = net.minecraft.src.Block.bedrock.blockID;
            ItemDict["waterflowing"] = net.minecraft.src.Block.waterMoving.blockID;
            ItemDict["waterstationary"] = net.minecraft.src.Block.waterStill.blockID;
            ItemDict["lavaflowing"] = net.minecraft.src.Block.lavaMoving.blockID;
            ItemDict["lavastationary"] = net.minecraft.src.Block.lavaStill.blockID;
            ItemDict["sand"] = net.minecraft.src.Block.sand.blockID;
            ItemDict["gravel"] = net.minecraft.src.Block.gravel.blockID;
            ItemDict["goldore"] = net.minecraft.src.Block.oreGold.blockID;
            ItemDict["ironore"] = net.minecraft.src.Block.oreIron.blockID;
            ItemDict["coalore"] = net.minecraft.src.Block.oreCoal.blockID;
            ItemDict["wood"] = net.minecraft.src.Block.wood.blockID;
            ItemDict["leaves"] = net.minecraft.src.Block.leaves.blockID;
            ItemDict["sponge"] = net.minecraft.src.Block.sponge.blockID;
            ItemDict["glass"] = net.minecraft.src.Block.glass.blockID;
            ItemDict["lapisore"] = net.minecraft.src.Block.oreLapis.blockID;
            ItemDict["lapislazuliore"] = net.minecraft.src.Block.oreLapis.blockID;
            ItemDict["lapisblock"] = net.minecraft.src.Block.blockLapis.blockID;
            ItemDict["lapislazuliblock"] = net.minecraft.src.Block.blockLapis.blockID;
            ItemDict["dispenser"] = net.minecraft.src.Block.dispenser.blockID;
            ItemDict["sandstone"] = net.minecraft.src.Block.sandStone.blockID;
            ItemDict["musicblock"] = net.minecraft.src.Block.musicBlock.blockID;
            ItemDict["noteblock"] = net.minecraft.src.Block.musicBlock.blockID;
            ItemDict["poweredrail"] = net.minecraft.src.Block.railPowered.blockID;
            ItemDict["detectorrail"] = net.minecraft.src.Block.railDetector.blockID;
            ItemDict["stickypiston"] = net.minecraft.src.Block.pistonStickyBase.blockID;
            ItemDict["cobwebs"] = net.minecraft.src.Block.web.blockID;
            ItemDict["cobweb"] = net.minecraft.src.Block.web.blockID;
            ItemDict["web"] = net.minecraft.src.Block.web.blockID;
            ItemDict["deadbush"] = net.minecraft.src.Block.deadBush.blockID;
            ItemDict["tallgrass"] = net.minecraft.src.Block.tallGrass.blockID;
            ItemDict["piston"] = net.minecraft.src.Block.pistonBase.blockID;
            ItemDict["wool"] = net.minecraft.src.Block.cloth.blockID;
            ItemDict["cloth"] = net.minecraft.src.Block.cloth.blockID;
            ItemDict["daisy"] = net.minecraft.src.Block.plantYellow.blockID;
            ItemDict["yellowplant"] = net.minecraft.src.Block.plantYellow.blockID;
            ItemDict["yellowflower"] = net.minecraft.src.Block.plantYellow.blockID;
            ItemDict["rose"] = net.minecraft.src.Block.plantRed.blockID;
            ItemDict["redplant"] = net.minecraft.src.Block.plantRed.blockID;
            ItemDict["redflower"] = net.minecraft.src.Block.plantRed.blockID;
            ItemDict["brownmushroom"] = net.minecraft.src.Block.mushroomBrown.blockID;
            ItemDict["redmushroom"] = net.minecraft.src.Block.mushroomRed.blockID;
            ItemDict["goldblock"] = net.minecraft.src.Block.blockGold.blockID;
            ItemDict["ironblock"] = net.minecraft.src.Block.blockSteel.blockID;
            ItemDict["stackedslab"] = net.minecraft.src.Block.stairDouble.blockID;
            ItemDict["doubleslab"] = net.minecraft.src.Block.stairDouble.blockID;
            ItemDict["slab"] = net.minecraft.src.Block.stairSingle.blockID;
            ItemDict["brick"] = net.minecraft.src.Block.brick.blockID;
            ItemDict["bricks"] = net.minecraft.src.Block.brick.blockID;
            ItemDict["tnt"] = net.minecraft.src.Block.tnt.blockID;
            ItemDict["explosive"] = net.minecraft.src.Block.tnt.blockID;
            ItemDict["bookshelf"] = net.minecraft.src.Block.bookShelf.blockID;
            ItemDict["bookcase"] = net.minecraft.src.Block.bookShelf.blockID;
            ItemDict["mossy"] = net.minecraft.src.Block.cobblestoneMossy.blockID;
            ItemDict["mossycobble"] = net.minecraft.src.Block.cobblestoneMossy.blockID;
            ItemDict["mossycobblestone"] = net.minecraft.src.Block.cobblestoneMossy.blockID;
            ItemDict["obsidian"] = net.minecraft.src.Block.obsidian.blockID;
            ItemDict["torch"] = net.minecraft.src.Block.torchWood.blockID;
            ItemDict["fire"] = net.minecraft.src.Block.fire.blockID;
            ItemDict["spawner"] = net.minecraft.src.Block.mobSpawner.blockID;
            ItemDict["woodstairs"] = net.minecraft.src.Block.stairCompactPlanks.blockID;
            ItemDict["woodstair"] = net.minecraft.src.Block.stairCompactPlanks.blockID;
            ItemDict["plankstairs"] = net.minecraft.src.Block.stairCompactPlanks.blockID;
            ItemDict["plankstair"] = net.minecraft.src.Block.stairCompactPlanks.blockID;
            ItemDict["chest"] = net.minecraft.src.Block.chest.blockID;
            ItemDict["diamondore"] = net.minecraft.src.Block.oreDiamond.blockID;
            ItemDict["diamondblock"] = net.minecraft.src.Block.blockDiamond.blockID;
            ItemDict["craftingtable"] = net.minecraft.src.Block.workbench.blockID;
            ItemDict["workbench"] = net.minecraft.src.Block.workbench.blockID;
            ItemDict["soil"] = 60;
            ItemDict["furnace"] = net.minecraft.src.Block.stoneOvenIdle.blockID;
            ItemDict["oven"] = net.minecraft.src.Block.stoneOvenIdle.blockID;
            ItemDict["ladder"] = net.minecraft.src.Block.ladder.blockID;
            ItemDict["rail"] = net.minecraft.src.Block.minecartTrack.blockID;
            ItemDict["rails"] = net.minecraft.src.Block.minecartTrack.blockID;
            ItemDict["track"] = net.minecraft.src.Block.minecartTrack.blockID;
            ItemDict["tracks"] = net.minecraft.src.Block.minecartTrack.blockID;
            ItemDict["stonestairs"] = net.minecraft.src.Block.stairCompactCobblestone.blockID;
            ItemDict["cobblestairs"] = net.minecraft.src.Block.stairCompactCobblestone.blockID;
            ItemDict["cobblestonestairs"] = net.minecraft.src.Block.stairCompactCobblestone.blockID;
            ItemDict["stonestair"] = net.minecraft.src.Block.stairCompactCobblestone.blockID;
            ItemDict["cobblestair"] = net.minecraft.src.Block.stairCompactCobblestone.blockID;
            ItemDict["cobblestonestair"] = net.minecraft.src.Block.stairCompactCobblestone.blockID;
            ItemDict["lever"] = net.minecraft.src.Block.lever.blockID;
            ItemDict["stonepressureplate"] = net.minecraft.src.Block.pressurePlateStone.blockID;
            ItemDict["stoneplate"] = net.minecraft.src.Block.pressurePlateStone.blockID;
            ItemDict["woodpressureplate"] = net.minecraft.src.Block.pressurePlatePlanks.blockID;
            ItemDict["woodplate"] = net.minecraft.src.Block.pressurePlatePlanks.blockID;
            ItemDict["pressureplate"] = net.minecraft.src.Block.pressurePlatePlanks.blockID;
            ItemDict["plate"] = net.minecraft.src.Block.pressurePlatePlanks.blockID;
            ItemDict["redstoneore"] = net.minecraft.src.Block.oreRedstone.blockID;
            ItemDict["glowingredstoneore"] = net.minecraft.src.Block.oreRedstoneGlowing.blockID;
            ItemDict["activeredstoneore"] = net.minecraft.src.Block.oreRedstone.blockID;
            ItemDict["redstonetorch"] = net.minecraft.src.Block.torchRedstoneActive.blockID;
            ItemDict["button"] = net.minecraft.src.Block.button.blockID;
            ItemDict["snow"] = net.minecraft.src.Block.snow.blockID;
            ItemDict["ice"] = net.minecraft.src.Block.ice.blockID;
            ItemDict["iceblock"] = net.minecraft.src.Block.ice.blockID;
            ItemDict["snowblock"] = net.minecraft.src.Block.blockSnow.blockID;
            ItemDict["cactus"] = net.minecraft.src.Block.cactus.blockID;
            ItemDict["clayblock"] = net.minecraft.src.Block.blockClay.blockID;
            ItemDict["jukebox"] = net.minecraft.src.Block.jukebox.blockID;
            ItemDict["recordplayer"] = net.minecraft.src.Block.jukebox.blockID;
            ItemDict["fence"] = net.minecraft.src.Block.fence.blockID;
            ItemDict["pumpkin"] = net.minecraft.src.Block.pumpkin.blockID;
            ItemDict["netherrack"] = net.minecraft.src.Block.bloodStone.blockID;
            ItemDict["soulsand"] = net.minecraft.src.Block.slowSand.blockID;
            ItemDict["glowstone"] = net.minecraft.src.Block.glowStone.blockID;
            ItemDict["glowstoneblock"] = net.minecraft.src.Block.glowStone.blockID;
            ItemDict["portal"] = net.minecraft.src.Block.portal.blockID;
            ItemDict["lantern"] = net.minecraft.src.Block.pumpkinLantern.blockID;
            ItemDict["lockedchest"] = net.minecraft.src.Block.lockedChest.blockID;
            ItemDict["trapdoor"] = net.minecraft.src.Block.trapdoor.blockID;
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
            return new net.minecraft.src.ItemStack(ItemDict[(string)value], 1, 0);
        }
    }
}
