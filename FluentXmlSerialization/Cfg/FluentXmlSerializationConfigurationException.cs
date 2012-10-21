//-----------------------------------------------------------------------
// <copyright file="FluentConfiguration.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FluentXmlSerialization.Cfg
{
    /// <summary>
    /// Desctiption of FluentXmlSerializationConfigurationException.
    /// </summary>
    public class FluentXmlSerializationConfigurationException : Exception, ISerializable
    {
        public FluentXmlSerializationConfigurationException()
        {
            // empty
        }

         public FluentXmlSerializationConfigurationException(string message) : this(message, null)
        {
             // empty
        }

        public FluentXmlSerializationConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
            this.PossibleReasons = new List<string>();
        }

        // This constructor is needed for serialization.
        protected FluentXmlSerializationConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.PossibleReasons = info.GetValue("PossibleReasons", typeof(IList<string>)) as List<string>; 
        }
        
        public IList<string> PossibleReasons { get; private set; }
    }
}