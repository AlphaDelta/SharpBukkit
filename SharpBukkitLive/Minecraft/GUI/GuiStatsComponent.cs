// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	//[System.Serializable]
	//public class GuiStatsComponent : javax.swing.JComponent
	//{
	//	public GuiStatsComponent()
	//	{
	//		// Referenced classes of package net.minecraft.src:
	//		//            GuiStatsListener, NetworkManager
	//		memoryUse = new int[256];
	//		updateCounter = 0;
	//		displayStrings = new string[10];
	//		SetPreferredSize(new java.awt.Dimension(256, 196));
	//		SetMinimumSize(new java.awt.Dimension(256, 196));
	//		SetMaximumSize(new java.awt.Dimension(256, 196));
	//		(new javax.swing.Timer(500, new net.minecraft.src.GuiStatsListener(this))).Start(
	//			);
	//		SetBackground(java.awt.Color.BLACK);
	//	}

	//	private void UpdateStats()
	//	{
	//		long l = java.lang.Runtime.GetRuntime().TotalMemory() - java.lang.Runtime.GetRuntime
	//			().FreeMemory();
	//		Sharpen.Runtime.Gc();
	//		displayStrings[0] = (new java.lang.StringBuilder()).Append("Memory use: ").Append
	//			(l / 1024L / 1024L).Append(" mb (").Append((java.lang.Runtime.GetRuntime().FreeMemory
	//			() * 100L) / java.lang.Runtime.GetRuntime().MaxMemory()).Append("% free)").ToString
	//			();
	//		displayStrings[1] = (new java.lang.StringBuilder()).Append("Threads: ").Append(net.minecraft.src.NetworkManager
	//			.numReadThreads).Append(" + ").Append(net.minecraft.src.NetworkManager.numWriteThreads
	//			).ToString();
	//		memoryUse[updateCounter++ & 0xff] = (int)((l * 100L) / java.lang.Runtime
	//			.GetRuntime().MaxMemory());
	//		Repaint();
	//	}

	//	public override void Paint(java.awt.Graphics g)
	//	{
	//		g.SetColor(new java.awt.Color(0xffffff));
	//		g.FillRect(0, 0, 256, 192);
	//		for (int i = 0; i < 256; i++)
	//		{
	//			int k = memoryUse[i + updateCounter & 0xff];
	//			g.SetColor(new java.awt.Color(k + 28 << 16));
	//			g.FillRect(i, 100 - k, 1, k);
	//		}
	//		g.SetColor(java.awt.Color.BLACK);
	//		for (int j = 0; j < displayStrings.Length; j++)
	//		{
	//			string s = displayStrings[j];
	//			if (s != null)
	//			{
	//				g.DrawString(s, 32, 116 + j * 16);
	//			}
	//		}
	//	}

	//	internal static void Update(net.minecraft.src.GuiStatsComponent guistatscomponent
	//		)
	//	{
	//		guistatscomponent.UpdateStats();
	//	}

	//	private int[] memoryUse;

	//	private int updateCounter;

	//	private string[] displayStrings;
	//}
}
