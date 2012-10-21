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
    /// Description of IgnorePart.
    /// </summary>
    public class IgnorePart : IIgnoreMappingProvider
    {
        private Type type;
        private Member member;
        
        public IgnorePart(Type classType, Member classMember)
        {
            this.type = classType;
            this.member = classMember;
        }
        
        public IgnoreMapping GetIgnoreMapping()
        {
            return new IgnoreMapping(this.member);
        }
    }
}
