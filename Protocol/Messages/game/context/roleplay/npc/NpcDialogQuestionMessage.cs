#region License GNU GPL
// NpcDialogQuestionMessage.cs
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
    public class NpcDialogQuestionMessage : NetworkMessage
    {
        public const uint Id = 5617;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public short messageId;
        public string[] dialogParams;
        public short[] visibleReplies;
        
        public NpcDialogQuestionMessage()
        {
        }
        
        public NpcDialogQuestionMessage(short messageId, string[] dialogParams, short[] visibleReplies)
        {
            this.messageId = messageId;
            this.dialogParams = dialogParams;
            this.visibleReplies = visibleReplies;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(messageId);
            writer.WriteUShort((ushort)dialogParams.Length);
            foreach (var entry in dialogParams)
            {
                 writer.WriteUTF(entry);
            }
            writer.WriteUShort((ushort)visibleReplies.Length);
            foreach (var entry in visibleReplies)
            {
                 writer.WriteShort(entry);
            }
        }
        
        public override void Deserialize(IDataReader reader)
        {
            messageId = reader.ReadShort();
            if (messageId < 0)
                throw new Exception("Forbidden value on messageId = " + messageId + ", it doesn't respect the following condition : messageId < 0");
            var limit = reader.ReadUShort();
            dialogParams = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                 dialogParams[i] = reader.ReadUTF();
            }
            limit = reader.ReadUShort();
            visibleReplies = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 visibleReplies[i] = reader.ReadShort();
            }
        }
        
    }
    
}