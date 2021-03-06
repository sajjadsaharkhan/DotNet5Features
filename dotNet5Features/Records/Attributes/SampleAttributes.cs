using System;

namespace dotNet5Features.Records.Attributes
{
    public class SampleAttributes : Attribute
    {
        // this is new short syntax to initilize properties from constructor
        public SampleAttributes(string name) => (Name) = (name);

        // when we add 'init' instead of 'set' we can't change value of this properties when property unless constructor or programmatically from inner class
        public string Name { get; init; }
    }
}
