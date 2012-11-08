﻿#region License GNU GPL
// DlmReader.cs
// 
// Copyright (C) 2012 - BehaviorIsManaged
// 
// This program is free software; you can redistribute it and/or modify it 
// under the terms of the GNU General Public License as published by the Free Software Foundation;
// either version 2 of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details. 
// You should have received a copy of the GNU General Public License along with this program; 
// if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
#endregion
using System;
using System.IO;
using BiM.Core.IO;
using BiM.Protocol.Data;

namespace BiM.Protocol.Tools.Dlm
{
    public class DlmReader : IDisposable
    {
        private BigEndianReader m_reader;
        private Stream m_stream;

        public DlmReader(string filePath)
        {
            m_stream = File.OpenRead(filePath);
            m_reader = new BigEndianReader(m_stream);
        }

        public DlmReader(Stream stream)
        {
            m_stream = stream;
            m_reader = new BigEndianReader(m_stream);
        }

        public DlmReader(string filePath, string decryptionKey)
        {
            m_stream = File.OpenRead(filePath);
            m_reader = new BigEndianReader(m_stream);
            DecryptionKey = decryptionKey;
        }

        public DlmReader(Stream stream, string decryptionKey)
        {
            m_stream = stream;
            m_reader = new BigEndianReader(m_stream);
            DecryptionKey = decryptionKey;
        }

        public string DecryptionKey
        {
            get;
            set;
        }

        public Func<int, string> DecryptionKeyProvider
        {
            get;
            set;
        }

        public DlmMap ReadMap()
        {
            m_reader.Seek(0, SeekOrigin.Begin);
            int header = m_reader.ReadByte();

            if (header != 77)
            {
                try
                {
                    m_reader.Seek(0, SeekOrigin.Begin);
                    var output = new MemoryStream();
                    ZipHelper.Deflate(new MemoryStream(m_reader.ReadBytes((int) m_reader.BytesAvailable)), output);

                    var uncompress = output.ToArray();

                    ChangeStream(new MemoryStream(uncompress));

                    header = m_reader.ReadByte();

                    if (header != 77)
                        throw new FileLoadException("Wrong header file");

                }
                catch (Exception ex)
                {
                    throw new FileLoadException("Wrong header file");
                }
            }

            var map = DlmMap.ReadFromStream(m_reader, this);

            return map;
        }

        internal void ChangeStream(Stream stream)
        {
            m_stream.Dispose();
            m_reader.Dispose();

            m_stream = stream;
            m_reader = new BigEndianReader(m_stream);
        }

        public void Dispose()
        {
            m_stream.Dispose();
            m_reader.Dispose();
        }
    }
}