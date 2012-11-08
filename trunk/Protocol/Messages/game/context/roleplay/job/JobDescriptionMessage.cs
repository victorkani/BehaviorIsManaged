#region License GNU GPL
// JobDescriptionMessage.cs
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
using System.Collections.Generic;
using System.Linq;
using BiM.Protocol.Types;
using BiM.Core.IO;
using BiM.Core.Network;

namespace BiM.Protocol.Messages
{
    public class JobDescriptionMessage : NetworkMessage
    {
        public const uint Id = 5655;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.JobDescription[] jobsDescription;
        
        public JobDescriptionMessage()
        {
        }
        
        public JobDescriptionMessage(Types.JobDescription[] jobsDescription)
        {
            this.jobsDescription = jobsDescription;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort((ushort)jobsDescription.Length);
            foreach (var entry in jobsDescription)
            {
                 entry.Serialize(writer);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadUShort();
            jobsDescription = new Types.JobDescription[limit];
            for (int i = 0; i < limit; i++)
            {
                 jobsDescription[i] = new Types.JobDescription();
                 jobsDescription[i].Deserialize(reader);
            }
        }
        
    }
    
}