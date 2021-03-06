using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet5Features.InitOnlySetters
{
    public class SampleInitClass
    {        
        // this is new short syntax to initilize properties from constructor
        public SampleInitClass(int initFromConstructor)
            => (InitFromConstructor) = (initFromConstructor);
    
        //we can initilize this property when create instance of this object in constructor
        public int InitFromConstructor { get; init; }

        //we can initilize this property when create instance of this object in object initilizer
        public int InitFromObjectInitializer { get; init; }

        // we can initilize and change value of this property whereever we need to change!
        public int NormalProperty { get; set; }

        // we cannot change value of this propery no where!
        public int ReadOnlyProperty { get; }
    }
}
