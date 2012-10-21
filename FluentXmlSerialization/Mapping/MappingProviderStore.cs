//-----------------------------------------------------------------------
// <copyright file="ClassMap.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using FluentXmlSerialization.Mapping.Providers;

namespace FluentXmlSerialization.Mapping
{
    /// <summary>
    /// Description of MappingProviderStore.
    /// </summary>
    public class MappingProviderStore
    {
        public IRootMappingProvider Root { get; set; }
        public ITypeMappingProvider Type { get; set; }
        public IList<IIgnoreMappingProvider> Ignores { get; private set; }
        public IList<IElementMappingProvider> Elements { get; private set; }
        public IList<IAttributeMappingProvider> Attributes { get; private set; }
        public IList<ITextMappingProvider> Text { get; private set; }
        
        public MappingProviderStore()
        {
            this.Ignores = new List<IIgnoreMappingProvider>();
            this.Elements = new List<IElementMappingProvider>();
            this.Attributes = new List<IAttributeMappingProvider>();
            this.Text = new List<ITextMappingProvider>();
        }
    }
}
