// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using java.io;
using Sharpen;
using System;
using System.IO;
using System.IO.Compression;

namespace net.minecraft.src
{
	public class RegionFile : IDisposable
	{
		public RegionFile(string file)
		{
			// Referenced classes of package net.minecraft.src:
			//            RegionFileChunkBuffer
			lastModified = 0L;
			fileName = file;
			Debugln((new java.lang.StringBuilder()).Append("REGION LOAD ").Append(fileName).ToString
				());
			sizeDelta = 0;
			try
			{
				if (File.Exists(file))
				{
					lastModified = new DateTimeOffset(File.GetLastWriteTime(file)).ToUnixTimeMilliseconds();
				}

				string dir = System.IO.Path.GetDirectoryName(file);
				if (!Directory.Exists(dir))
					Directory.CreateDirectory(dir);

				fs = File.Open(file, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
				dataFile = new DataOutputStream(fs);//new java.io.RandomAccessFile(file, "rw");
				dataFileIn = new DataInputStream(fs);
				if (dataFile.Length < 4096L)
				{
					for (int i = 0; i < 1024; i++)
					{
						dataFile.WriteInt(0);
					}
					for (int j = 0; j < 1024; j++)
					{
						dataFile.WriteInt(0);
					}
					sizeDelta += 8192;
				}
				if ((dataFile.Length & 4095L) != 0L)
				{
					for (int k = 0; (long)k < (dataFile.Length & 4095L); k++)
					{
						dataFile.Write(0);
					}
				}
				int l = (int)dataFile.Length / 4096;
				sectorFree = new System.Collections.ArrayList(l);
				for (int i1 = 0; i1 < l; i1++)
				{
					sectorFree.Add(true);
				}
				sectorFree[0] = false;
				sectorFree[1] = false;
				dataFile.Seek(0L);
				for (int j1 = 0; j1 < 1024; j1++)
				{
					int l1 = dataFileIn.ReadInt();
					offsets[j1] = l1;
					if (l1 == 0 || (l1 >> 8) + (l1 & unchecked((int)(0xff))) > sectorFree.Count)
					{
						continue;
					}
					for (int j2 = 0; j2 < (l1 & unchecked((int)(0xff))); j2++)
					{
						sectorFree[(l1 >> 8) + j2] = false;
					}
				}
				for (int k1 = 0; k1 < 1024; k1++)
				{
					int i2 = dataFileIn.ReadInt();
					chunkTimestamps[k1] = i2;
				}
			}
			catch (System.IO.IOException ioexception)
			{
				Sharpen.Runtime.PrintStackTrace(ioexception);
			}
		}

		public virtual int GetSizeDelta()
		{
			lock (this)
			{
				int i = sizeDelta;
				sizeDelta = 0;
				return i;
			}
		}

		private void Debug(string s)
		{
		}

		private void Debugln(string s)
		{
			Debug((new java.lang.StringBuilder()).Append(s).Append("\n").ToString());
		}

		private void Debug(string s, int i, int j, string s1)
		{
			Debug((new java.lang.StringBuilder()).Append("REGION ").Append(s).Append(" ").Append
				(System.IO.Path.GetFileName(fileName)).Append("[").Append(i).Append(",").Append(j).Append("] = ").
				Append(s1).ToString());
		}

		private void Debug(string s, int i, int j, int k, string s1)
		{
			Debug((new java.lang.StringBuilder()).Append("REGION ").Append(s).Append(" ").Append
				(System.IO.Path.GetFileName(fileName)).Append("[").Append(i).Append(",").Append(j).Append("] ").Append
				(k).Append("B = ").Append(s1).ToString());
		}

		private void Debugln(string s, int i, int j, string s1)
		{
			Debug(s, i, j, (new java.lang.StringBuilder()).Append(s1).Append("\n").ToString()
				);
		}

		public virtual java.io.DataInputStream GetChunkDataInputStream(int i, int j)
		{
			lock (this)
			{
				if (OutOfBounds(i, j))
				{
					Debugln("READ", i, j, "out of bounds");
					return null;
				}
				try
				{
					int k = GetOffset(i, j);
					if (k == 0)
					{
						return null;
					}
					int l = k >> 8;
					int i1 = k & unchecked((int)(0xff));
					if (l + i1 > sectorFree.Count)
					{
						Debugln("READ", i, j, "invalid sector");
						return null;
					}
					dataFile.Seek(l * 4096);
					int j1 = dataFileIn.ReadInt();
					if (j1 > 4096 * i1)
					{
						Debugln("READ", i, j, (new java.lang.StringBuilder()).Append("invalid length: ").
							Append(j1).Append(" > 4096 * ").Append(i1).ToString());
						return null;
					}
					byte byte0 = dataFileIn.ReadByte();
					if (byte0 == 1)
					{
						byte[] abyte0 = new byte[j1 - 1];
						dataFileIn.Read(abyte0);
						java.io.DataInputStream datainputstream = new java.io.DataInputStream(new GZipStream(new MemoryStream(abyte0), CompressionMode.Decompress));
						return datainputstream;
					}
					if (byte0 == 2)
					{
						byte[] abyte1 = new byte[j1 - 1];
						dataFileIn.Read(abyte1);
						java.io.DataInputStream datainputstream1 = new java.io.DataInputStream(new DeflateStream(new MemoryStream(abyte1), CompressionMode.Decompress));
						return datainputstream1;
					}
					else
					{
						Debugln("READ", i, j, (new java.lang.StringBuilder()).Append("unknown version ").
							Append(byte0).ToString());
						return null;
					}
				}
				catch (System.IO.IOException)
				{
					Debugln("READ", i, j, "exception");
				}
				return null;
			}
		}

		public virtual java.io.DataOutputStream GetChunkDataOutputStream(int i, int j)
		{
			if (OutOfBounds(i, j))
			{
				return null;
			}
			else
			{
				return new java.io.DataOutputStream(new DeflateStream(new net.minecraft.src.RegionFileChunkBuffer(this, i, j), CompressionLevel.Fastest));
			}
		}

		protected internal virtual void Write(int i, int j, byte[] abyte0, int k)
		{
			lock (this)
			{
				try
				{
					int l = GetOffset(i, j);
					int i1 = l >> 8;
					int l1 = l & unchecked((int)(0xff));
					int i2 = (k + 5) / 4096 + 1;
					if (i2 >= 256)
					{
						return;
					}
					if (i1 != 0 && l1 == i2)
					{
						Debug("SAVE", i, j, k, "rewrite");
						Write(i1, abyte0, k);
					}
					else
					{
						for (int j2 = 0; j2 < l1; j2++)
						{
							sectorFree[i1 + j2] = true;
						}
						int k2 = sectorFree.IndexOf(true);
						int l2 = 0;
						if (k2 != -1)
						{
							int i3 = k2;
							do
							{
								if (i3 >= sectorFree.Count)
								{
									break;
								}
								if (l2 != 0)
								{
									if (((bool)sectorFree[i3]))
									{
										l2++;
									}
									else
									{
										l2 = 0;
									}
								}
								else
								{
									if (((bool)sectorFree[i3]))
									{
										k2 = i3;
										l2 = 1;
									}
								}
								if (l2 >= i2)
								{
									break;
								}
								i3++;
							}
							while (true);
						}
						if (l2 >= i2)
						{
							Debug("SAVE", i, j, k, "reuse");
							int j1 = k2;
							SetOffset(i, j, j1 << 8 | i2);
							for (int j3 = 0; j3 < i2; j3++)
							{
								sectorFree[j1 + j3] = false;
							}
							Write(j1, abyte0, k);
						}
						else
						{
							Debug("SAVE", i, j, k, "grow");
							dataFile.Seek(dataFile.Length, SeekOrigin.Begin);
							int k1 = sectorFree.Count;
							for (int k3 = 0; k3 < i2; k3++)
							{
								dataFile.Write(emptySector);
								sectorFree.Add(false);
							}
							sizeDelta += 4096 * i2;
							Write(k1, abyte0, k);
							SetOffset(i, j, k1 << 8 | i2);
						}
					}
					SetChunkTimestamp(i, j, (int)(Sharpen.Runtime.CurrentTimeMillis() / 1000L));
				}
				catch (System.IO.IOException ioexception)
				{
					Sharpen.Runtime.PrintStackTrace(ioexception);
				}
			}
		}

		/// <exception cref="System.IO.IOException"/>
		private void Write(int i, byte[] abyte0, int j)
		{
			Debugln((new java.lang.StringBuilder()).Append(" ").Append(i).ToString());
			dataFile.Seek(i * 4096, SeekOrigin.Begin);
			dataFile.WriteInt(j + 1);
			dataFile.WriteByte(2);
			dataFile.Write(abyte0, 0, j);
		}

		private bool OutOfBounds(int i, int j)
		{
			return i < 0 || i >= 32 || j < 0 || j >= 32;
		}

		private int GetOffset(int i, int j)
		{
			return offsets[i + j * 32];
		}

		public virtual bool IsChunkSaved(int i, int j)
		{
			return GetOffset(i, j) != 0;
		}

		/// <exception cref="System.IO.IOException"/>
		private void SetOffset(int i, int j, int k)
		{
			offsets[i + j * 32] = k;
			dataFile.Seek((i + j * 32) * 4, SeekOrigin.Begin);
			dataFile.WriteInt(k);
		}

		/// <exception cref="System.IO.IOException"/>
		private void SetChunkTimestamp(int i, int j, int k)
		{
			chunkTimestamps[i + j * 32] = k;
			dataFile.Seek(4096 + (i + j * 32) * 4, SeekOrigin.Begin);
			dataFile.WriteInt(k);
		}

		/// <exception cref="System.IO.IOException"/>
		public virtual void Close()
		{
			dataFile.Close();
			dataFileIn.Close();
		}

		bool _disposed = false;
		public void Dispose()
		{
			if (_disposed) return;

			_disposed = true;

			Close();
		}

		private static readonly byte[] emptySector = new byte[4096];

		private readonly string fileName;

		//private java.io.RandomAccessFile dataFile;
		FileStream fs;
		private DataOutputStream dataFile;
		private DataInputStream dataFileIn;

		private readonly int[] offsets = new int[1024];

		private readonly int[] chunkTimestamps = new int[1024];

		private System.Collections.ArrayList sectorFree;

		private int sizeDelta;

		private long lastModified;
	}
}
