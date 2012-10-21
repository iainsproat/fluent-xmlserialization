//-----------------------------------------------------------------------
// <copyright file="OverridesModel.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using FluentXmlSerialization.MappingModel;

namespace FluentXmlSerialization
{
    public interface IMappingProvider
    {
        ClassMapping GetClassMapping();
    }
}
