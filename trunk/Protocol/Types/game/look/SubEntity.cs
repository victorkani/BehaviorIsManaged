#region License GNU GPL
// SubEntity.cs
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
    public class SubEntity
    {
        public const short Id = 54;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public sbyte bindingPointCategory;
        public sbyte bindingPointIndex;
        public Types.EntityLook subEntityLook;
        
        public SubEntity()
        {
        }
        
        public SubEntity(sbyte bindingPointCategory, sbyte bindingPointIndex, Types.EntityLook subEntityLook)
        {
            this.bindingPointCategory = bindingPointCategory;
            this.bindingPointIndex = bindingPointIndex;
            this.subEntityLook = subEntityLook;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(bindingPointCategory);
            writer.WriteSByte(bindingPointIndex);
            subEntityLook.Serialize(writer);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            bindingPointCategory = reader.ReadSByte();
            if (bindingPointCategory < 0)
                throw new Exception("Forbidden value on bindingPointCategory = " + bindingPointCategory + ", it doesn't respect the following condition : bindingPointCategory < 0");
            bindingPointIndex = reader.ReadSByte();
            if (bindingPointIndex < 0)
                throw new Exception("Forbidden value on bindingPointIndex = " + bindingPointIndex + ", it doesn't respect the following condition : bindingPointIndex < 0");
            subEntityLook = new Types.EntityLook();
            subEntityLook.Deserialize(reader);
        }
        
    }
    
}