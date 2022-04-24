using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Tests
{
    public class Bootstrapper : Core.Bootstrapper
    {
        public Bootstrapper(Assembly assembly,Type viewType) : base(assembly,viewType)
        {

        }
    }
}
