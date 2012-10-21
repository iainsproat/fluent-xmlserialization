//-----------------------------------------------------------------------
// <copyright file="IgnorePart.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;

using FluentXmlSerialization.MappingModel;

namespace FluentXmlSerialization.Mapping.Providers
{
    /// <summary>
    /// Description of IElementMappingProvider.
    /// </summary>
    public interface IElementMappingProvider
    {
        ElementMapping GetElementMapping();
    }
}
