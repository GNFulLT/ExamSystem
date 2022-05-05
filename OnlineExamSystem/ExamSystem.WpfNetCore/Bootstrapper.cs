using Autofac;
using ExamSystem.Core.ViewModels;
using ExamSystem.Core.ViewModels.LoginPanel;
using ExamSystem.WpfNetCore.Views.LoginPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ExamSystem.WpfNetCore
{
    public class Bootstrapper : Core.Bootstrapper
    {
        public Bootstrapper(Assembly assembly,Type viewType) : base(assembly,viewType)
        {

        }
        protected override void Initialize(Assembly assembly, Type viewType)
        {
            base.Initialize(assembly, viewType);

            foreach (var type in assembly.DefinedTypes.Where(e =>
            e.IsSubclassOf(typeof(UserControl))))
            {
                ContainerBuilder.RegisterType(type.AsType());
            }


        }
    }
}
