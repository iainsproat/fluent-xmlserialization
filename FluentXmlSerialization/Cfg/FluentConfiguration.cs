//-----------------------------------------------------------------------
// <copyright file="MathMLSerializer.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FluentXmlSerialization.Cfg
{
    /// <summary>
    /// Description of FluentConfiguration.
    /// </summary>
    public class FluentConfiguration
    {
        // TODO internationalisation?
        private const string ExceptionMessage = "An invalid or incomplete configuration was used while creating XmlAttributeOverrides. Check PossibleReasons collection, and InnerException for more detail.";
        private const string ExceptionMappingMessage = "No mappings were configured through the Mappings method.";
        
        private bool mappingsSet;
        private readonly IList<Action<MappingConfiguration>> mappingsBuilders = new List<Action<MappingConfiguration>>();
        private XmlAttributeOverrides orides;
        
        internal FluentConfiguration()
            : this(new XmlAttributeOverrides())
        {
            // empty
        }
        
        internal FluentConfiguration(XmlAttributeOverrides xmlAttributeOverrides)
        {
            this.orides = xmlAttributeOverrides;
        }
        
        internal XmlAttributeOverrides Overrides
        {
            get
            {
                return this.orides;
            }
        }
        
        public FluentConfiguration Mappings(Action<MappingConfiguration> mappings)
        {
            this.mappingsBuilders.Add(mappings);
            this.mappingsSet = true;
            return this;
        }
        
        public XmlAttributeOverrides BuildOverrides()
        {
            // FIXME
//            try 
//            {
                return this.BuildOverridesImplementation();
//            }
//            catch (Exception ex)
//            {
//                throw CreateConfigurationException(ex);
//            }
        }
        
        private XmlAttributeOverrides BuildOverridesImplementation()
        {
            var mappingConfiguration = new MappingConfiguration();
            
            foreach(var builder in mappingsBuilders)
            {
                builder(mappingConfiguration);
            }
            
            mappingConfiguration.Apply(this.Overrides);
            
            return this.Overrides;
        }
        
        private FluentXmlSerializationConfigurationException CreateConfigurationException(Exception innerException)
        {
            var ex = new FluentXmlSerializationConfigurationException(ExceptionMessage, innerException);

            if (!mappingsSet)
            {
                ex.PossibleReasons.Add(ExceptionMappingMessage);
            }
            
            return ex;
        }
        
        
        
    }
}
