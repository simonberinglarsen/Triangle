using Autofac;
using SchantzDemo.Services;

namespace SchantzDemo
{
    class Program
    { 
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // setup dependencies using autofac
            var builder = new ContainerBuilder();
            builder.RegisterType<Logger>().As<ILogger>();
            builder.RegisterType<FloatArrayParser>().As<IArgumentParser>();
            builder.RegisterType<TriangleFactory>().As<ITriangleFactory>();
            builder.RegisterType<SchantzDemo>().As<SchantzDemo>();
            var container = builder.Build();

            // run demo
            using (var scope = container.BeginLifetimeScope())
            {
                var demo = scope.Resolve<SchantzDemo>();
                demo.Run(args);
            }
        }
    }
}