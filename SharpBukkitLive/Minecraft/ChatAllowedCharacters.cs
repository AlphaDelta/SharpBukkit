// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class ChatAllowedCharacters
	{
		public ChatAllowedCharacters()
		{
		}

		private static string GetAllowedCharacters()
		{
			//string s = string.Empty;
			//try
			//{
			//	java.io.BufferedReader bufferedreader = new java.io.BufferedReader(new java.io.InputStreamReader
			//		((Sharpen.Runtime.GetClassForType(typeof(net.minecraft.src.ChatAllowedCharacters
			//		))).GetResourceAsStream("/font.txt"), "UTF-8"));
			//	string s1 = string.Empty;
			//	do
			//	{
			//		string s2;
			//		if ((s2 = bufferedreader.ReadLine()) == null)
			//		{
			//			break;
			//		}
			//		if (!s2.StartsWith("#"))
			//		{
			//			s = (new java.lang.StringBuilder()).Append(s).Append(s2).ToString();
			//		}
			//	}
			//	while (true);
			//	bufferedreader.Close();
			//}
			//catch (System.Exception)
			//{
			//}
			return " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_'abcdefghijklmnopqrstuvwxyz{|}~⌂ÇüéâäàåçêëèïîìÄÅÉæÆôöòûùÿÖÜø£Ø×ƒáíóúñÑªº¿®¬½¼¡«»";
		}

		public static readonly string allowedCharacters = GetAllowedCharacters();

		public static readonly char[] field_22175_b = new char[] { '/', '\n', '\r', '\t', 
			'\0', '\f', '`', '?', '*', '\\', '<', '>', '|', '"', ':' };
	}
}
