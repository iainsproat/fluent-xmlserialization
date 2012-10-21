//-----------------------------------------------------------------------
// <copyright file="AttributePart.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Xml.Serialization;

namespace FluentXmlSerialization.MappingModel
{
    /// <summary>
    /// Description of AttributeMapping.
    /// </summary>
    public class AttributeMapping
    {
        public AttributeMapping(Member memb)
        {
            this.Member = memb;
        }
        
        public Member Member { get; private set; }
        
        public string AttributeName { get; set; }
        public string DataType { get; set; }
        
        public XmlAttributeAttribute GetAttributeAttribute()
        {
            XmlAttributeAttribute attr = new XmlAttributeAttribute();
            
            if (!string.IsNullOrWhiteSpace(this.AttributeName))
            {
                attr.AttributeName = this.AttributeName;
            }
            
            if (!string.IsNullOrWhiteSpace(this.DataType))
            {
                attr.DataType = this.DataType;
            }
            
            return attr;
        }
    }
}
