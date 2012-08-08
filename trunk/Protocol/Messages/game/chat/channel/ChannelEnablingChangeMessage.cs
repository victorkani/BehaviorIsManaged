// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'ChannelEnablingChangeMessage.xml' the '27/06/2012 15:54:59'
using System;
using BiM.Core.IO;
using BiM.Core.Network;

namespace BiM.Protocol.Messages
{
	public class ChannelEnablingChangeMessage : NetworkMessage
	{
		public const uint Id = 891;
		public override uint MessageId
		{
			get
			{
				return 891;
			}
		}
		
		public sbyte channel;
		public bool enable;
		
		public ChannelEnablingChangeMessage()
		{
		}
		
		public ChannelEnablingChangeMessage(sbyte channel, bool enable)
		{
			this.channel = channel;
			this.enable = enable;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(channel);
			writer.WriteBoolean(enable);
		}
		
		public override void Deserialize(IDataReader reader)
		{
			channel = reader.ReadSByte();
			if ( channel < 0 )
			{
				throw new Exception("Forbidden value on channel = " + channel + ", it doesn't respect the following condition : channel < 0");
			}
			enable = reader.ReadBoolean();
		}
	}
}