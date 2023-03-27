﻿using Castle.DynamicProxy;
using Obilet.Core.Attributes;
using System.Reflection;

namespace Obilet.Core.Interceptors {

	public abstract class BaseInterceptor<TAttribute> : IInterceptor where TAttribute : BaseAttribute {

		protected virtual void OnBefore(IInvocation invocation, TAttribute attribute) { }

		protected virtual void OnAfter(IInvocation invocation, TAttribute attribute) { }

		protected virtual void OnException(IInvocation invocation, Exception ex, TAttribute attribute) { }

		protected virtual void OnSuccess(IInvocation invocation, TAttribute attribute) { }

		public virtual void Intercept(IInvocation invocation) {

			var attribute = GetAttribute(invocation.MethodInvocationTarget, invocation.TargetType);

			if (attribute is null) invocation.Proceed();
			else {
				var succeeded = true;
				OnBefore(invocation, attribute);
				try {
					invocation.Proceed();
				}
				catch (Exception ex) {
					succeeded = false;
					OnException(invocation, ex, attribute);
					throw;
				}
				finally {
					if (succeeded) OnSuccess(invocation, attribute);
				}
				OnAfter(invocation, attribute);
			}
		}

		private TAttribute? GetAttribute(MethodInfo methodInfo, Type type) {

			var attribute = methodInfo.GetCustomAttribute<TAttribute>(true);
			if (attribute is not null) return attribute;
			return type.GetTypeInfo().GetCustomAttribute<TAttribute>(true);
		}

	}
}
