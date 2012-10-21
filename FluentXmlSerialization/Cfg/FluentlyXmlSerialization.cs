//-----------------------------------------------------------------------
// <copyright file="MathMLSerializer.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace FluentXmlSerialization.Cfg
{
    /// <summary>
    /// Fluently configure Xml serialization attribute overrides
    /// </summary>
    public class FluentlyXmlSerialization
    {
        public static FluentConfiguration Configure()
        {
            return new FluentConfiguration();
        }
    }
}
