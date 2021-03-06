// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;
using System;
using System.Collections.Generic;

namespace net.minecraft.src
{
    public class NetServerHandler : net.minecraft.src.NetHandler, net.minecraft.src.ICommandListener
    {
        public NetServerHandler(net.minecraft.server.MinecraftServer minecraftserver, net.minecraft.src.NetworkManager
             networkmanager, net.minecraft.src.EntityPlayerMP entityplayermp)
        {
            // Referenced classes of package net.minecraft.src:
            //            NetHandler, ICommandListener, NetworkManager, EntityPlayerMP, 
            //            Packet0KeepAlive, Packet255KickDisconnect, Packet3Chat, ServerConfigurationManager, 
            //            Packet27Position, Packet10Flying, Entity, WorldServer, 
            //            AxisAlignedBB, Packet13PlayerLookMove, Packet14BlockDig, WorldProvider, 
            //            ChunkCoordinates, MathHelper, ItemInWorldManager, Packet53BlockChange, 
            //            InventoryPlayer, Packet15Place, ItemStack, Container, 
            //            Packet103SetSlot, Slot, Packet16BlockItemSwitch, ChatAllowedCharacters, 
            //            Packet18Animation, Packet19EntityAction, Packet7UseEntity, Packet102WindowClick, 
            //            Packet106Transaction, Packet130UpdateSign, TileEntitySign, Packet, 
            //            Packet9Respawn, Packet101CloseWindow
            disconnected = false;
            hasMoved = true;
            field_10_k = new System.Collections.Hashtable();
            mcServer = minecraftserver;
            netManager = networkmanager;
            networkmanager.SetNetHandler(this);
            playerEntity = entityplayermp;
            entityplayermp.netServerHandler = this;
        }

        public virtual void HandlePackets()
        {
            field_22003_h = false;

            // CRAFTBUKKIT/SHARP start
            try
            {
                netManager.ProcessReadPackets();
            }
#if !DEBUG
            catch (Exception e)
            {
                logger.Warning("NetServerHandler exception came from " + playerEntity.username);
                KickPlayer(e.GetType().Name);
            }
#endif
            finally { }
            // CRAFTBUKKIT/SHARP end

            if (field_15_f - field_22004_g > 20)
            {
                SendPacket(new net.minecraft.src.Packet0KeepAlive());
            }
        }

        public virtual void KickPlayer(string s)
        {
            playerEntity.Func_30002_A();
            SendPacket(new net.minecraft.src.Packet255KickDisconnect(s));
            netManager.ServerShutdown();
            mcServer.serverConfigurationManager.SendPacketToAllPlayers(new net.minecraft.src.Packet3Chat((
                new java.lang.StringBuilder()).Append("�e").Append(playerEntity.username).Append
                (" left the game.").ToString()));
            mcServer.serverConfigurationManager.PlayerLoggedOut(playerEntity);
            disconnected = true;
        }

        public override void HandleMovementTypePacket(net.minecraft.src.Packet27Position
            packet27position)
        {
            playerEntity.SetMovementType(
                packet27position.GetStrafeMovement(),
                packet27position.GetForwardMovement(),
                packet27position.GetIsSneaking(),
                packet27position.GetIsInJump(),
                packet27position.GetPitch(),
                packet27position.GetYaw());
        }

        public override void HandleFlying(net.minecraft.src.Packet10Flying packet10flying
            )
        {
            net.minecraft.src.WorldServer worldserver = mcServer.GetWorldServer(playerEntity
                .dimension);
            field_22003_h = true;
            if (!hasMoved)
            {
                double d = packet10flying.yPosition - lastPosY;
                if (packet10flying.xPosition == lastPosX && d * d < 0.01D && packet10flying.zPosition
                     == lastPosZ)
                {
                    hasMoved = true;
                }
            }
            if (hasMoved)
            {
                if (playerEntity.ridingEntity != null)
                {
                    float f = playerEntity.rotationYaw;
                    float f1 = playerEntity.rotationPitch;
                    playerEntity.ridingEntity.UpdateRiderPosition();
                    double d2 = playerEntity.posX;
                    double d4 = playerEntity.posY;
                    double d6 = playerEntity.posZ;
                    double d8 = 0.0D;
                    double d9 = 0.0D;
                    if (packet10flying.rotating)
                    {
                        f = packet10flying.yaw;
                        f1 = packet10flying.pitch;
                    }
                    if (packet10flying.moving && packet10flying.yPosition == -999D && packet10flying.
                        stance == -999D)
                    {
                        d8 = packet10flying.xPosition;
                        d9 = packet10flying.zPosition;
                    }
                    playerEntity.onGround = packet10flying.onGround;
                    playerEntity.OnUpdateEntity(true);
                    playerEntity.MoveEntity(d8, 0.0D, d9);
                    playerEntity.SetPositionAndRotation(d2, d4, d6, f, f1);
                    playerEntity.motionX = d8;
                    playerEntity.motionZ = d9;
                    if (playerEntity.ridingEntity != null)
                    {
                        worldserver.Func_12017_b(playerEntity.ridingEntity, true);
                    }
                    if (playerEntity.ridingEntity != null)
                    {
                        playerEntity.ridingEntity.UpdateRiderPosition();
                    }
                    mcServer.serverConfigurationManager.Func_613_b(playerEntity);
                    lastPosX = playerEntity.posX;
                    lastPosY = playerEntity.posY;
                    lastPosZ = playerEntity.posZ;
                    worldserver.UpdateEntity(playerEntity);
                    return;
                }
                if (playerEntity.IsSleeping())
                {
                    playerEntity.OnUpdateEntity(true);
                    playerEntity.SetPositionAndRotation(lastPosX, lastPosY, lastPosZ, playerEntity.rotationYaw
                        , playerEntity.rotationPitch);
                    worldserver.UpdateEntity(playerEntity);
                    return;
                }
                double d1 = playerEntity.posY;
                lastPosX = playerEntity.posX;
                lastPosY = playerEntity.posY;
                lastPosZ = playerEntity.posZ;
                double d3 = playerEntity.posX;
                double d5 = playerEntity.posY;
                double d7 = playerEntity.posZ;
                float f2 = playerEntity.rotationYaw;
                float f3 = playerEntity.rotationPitch;
                if (packet10flying.moving && packet10flying.yPosition == -999D && packet10flying.
                    stance == -999D)
                {
                    packet10flying.moving = false;
                }
                if (packet10flying.moving)
                {
                    d3 = packet10flying.xPosition;
                    d5 = packet10flying.yPosition;
                    d7 = packet10flying.zPosition;
                    double d10 = packet10flying.stance - packet10flying.yPosition;
                    if (!playerEntity.IsSleeping() && (d10 > 1.6499999999999999D || d10 < 0.10000000000000001D
                        ))
                    {
                        KickPlayer("Illegal stance");
                        logger.Warning((new java.lang.StringBuilder()).Append(playerEntity.username).Append
                            (" had an illegal stance: ").Append(d10).ToString());
                        return;
                    }
                    if (System.Math.Abs(packet10flying.xPosition) > 32000000D || System.Math.Abs(packet10flying
                        .zPosition) > 32000000D)
                    {
                        KickPlayer("Illegal position");
                        return;
                    }
                }
                if (packet10flying.rotating)
                {
                    f2 = packet10flying.yaw;
                    f3 = packet10flying.pitch;
                }
                playerEntity.OnUpdateEntity(true);
                playerEntity.ySize = 0.0F;
                playerEntity.SetPositionAndRotation(lastPosX, lastPosY, lastPosZ, f2, f3);
                if (!hasMoved)
                {
                    return;
                }
                double d11 = d3 - playerEntity.posX;
                double d12 = d5 - playerEntity.posY;
                double d13 = d7 - playerEntity.posZ;
                double d14 = d11 * d11 + d12 * d12 + d13 * d13;
                if (d14 > 100D)
                {
                    logger.Warning((new java.lang.StringBuilder()).Append(playerEntity.username).Append
                        (" moved too quickly!").ToString());
                    KickPlayer("You moved too quickly :( (Hacking?)");
                    return;
                }
                float f4 = 0.0625F;
                bool flag = worldserver.GetCollidingBoundingBoxes(playerEntity, playerEntity.boundingBox
                    .Copy().GetInsetBoundingBox(f4, f4, f4)).Count == 0;
                playerEntity.MoveEntity(d11, d12, d13);
                d11 = d3 - playerEntity.posX;
                d12 = d5 - playerEntity.posY;
                if (d12 > -0.5D || d12 < 0.5D)
                {
                    d12 = 0.0D;
                }
                d13 = d7 - playerEntity.posZ;
                d14 = d11 * d11 + d12 * d12 + d13 * d13;
                bool flag1 = false;
                if (d14 > 0.0625D && !playerEntity.IsSleeping())
                {
                    flag1 = true;
                    logger.Warning((new java.lang.StringBuilder()).Append(playerEntity.username).Append
                        (" moved wrongly!").ToString());
                    System.Console.Out.WriteLine((new java.lang.StringBuilder()).Append("Got position "
                        ).Append(d3).Append(", ").Append(d5).Append(", ").Append(d7).ToString());
                    System.Console.Out.WriteLine((new java.lang.StringBuilder()).Append("Expected ").
                        Append(playerEntity.posX).Append(", ").Append(playerEntity.posY).Append(", ").Append
                        (playerEntity.posZ).ToString());
                }
                playerEntity.SetPositionAndRotation(d3, d5, d7, f2, f3);
                bool flag2 = worldserver.GetCollidingBoundingBoxes(playerEntity, playerEntity.boundingBox
                    .Copy().GetInsetBoundingBox(f4, f4, f4)).Count == 0;
                if (flag && (flag1 || !flag2) && !playerEntity.IsSleeping())
                {
                    TeleportTo(lastPosX, lastPosY, lastPosZ, f2, f3);
                    return;
                }
                net.minecraft.src.AxisAlignedBB axisalignedbb = playerEntity.boundingBox.Copy().Expand
                    (f4, f4, f4).AddCoord(0.0D, -0.55000000000000004D, 0.0D);
                if (!mcServer.allowFlight && !worldserver.Func_27069_b(axisalignedbb))
                {
                    if (d12 >= -0.03125D)
                    {
                        playerInAirTime++;
                        if (playerInAirTime > 80)
                        {
                            logger.Warning((new java.lang.StringBuilder()).Append(playerEntity.username).Append
                                (" was kicked for floating too long!").ToString());
                            KickPlayer("Flying is not enabled on this server");
                            return;
                        }
                    }
                }
                else
                {
                    playerInAirTime = 0;
                }
                playerEntity.onGround = packet10flying.onGround;
                mcServer.serverConfigurationManager.Func_613_b(playerEntity);
                playerEntity.HandleFalling(playerEntity.posY - d1, packet10flying.onGround);
            }
        }

        public virtual void TeleportTo(double d, double d1, double d2, float f, float f1)
        {
            hasMoved = false;
            lastPosX = d;
            lastPosY = d1;
            lastPosZ = d2;
            playerEntity.SetPositionAndRotation(d, d1, d2, f, f1);
            playerEntity.netServerHandler.SendPacket(new net.minecraft.src.Packet13PlayerLookMove
                (d, d1 + 1.6200000047683716D, d1, d2, f, f1, false));
        }

        public override void HandleBlockDig(net.minecraft.src.Packet14BlockDig packet14blockdig)
        {
            if (playerEntity.isDead) return; // CRAFTBUKKIT

            net.minecraft.src.WorldServer worldserver = mcServer.GetWorldServer(playerEntity
                .dimension);
            if (packet14blockdig.status == 4)
            {
                playerEntity.DropCurrentItem();
                return;
            }
            bool flag = worldserver.weirdIsOpCache = worldserver.worldProvider.worldType != 0 ||
                 mcServer.serverConfigurationManager.IsOp(playerEntity.username);
            bool flag1 = false;
            if (packet14blockdig.status == 0)
            {
                flag1 = true;
            }
            if (packet14blockdig.status == 2)
            {
                flag1 = true;
            }
            int i = packet14blockdig.xPosition;
            int j = packet14blockdig.yPosition;
            int k = packet14blockdig.zPosition;
            if (flag1)
            {
                double d = playerEntity.posX - ((double)i + 0.5D);
                double d1 = playerEntity.posY - ((double)j + 0.5D);
                double d3 = playerEntity.posZ - ((double)k + 0.5D);
                double d5 = d * d + d1 * d1 + d3 * d3;
                if (d5 > 36D)
                {
                    return;
                }
            }
            net.minecraft.src.ChunkCoordinates chunkcoordinates = worldserver.GetSpawnPoint();
            int l = (int)net.minecraft.src.MathHelper.Abs(i - chunkcoordinates.posX);
            int i1 = (int)net.minecraft.src.MathHelper.Abs(k - chunkcoordinates.posZ);
            if (l > i1)
            {
                i1 = l;
            }
            if (packet14blockdig.status == 0)
            {
                if (i1 > 16 || flag)
                {
                    playerEntity.itemInWorldManager.Func_324_a(i, j, k, packet14blockdig.face);
                }
                else
                {
                    playerEntity.netServerHandler.SendPacket(new net.minecraft.src.Packet53BlockChange
                        (i, j, k, worldserver));
                }
            }
            else
            {
                if (packet14blockdig.status == 2)
                {
                    playerEntity.itemInWorldManager.Func_22045_b(i, j, k);
                    if (worldserver.GetBlockId(i, j, k) != 0)
                    {
                        playerEntity.netServerHandler.SendPacket(new net.minecraft.src.Packet53BlockChange
                            (i, j, k, worldserver));
                    }
                }
                else
                {
                    if (packet14blockdig.status == 3)
                    {
                        double d2 = playerEntity.posX - ((double)i + 0.5D);
                        double d4 = playerEntity.posY - ((double)j + 0.5D);
                        double d6 = playerEntity.posZ - ((double)k + 0.5D);
                        double d7 = d2 * d2 + d4 * d4 + d6 * d6;
                        if (d7 < 256D)
                        {
                            playerEntity.netServerHandler.SendPacket(new net.minecraft.src.Packet53BlockChange
                                (i, j, k, worldserver));
                        }
                    }
                }
            }
            worldserver.weirdIsOpCache = false;
        }

        public override void HandlePlace(net.minecraft.src.Packet15Place packet15place)
        {
            net.minecraft.src.WorldServer worldserver = mcServer.GetWorldServer(playerEntity
                .dimension);
            net.minecraft.src.ItemStack itemstack = playerEntity.inventory.GetCurrentItem();
            bool flag = worldserver.weirdIsOpCache = worldserver.worldProvider.worldType != 0 ||
                 mcServer.serverConfigurationManager.IsOp(playerEntity.username);
            if (packet15place.direction == 255)
            {
                if (itemstack == null)
                {
                    return;
                }
                playerEntity.itemInWorldManager.Func_6154_a(playerEntity, worldserver, itemstack);
            }
            else
            {
                int i = packet15place.xPosition;
                int j = packet15place.yPosition;
                int k = packet15place.zPosition;
                int l = packet15place.direction;
                net.minecraft.src.ChunkCoordinates chunkcoordinates = worldserver.GetSpawnPoint();
                int i1 = (int)net.minecraft.src.MathHelper.Abs(i - chunkcoordinates.posX);
                int j1 = (int)net.minecraft.src.MathHelper.Abs(k - chunkcoordinates.posZ);
                if (i1 > j1)
                {
                    j1 = i1;
                }
                if (hasMoved && playerEntity.GetDistanceSq((double)i + 0.5D, (double)j + 0.5D, (double
                    )k + 0.5D) < 64D && (j1 > 16 || flag))
                {
                    playerEntity.itemInWorldManager.ActiveBlockOrUseItem(playerEntity, worldserver, itemstack
                        , i, j, k, l);
                }
                playerEntity.netServerHandler.SendPacket(new net.minecraft.src.Packet53BlockChange
                    (i, j, k, worldserver));
                if (l == 0)
                {
                    j--;
                }
                if (l == 1)
                {
                    j++;
                }
                if (l == 2)
                {
                    k--;
                }
                if (l == 3)
                {
                    k++;
                }
                if (l == 4)
                {
                    i--;
                }
                if (l == 5)
                {
                    i++;
                }
                playerEntity.netServerHandler.SendPacket(new net.minecraft.src.Packet53BlockChange
                    (i, j, k, worldserver));
            }
            itemstack = playerEntity.inventory.GetCurrentItem();
            if (itemstack != null && itemstack.stackSize == 0)
            {
                playerEntity.inventory.mainInventory[playerEntity.inventory.currentItem] = null;
            }
            playerEntity.isChangingQuantityOnly = true;
            playerEntity.inventory.mainInventory[playerEntity.inventory.currentItem] = net.minecraft.src.ItemStack
                .CloneStack(playerEntity.inventory.mainInventory[playerEntity.inventory.currentItem
                ]);
            net.minecraft.src.Slot slot = playerEntity.currentCraftingInventory.Func_20127_a(
                playerEntity.inventory, playerEntity.inventory.currentItem);
            playerEntity.currentCraftingInventory.UpdateCraftingMatrix();
            playerEntity.isChangingQuantityOnly = false;
            if (!net.minecraft.src.ItemStack.AreItemStacksEqual(playerEntity.inventory.GetCurrentItem
                (), packet15place.itemStack))
            {
                SendPacket(new net.minecraft.src.Packet103SetSlot(playerEntity.currentCraftingInventory
                    .windowId, slot.id, playerEntity.inventory.GetCurrentItem()));
            }
            worldserver.weirdIsOpCache = false;
        }

        public override void HandleErrorMessage(string s, object[] aobj)
        {
            //TODO: Hook leave message
            logger.Info((new java.lang.StringBuilder()).Append(playerEntity.username).Append(" lost connection: ").Append(s).ToString());
            mcServer.serverConfigurationManager.SendPacketToAllPlayers(new net.minecraft.src.Packet3Chat((new java.lang.StringBuilder()).Append("�e").Append(playerEntity.username).Append(" left the game.").ToString()));
            mcServer.serverConfigurationManager.PlayerLoggedOut(playerEntity);
            disconnected = true;
        }

        public override void RegisterPacket(net.minecraft.src.Packet packet)
        {
            if (disconnected) return;

            logger.Warning((new java.lang.StringBuilder()).Append(this.GetType().Name).Append(" wasn't prepared to deal with a ").Append(packet.GetType().Name).ToString());
            KickPlayer("Protocol error, unexpected packet");
        }

        public virtual void SendPacket(net.minecraft.src.Packet packet)
        {
            netManager.AddToSendQueue(packet); //TODO: Craftbukkit -- reroute chunk compression to another thread
            //field_22004_g = field_15_f; // CRAFTBUKKIT -- e85c99289cd0f56cb9aff8e673f3e87664cc4321 fix latency issues
        }

        public override void HandleBlockItemSwitch(net.minecraft.src.Packet16BlockItemSwitch packet16blockitemswitch)
        {
            if (this.playerEntity.isDead) return; // CRAFTBUKKIT

            if (packet16blockitemswitch.id >= 0 && packet16blockitemswitch.id < net.minecraft.src.InventoryPlayer.GetNumberOfSlots())
            {
                playerEntity.inventory.currentItem = packet16blockitemswitch.id;
            }
            else
            {
                logger.Warning((new java.lang.StringBuilder()).Append(playerEntity.username).Append(" tried to set an invalid carried item").ToString());
                this.KickPlayer("Nope!"); // CRAFTBUKKIT
            }
        }

        public override void HandleChat(net.minecraft.src.Packet3Chat packet3chat)
        {
            string s = packet3chat.message;
            if (s.Length > 100)
            {
                KickPlayer("Chat message too long");
                return;
            }
            s = s.Trim();
            for (int i = 0; i < s.Length; i++)
            {
                if (net.minecraft.src.ChatAllowedCharacters.allowedCharacters.IndexOf(s[i]) < 0)
                {
                    KickPlayer("Illegal characters in chat");
                    return;
                }
            }
            if (s.StartsWith("/"))
            {
                HandleSlashCommand(s);
            }
            else
            {
                s = (new java.lang.StringBuilder()).Append("<").Append(playerEntity.username).Append
                    ("> ").Append(s).ToString();
                logger.Info(s);
                mcServer.serverConfigurationManager.SendPacketToAllPlayers(new net.minecraft.src.Packet3Chat(s
                    ));
            }
        }

        private void HandleSlashCommand(string s)
        {
            mcServer.AddCommand(s.Substring(1), this);
            //if (s.ToLower().StartsWith("/me "))
            //{
            //    s = (new java.lang.StringBuilder()).Append("* ").Append(playerEntity.username).Append
            //        (" ").Append(s.Substring(s.IndexOf(" ")).Trim()).ToString();
            //    logger.Info(s);
            //    mcServer.configManager.SendPacketToAllPlayers(new net.minecraft.src.Packet3Chat(s));
            //}
            //else
            //{
            //    if (s.ToLower().StartsWith("/kill"))
            //    {
            //        playerEntity.AttackEntityFrom(null, 1000);
            //    }
            //    else
            //    {
            //        if (s.ToLower().StartsWith("/tell "))
            //        {
            //            string[] @as = s.Split(" ");
            //            if (@as.Length >= 3)
            //            {
            //                s = s.Substring(s.IndexOf(" ")).Trim();
            //                s = s.Substring(s.IndexOf(" ")).Trim();
            //                s = (new java.lang.StringBuilder()).Append("\x9ad").Append(playerEntity.username)
            //                    .Append(" whispers ").Append(s).ToString();
            //                logger.Info((new java.lang.StringBuilder()).Append(s).Append(" to ").Append(@as[1
            //                    ]).ToString());
            //                if (!mcServer.configManager.SendPacketToPlayer(@as[1], new net.minecraft.src.Packet3Chat
            //                    (s)))
            //                {
            //                    SendPacket(new net.minecraft.src.Packet3Chat("\xf7cThere's no player by that name online."
            //                        ));
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (mcServer.configManager.IsOp(playerEntity.username))
            //            {
            //                string s1 = s.Substring(1);
            //                logger.Info((new java.lang.StringBuilder()).Append(playerEntity.username).Append(
            //                    " issued server command: ").Append(s1).ToString());
            //                mcServer.AddCommand(s1, this);
            //            }
            //            else
            //            {
            //                string s2 = s.Substring(1);
            //                logger.Info((new java.lang.StringBuilder()).Append(playerEntity.username).Append(
            //                    " tried command: ").Append(s2).ToString());
            //            }
            //        }
            //    }
            //}
        }

        public override void HandleArmAnimation(net.minecraft.src.Packet18Animation packet18animation)
        {
            if (this.playerEntity.isDead) return; // CRAFTBUKKIT

            if (packet18animation.animate == 1)
            {
                //TODO: Craftbukkit -- Raytrace to look for 'rogue armswings'
                playerEntity.SwingItem();
            }
        }

        public override void HandleEntityAction(net.minecraft.src.Packet19EntityAction packet19entityaction)
        {
            if (this.playerEntity.isDead) return; // CRAFTBUKKIT

            //TODO: Hook ToogleSneak

            if (packet19entityaction.state == 1)
            {
                playerEntity.SetSneaking(true);
            }
            else if (packet19entityaction.state == 2)
            {
                playerEntity.SetSneaking(false);
            }
            else if (packet19entityaction.state == 3)
            {
                //TODO: Craftbukkit -- Can't leave bed if not in one! (???)
                playerEntity.WakeUpPlayer(false, true, true);
                hasMoved = false;
            }
        }

        public override void HandleKickDisconnect(net.minecraft.src.Packet255KickDisconnect
             packet255kickdisconnect)
        {
            netManager.NetworkShutdown("disconnect.quitting", new object[0]);
        }

        public virtual int GetNumChunkDataPackets()
        {
            return netManager.GetNumChunkDataPackets();
        }

        public virtual void Log(string s)
        {
            //SendPacket(new net.minecraft.src.Packet3Chat((new java.lang.StringBuilder()).Append("�d").Append(s).ToString()));
            SendPacket(new net.minecraft.src.Packet3Chat(s));
        }

        public virtual string GetUsername()
        {
            return playerEntity.username;
        }

        public override void HandleUseEntity(net.minecraft.src.Packet7UseEntity packet7useentity)
        {
            if (this.playerEntity.isDead) return; // CRAFTBUKKIT

            net.minecraft.src.WorldServer worldserver = mcServer.GetWorldServer(playerEntity.dimension);
            net.minecraft.src.Entity entity = worldserver.Func_6158_a(packet7useentity.targetEntity);
            ItemStack itemInHand = this.playerEntity.inventory.GetCurrentItem(); // CRAFTBUKKIT
            if (entity != null && playerEntity.CanEntityBeSeen(entity) && playerEntity.GetDistanceSqToEntity(entity) < 36D)
            {
                if (packet7useentity.isLeftClick == 0)
                {
                    playerEntity.UseCurrentItemOnEntity(entity);

                    // CRAFTBUKKIT start - update the client if the item is an infinite one
                    if (itemInHand != null && itemInHand.stackSize <= -1)
                    {
                        this.playerEntity.UpdateInventory(this.playerEntity.currentCraftingInventory);
                    }
                    // CRAFTBUKKIT end
                }
                else if (packet7useentity.isLeftClick == 1)
                {
                    // CRAFTBUKKIT start
                    if ((entity is EntityItem) || (entity is EntityArrow)) {
                        String type = entity.GetType().Name;
                        KickPlayer("Attacking an " + type + " is not permitted");
                        logger.Warning("Player " + playerEntity.username + " tried to attack an " + type + ", so I have disconnected them for exploiting.");
                        return;
                    }
                    // CRAFTBUKKIT end

                    playerEntity.AttackTargetEntityWithCurrentItem(entity);

                    // CRAFTBUKKIT start - update the client if the item is an infinite one
                    if (itemInHand != null && itemInHand.stackSize <= -1)
                    {
                        this.playerEntity.UpdateInventory(this.playerEntity.currentCraftingInventory);
                    }
                    // CRAFTBUKKIT end
                }
            }
        }

        public override void HandleRespawnPacket(net.minecraft.src.Packet9Respawn packet9respawn)
        {
            if (playerEntity.health <= 0)
            {
                playerEntity = mcServer.serverConfigurationManager.RecreatePlayerEntity(playerEntity, 0);
            }
        }

        public override void HandleCraftingGuiClosedPacked(net.minecraft.src.Packet101CloseWindow packet101closewindow)
        {
            if (this.playerEntity.isDead) return; // CRAFTBUKKIT

            playerEntity.CloseCraftingGui();
        }

        public override void HandleWindowClick(net.minecraft.src.Packet102WindowClick packet102windowclick)
        {
            if (this.playerEntity.isDead) return; // CRAFTBUKKIT

            if (playerEntity.currentCraftingInventory.windowId == packet102windowclick.window_Id
                 && playerEntity.currentCraftingInventory.GetCanCraft(playerEntity))
            {
                net.minecraft.src.ItemStack itemstack = playerEntity.currentCraftingInventory.Func_27085_a
                    (packet102windowclick.inventorySlot, packet102windowclick.mouseClick, packet102windowclick
                    .field_27039_f, playerEntity);
                if (net.minecraft.src.ItemStack.AreItemStacksEqual(packet102windowclick.itemStack
                    , itemstack))
                {
                    playerEntity.netServerHandler.SendPacket(new net.minecraft.src.Packet106Transaction
                        (packet102windowclick.window_Id, packet102windowclick.action, true));
                    playerEntity.isChangingQuantityOnly = true;
                    playerEntity.currentCraftingInventory.UpdateCraftingMatrix();
                    playerEntity.UpdateHeldItem();
                    playerEntity.isChangingQuantityOnly = false;
                }
                else
                {
                    field_10_k[playerEntity.currentCraftingInventory.windowId] = packet102windowclick.action;
                    playerEntity.netServerHandler.SendPacket(new net.minecraft.src.Packet106Transaction
                        (packet102windowclick.window_Id, packet102windowclick.action, false));
                    playerEntity.currentCraftingInventory.SetCanCraft(playerEntity, false);
                    List<ItemStack> arraylist = new List<ItemStack>();
                    for (int i = 0; i < playerEntity.currentCraftingInventory.inventorySlots.Count; i
                        ++)
                    {
                        arraylist.Add(((net.minecraft.src.Slot)playerEntity.currentCraftingInventory.inventorySlots
                            [i]).GetStack());
                    }
                    playerEntity.UpdateCraftingInventory(playerEntity.currentCraftingInventory, arraylist
                        );
                }
            }
        }

        public override void HandleTransaction(net.minecraft.src.Packet106Transaction packet106transaction)
        {
            if (this.playerEntity.isDead) return; // CRAFTBUKKIT

            short short1 = (short)field_10_k[playerEntity.currentCraftingInventory.windowId];
            if (short1 != null && packet106transaction.shortWindowId == short1 && playerEntity
                .currentCraftingInventory.windowId == packet106transaction.windowId && !playerEntity
                .currentCraftingInventory.GetCanCraft(playerEntity))
            {
                playerEntity.currentCraftingInventory.SetCanCraft(playerEntity, true);
            }
        }

        public override void HandleUpdateSign(net.minecraft.src.Packet130UpdateSign packet130updatesign)
        {
            if (this.playerEntity.isDead) return; // CRAFTBUKKIT

            net.minecraft.src.WorldServer worldserver = mcServer.GetWorldServer(playerEntity.dimension);
            if (worldserver.BlockExists(packet130updatesign.xPosition, packet130updatesign.yPosition, packet130updatesign.zPosition))
            {
                net.minecraft.src.TileEntity tileentity = worldserver.GetBlockTileEntity(packet130updatesign.xPosition, packet130updatesign.yPosition, packet130updatesign.zPosition);
                if (tileentity is net.minecraft.src.TileEntitySign)
                {
                    net.minecraft.src.TileEntitySign tileentitysign = (net.minecraft.src.TileEntitySign)tileentity;
                    if (!tileentitysign.GetEditable())
                    {
                        mcServer.LogWarning((new java.lang.StringBuilder()).Append("Player ").Append(playerEntity.username).Append(" just tried to change non-editable sign").ToString());
                        this.SendPacket(new Packet130UpdateSign(packet130updatesign.xPosition, packet130updatesign.yPosition, packet130updatesign.zPosition, tileentitysign.Lines)); // CRAFTBUKKIT
                        return;
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    bool lineValid = true;
                    if (packet130updatesign.signLines[i].Length > 15)
                    {
                        lineValid = false;
                    }
                    else
                    {
                        for (int l = 0; l < packet130updatesign.signLines[i].Length; l++)
                        {
                            if (net.minecraft.src.ChatAllowedCharacters.allowedCharacters.IndexOf(packet130updatesign.signLines[i][l]) < 0)
                            {
                                lineValid = false;
                            }
                        }
                    }
                    if (!lineValid)
                    {
                        packet130updatesign.signLines[i] = "!?";
                    }
                }
                if (tileentity is net.minecraft.src.TileEntitySign)
                {
                    int x = packet130updatesign.xPosition;
                    int y = packet130updatesign.yPosition;
                    int z = packet130updatesign.zPosition;
                    net.minecraft.src.TileEntitySign tileentitysign1 = (net.minecraft.src.TileEntitySign)tileentity;
                    for (int j1 = 0; j1 < 4; j1++)
                    {
                        tileentitysign1.Lines[j1] = packet130updatesign.signLines[j1];
                    }
                    tileentitysign1.SetEditable(false);
                    tileentitysign1.OnInventoryChanged();
                    worldserver.MarkBlockNeedsUpdate(x, y, z);
                }
            }
        }

        public override bool IsServerHandler()
        {
            return true;
        }

        public static Logger logger = Logger.GetLogger();

        public net.minecraft.src.NetworkManager netManager;

        public bool disconnected;

        private net.minecraft.server.MinecraftServer mcServer;

        public net.minecraft.src.EntityPlayerMP playerEntity;

        private int field_15_f;

        private int field_22004_g;

        private int playerInAirTime;

        private bool field_22003_h;

        private double lastPosX;

        private double lastPosY;

        private double lastPosZ;

        private bool hasMoved;

        private System.Collections.IDictionary field_10_k;
    }
}
