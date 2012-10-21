//-----------------------------------------------------------------------
// <copyright file="ITextMappingProvider.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Xml.Serialization;

namespace FluentXmlSerialization.MappingModel
{
    /// <summary>
    /// Description of TextMapping.
    /// </summary>
    public class TextMapping
    {
        public TextMapping(Member memb)
        {
            this.Member = memb;
        }
        
        public Member Member { get; private set; }
        
        public Type Type { get; set; }
        
        public XmlTextAttribute GetTextAttribute()
        {
            XmlTextAttribute attr = new XmlTextAttribute();
            if (this.Type != null)
            {
                attr.Type = this.Type;
            }
            return attr;
        }
    }
}
