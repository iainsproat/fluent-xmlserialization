//-----------------------------------------------------------------------
// <copyright file="MathMLMap.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FluentXmlSerialization.MappingModel;
using FluentXmlSerialization.Utils;

namespace FluentXmlSerialization.Mapping
{
    /// <summary>
    /// Description of ClassMap.
    /// </summary>
    /// <remarks>
    /// Inspired by Fluent NHibernate
    /// </remarks>
    public class ClassMap<T> : IMappingProvider
    {
        readonly MappingProviderStore providers;
        
        public ClassMap()
        {
            this.providers = new MappingProviderStore();
        }
        
        public RootPart Root()
        {
            RootPart part = new RootPart(EntityType);
            providers.Root = part;
            return part;
        }
        
        public TypePart Type()
        {
            TypePart part = new TypePart(EntityType);
            providers.Type = part;
            return part;
        }
        
        public IgnorePart Ignore(Expression<Func<T, object>> memberExpression)
        {
            return this.Ignore(memberExpression.ToMember());
        }
        
        public IgnorePart Ignore(Member member)
        {
            IgnorePart part = new IgnorePart(EntityType, member);
            providers.Ignores.Add(part);
            return part;
        }
        
        public ElementPart Element(Expression<Func<T, object>> memberExpression)
        {
            return this.Element(memberExpression.ToMember());
        }
        
        public ElementPart Element(Member member)
        {
            ElementPart part = new ElementPart(EntityType, member);
            providers.Elements.Add(part);
            return part;
        }
        
        public AttributePart Attribute(Expression<Func<T, object>> memberExpression)
        {
            return this.Attribute(memberExpression.ToMember());
        }
        
        public AttributePart Attribute(Member member)
        {
            AttributePart part = new AttributePart(EntityType, member);
            providers.Attributes.Add(part);
            return part;
        }
        
        public TextPart Text(Expression<Func<T, object>> memberExpression)
        {
            return this.Text(memberExpression.ToMember());
        }
        
        public TextPart Text(Member member)
        {
            TextPart part = new TextPart(EntityType, member);
            providers.Text.Add(part);
            return part;
        }
        
        public ClassMapping GetClassMapping()
        {
            ClassMapping mapping = new ClassMapping(EntityType);
            mapping.SetRoot(providers.Root);
            mapping.SetType(providers.Type);
            mapping.SetIgnores(providers.Ignores);
            mapping.SetElements(providers.Elements);
            mapping.SetAttributes(providers.Attributes);
            mapping.SetText(providers.Text);
            return mapping;
        }
        
        internal Type EntityType
        {
            get { return typeof(T); }
        }
    }
}
