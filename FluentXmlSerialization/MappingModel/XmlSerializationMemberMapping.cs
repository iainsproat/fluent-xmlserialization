//-----------------------------------------------------------------------
// <copyright file="XmlSerializationMapping.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Xml.Serialization;

namespace FluentXmlSerialization.MappingModel
{
    /// <summary>
    /// Description of XmlSerializationMemberMapping.
    /// </summary>
    public class XmlSerializationMemberMapping : XmlSerializationMapping
    {
        public XmlSerializationMemberMapping(Type mappingType, string memberName, XmlAttributes attrs)
            : base(mappingType, attrs)
        {
            this.Member = memberName;
        }
        
        public string Member
        {
            get;
            private set;
        }
    }
}
