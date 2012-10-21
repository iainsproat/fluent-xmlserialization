//-----------------------------------------------------------------------
// <copyright file="ClassMap.cs" company="Iain Sproat">
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
    /// Description of TypePart.
    /// </summary>
    public class TypePart : ITypeMappingProvider
    {
        private readonly Type entityType;
        private string name;
        private string ns;
        
        
        internal TypePart(Type entity)
        {
            this.entityType = entity;
        }
        
        public TypePart TypeName(string typName)
        {
            this.name = typName;
            return this;
        }
        
        public TypePart Namespace(string typeNamespace)
        {
            this.ns = typeNamespace;
            return this;
        }
        
        public TypeMapping GetTypeMapping()
        {
            return new TypeMapping{
                TypeName = this.name,
                Namespace = this.ns
            };
        }
    }
}
