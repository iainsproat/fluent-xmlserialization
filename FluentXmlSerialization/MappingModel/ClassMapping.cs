//-----------------------------------------------------------------------
// <copyright file="OverridesModel.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

using FluentXmlSerialization.Mapping.Providers;

namespace FluentXmlSerialization.MappingModel
{
    /// <summary>
    /// Description of ClassMapping.
    /// </summary>
    public class ClassMapping
    {
        private Type classType;
        private RootMapping root;
        private TypeMapping type;
        private IList<Member> knownMembers = new List<Member>();
        private IDictionary<Member, IgnoreMapping> ignores = new Dictionary<Member, IgnoreMapping>();
        private IDictionary<Member, IList<ElementMapping>> elements = new Dictionary<Member, IList<ElementMapping>>();
        private IDictionary<Member, AttributeMapping> attributes = new Dictionary<Member, AttributeMapping>();
        private IDictionary<Member, TextMapping> text = new Dictionary<Member, TextMapping>();
        
        public ClassMapping(Type entityType)
        {
            this.classType = entityType;
        }
        
        public IList<XmlSerializationMapping> GetAllMappings()
        {
            IList<XmlSerializationMapping> mappings = new List<XmlSerializationMapping>();
            
            mappings.Add(new XmlSerializationClassMapping(classType, this.GetClassAttributes()));
            
            foreach (Member member in this.knownMembers)
            {
                mappings.Add( new XmlSerializationMemberMapping(classType, member.Name, this.GetMemberAttributes(member)) );
            }
            return mappings;
        }
        
        
        
        private XmlAttributes GetClassAttributes()
        {
            XmlAttributes attrs = new XmlAttributes();
            if (this.root != null)
            {
                attrs.XmlRoot = this.root.GetRootAttribute();
            }
            
            if (this.type != null)
            {
                attrs.XmlType = this.type.GetTypeAttribute();
            }
            
            return attrs;
        }
        
        private XmlAttributes GetMemberAttributes(Member member)
        {
            XmlAttributes attrs = new XmlAttributes();
            
            if (this.ignores.ContainsKey(member))
            {
                attrs.XmlIgnore = true;
            }
            
            if (this.elements.ContainsKey(member))
            {
                this.CompileElementAttributes(member, attrs.XmlElements.Add);
            }
            
            if (this.attributes.ContainsKey(member))
            {
                attrs.XmlAttribute = this.attributes[member].GetAttributeAttribute();
            }
            
            if (this.text.ContainsKey(member))
            {
                attrs.XmlText = this.text[member].GetTextAttribute();
            }
            
            return attrs;
        }
        
        private void CompileElementAttributes(Member member, Func<XmlElementAttribute, int> add)
        {
            IList<ElementMapping> elementMappings = this.elements[member];
            foreach(ElementMapping mapping in elementMappings)
            {
                add(mapping.GetElementAttribute());
            }
        }
        
        public void SetRoot(IRootMappingProvider rootMappingProvider)
        {
            if (rootMappingProvider == null)
            {
                return;
            }
            
            this.root = rootMappingProvider.GetRootMapping();
        }
        
        public void SetType(ITypeMappingProvider typeMappingProvider)
        {
            if (typeMappingProvider == null)
            {
                return;
            }
            
            this.type = typeMappingProvider.GetTypeMapping();
        }
        
        public void SetIgnores(IList<IIgnoreMappingProvider> ignoreMappingProviders)
        {
            IgnoreMapping ignoreMapping;
            foreach(IIgnoreMappingProvider provider in ignoreMappingProviders)
            {
                ignoreMapping = provider.GetIgnoreMapping();
                this.RegisterIfNewMember(ignoreMapping.Member);
                this.ignores.Add(ignoreMapping.Member, ignoreMapping);
            }
        }
        
        public void SetElements(IList<IElementMappingProvider> elementMappingProviders)
        {
            ElementMapping elementMapping;
            foreach(IElementMappingProvider provider in elementMappingProviders)
            {
                elementMapping = provider.GetElementMapping();
                this.RegisterIfNewMember(elementMapping.Member);
                this.AddElement(elementMapping.Member, elementMapping);
            }
        }
        
        public void SetAttributes(IList<IAttributeMappingProvider> attributeMappingProviders)
        {
            AttributeMapping attributeMapping;
            foreach (IAttributeMappingProvider provider in attributeMappingProviders)
            {
                attributeMapping = provider.GetAttributeMapping();
                this.RegisterIfNewMember(attributeMapping.Member);
                this.attributes.Add(attributeMapping.Member, attributeMapping);
            }
        }
        
        public void SetText(IList<ITextMappingProvider> textMappingProviders)
        {
            TextMapping textMapping;
            foreach (ITextMappingProvider provider in textMappingProviders)
            {
                textMapping = provider.GetTextMapping();
                this.RegisterIfNewMember(textMapping.Member);
                this.text.Add(textMapping.Member, textMapping);
            }
        }
        
        private void RegisterIfNewMember(Member item)
        {
            if (!this.knownMembers.Contains(item))
            {
                this.knownMembers.Add(item);
            }
        }
        
        private void AddElement(Member key, ElementMapping elementMapping)
        {
            if (!this.elements.ContainsKey(key))
            {
                this.elements.Add(key, new List<ElementMapping>());
            }
            
            this.elements[key].Add(elementMapping);
        }
    }
}
