// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;
using System.Collections.Generic;

namespace net.minecraft.src
{
    public class EntityPlayerMP : net.minecraft.src.EntityPlayer, net.minecraft.src.ICrafting
    {
        public EntityPlayerMP(net.minecraft.server.MinecraftServer minecraftserver, net.minecraft.src.World
             world, string s, net.minecraft.src.ItemInWorldManager iteminworldmanager)
            : base(world)
        {
            // Referenced classes of package net.minecraft.src:
            //            EntityPlayer, ICrafting, ItemStack, ItemInWorldManager, 
            //            World, ChunkCoordinates, WorldProvider, WorldServer, 
            //            Container, Packet5PlayerInventory, EntityTracker, InventoryPlayer, 
            //            EntityArrow, Item, NetServerHandler, ItemMapBase, 
            //            ChunkCoordIntPair, Packet51MapChunk, TileEntity, PropertyManager, 
            //            ServerConfigurationManager, Packet8UpdateHealth, Entity, EntityItem, 
            //            Packet22Collect, Packet18Animation, EnumStatus, Packet17Sleep, 
            //            Packet39AttachEntity, Packet100OpenWindow, ContainerWorkbench, IInventory, 
            //            ContainerChest, TileEntityFurnace, ContainerFurnace, TileEntityDispenser, 
            //            ContainerDispenser, SlotCrafting, Packet103SetSlot, Packet104WindowItems, 
            //            Packet105UpdateProgressbar, Packet101CloseWindow, StatBase, Packet200Statistic, 
            //            StringTranslate, Packet3Chat
            loadedChunks = new List<ChunkCoordIntPair>();
            field_420_ah = new HashSet<ChunkCoordIntPair>();
            lastHealth = unchecked((int)(0xfa0a1f01));
            ticksOfInvuln = 60;
            currentWindowId = 0;
            iteminworldmanager.thisPlayer = this;
            itemInWorldManager = iteminworldmanager;
            net.minecraft.src.ChunkCoordinates chunkcoordinates = world.GetSpawnPoint();
            int i = chunkcoordinates.posX;
            int j = chunkcoordinates.posZ;
            int k = chunkcoordinates.posY;
            if (!world.worldProvider.field_4306_c)
            {
                i += rand.Next(20) - 10;
                k = world.FindTopSolidBlock(i, j);
                j += rand.Next(20) - 10;
            }
            SetLocationAndAngles((double)i + 0.5D, k, (double)j + 0.5D, 0.0F, 0.0F);
            mcServer = minecraftserver;
            stepHeight = 0.0F;
            username = s;
            yOffset = 0.0F;
        }

        public override void SetWorldHandler(net.minecraft.src.World world)
        {
            base.SetWorldHandler(world);
            itemInWorldManager = new net.minecraft.src.ItemInWorldManager((net.minecraft.src.WorldServer
                )world);
            itemInWorldManager.thisPlayer = this;
        }

        public virtual void Func_20057_k()
        {
            currentCraftingInventory.OnCraftGuiOpened(this);
        }

        public override net.minecraft.src.ItemStack[] GetInventory()
        {
            return playerInventory;
        }

        protected internal override void ResetHeight()
        {
            yOffset = 0.0F;
        }

        public override float GetEyeHeight()
        {
            return 1.62F;
        }

        public override void OnUpdate()
        {
            itemInWorldManager.Func_328_a();
            ticksOfInvuln--;
            currentCraftingInventory.UpdateCraftingMatrix();
            for (int i = 0; i < 5; i++)
            {
                net.minecraft.src.ItemStack itemstack = GetEquipmentInSlot(i);
                if (itemstack != playerInventory[i])
                {
                    mcServer.GetEntityTracker(dimension).SendPacketToTrackedPlayers(this, new net.minecraft.src.Packet5PlayerInventory
                        (entityId, i, itemstack));
                    playerInventory[i] = itemstack;
                }
            }
        }

        public virtual net.minecraft.src.ItemStack GetEquipmentInSlot(int i)
        {
            if (i == 0)
            {
                return inventory.GetCurrentItem();
            }
            else
            {
                return inventory.armorInventory[i - 1];
            }
        }

        public override void OnDeath(net.minecraft.src.Entity entity)
        {
            inventory.DropAllItems();
        }

        public override bool AttackEntityFrom(net.minecraft.src.Entity entity, int i)
        {
            if (ticksOfInvuln > 0)
            {
                return false;
            }
            if (!mcServer.pvpOn)
            {
                if (entity is net.minecraft.src.EntityPlayer)
                {
                    return false;
                }
                if (entity is net.minecraft.src.EntityArrow)
                {
                    net.minecraft.src.EntityArrow entityarrow = (net.minecraft.src.EntityArrow)entity;
                    if (entityarrow.owner is net.minecraft.src.EntityPlayer)
                    {
                        return false;
                    }
                }
            }
            return base.AttackEntityFrom(entity, i);
        }

        protected internal override bool IsPVPEnabled()
        {
            return mcServer.pvpOn;
        }

        public override void Heal(int i)
        {
            base.Heal(i);
        }

        public virtual void OnUpdateEntity(bool flag)
        {
            base.OnUpdate();
            for (int i = 0; i < inventory.GetSizeInventory(); i++)
            {
                net.minecraft.src.ItemStack itemstack = inventory.GetStackInSlot(i);
                if (itemstack == null || !net.minecraft.src.Item.itemsList[itemstack.itemID].Func_28019_b
                    () || playerNetServerHandler.GetNumChunkDataPackets() > 2)
                {
                    continue;
                }
                net.minecraft.src.Packet packet = ((net.minecraft.src.ItemMapBase)net.minecraft.src.Item
                    .itemsList[itemstack.itemID]).Func_28022_b(itemstack, worldObj, this);
                if (packet != null)
                {
                    playerNetServerHandler.SendPacket(packet);
                }
            }
            if (flag && loadedChunks.Count > 0)
            {
                net.minecraft.src.ChunkCoordIntPair chunkcoordintpair = (net.minecraft.src.ChunkCoordIntPair
                    )loadedChunks[0];
                if (chunkcoordintpair != null)
                {
                    bool flag1 = false;
                    if (playerNetServerHandler.GetNumChunkDataPackets() < 4)
                    {
                        flag1 = true;
                    }
                    if (flag1)
                    {
                        net.minecraft.src.WorldServer worldserver = mcServer.GetWorldManager(dimension);
                        loadedChunks.Remove(chunkcoordintpair);
                        playerNetServerHandler.SendPacket(new net.minecraft.src.Packet51MapChunk(chunkcoordintpair
                            .chunkXPos * 16, 0, chunkcoordintpair.chunkZPos * 16, 16, 128, 16, worldserver));
                        System.Collections.Generic.List<TileEntity> list = worldserver.GetTileEntityList(chunkcoordintpair.chunkXPos
                             * 16, 0, chunkcoordintpair.chunkZPos * 16, chunkcoordintpair.chunkXPos * 16 + 16
                            , 128, chunkcoordintpair.chunkZPos * 16 + 16);
                        for (int j = 0; j < list.Count; j++)
                        {
                            GetTileEntityInfo((net.minecraft.src.TileEntity)list[j]);
                        }
                    }
                }
            }
            if (inPortal)
            {
                if (mcServer.propertyManagerObj.GetBooleanProperty("allow-nether", true))
                {
                    if (currentCraftingInventory != personalCraftingInventory)
                    {
                        UsePersonalCraftingInventory();
                    }
                    if (ridingEntity != null)
                    {
                        MountEntity(ridingEntity);
                    }
                    else
                    {
                        timeInPortal += 0.0125F;
                        if (timeInPortal >= 1.0F)
                        {
                            timeInPortal = 1.0F;
                            timeUntilPortal = 10;
                            mcServer.configManager.SendPlayerToOtherDimension(this);
                        }
                    }
                    inPortal = false;
                }
            }
            else
            {
                if (timeInPortal > 0.0F)
                {
                    timeInPortal -= 0.05F;
                }
                if (timeInPortal < 0.0F)
                {
                    timeInPortal = 0.0F;
                }
            }
            if (timeUntilPortal > 0)
            {
                timeUntilPortal--;
            }
            if (health != lastHealth)
            {
                playerNetServerHandler.SendPacket(new net.minecraft.src.Packet8UpdateHealth(health
                    ));
                lastHealth = health;
            }
        }

        private void GetTileEntityInfo(net.minecraft.src.TileEntity tileentity)
        {
            if (tileentity != null)
            {
                net.minecraft.src.Packet packet = tileentity.GetDescriptionPacket();
                if (packet != null)
                {
                    playerNetServerHandler.SendPacket(packet);
                }
            }
        }

        public override void OnLivingUpdate()
        {
            base.OnLivingUpdate();
        }

        public override void OnItemPickup(net.minecraft.src.Entity entity, int i)
        {
            //TODO: Sanity check stack size for the love of god
            if (!entity.isDead)
            {
                net.minecraft.src.EntityTracker entitytracker = mcServer.GetEntityTracker(dimension
                    );
                if (entity is net.minecraft.src.EntityItem)
                {
                    entitytracker.SendPacketToTrackedPlayers(entity, new net.minecraft.src.Packet22Collect
                        (entity.entityId, entityId));
                }
                if (entity is net.minecraft.src.EntityArrow)
                {
                    entitytracker.SendPacketToTrackedPlayers(entity, new net.minecraft.src.Packet22Collect
                        (entity.entityId, entityId));
                }
            }
            base.OnItemPickup(entity, i);
            currentCraftingInventory.UpdateCraftingMatrix();
        }

        public override void SwingItem()
        {
            if (!isSwinging)
            {
                swingProgressInt = -1;
                isSwinging = true;
                net.minecraft.src.EntityTracker entitytracker = mcServer.GetEntityTracker(dimension
                    );
                entitytracker.SendPacketToTrackedPlayers(this, new net.minecraft.src.Packet18Animation
                    (this, 1));
            }
        }

        public virtual void Func_22068_s()
        {
        }

        public override net.minecraft.src.EnumStatus GoToSleep(int i, int j, int k)
        {
            net.minecraft.src.EnumStatus enumstatus = base.GoToSleep(i, j, k);
            if (enumstatus == net.minecraft.src.EnumStatus.OK)
            {
                net.minecraft.src.EntityTracker entitytracker = mcServer.GetEntityTracker(dimension
                    );
                net.minecraft.src.Packet17Sleep packet17sleep = new net.minecraft.src.Packet17Sleep
                    (this, 0, i, j, k);
                entitytracker.SendPacketToTrackedPlayers(this, packet17sleep);
                playerNetServerHandler.TeleportTo(posX, posY, posZ, rotationYaw, rotationPitch);
                playerNetServerHandler.SendPacket(packet17sleep);
            }
            return enumstatus;
        }

        public override void WakeUpPlayer(bool flag, bool flag1, bool flag2)
        {
            if (Func_22057_E())
            {
                net.minecraft.src.EntityTracker entitytracker = mcServer.GetEntityTracker(dimension
                    );
                entitytracker.SendPacketToTrackedPlayersAndTrackedEntity(this, new net.minecraft.src.Packet18Animation
                    (this, 3));
            }
            base.WakeUpPlayer(flag, flag1, flag2);
            if (playerNetServerHandler != null)
            {
                playerNetServerHandler.TeleportTo(posX, posY, posZ, rotationYaw, rotationPitch);
            }
        }

        public override void MountEntity(net.minecraft.src.Entity entity)
        {
            base.MountEntity(entity);
            playerNetServerHandler.SendPacket(new net.minecraft.src.Packet39AttachEntity(this
                , ridingEntity));
            playerNetServerHandler.TeleportTo(posX, posY, posZ, rotationYaw, rotationPitch);
        }

        protected internal override void UpdateFallState(double d, bool flag)
        {
        }

        public virtual void HandleFalling(double d, bool flag)
        {
            base.UpdateFallState(d, flag);
        }

        private void GetNextWidowId()
        {
            currentWindowId = currentWindowId % 100 + 1;
        }

        public override void DisplayWorkbenchGUI(int i, int j, int k)
        {
            GetNextWidowId();
            playerNetServerHandler.SendPacket(new net.minecraft.src.Packet100OpenWindow(currentWindowId
                , 1, "Crafting", 9));
            currentCraftingInventory = new net.minecraft.src.ContainerWorkbench(inventory, worldObj
                , i, j, k);
            currentCraftingInventory.windowId = currentWindowId;
            currentCraftingInventory.OnCraftGuiOpened(this);
        }

        public override void DisplayGUIChest(net.minecraft.src.IInventory iinventory)
        {
            GetNextWidowId();
            playerNetServerHandler.SendPacket(new net.minecraft.src.Packet100OpenWindow(currentWindowId
                , 0, iinventory.GetInvName(), iinventory.GetSizeInventory()));
            currentCraftingInventory = new net.minecraft.src.ContainerChest(inventory, iinventory
                );
            currentCraftingInventory.windowId = currentWindowId;
            currentCraftingInventory.OnCraftGuiOpened(this);
        }

        public override void DisplayGUIFurnace(net.minecraft.src.TileEntityFurnace tileentityfurnace
            )
        {
            GetNextWidowId();
            playerNetServerHandler.SendPacket(new net.minecraft.src.Packet100OpenWindow(currentWindowId
                , 2, tileentityfurnace.GetInvName(), tileentityfurnace.GetSizeInventory()));
            currentCraftingInventory = new net.minecraft.src.ContainerFurnace(inventory, tileentityfurnace
                );
            currentCraftingInventory.windowId = currentWindowId;
            currentCraftingInventory.OnCraftGuiOpened(this);
        }

        public override void DisplayGUIDispenser(net.minecraft.src.TileEntityDispenser tileentitydispenser
            )
        {
            GetNextWidowId();
            playerNetServerHandler.SendPacket(new net.minecraft.src.Packet100OpenWindow(currentWindowId
                , 3, tileentitydispenser.GetInvName(), tileentitydispenser.GetSizeInventory()));
            currentCraftingInventory = new net.minecraft.src.ContainerDispenser(inventory, tileentitydispenser
                );
            currentCraftingInventory.windowId = currentWindowId;
            currentCraftingInventory.OnCraftGuiOpened(this);
        }

        public virtual void UpdateCraftingInventorySlot(net.minecraft.src.Container container
            , int i, net.minecraft.src.ItemStack itemstack)
        {
            if (container.GetSlot(i) is net.minecraft.src.SlotCrafting)
            {
                return;
            }
            if (isChangingQuantityOnly)
            {
                return;
            }
            else
            {
                playerNetServerHandler.SendPacket(new net.minecraft.src.Packet103SetSlot(container
                    .windowId, i, itemstack));
                return;
            }
        }

        public virtual void Func_28017_a(net.minecraft.src.Container container)
        {
            UpdateCraftingInventory(container, container.GetItemStacks());
        }

        public virtual void UpdateCraftingInventory(net.minecraft.src.Container container
            , System.Collections.IList list)
        {
            playerNetServerHandler.SendPacket(new net.minecraft.src.Packet104WindowItems(container
                .windowId, list));
            playerNetServerHandler.SendPacket(new net.minecraft.src.Packet103SetSlot(-1, -1,
                inventory.GetItemStack()));
        }

        public virtual void UpdateCraftingInventoryInfo(net.minecraft.src.Container container
            , int i, int j)
        {
            playerNetServerHandler.SendPacket(new net.minecraft.src.Packet105UpdateProgressbar
                (container.windowId, i, j));
        }

        public override void OnItemStackChanged(net.minecraft.src.ItemStack itemstack)
        {
        }

        protected internal override void UsePersonalCraftingInventory()
        {
            playerNetServerHandler.SendPacket(new net.minecraft.src.Packet101CloseWindow(currentCraftingInventory
                .windowId));
            CloseCraftingGui();
        }

        public virtual void UpdateHeldItem()
        {
            if (isChangingQuantityOnly)
            {
                return;
            }
            else
            {
                playerNetServerHandler.SendPacket(new net.minecraft.src.Packet103SetSlot(-1, -1,
                    inventory.GetItemStack()));
                return;
            }
        }

        public virtual void CloseCraftingGui()
        {
            currentCraftingInventory.OnCraftGuiClosed(this);
            currentCraftingInventory = personalCraftingInventory;
        }

        public virtual void SetMovementType(float moveStrafing, float moveForward, bool isJumping, bool isSneaking, float pitch, float yaw)
        {
            base.moveStrafing = moveStrafing;
            base.moveForward = moveForward;
            base.isJumping = isJumping;
            SetSneaking(isSneaking);
            rotationPitch = pitch;
            rotationYaw = yaw;
        }

        public override void AddStat(net.minecraft.src.StatBase statbase, int i)
        {
            if (statbase == null)
            {
                return;
            }
            if (!statbase.ServerStatistic)
            {
                for (; i > 100; i -= 100)
                {
                    playerNetServerHandler.SendPacket(new net.minecraft.src.Packet200Statistic(statbase.statId, 100));
                }
                playerNetServerHandler.SendPacket(new net.minecraft.src.Packet200Statistic(statbase.statId, i));
            }
        }

        public virtual void Func_30002_A()
        {
            if (ridingEntity != null)
            {
                MountEntity(ridingEntity);
            }
            if (riddenByEntity != null)
            {
                riddenByEntity.MountEntity(this);
            }
            if (sleeping)
            {
                WakeUpPlayer(true, false, false);
            }
        }

        public virtual void Func_30001_B()
        {
            lastHealth = unchecked((int)(0xfa0a1f01));
        }

        public override void Func_22061_a(string s)
        {
            net.minecraft.src.StringTranslate stringtranslate = net.minecraft.src.StringTranslate
                .GetInstance();
            string s1 = stringtranslate.TranslateKey(s);
            playerNetServerHandler.SendPacket(new net.minecraft.src.Packet3Chat(s1));
        }

        public net.minecraft.src.NetServerHandler playerNetServerHandler;

        public net.minecraft.server.MinecraftServer mcServer;

        public net.minecraft.src.ItemInWorldManager itemInWorldManager;

        public double field_9155_d;

        public double field_9154_e;

        public System.Collections.Generic.List<ChunkCoordIntPair> loadedChunks;

        public HashSet<ChunkCoordIntPair> field_420_ah;

        private int lastHealth;

        private int ticksOfInvuln;

        private net.minecraft.src.ItemStack[] playerInventory = new net.minecraft.src.ItemStack
            [] { null, null, null, null, null };

        private int currentWindowId;

        public bool isChangingQuantityOnly;
    }
}
