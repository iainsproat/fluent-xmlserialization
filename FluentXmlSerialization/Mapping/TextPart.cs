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
    /// Description of TextPart.
    /// </summary>
    public class TextPart : ITextMappingProvider
    {
        private Type type;
        private Member member;
        private Type contType;
        
        public TextPart(Type classType, Member classMember)
        {
            this.type = classType;
            this.member = classMember;
        }
        
        public TextPart Type(Type contentType)
        {
            this.contType = contentType;
            return this;
        }
        
        public TextMapping GetTextMapping()
        {
            TextMapping mapping = new TextMapping(this.member);
            mapping.Type = this.contType;
            return mapping;
        }
    }
}
