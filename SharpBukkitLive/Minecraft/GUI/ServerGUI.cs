// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	//[System.Serializable]
	//public class ServerGUI : javax.swing.JComponent, net.minecraft.src.ICommandListener
	//{
	//	// Referenced classes of package net.minecraft.src:
	//	//            ICommandListener, ServerWindowAdapter, GuiStatsComponent, PlayerListBox, 
	//	//            GuiLogOutputHandler, ServerGuiCommandListener, ServerGuiFocusAdapter
	//	public static void InitGui(net.minecraft.server.MinecraftServer minecraftserver)
	//	{
	//		try
	//		{
	//			javax.swing.UIManager.SetLookAndFeel(javax.swing.UIManager.GetSystemLookAndFeelClassName
	//				());
	//		}
	//		catch (System.Exception)
	//		{
	//		}
	//		net.minecraft.src.ServerGUI servergui = new net.minecraft.src.ServerGUI(minecraftserver
	//			);
	//		javax.swing.JFrame jframe = new javax.swing.JFrame("Minecraft server");
	//		jframe.Add(servergui);
	//		jframe.Pack();
	//		jframe.SetLocationRelativeTo(null);
	//		jframe.SetVisible(true);
	//		jframe.AddWindowListener(new net.minecraft.src.ServerWindowAdapter(minecraftserver
	//			));
	//	}

	//	public ServerGUI(net.minecraft.server.MinecraftServer minecraftserver)
	//	{
	//		mcServer = minecraftserver;
	//		SetPreferredSize(new java.awt.Dimension(854, 480));
	//		SetLayout(new java.awt.BorderLayout());
	//		try
	//		{
	//			Add(GetLogComponent(), "Center");
	//			Add(GetStatsComponent(), "West");
	//		}
	//		catch (System.Exception exception)
	//		{
	//			Sharpen.Runtime.PrintStackTrace(exception);
	//		}
	//	}

	//	private javax.swing.JComponent GetStatsComponent()
	//	{
	//		javax.swing.JPanel jpanel = new javax.swing.JPanel(new java.awt.BorderLayout());
	//		jpanel.Add(new net.minecraft.src.GuiStatsComponent(), "North");
	//		jpanel.Add(GetPlayerListComponent(), "Center");
	//		jpanel.SetBorder(new javax.swing.border.TitledBorder(new javax.swing.border.EtchedBorder
	//			(), "Stats"));
	//		return jpanel;
	//	}

	//	private javax.swing.JComponent GetPlayerListComponent()
	//	{
	//		net.minecraft.src.PlayerListBox playerlistbox = new net.minecraft.src.PlayerListBox
	//			(mcServer);
	//		javax.swing.JScrollPane jscrollpane = new javax.swing.JScrollPane(playerlistbox, 
	//			22, 30);
	//		jscrollpane.SetBorder(new javax.swing.border.TitledBorder(new javax.swing.border.EtchedBorder
	//			(), "Players"));
	//		return jscrollpane;
	//	}

	//	private javax.swing.JComponent GetLogComponent()
	//	{
	//		javax.swing.JPanel jpanel = new javax.swing.JPanel(new java.awt.BorderLayout());
	//		javax.swing.JTextArea jtextarea = new javax.swing.JTextArea();
	//		logger.AddHandler(new net.minecraft.src.GuiLogOutputHandler(jtextarea));
	//		javax.swing.JScrollPane jscrollpane = new javax.swing.JScrollPane(jtextarea, 22, 
	//			30);
	//		jtextarea.SetEditable(false);
	//		javax.swing.JTextField jtextfield = new javax.swing.JTextField();
	//		jtextfield.AddActionListener(new net.minecraft.src.ServerGuiCommandListener(this, 
	//			jtextfield));
	//		jtextarea.AddFocusListener(new net.minecraft.src.ServerGuiFocusAdapter(this));
	//		jpanel.Add(jscrollpane, "Center");
	//		jpanel.Add(jtextfield, "South");
	//		jpanel.SetBorder(new javax.swing.border.TitledBorder(new javax.swing.border.EtchedBorder
	//			(), "Log and chat"));
	//		return jpanel;
	//	}

	//	public virtual void Log(string s)
	//	{
	//		logger.Info(s);
	//	}

	//	public virtual string GetUsername()
	//	{
	//		return "CONSOLE";
	//	}

	//	internal static net.minecraft.server.MinecraftServer GetMinecraftServer(net.minecraft.src.ServerGUI
	//		 servergui)
	//	{
	//		return servergui.mcServer;
	//	}

	//	public static java.util.logging.Logger logger = java.util.logging.Logger.GetLogger
	//		("Minecraft");

	//	private net.minecraft.server.MinecraftServer mcServer;
	//}
}
