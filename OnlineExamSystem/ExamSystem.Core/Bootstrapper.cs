using Autofac;
using ExamSystem.Core.Utilities.Hashers;
using ExamSystem.Core.Utilities.Services.SubServices.AccountService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExamSystem.Core
{
    public abstract class Bootstrapper
    {

        protected ContainerBuilder ContainerBuilder
        {
            get; private set;
        }
        public Bootstrapper(Assembly assembly,Type viewType)
        {
            Resolver.currAssembly = assembly;
            Initialize(assembly,viewType);
            FinishInitialization();
            LinkViewAndViewModel();
        }
        protected virtual void Initialize(Assembly assembly,Type mainViewType)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            ContainerBuilder = new ContainerBuilder();
           
            foreach (var type in currentAssembly.DefinedTypes.Where(e =>
             e.IsSubclassOf(typeof(ViewModel))))
            {
                ContainerBuilder.RegisterType(type.AsType());
            }
            if(mainViewType != null)
            {
                foreach (var type in assembly.DefinedTypes.Where(e =>
            e.IsSubclassOf(mainViewType)))
                {
                    ContainerBuilder.RegisterType(type.AsType());
                }
            }
            


            //For Dependency Injection
            List<TypeInfo> infos = currentAssembly.DefinedTypes.ToList();
            List<string> addedI = new List<string>();
            List<string> addedC = new List<string>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for(int i = 0; i < infos.Count; i++)
            {
                if (infos[i].Namespace is null)
                    continue;
                if (!infos[i].Namespace.Contains("ExamSystem.Core.Utilities"))
                    continue;
                if (infos[i].IsGenericType)
                    continue;
                if (infos[i].GetTypeInfo().GetCustomAttributes<CompilerGeneratedAttribute>().Any())
                    continue;
                if (!infos[i].Name.StartsWith("I"))
                {
                    if(dict.ContainsKey("I" + infos[i].Name))
                    {
                        int index = dict.GetValueOrDefault("I"+infos[i].Name);
                        ContainerBuilder.RegisterType(infos[i].AsType()).As(infos[index].AsType());
                        addedC.Add(infos[i].Name);
                        addedI.Add(infos[index].Name);
                    }
                    else
                    {
                        dict.Add("I" + infos[i].Name, i);
                    }
                }
                else
                {
                    if (dict.ContainsKey(infos[i].Name))
                    {
                        int index = dict.GetValueOrDefault(infos[i].Name);
                        ContainerBuilder.RegisterType(infos[index].AsType()).As(infos[i].AsType());
                        addedI.Add(infos[i].Name);
                        addedC.Add(infos[index].Name);

                    }
                    else
                    {
                        string key = infos[i].Name.Substring(1);
                        dict.Add(key, i);
                    }
                }
            }
            ContainerBuilder.RegisterType<PasswordHasher_HMACSHA512>().As<IPasswordHasher>();
            int x = 5;
        }
        private void FinishInitialization()
        {
            var container = ContainerBuilder.Build();
            Resolver.Initialize(container);
        }

        public T Resolve<T>()
        {
            return Resolver.Resolve<T>();
        }

        public void LinkViewAndViewModel()
        {
            Type[] types = Resolver.currAssembly.GetTypes();
            foreach(var type in types)
            {
                var attrs = type.GetCustomAttributes();
                foreach (var attr in attrs)
                {
                    if(typeof(ViewForAttribute) == attr.GetType())
                    {
                        var viewFor = attr as ViewForAttribute;
                        viewFor.LinkViewAndViewModel();
                    }
                }
            }
        }
    }
}
