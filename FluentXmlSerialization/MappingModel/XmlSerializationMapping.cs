//-----------------------------------------------------------------------
// <copyright file="OverridesModel.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Xml.Serialization;

namespace FluentXmlSerialization.MappingModel
{
    /// <summary>
    /// Description of XmlSerializationMapping.
    /// </summary>
    public abstract class XmlSerializationMapping
    {
        public XmlSerializationMapping(Type mappingType, XmlAttributes attrs)
        {
            this.Type = mappingType;
            this.Attributes = attrs;
        }
        
        public Type Type
        {
            get;
            private set;
        }
        
        public XmlAttributes Attributes
        {
            get;
            private set;
        }
    }
}
