#region License
// The MIT License (MIT)
//
// Copyright (c) 2020 Wanzyee Studio
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace SavingSystem
{
    internal static class JsonHelperExtensions
    {
        private static StringBuilder CreateStringBuilderWithSpaceAfter(string message)
        {
            var builder = new StringBuilder(message);

            if (message.EndsWith("."))
            {
                builder.Append(' ');
            }
            else if (!message.EndsWith(". "))
            {
                builder.Append(". ");
            }

            return builder;
        }

        [return: MaybeNull]
        public static T ReadViaSerializer<T>(this JsonReader reader, JsonSerializer serializer)
        {
            reader.Read();
            return serializer.Deserialize<T>(reader);
        }

        public static float? ReadAsFloat(this JsonReader reader)
        {
            // https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/issues/46

            var str = reader.ReadAsString();

            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            else if (float.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out var valueParsed))
            {
                return valueParsed;
            }
            else
            {
                return 0f;
            }
        }

        public static byte? ReadAsInt8(this JsonReader reader)
        {
            return checked((byte)(reader.ReadAsInt32() ?? 0));
        }
    }
}