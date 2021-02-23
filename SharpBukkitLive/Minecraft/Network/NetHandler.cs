// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
    public abstract class NetHandler
    {
        public NetHandler()
        {
        }

        // Referenced classes of package net.minecraft.src:
        //            Packet51MapChunk, Packet, Packet255KickDisconnect, Packet1Login, 
        //            Packet10Flying, Packet52MultiBlockChange, Packet14BlockDig, Packet53BlockChange, 
        //            Packet50PreChunk, Packet20NamedEntitySpawn, Packet30Entity, Packet34EntityTeleport, 
        //            Packet15Place, Packet16BlockItemSwitch, Packet29DestroyEntity, Packet21PickupSpawn, 
        //            Packet22Collect, Packet3Chat, Packet23VehicleSpawn, Packet18Animation, 
        //            Packet19EntityAction, Packet2Handshake, Packet24MobSpawn, Packet4UpdateTime, 
        //            Packet6SpawnPosition, Packet28EntityVelocity, Packet40EntityMetadata, Packet39AttachEntity, 
        //            Packet7UseEntity, Packet38EntityStatus, Packet8UpdateHealth, Packet9Respawn, 
        //            Packet60Explosion, Packet100OpenWindow, Packet101CloseWindow, Packet102WindowClick, 
        //            Packet103SetSlot, Packet104WindowItems, Packet130UpdateSign, Packet105UpdateProgressbar, 
        //            Packet5PlayerInventory, Packet106Transaction, Packet25EntityPainting, Packet54PlayNoteBlock, 
        //            Packet200Statistic, Packet17Sleep, Packet27Position, Packet70Bed, 
        //            Packet71Weather, Packet131MapData, Packet61DoorChange
        public abstract bool IsServerHandler();

        public virtual void HandleMapChunk(net.minecraft.src.Packet51MapChunk packet51mapchunk) { }

        public virtual void RegisterPacket(net.minecraft.src.Packet packet) { }

        public virtual void HandleErrorMessage(string s, object[] aobj) { }

        public virtual void HandleKickDisconnect(net.minecraft.src.Packet255KickDisconnect packet255kickdisconnect)
        {
            RegisterPacket(packet255kickdisconnect);
        }

        public virtual void HandleLogin(net.minecraft.src.Packet1Login packet1login)
        {
            RegisterPacket(packet1login);
        }

        public virtual void HandleFlying(net.minecraft.src.Packet10Flying packet10flying)
        {
            RegisterPacket(packet10flying);
        }

        public virtual void HandleMultiBlockChange(net.minecraft.src.Packet52MultiBlockChange packet52multiblockchange)
        {
            RegisterPacket(packet52multiblockchange);
        }

        public virtual void HandleBlockDig(net.minecraft.src.Packet14BlockDig packet14blockdig)
        {
            RegisterPacket(packet14blockdig);
        }

        public virtual void HandleBlockChange(net.minecraft.src.Packet53BlockChange packet53blockchange)
        {
            RegisterPacket(packet53blockchange);
        }

        public virtual void HandlePreChunk(net.minecraft.src.Packet50PreChunk packet50prechunk)
        {
            RegisterPacket(packet50prechunk);
        }

        public virtual void HandleNamedEntitySpawn(net.minecraft.src.Packet20NamedEntitySpawn packet20namedentityspawn)
        {
            RegisterPacket(packet20namedentityspawn);
        }

        public virtual void HandleEntity(net.minecraft.src.Packet30Entity packet30entity)
        {
            RegisterPacket(packet30entity);
        }

        public virtual void HandleEntityTeleport(net.minecraft.src.Packet34EntityTeleport packet34entityteleport)
        {
            RegisterPacket(packet34entityteleport);
        }

        public virtual void HandlePlace(net.minecraft.src.Packet15Place packet15place)
        {
            RegisterPacket(packet15place);
        }

        public virtual void HandleBlockItemSwitch(net.minecraft.src.Packet16BlockItemSwitch packet16blockitemswitch)
        {
            RegisterPacket(packet16blockitemswitch);
        }

        public virtual void HandleDestroyEntity(net.minecraft.src.Packet29DestroyEntity packet29destroyentity)
        {
            RegisterPacket(packet29destroyentity);
        }

        public virtual void HandlePickupSpawn(net.minecraft.src.Packet21PickupSpawn packet21pickupspawn)
        {
            RegisterPacket(packet21pickupspawn);
        }

        public virtual void HandleCollect(net.minecraft.src.Packet22Collect packet22collect)
        {
            RegisterPacket(packet22collect);
        }

        public virtual void HandleChat(net.minecraft.src.Packet3Chat packet3chat)
        {
            RegisterPacket(packet3chat);
        }

        public virtual void HandleVehicleSpawn(net.minecraft.src.Packet23VehicleSpawn packet23vehiclespawn)
        {
            RegisterPacket(packet23vehiclespawn);
        }

        public virtual void HandleArmAnimation(net.minecraft.src.Packet18Animation packet18animation)
        {
            RegisterPacket(packet18animation);
        }

        public virtual void HandleEntityAction(net.minecraft.src.Packet19EntityAction packet19entityaction)
        {
            RegisterPacket(packet19entityaction);
        }

        public virtual void HandleHandshake(net.minecraft.src.Packet2Handshake packet2handshake
            )
        {
            RegisterPacket(packet2handshake);
        }

        public virtual void HandleMobSpawn(net.minecraft.src.Packet24MobSpawn packet24mobspawn)
        {
            RegisterPacket(packet24mobspawn);
        }

        public virtual void HandleUpdateTime(net.minecraft.src.Packet4UpdateTime packet4updatetime)
        {
            RegisterPacket(packet4updatetime);
        }

        public virtual void HandleSpawnPosition(net.minecraft.src.Packet6SpawnPosition packet6spawnposition)
        {
            RegisterPacket(packet6spawnposition);
        }

        public virtual void HandleEntityVelocity(net.minecraft.src.Packet28EntityVelocity packet28entityvelocity)
        {
            RegisterPacket(packet28entityvelocity);
        }

        public virtual void HandleEntityMetadata(net.minecraft.src.Packet40EntityMetadata packet40entitymetadata)
        {
            RegisterPacket(packet40entitymetadata);
        }

        public virtual void HandleAttachEntity(net.minecraft.src.Packet39AttachEntity packet39attachentity)
        {
            RegisterPacket(packet39attachentity);
        }

        public virtual void HandleUseEntity(net.minecraft.src.Packet7UseEntity packet7useentity)
        {
            RegisterPacket(packet7useentity);
        }

        public virtual void HandleEntityStatus(net.minecraft.src.Packet38EntityStatus packet38entitystatus)
        {
            RegisterPacket(packet38entitystatus);
        }

        public virtual void HandleHealth(net.minecraft.src.Packet8UpdateHealth packet8updatehealth)
        {
            RegisterPacket(packet8updatehealth);
        }

        public virtual void HandleRespawnPacket(net.minecraft.src.Packet9Respawn packet9respawn)
        {
            RegisterPacket(packet9respawn);
        }

        public virtual void HandleExplosion(net.minecraft.src.Packet60Explosion packet60explosion)
        {
            RegisterPacket(packet60explosion);
        }

        public virtual void HandleOpenWindow(net.minecraft.src.Packet100OpenWindow packet100openwindow)
        {
            RegisterPacket(packet100openwindow);
        }

        public virtual void HandleCraftingGuiClosedPacked(net.minecraft.src.Packet101CloseWindow packet101closewindow)
        {
            RegisterPacket(packet101closewindow);
        }

        public virtual void HandleWindowClick(net.minecraft.src.Packet102WindowClick packet102windowclick)
        {
            RegisterPacket(packet102windowclick);
        }

        public virtual void HandleSetSlot(net.minecraft.src.Packet103SetSlot packet103setslot)
        {
            RegisterPacket(packet103setslot);
        }

        public virtual void HandleWindowItems(net.minecraft.src.Packet104WindowItems packet104windowitems)
        {
            RegisterPacket(packet104windowitems);
        }

        public virtual void HandleUpdateSign(net.minecraft.src.Packet130UpdateSign packet130updatesign)
        {
            RegisterPacket(packet130updatesign);
        }

        public virtual void HandleUpdateProgressBar(net.minecraft.src.Packet105UpdateProgressbar packet105updateprogressbar)
        {
            RegisterPacket(packet105updateprogressbar);
        }

        public virtual void HandlePlayerInventory(net.minecraft.src.Packet5PlayerInventory packet5playerinventory)
        {
            RegisterPacket(packet5playerinventory);
        }

        public virtual void HandleTransaction(net.minecraft.src.Packet106Transaction packet106transaction)
        {
            RegisterPacket(packet106transaction);
        }

        public virtual void HandleEntityPainting(net.minecraft.src.Packet25EntityPainting packet25entitypainting)
        {
            RegisterPacket(packet25entitypainting);
        }

        public virtual void HandlePlayNoteBlock(net.minecraft.src.Packet54PlayNoteBlock packet54playnoteblock)
        {
            RegisterPacket(packet54playnoteblock);
        }

        public virtual void HandleStatistic(net.minecraft.src.Packet200Statistic packet200statistic)
        {
            RegisterPacket(packet200statistic);
        }

        public virtual void HandleSleep(net.minecraft.src.Packet17Sleep packet17sleep)
        {
            RegisterPacket(packet17sleep);
        }

        public virtual void HandleMovementTypePacket(net.minecraft.src.Packet27Position packet27position)
        {
            RegisterPacket(packet27position);
        }

        public virtual void HandleBed(net.minecraft.src.Packet70Bed packet70bed)
        {
            RegisterPacket(packet70bed);
        }

        public virtual void HandleWeather(net.minecraft.src.Packet71Weather packet71weather)
        {
            RegisterPacket(packet71weather);
        }

        public virtual void HandleMapData(net.minecraft.src.Packet131MapData packet131mapdata)
        {
            RegisterPacket(packet131mapdata);
        }

        public virtual void HandleDoorChange(net.minecraft.src.Packet61DoorChange packet61doorchange)
        {
            RegisterPacket(packet61doorchange);
        }
    }
}
