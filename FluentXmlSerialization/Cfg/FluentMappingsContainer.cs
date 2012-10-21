//-----------------------------------------------------------------------
// <copyright file="MappingConfiguration.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;

namespace FluentXmlSerialization.Cfg
{
    /// <summary>
    /// Description of FluentMappingsContainer.
    /// </summary>
    public class FluentMappingsContainer
    {
        private readonly IList<Assembly> assemblies = new List<Assembly>();
                
        public FluentMappingsContainer AddFromAssemblyOf<T>()
        {
            return this.AddFromAssembly(typeof(T).Assembly);
        }

        public FluentMappingsContainer AddFromAssembly(Assembly assembly)
        {
            this.assemblies.Add(assembly);
            this.WasUsed = true;
            return this;
		}
        
        internal bool WasUsed { get; set; }
        
        internal void Apply(OverridesModel model)
        {
            foreach (var assembly in this.assemblies)
            {
                model.AddMappingsFromAssembly(assembly);
            }
        }
    }
}
