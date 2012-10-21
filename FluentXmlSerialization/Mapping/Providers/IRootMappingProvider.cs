//-----------------------------------------------------------------------
// <copyright file="ClassMap.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Xml.Serialization;

using FluentXmlSerialization.MappingModel;

namespace FluentXmlSerialization.Mapping.Providers
{
    /// <summary>
    /// Description of IRootPartProvider.
    /// </summary>
    public interface IRootMappingProvider
    {
        RootMapping GetRootMapping();
    }
}
