

// Generated on 09/23/2012 22:27:06
using System;
using System.Collections.Generic;
using System.Linq;
using BiM.Protocol.Types;
using BiM.Core.IO;
using BiM.Core.Network;

namespace BiM.Protocol.Messages
{
    public class StartupActionsExecuteMessage : NetworkMessage
    {
        public const uint Id = 1302;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        
        public StartupActionsExecuteMessage()
        {
        }
        
        
        public override void Serialize(IDataWriter writer)
        {
        }
        
        public override void Deserialize(IDataReader reader)
        {
        }
        
    }
    
}