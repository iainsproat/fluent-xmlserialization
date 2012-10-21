using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentXmlSerialization
{
	/// <summary>
	/// Facade over an assembly for retrieving type instances.
	/// </summary>
	public class AssemblyTypeSource : ITypeSource
	{
		readonly Assembly source;

		public AssemblyTypeSource(Assembly source)
		{
			if (source == null) throw new ArgumentNullException("source");

			this.source = source;
		}

		#region ITypeSource Members

		public IEnumerable<Type> GetTypes()
		{
			return source.GetTypes().OrderBy(x => x.FullName);
		}

		public string GetIdentifier()
		{
			return source.GetName().FullName;
		}

		#endregion

		public override int GetHashCode()
		{
			return source.GetHashCode();
		}
	}
}