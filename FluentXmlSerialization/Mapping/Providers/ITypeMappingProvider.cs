//-----------------------------------------------------------------------
// <copyright file="IRootMappingProvider.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;


using FluentXmlSerialization.MappingModel;

namespace FluentXmlSerialization.Mapping.Providers
{
    /// <summary>
    /// Description of ITypeMappingProvider.
    /// </summary>
    public interface ITypeMappingProvider
    {
        TypeMapping GetTypeMapping();
    }
}
