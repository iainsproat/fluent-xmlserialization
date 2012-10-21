using System;
using System.Linq.Expressions;

namespace FluentXmlSerialization.Utils
{
    public static class ReflectionExtensions
    {
        public static Member ToMember<TMapping, TReturn>(this Expression<Func<TMapping, TReturn>> propertyExpression)
        {
            return ReflectHelper.GetMember(propertyExpression);
        }
    }
}