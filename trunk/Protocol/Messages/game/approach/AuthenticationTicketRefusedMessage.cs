

// Generated on 09/23/2012 22:26:46
using System;
using System.Collections.Generic;
using System.Linq;
using BiM.Protocol.Types;
using BiM.Core.IO;
using BiM.Core.Network;

namespace BiM.Protocol.Messages
{
    public class AuthenticationTicketRefusedMessage : NetworkMessage
    {
        public const uint Id = 112;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        
        public AuthenticationTicketRefusedMessage()
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