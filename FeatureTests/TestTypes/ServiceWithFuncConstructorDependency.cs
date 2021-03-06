﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjection.FeatureTests.TestTypes {
    public class ServiceWithFuncConstructorDependency {
        private readonly Func<IService> factory;

        public ServiceWithFuncConstructorDependency(Func<IService> factory) {
            this.factory = factory;
        }

        public Func<IService> Factory {
            get { return this.factory; } 
        }
    }
}
