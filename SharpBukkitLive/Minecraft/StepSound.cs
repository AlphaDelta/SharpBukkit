// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) braces deadcode 
using Sharpen;

namespace net.minecraft.src
{
	public class StepSound
	{
		public StepSound(string s, float f, float f1)
		{
			field_1029_a = s;
			field_1028_b = f;
			field_1030_c = f1;
		}

		public virtual float GetVolume()
		{
			return field_1028_b;
		}

		public virtual float GetPitch()
		{
			return field_1030_c;
		}

		public virtual string Func_737_c()
		{
			return (new java.lang.StringBuilder()).Append("step.").Append(field_1029_a).ToString
				();
		}

		public readonly string field_1029_a;

		public readonly float field_1028_b;

		public readonly float field_1030_c;
	}
}
