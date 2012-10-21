//-----------------------------------------------------------------------
// <copyright file="ClassMap.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;

using FluentXmlSerialization.Mapping.Providers;
using FluentXmlSerialization.MappingModel;

namespace FluentXmlSerialization.Mapping
{
    /// <summary>
    /// Description of MemberPart.
    /// </summary>
    public class ElementPart : IElementMappingProvider
    {
        private Type type;
        private Member member;
        private string eleName;
        private string eleNamespace;
        private Type eleType;
        
        public ElementPart(Type classType, Member classMember)
        {
            this.type = classType;
            this.member = classMember;
        }
        
        public ElementPart ElementName(string name)
        {
            this.eleName = name;
            return this;
        }
        
        public ElementPart Namespace(string elementNamespace)
        {
            this.eleNamespace = elementNamespace;
            return this;
        }
        
        public ElementPart Type(Type elementType)
        {
            this.eleType = elementType;
            return this;
        }
        
        public ElementMapping GetElementMapping()
        {
            ElementMapping mapping = new ElementMapping(this.member);
            
            if (!string.IsNullOrWhiteSpace(this.eleName))
            {
                mapping.ElementName = this.eleName;
            }
            
            if (!string.IsNullOrWhiteSpace(this.eleNamespace))
            {
                mapping.Namespace = this.eleNamespace;
            }
            
            if (this.eleType != null)
            {
                mapping.Type = this.eleType;
            }
            
            return mapping;
        }
    }
}
