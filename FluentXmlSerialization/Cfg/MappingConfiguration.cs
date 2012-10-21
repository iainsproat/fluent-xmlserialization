//-----------------------------------------------------------------------
// <copyright file="FluentConfiguration.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Xml.Serialization;

namespace FluentXmlSerialization.Cfg
{
    /// <summary>
    /// Description of MappingConfiguration.
    /// </summary>
    public class MappingConfiguration
    {
        private OverridesModel model;
        
        public MappingConfiguration()
        {
            this.FluentMappings = new FluentMappingsContainer();
            this.model = new OverridesModel();
        }
        
        public FluentMappingsContainer FluentMappings { get; private set; }
        
        public void Apply(XmlAttributeOverrides overrides)
        {
            this.FluentMappings.Apply(model);
            this.model.Configure(overrides);
        }
    }
}
