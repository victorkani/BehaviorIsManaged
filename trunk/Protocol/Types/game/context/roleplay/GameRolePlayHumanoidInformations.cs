#region License GNU GPL
// GameRolePlayHumanoidInformations.cs
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
using BiM.Core.IO;

namespace BiM.Protocol.Types
{
    public class GameRolePlayHumanoidInformations : GameRolePlayNamedActorInformations
    {
        public const short Id = 159;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public Types.HumanInformations humanoidInfo;
        public int accountId;
        
        public GameRolePlayHumanoidInformations()
        {
        }
        
        public GameRolePlayHumanoidInformations(int contextualId, Types.EntityLook look, Types.EntityDispositionInformations disposition, string name, Types.HumanInformations humanoidInfo, int accountId)
         : base(contextualId, look, disposition, name)
        {
            this.humanoidInfo = humanoidInfo;
            this.accountId = accountId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(humanoidInfo.TypeId);
            humanoidInfo.Serialize(writer);
            writer.WriteInt(accountId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            humanoidInfo = Types.ProtocolTypeManager.GetInstance<Types.HumanInformations>(reader.ReadShort());
            humanoidInfo.Deserialize(reader);
            accountId = reader.ReadInt();
            if (accountId < 0)
                throw new Exception("Forbidden value on accountId = " + accountId + ", it doesn't respect the following condition : accountId < 0");
        }
        
    }
    
}