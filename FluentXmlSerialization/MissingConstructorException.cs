using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace FluentXmlSerialization
{
    [Serializable]
    public class MissingConstructorException : Exception
    {
        public MissingConstructorException(Type type)
            : base(String.Format(
                CultureInfo.InvariantCulture,
                "'{0}' is missing a parameterless constructor.",
                type.AssemblyQualifiedName))
        {}

        protected MissingConstructorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {}
    }
}