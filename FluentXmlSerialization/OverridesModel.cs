//-----------------------------------------------------------------------
// <copyright file="MappingConfiguration.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------

namespace FluentXmlSerialization
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Serialization;

    using FluentXmlSerialization.MappingModel;
    using FluentXmlSerialization.Utils;

    /// <summary>
    /// Description of OverridesModel.
    /// </summary>
    public class OverridesModel
    {
        protected readonly IList<IMappingProvider> classProviders = new List<IMappingProvider>();
        private IEnumerable<XmlSerializationMapping> compiledMappings;
        
        public OverridesModel()
        {
            // empty
        }
        
        public void Configure(XmlAttributeOverrides overrides)
        {
            EnsureMappingsBuilt();
            
            foreach(XmlSerializationMapping mapping in this.compiledMappings)
            {
                if (mapping is XmlSerializationClassMapping)
                {
                    overrides.Add(mapping.Type, mapping.Attributes);
                }
                else if (mapping is XmlSerializationMemberMapping)
                {
                    XmlSerializationMemberMapping memberMapping = mapping as XmlSerializationMemberMapping;
                    overrides.Add(memberMapping.Type, memberMapping.Member, memberMapping.Attributes);
                }
            }
        }
        
        public void Add(Type type)
        {
            var mapping = type.InstantiateUsingParameterlessConstructor();

            if (mapping is IMappingProvider)
            {
                this.Add((IMappingProvider)mapping);
            }
            else
            {
                throw new InvalidOperationException(String.Format(
                    CultureInfo.InvariantCulture,
                    "Unsupported mapping type '{0}'",
                    type.FullName));
            }
        }
        
        public void Add(IMappingProvider provider)
        {
            classProviders.Add(provider);
        }
        
        public void AddMappingsFromAssembly(Assembly assembly)
        {
            this.AddMappingsFromSource(new AssemblyTypeSource(assembly));
        }
        
        public void AddMappingsFromSource(ITypeSource source)
        {
            source.GetTypes()
                .Where(x => IsMappingOf<IMappingProvider>(x))
                .Each(this.Add);
        }
        
        private void EnsureMappingsBuilt()
        {
            if (this.compiledMappings != null) return;

            this.compiledMappings = BuildMappings();
        }
        
        public virtual IEnumerable<XmlSerializationMapping> BuildMappings()
        {
            var xmlSerializationAttributes = new List<XmlSerializationMapping>();
            
            foreach (var classMap in this.classProviders)
            {
                AddClass(xmlSerializationAttributes, classMap.GetClassMapping());
            }
            
            return xmlSerializationAttributes;
        }
        
        private void AddClass(IList<XmlSerializationMapping> attributes, ClassMapping classMapping)
        {
            IList<XmlSerializationMapping> attributesForClass = classMapping.GetAllMappings();
            foreach(XmlSerializationMapping mapping in attributesForClass)
            {
                attributes.Add(mapping);
            }
        }
        
        private bool IsMappingOf<T>(Type type)
        {
            return !type.IsGenericType && typeof(T).IsAssignableFrom(type);
        }
    }
}
