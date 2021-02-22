// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using SharpBukkitLive.SharpBukkit;
using Sharpen;
using System.IO;

namespace net.minecraft.src
{
    public class ChunkLoader : net.minecraft.src.IChunkLoader
    {
        public ChunkLoader(string file, bool flag)
        {
            // Referenced classes of package net.minecraft.src:
            //            IChunkLoader, CompressedStreamTools, NBTTagCompound, Chunk, 
            //            World, WorldInfo, NibbleArray, NBTTagList, 
            //            Entity, TileEntity, EntityList
            saveDir = file;
            createIfNecessary = flag;
        }

        private string ChunkFileForXZ(int i, int j)
        {
            string s = (new java.lang.StringBuilder()).Append("c.").Append(Base36.Encode(i)).Append(".").Append(Base36.Encode(j)).Append(".dat").ToString();
            string s1 = Base36.Encode(i & unchecked((int)(0x3f)));
            string s2 = Base36.Encode(j & unchecked((int)(0x3f)));
            string file = System.IO.Path.Combine(saveDir, s1);
            if (!System.IO.File.Exists(file))
            {
                if (createIfNecessary)
                {
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(file));
                    //file.Mkdir();
                }
                else
                {
                    return null;
                }
            }
            file = System.IO.Path.Combine(file, s2);
            if (!System.IO.File.Exists(file))
            {
                if (createIfNecessary)
                {
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(file));
                }
                else
                {
                    return null;
                }
            }
            file = System.IO.Path.Combine(file, s);
            if (!System.IO.File.Exists(file) && !createIfNecessary)
            {
                return null;
            }
            else
            {
                return file;
            }
        }

        /// <exception cref="System.IO.IOException"/>
        public virtual net.minecraft.src.Chunk LoadChunk(net.minecraft.src.World world, int
             i, int j)
        {
            string file = ChunkFileForXZ(i, j);
            if (file != null && System.IO.File.Exists(file))
            {
                try
                {
                    net.minecraft.src.NBTTagCompound nbttagcompound = null;
                    //java.io.FileInputStream fileinputstream = new java.io.FileInputStream(file);
                    using (System.IO.FileStream fileinputstream = System.IO.File.OpenRead(file))
                        nbttagcompound = net.minecraft.src.CompressedStreamTools.ReadCompoundFromStream(fileinputstream);

                    if (!nbttagcompound.HasKey("Level"))
                    {
                        System.Console.Out.WriteLine((new java.lang.StringBuilder()).Append("Chunk file at "
                            ).Append(i).Append(",").Append(j).Append(" is missing level data, skipping").ToString
                            ());
                        return null;
                    }
                    if (!nbttagcompound.GetCompoundTag("Level").HasKey("Blocks"))
                    {
                        System.Console.Out.WriteLine((new java.lang.StringBuilder()).Append("Chunk file at "
                            ).Append(i).Append(",").Append(j).Append(" is missing block data, skipping").ToString
                            ());
                        return null;
                    }
                    net.minecraft.src.Chunk chunk = LoadChunkIntoWorldFromCompound(world, nbttagcompound
                        .GetCompoundTag("Level"));
                    if (!chunk.IsAtLocation(i, j))
                    {
                        System.Console.Out.WriteLine((new java.lang.StringBuilder()).Append("Chunk file at "
                            ).Append(i).Append(",").Append(j).Append(" is in the wrong location; relocating. (Expected "
                            ).Append(i).Append(", ").Append(j).Append(", got ").Append(chunk.xPosition).Append
                            (", ").Append(chunk.zPosition).Append(")").ToString());
                        nbttagcompound.SetInteger("xPos", i);
                        nbttagcompound.SetInteger("zPos", j);
                        chunk = LoadChunkIntoWorldFromCompound(world, nbttagcompound.GetCompoundTag("Level"
                            ));
                    }
                    chunk.Func_25083_h();
                    return chunk;
                }
                catch (System.Exception exception)
                {
                    Sharpen.Runtime.PrintStackTrace(exception);
                }
            }
            return null;
        }

        /// <exception cref="System.IO.IOException"/>
        public virtual void SaveChunk(net.minecraft.src.World world, net.minecraft.src.Chunk
             chunk)
        {
            world.CheckSessionLock();
            string file = ChunkFileForXZ(chunk.xPosition, chunk.zPosition);
            if (System.IO.File.Exists(file))
            {
                net.minecraft.src.WorldInfo worldinfo = world.GetWorldInfo();
                worldinfo.SetSizeOnDisk(worldinfo.GetSizeOnDisk() - file.Length);
            }
            try
            {
                string file1 = System.IO.Path.Combine(saveDir, "tmp_chunk.dat");
                using (FileStream fileoutputstream = File.OpenWrite(file1))
                {
                    net.minecraft.src.NBTTagCompound nbttagcompound = new net.minecraft.src.NBTTagCompound
                        ();
                    net.minecraft.src.NBTTagCompound nbttagcompound1 = new net.minecraft.src.NBTTagCompound
                        ();
                    nbttagcompound.SetTag("Level", nbttagcompound1);
                    StoreChunkInCompound(chunk, world, nbttagcompound1);
                    net.minecraft.src.CompressedStreamTools.WriteGzippedCompoundToOutputStream(nbttagcompound, fileoutputstream);
                    //fileoutputstream.Close();
                }
                if (System.IO.File.Exists(file))
                    System.IO.File.Delete(file);
                System.IO.File.Move(file1, file);
                //file1.RenameTo(file);
                net.minecraft.src.WorldInfo worldinfo1 = world.GetWorldInfo();
                worldinfo1.SetSizeOnDisk(worldinfo1.GetSizeOnDisk() + file.Length);
            }
            catch (System.Exception exception)
            {
                Sharpen.Runtime.PrintStackTrace(exception);
            }
        }

        public static void StoreChunkInCompound(net.minecraft.src.Chunk chunk, net.minecraft.src.World
             world, net.minecraft.src.NBTTagCompound nbttagcompound)
        {
            world.CheckSessionLock();
            nbttagcompound.SetInteger("xPos", chunk.xPosition);
            nbttagcompound.SetInteger("zPos", chunk.zPosition);
            nbttagcompound.SetLong("LastUpdate", world.GetWorldTime());
            nbttagcompound.SetByteArray("Blocks", chunk.blocks);
            nbttagcompound.SetByteArray("Data", chunk.data.data);
            nbttagcompound.SetByteArray("SkyLight", chunk.skylightMap.data);
            nbttagcompound.SetByteArray("BlockLight", chunk.blocklightMap.data);
            nbttagcompound.SetByteArray("HeightMap", chunk.heightMap);
            nbttagcompound.SetBoolean("TerrainPopulated", chunk.isTerrainPopulated);
            chunk.hasEntities = false;
            net.minecraft.src.NBTTagList nbttaglist = new net.minecraft.src.NBTTagList();
            for (int i = 0; i < chunk.entities.Length; i++)
            {
                System.Collections.IEnumerator iterator = chunk.entities[i].GetEnumerator();
                do
                {
                    if (!iterator.MoveNext())
                    {
                        goto label0_continue;
                    }
                    net.minecraft.src.Entity entity = (net.minecraft.src.Entity)iterator.Current;
                    chunk.hasEntities = true;
                    net.minecraft.src.NBTTagCompound nbttagcompound1 = new net.minecraft.src.NBTTagCompound
                        ();
                    if (entity.AddEntityID(nbttagcompound1))
                    {
                        nbttaglist.SetTag(nbttagcompound1);
                    }
                }
                while (true);
                label0_continue:;
            }
            label0_break:;
            nbttagcompound.SetTag("Entities", nbttaglist);
            net.minecraft.src.NBTTagList nbttaglist1 = new net.minecraft.src.NBTTagList();
            net.minecraft.src.NBTTagCompound nbttagcompound2;
            for (System.Collections.IEnumerator iterator1 = chunk.chunkTileEntityMap.Values.GetEnumerator
                (); iterator1.MoveNext(); nbttaglist1.SetTag(nbttagcompound2))
            {
                net.minecraft.src.TileEntity tileentity = (net.minecraft.src.TileEntity)iterator1
                    .Current;
                nbttagcompound2 = new net.minecraft.src.NBTTagCompound();
                tileentity.WriteToNBT(nbttagcompound2);
            }
            nbttagcompound.SetTag("TileEntities", nbttaglist1);
        }

        public static net.minecraft.src.Chunk LoadChunkIntoWorldFromCompound(net.minecraft.src.World
             world, net.minecraft.src.NBTTagCompound nbttagcompound)
        {
            int i = nbttagcompound.GetInteger("xPos");
            int j = nbttagcompound.GetInteger("zPos");
            net.minecraft.src.Chunk chunk = new net.minecraft.src.Chunk(world, i, j);
            chunk.blocks = nbttagcompound.GetByteArray("Blocks");
            chunk.data = new net.minecraft.src.NibbleArray(nbttagcompound.GetByteArray("Data"
                ));
            chunk.skylightMap = new net.minecraft.src.NibbleArray(nbttagcompound.GetByteArray
                ("SkyLight"));
            chunk.blocklightMap = new net.minecraft.src.NibbleArray(nbttagcompound.GetByteArray
                ("BlockLight"));
            chunk.heightMap = nbttagcompound.GetByteArray("HeightMap");
            chunk.isTerrainPopulated = nbttagcompound.GetBoolean("TerrainPopulated");
            if (!chunk.data.IsValid())
            {
                chunk.data = new net.minecraft.src.NibbleArray(chunk.blocks.Length);
            }
            if (chunk.heightMap == null || !chunk.skylightMap.IsValid())
            {
                chunk.heightMap = new byte[256];
                chunk.skylightMap = new net.minecraft.src.NibbleArray(chunk.blocks.Length);
                chunk.Func_353_b();
            }
            if (!chunk.blocklightMap.IsValid())
            {
                chunk.blocklightMap = new net.minecraft.src.NibbleArray(chunk.blocks.Length);
                chunk.Func_348_a();
            }
            net.minecraft.src.NBTTagList nbttaglist = nbttagcompound.GetTagList("Entities");
            if (nbttaglist != null)
            {
                for (int k = 0; k < nbttaglist.TagCount(); k++)
                {
                    net.minecraft.src.NBTTagCompound nbttagcompound1 = (net.minecraft.src.NBTTagCompound
                        )nbttaglist.TagAt(k);
                    net.minecraft.src.Entity entity = net.minecraft.src.EntityList.CreateEntityFromNBT
                        (nbttagcompound1, world);
                    chunk.hasEntities = true;
                    if (entity != null)
                    {
                        chunk.AddEntity(entity);
                    }
                }
            }
            net.minecraft.src.NBTTagList nbttaglist1 = nbttagcompound.GetTagList("TileEntities"
                );
            if (nbttaglist1 != null)
            {
                for (int l = 0; l < nbttaglist1.TagCount(); l++)
                {
                    net.minecraft.src.NBTTagCompound nbttagcompound2 = (net.minecraft.src.NBTTagCompound
                        )nbttaglist1.TagAt(l);
                    net.minecraft.src.TileEntity tileentity = net.minecraft.src.TileEntity.CreateAndLoadEntity
                        (nbttagcompound2);
                    if (tileentity != null)
                    {
                        chunk.AddTileEntity(tileentity);
                    }
                }
            }
            return chunk;
        }

        public virtual void Func_661_a()
        {
        }

        public virtual void SaveExtraData()
        {
        }

        /// <exception cref="System.IO.IOException"/>
        public virtual void SaveExtraChunkData(net.minecraft.src.World world, net.minecraft.src.Chunk
             chunk)
        {
        }

        private string saveDir;

        private bool createIfNecessary;
    }
}
