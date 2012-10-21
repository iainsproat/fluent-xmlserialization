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
    /// Description of XmlSerializationClassMapping.
    /// </summary>
    public class XmlSerializationClassMapping : XmlSerializationMapping
    {
        public XmlSerializationClassMapping(Type mappingType, XmlAttributes attrs)
            : base(mappingType, attrs)
        {
            // empty
        }
    }
}
