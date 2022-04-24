***This project is under development***

# **ExamSystem**
- C# WPF
- Vanilla MVVM (Without any framework)
- TDD (NUnit Tests)
- Wrappers C++
- MongoDB Cloud Database
- Localization

This application use MongoDB Atlas Database and use NoSql. Includes MVVM, TDD pattern and conform to the SOLID principles, Dependency Injection etc...
## Design Tools
- [MaterialDesignInXaml](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit)

## Technical requirements
To be able to debug or run in visual studio, you will need to have .NET Standart 2.1 and .NET 5.0 and this project created in Visual Studio 2019 Community Version. 
### Nuget Packages That Should Be Emphasized
- AutoFac
- PropertyChanged.Fody
## Project overview
ExamSystem is a project that easily configure for another platforms or frameworks with supporting MVVM design pattern. ExamSystem mainly contains two seperate parts. These are : 
### ExamSystem.Core
This is which holds viewmodels models and utilities. This application's targeted framework is class library so it shares its contents with any project that referenced this.
### ExamSystem.{Platform}
This is which holds views,custom controls and converters (if any view needs it). It fetch the binding contents from ExamSystem.Core so you just need to build your view that depend on a specific platform and bind the content to viewmodel that stands in ExamSystem.Core. 

## Obligations That ExamSystem.{Platform} have to conform to

Every Page, Window or what equivalent is for these have to have ViewFor Attribute and must take its viewmodel as a paramater. Datacontext must be specified in ctor. An example:

```
[ViewFor(typeof(CustomView),typeof(CustomViewModel))]
   public partial class CustomView : Window{
   public CustomView(CustomViewModel viewModel){
               InitializeComponent();
               DataContext = viewModel;
   }
   }
```

With this attribute, project knows what should i get a instance for this viewmodel. There will be thrown an exception if this attribute is not used.

Every ExamSystem.{Platform} have to write their own startup method and have a Bootstrapper class that is inherited from ExamSystem.Core.Bootstrapper after than it needs to send its current assembly and the TypeOfView that is type of startup screen as a paramater to the ctor. Example usage :

`public class Bootstrapper : Core.Bootstrapper
    {
        public Bootstrapper(Assembly assembly,Type viewType) : base(assembly,viewType)
        {
        }}`
        
And in startup method, create a Bootstrapper object. Initialization processes are used in the ctor so you don't need to use any method for initialization.

 `            Bootstrapper strapper = new Bootstrapper(Assembly.GetExecutingAssembly(),typeof(Window));
`

And finally after creating strapper we need to Resolve startup view and show it

`
Application.Current.MainWindow = strapper.Resolve<LoginScreenView>();
            Application.Current.MainWindow.Show();
`

## Handling Localization
With LocalableProperty Attribute, We specify a property that we want to use text that stands in {LANG}.localization.json with LocalableProperty Attribute. After that when we use generic methods that Localization.SetDefaultLocalization or Localization.SetLocalization(), its implement text to property which has LocalableProperty Attribute automatically. Lastly we can specify name of json key property by change the attribute ctor paramater.

`[LocalableProperty($"{specifiedName}")]`

## Handling ExamSystem.Core Problems
.NET Standarts doesn't have any Command, CommandManager, ValidationRules classess. So we need to implement them with own declarations. You can found custom these classes in ExamSystem.Core namespace.

## Handling automatically ContainerBuilder.Register for dependency injection.
It uses O(n) time complexity approach with using Dictionaries. Simple codes here : 
```           
List<TypeInfo> infos = currentAssembly.DefinedTypes.ToList();
 Dictionary<string, int> dict = new Dictionary<string, int>();
            for(int i = 0; i < infos.Count; i++)
            {
                if (infos[i].Namespace is null)
                    continue;
                if (!infos[i].Namespace.Contains("ExamSystem.Core.Utilities"))
                    continue;
                if (infos[i].IsGenericType)
                    continue;
                if (!infos[i].Name.StartsWith("I"))
                {
                    if(dict.ContainsKey("I" + infos[i].Name))
                    {
                        int index = dict.GetValueOrDefault("I"+infos[i].Name);
                        ContainerBuilder.RegisterType(infos[i].AsType()).As(infos[index].AsType());
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

                    }
                    else
                    {
                        string key = infos[i].Name.Substring(1);
                        dict.Add(key, i);
                    }
                }
            }
```

And if we have a class that is not in ExamSystem.Core.Utilities namespace we can just specify it by use these : 

`                if (!infos[i].Namespace.Contains("ExamSystem.Core.Utilities") && !infos[i].Namespace.Contains("ExamSystem.Core.{NameSpace}"))
`
