//-----------------------------------------------------------------------
// <copyright file="IElementMappingProvider.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Xml.Serialization;

namespace FluentXmlSerialization.MappingModel
{
    /// <summary>
    /// Description of ElementMapping.
    /// </summary>
    public class ElementMapping
    {
        public ElementMapping(Member memb)
        {
            this.Member = memb;
        }
        
        public Member Member { get; private set; }
        
        public string ElementName { get; set; }
        public string Namespace { get; set; }
        public Type Type { get; set; }
        
        public XmlElementAttribute GetElementAttribute()
        {
            XmlElementAttribute attr = new XmlElementAttribute(this.ElementName, this.Type);
            attr.Namespace = this.Namespace;
            return attr;
        }
    }
}
