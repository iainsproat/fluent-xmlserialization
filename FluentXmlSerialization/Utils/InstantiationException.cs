//-----------------------------------------------------------------------
// <copyright file="ReflectHelper.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Runtime.Serialization;

namespace FluentXmlSerialization.Utils
{
    /// <summary>
    /// Description of InstantiationException.
    /// </summary>
    public class InstantiationException : Exception, ISerializable
    {
        private readonly System.Type type;
        
        public InstantiationException()
        {
        }

         public InstantiationException(string message, System.Type instantiatingType) : base(message)
        {
             this.type = instantiatingType;
        }

        public InstantiationException(string message, Exception innerException, System.Type instantiatingType) : base(message, innerException)
        {
            this.type = instantiatingType;
        }

        // This constructor is needed for serialization.
        protected InstantiationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.type = info.GetValue("type", typeof(System.Type)) as System.Type;
        }
        
        public override string Message
		{
            get { return base.Message + this.TypeName(); }
		}
        
        private string TypeName()
        {
            return this.type == null ? string.Empty : this.type.FullName;
        }
    }
}