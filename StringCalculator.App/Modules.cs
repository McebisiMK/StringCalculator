using Autofac;
using StringCalculator_Library;
using StringCalculator_Library.IValidations;
using StringCalculator_Library.Validations;

namespace StringCalculator_App
{
    public class Modules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Validator>().As<IValidator>();
            builder.RegisterType<StringCalculator>().As<IStringCalculator>();
        }
    }
}