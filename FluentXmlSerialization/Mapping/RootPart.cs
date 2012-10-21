//-----------------------------------------------------------------------
// <copyright file="MathMLMap.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Xml.Serialization;

using FluentXmlSerialization.Mapping.Providers;
using FluentXmlSerialization.MappingModel;

namespace FluentXmlSerialization.Mapping
{
    /// <summary>
    /// Description of RootPart.
    /// </summary>
    public class RootPart : IRootMappingProvider
    {
        private readonly Type entityType;
        private string name;
        private string ns;
        
        internal RootPart(Type entity)
        {
            this.entityType = entity;
        }
        
        public RootPart ElementName(string typeName)
        {
            this.name = typeName;
            return this;
        }
        
        public RootPart Namespace(string rootNamespace)
        {
            this.ns = rootNamespace;
            return this;
        }
        
        public RootMapping GetRootMapping()
        {
            return new RootMapping{
                ElementName = this.name,
                NameSpace = this.ns
            };
        }
    }
}
