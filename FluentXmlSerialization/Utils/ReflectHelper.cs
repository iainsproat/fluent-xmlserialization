//-----------------------------------------------------------------------
// <copyright file="Extensions.cs" company="NHibernate">
//    http://www.gnu.org/licenses/lgpl-2.1-standalone.html
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace FluentXmlSerialization.Utils
{
    /// <summary>
    /// Description of ReflectHelper.
    /// </summary>
    public class ReflectHelper
    {
        private static readonly Type[] NoClasses = Type.EmptyTypes;
        
        public static ConstructorInfo GetDefaultConstructor(Type type)
		{
			if (ReflectHelper.IsAbstractClass(type))
			{
				return null;
			}
			ConstructorInfo result;
			try
			{
				ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, CallingConventions.HasThis, ReflectHelper.NoClasses, null);
				result = constructor;
			}
			catch (Exception innerException)
			{
				throw new InstantiationException("A default (no-arg) constructor could not be found for: ", innerException, type);
			}
			return result;
		}
        
        public static bool IsAbstractClass(Type type)
		{
			return type.IsAbstract || type.IsInterface;
		}
        
        public static Member GetMember<TModel, TReturn>(Expression<Func<TModel, TReturn>> expression)
        {
            return GetMember(expression.Body);
        }
        
        private static Member GetMember(Expression expression)
        {
            if (IsIndexedPropertyAccess(expression))
                return GetDynamicComponentProperty(expression).ToMember();
            if (IsMethodExpression(expression))
                return ((MethodCallExpression)expression).Method.ToMember();

            var memberExpression = GetMemberExpression(expression);

            return memberExpression.Member.ToMember();
        }
        
        private static PropertyInfo GetDynamicComponentProperty(Expression expression)
        {
            Type desiredConversionType = null;
            MethodCallExpression methodCallExpression = null;
            var nextOperand = expression;

            while (nextOperand != null)
            {
                if (nextOperand.NodeType == ExpressionType.Call)
                {
                    methodCallExpression = nextOperand as MethodCallExpression;
                    desiredConversionType = desiredConversionType ?? methodCallExpression.Method.ReturnType;
                    break;
                }

                if (nextOperand.NodeType != ExpressionType.Convert)
                    throw new ArgumentException("Expression not supported", "expression");
	            
                var unaryExpression = (UnaryExpression)nextOperand;
                desiredConversionType = unaryExpression.Type;
                nextOperand = unaryExpression.Operand;
            }
                
            var constExpression = methodCallExpression.Arguments[0] as ConstantExpression;
                
            return new DummyPropertyInfo((string)constExpression.Value, desiredConversionType);
        }
        
        private static bool IsIndexedPropertyAccess(Expression expression)
        {
            return IsMethodExpression(expression) && expression.ToString().Contains("get_Item");
        }

        private static bool IsMethodExpression(Expression expression)
        {
            return expression is MethodCallExpression || (expression is UnaryExpression && IsMethodExpression((expression as UnaryExpression).Operand));
        }
        
        private static MemberExpression GetMemberExpression(Expression expression)
        {
            return GetMemberExpression(expression, true);
        }

        private static MemberExpression GetMemberExpression(Expression expression, bool enforceCheck)
        {
            MemberExpression memberExpression = null;
            if (expression.NodeType == ExpressionType.Convert)
            {
                var body = (UnaryExpression) expression;
                memberExpression = body.Operand as MemberExpression;
            }
            else if (expression.NodeType == ExpressionType.MemberAccess)
            {
                memberExpression = expression as MemberExpression;
            }

            if (enforceCheck && memberExpression == null)
            {
                throw new ArgumentException("Not a member access", "expression");
            }

            return memberExpression;
        }
    }
}
