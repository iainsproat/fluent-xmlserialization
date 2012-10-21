//-----------------------------------------------------------------------
// <copyright file="MappingProviderStore.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;

using FluentXmlSerialization.MappingModel;

namespace FluentXmlSerialization.Mapping.Providers
{
    /// <summary>
    /// Description of ITextMappingProvider.
    /// </summary>
    public interface ITextMappingProvider
    {
        TextMapping GetTextMapping();
    }
}
