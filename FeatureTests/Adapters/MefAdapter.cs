using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Registration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.FeatureTests.Adapters
{
    public class MefAdapter : FrameworkAdapterBase
    {
        private RegistrationBuilder registrationBuilder;
        private CompositionContainer container;
        private AggregateCatalog aggregateCatalog;

        public MefAdapter() 
        {
            registrationBuilder = new RegistrationBuilder();

            aggregateCatalog = new AggregateCatalog();
            aggregateCatalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly(), registrationBuilder));

           container = new CompositionContainer(aggregateCatalog);
        }

        public override Assembly FrameworkAssembly 
        {
            get { return typeof(RegistrationBuilder).Assembly; }
        }

        public override void RegisterTransient(Type serviceType, Type implementationType) {
            //registrationBuilder.ForType(implementationType).Export(s => serviceType);
        }

        public override void RegisterInstance(Type serviceType, object instance) {
            container.ComposeExportedValue(instance);
        }

        public override object Resolve(Type serviceType) {
            return container.GetExports(serviceType, null, null).FirstOrDefault().Value;
        }

        public override void RegisterSingleton(Type serviceType, Type implementationType) {
           throw new NotImplementedException();
        }
    }
}
