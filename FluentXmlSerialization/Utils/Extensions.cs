//-----------------------------------------------------------------------
// <copyright file="OverridesModel.cs" company="Iain Sproat">
//     Copyright Iain Sproat, 2012.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace FluentXmlSerialization.Utils
{
    /// <summary>
    /// Description of Extensions.
    /// </summary>
    public static class Extensions
    {
        
        public static object InstantiateUsingParameterlessConstructor(this Type type)
        {
            var constructor = ReflectHelper.GetDefaultConstructor(type);

            if (constructor == null)
                throw new MissingConstructorException(type);

            return constructor.Invoke(null);
        }
    }
}
