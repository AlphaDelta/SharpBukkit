using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AlphaDelta
{
    public partial class JavaProperties : Dictionary<string, string>
    {
        public new string this[string i]
        {
            get { return base.ContainsKey(i) ? base[i] : null; }//base[i]; }
            set { base[i] = (string)value; }
        }

        public bool IgnoreDuplicateKeyErrors = false;

        public void LoadString(string s)
        {
            using (Stream ms = new MemoryStream(Encoding.UTF8.GetBytes(s)))
                Load(ms);
        }

        public void Load(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                Load(fs);
        }

        public void Load(Stream s)
        {
            string line = null;

            bool multiline = false;
            int linenum = 0;
            StringBuilder sb = new StringBuilder();
            char[] buffer = null;
            using (StreamReader sr = new StreamReader(s, System.Text.Encoding.UTF8, false, 8192, true))
                while ((line = sr.ReadLine()) != null)
                {
                    linenum++;

                    /* Skip invalid lines */
                    line = line.TrimStart();
                    if (line.Length < 1 || !multiline && (String.IsNullOrWhiteSpace(line) || line[0] == '#' || line[0] == '!'))
                        continue; //Ignore empty lines (lines must be at least one character), whitespace lines, and comment lines

                    /* Line escaped? */
                    bool escape = false;
                    for (int i = line.Length - 1; i >= 0; i--)
                        if (line[i] == '\\') escape = !escape;
                        else break;

                    /* Parse */
                    if (escape || multiline)
                    {
                        //We're in a multiline value
                        string sub = line.Substring(0, line.Length - (escape ? 1 : 0));

                        if (String.IsNullOrWhiteSpace(sub))
                            continue;

                        sb.Append(sub);

                        if (!escape)
                        {
                            //The current line is not escaped, meaning the multiline value ends on this line
                            string sbs = sb.ToString();
                            sb.Clear();
                            ParseLine(sbs, linenum, buffer);
                        }
                    }
                    else
                        ParseLine(line, linenum, buffer);

                    multiline = escape;
                }

            if (multiline && sb.Length > 0) //uh oh
                ParseLine(sb.ToString(), linenum, buffer);
        }

        void ParseLine(string s, int linenum, char[] buffer)
        {
            //I chose efficiency over memory, so we're allocating 2x the length of s in memory. The reason I've done this is because no unescaped string can be larger than its escaped equivalent in size.
            if (buffer == null || buffer.Length < s.Length)
                buffer = new char[s.Length];

            string key = null;
            string value = "";
            bool esc = false;
            int bi = 0;
            for (int i = 0; i < s.Length; i++)
            {
                /* Escape character */
                if (s[i] == '\\')
                {
                    if (esc)
                        buffer[bi++] = '\\';
                    esc = !esc;

                    continue;
                }

                /* Escape sequence */
                if (esc)
                {
                    if (s[i] == 'r') buffer[bi++] = '\r'; /* Carriage return */
                    else if (s[i] == 'n') buffer[bi++] = '\n'; /* New-line */
                    else if (s[i] == 't') buffer[bi++] = '\t'; /* Tab-space */
                    else if (s[i] == 'f') buffer[bi++] = '\f'; /* Form-feed */
                    else if (s[i] == 'u') /* Unicode */
                    {
                        if (i + 4 > s.Length - 1)
                            throw new PropertyReaderException(linenum, i, "Stream ended in the middle of a unicode escape sequence. Expected \\uXXXX.");

                        string unicode = s.Substring(i + 1, 4);
                        foreach (char c in unicode)
                            if (
                                (c < '0' || c > '9') //0-9
                                && (c < 'A' || c > 'F') //A-F
                                && (c < 'a' || c > 'f') //a-f
                                )
                                throw new PropertyReaderException(linenum, i, $"Unicode escape sequence must be a 4 character hex number. Expected \\uXXXX, saw \\u'{unicode}'.");

                        buffer[bi++] = (char)int.Parse(unicode, System.Globalization.NumberStyles.HexNumber);
                        i += 4;
                    }
                    else buffer[bi++] = s[i];

                    esc = false;

                    continue;
                }

                if (!esc && key == null && (IsDelimiter(s[i]) || IsWhitespace(s[i]) || i == s.Length - 1))
                {
                    /* Ignore whitespace around delimiter */
                    if (IsWhitespace(s[i]))
                    {
                        while (IsWhitespace(s[++i])) ; //Ignore whitespace (left side)
                        if (IsDelimiter(s[i]))
                            while (IsWhitespace(s[++i])) ;  //Ignore whitespace (right side)
                        i--;
                    }
                    else if (i == s.Length - 1 && !IsDelimiter(s[i])) buffer[bi++] = s[i];

                    key = new string(buffer, 0, bi);
                    if (this.ContainsKey(key) && !IgnoreDuplicateKeyErrors)
                        throw new PropertyReaderException(linenum, $"Key '{key}' already exists in properties file");

                    bi = 0;
                    continue;
                }

                buffer[bi++] = s[i];
            }

            if (bi > 0)
                value = new string(buffer, 0, bi);
            this[key] = value;
        }

        bool IsDelimiter(char v)
        {
            return v == '=' || v == ':';
        }

        bool IsWhitespace(char c)
        {
            return c == ' ' || c == '\t' || c == '\f';
        }
    }

}
