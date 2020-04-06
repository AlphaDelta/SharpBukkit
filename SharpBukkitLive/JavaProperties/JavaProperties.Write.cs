using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AlphaDelta
{
    public partial class JavaProperties : Dictionary<string, string>
    {
        public PropertyWriterFormat OutputFormat = PropertyWriterFormat.EqualsNoSpaces;

        public void Save(string path)
        {
            using (FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
                Save(fs);
        }

        public void Save(Stream s)
        {
            string delimiter = "=";
            if (OutputFormat == PropertyWriterFormat.EqualsNoSpaces) delimiter = "=";
            else if (OutputFormat == PropertyWriterFormat.EqualsSurroundingSpaces) delimiter = " = ";
            else if (OutputFormat == PropertyWriterFormat.Colon) delimiter = ": ";

            using (StreamWriter sw = new StreamWriter(s, Encoding.UTF8))
            {
                foreach (KeyValuePair<string, string> kv in this)
                {
                    if (kv.Value == null || kv.Value.Length < 1)
                    {
                        //No value, just print key
                        sw.WriteLine(EscapeString(kv.Key, true));
                        continue;
                    }

                    sw.Write(EscapeString(kv.Key, true));
                    sw.Write(delimiter);
                    sw.WriteLine(EscapeString(kv.Value));
                }
                sw.Flush();
            }
        }

        string EscapeString(string s, bool iskey = false)
        {
            StringBuilder sb = new StringBuilder(s.Length + 0x10);

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ':' && iskey) sb.Append(@"\:");
                else if (s[i] == '=' && iskey) sb.Append(@"\=");
                else if (s[i] == '\\') sb.Append(@"\\");
                else if (s[i] == '\t') sb.Append(@"\t");
                else if (s[i] == '\r') sb.Append(@"\r");
                else if (s[i] == '\n') sb.Append(@"\n");
                else if (s[i] == '\f') sb.Append(@"\f");
                else if (s[i] < 0x0020 || s[i] > 0x1FFF || (s[i] >= 0x007F && s[i] <= 0x00A0))
                {
                    sb.Append(@"\u");
                    sb.Append(((int)s[i]).ToString("X4"));
                }
                else sb.Append(s[i]);
            }

            return sb.ToString();
        }
    }
}
