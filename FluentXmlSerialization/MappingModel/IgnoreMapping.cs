//-----------------------------------------------------------------------
// <copyright file="IIgnoreMappingProvider.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Xml.Serialization;

namespace FluentXmlSerialization.MappingModel
{
    /// <summary>
    /// Description of IgnoreMapping.
    /// </summary>
    public class IgnoreMapping
    {
        public IgnoreMapping(Member memb)
        {
            this.Member = memb;
        }
        
        public Member Member { get; private set; }
        
        public XmlIgnoreAttribute GetIgnoreAttribute()
        {
            return new XmlIgnoreAttribute();
        }
    }
}
