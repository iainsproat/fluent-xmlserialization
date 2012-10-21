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
    /// Description of AttributePart.
    /// </summary>
    public class AttributePart : IAttributeMappingProvider
    {
        private Type type;
        private Member member;
        private string attrName;
        private string attrDataType;
        
        public AttributePart(Type classType, Member classMember)
        {
            this.type = classType;
            this.member = classMember;
        }
        
        public AttributePart AttributeName(string name)
        {
            this.attrName = name;
            return this;
        }
        
        public AttributePart DataType(string dataType)
        {
            this.attrDataType = dataType;
            return this;
        }
        
        public AttributeMapping GetAttributeMapping()
        {
            AttributeMapping mapping = new AttributeMapping(this.member);
            mapping.AttributeName = this.attrName;
            mapping.DataType = this.attrDataType;
            return mapping;
        }
    }
}
