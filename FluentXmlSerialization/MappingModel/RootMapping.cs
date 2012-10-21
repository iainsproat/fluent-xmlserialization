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
    /// Description of RootMapping.
    /// </summary>
    public class RootMapping
    {
        public string ElementName { get; set; }
        public string NameSpace { get; set; }
        
        public XmlRootAttribute GetRootAttribute()
        {
            XmlRootAttribute root = new XmlRootAttribute();
            
            if (!string.IsNullOrWhiteSpace(this.ElementName))
            {
                root.ElementName = this.ElementName;
            }
            
            if (!string.IsNullOrWhiteSpace(this.NameSpace))
            {
                root.Namespace = this.NameSpace;
            }
            
            return root;
        }
    }
}
