//-----------------------------------------------------------------------
// <copyright file="ClassMapping.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Xml.Serialization;

namespace FluentXmlSerialization.MappingModel
{
    /// <summary>
    /// Description of TypeMapping.
    /// </summary>
    public class TypeMapping
    {
        public string TypeName { get; set; }
        
        public string Namespace { get; set; }
        
        public XmlTypeAttribute GetTypeAttribute()
        {
            XmlTypeAttribute type = new XmlTypeAttribute();

            if (!string.IsNullOrWhiteSpace(this.TypeName))
            {
                type.TypeName = this.TypeName;
            }
            
            if (!string.IsNullOrWhiteSpace(this.Namespace))
            {
                type.Namespace = this.Namespace;
            }
            
            return type;
        }
    }
}
