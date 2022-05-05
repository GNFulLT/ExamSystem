using Autofac;
using System;
using System.Reflection;

namespace ExamSystem.Core
{
    public static class Resolver
    {
        public static Assembly currAssembly;
        private static IContainer container;

        public static void Initialize(IContainer container)
        {
            Resolver.container = container;
        }
        
        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

    }
}
