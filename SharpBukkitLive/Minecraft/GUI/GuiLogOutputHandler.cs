// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	//public class GuiLogOutputHandler : java.util.logging.Handler
	//{
	//	public GuiLogOutputHandler(javax.swing.JTextArea jtextarea)
	//	{
	//		// Referenced classes of package net.minecraft.src:
	//		//            GuiLogFormatter
	//		field_998_b = new int[1024];
	//		field_1001_c = 0;
	//		field_999_a = new net.minecraft.src.GuiLogFormatter(this);
	//		SetFormatter(field_999_a);
	//		field_1000_d = jtextarea;
	//	}

	//	public override void Close()
	//	{
	//	}

	//	public override void Flush()
	//	{
	//	}

	//	public override void Publish(java.util.logging.LogRecord logrecord)
	//	{
	//		int i = field_1000_d.GetDocument().GetLength();
	//		field_1000_d.Append(field_999_a.Format(logrecord));
	//		field_1000_d.SetCaretPosition(field_1000_d.GetDocument().GetLength());
	//		int j = field_1000_d.GetDocument().GetLength() - i;
	//		if (field_998_b[field_1001_c] != 0)
	//		{
	//			field_1000_d.ReplaceRange(string.Empty, 0, field_998_b[field_1001_c]);
	//		}
	//		field_998_b[field_1001_c] = j;
	//		field_1001_c = (field_1001_c + 1) % 1024;
	//	}

	//	private int[] field_998_b;

	//	private int field_1001_c;

	//	internal java.util.logging.Formatter field_999_a;

	//	private javax.swing.JTextArea field_1000_d;
	//}
}
