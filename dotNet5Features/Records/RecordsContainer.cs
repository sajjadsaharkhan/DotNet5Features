using dotNet5Features.Records.Attributes;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet5Features.Records
{
    // record as a sample class with 2 properties
    public record Person(string FirstName, string LastName);

    // extend 'Person' class To a child class with the additional properties called 'Subject' with Inheritance
    //      1 - we should to pass args to 'Person' record(class) constructor
    //      2 - this record(class) is seald and we cannot extend another record(class) from this record(class)
    public sealed record Teacher(string FirstName, string LastName, string Subject) : Person(FirstName, LastName);

    // this record(class) wants extended from 'Teacher' but 'Teacher' is seald class.
    //      if we un-Comment th following line we get Syntax-Error
    //public record MathTeacher(string FirstName, string LastName) : Teacher(FirstName, LastName, "Math");

    // Sample record
    public record Sliding(int Page, int PageCount);

    // we can use another record(class) as properties type in records
    // we can add Attributes such as 'Authorize' or custom attributes to records
    // we can use records as inputModels or body from APIs
    [Authorize]
    [SampleAttributes("Salam")]
    public record SampleInputModel(Sliding sliding, string username);

    // a wonderfull feature!! records can have body like class
    //      Note 1 : in this syntax we write fewer code becuse we dont need to decleare properties like class
    //      Note 2 : we can call 'LogFromInnerMethods' from a instance of this record
    public record RecordWithImplementation(string Name)
    {
        public void LogFromInnerMethods()
        {
            Console.WriteLine($"Name is {Name}");
        }
    }

    // we can add computational properties or additional properties to records
    // if we add a additional property with set method we can't initilize it from constructor
    public record RecordWithAdditionalProperties(int Temperature)
    {
        public int Additional { get; set; }
        public float Fahrenheit => Temperature * 1.8f + 32;
    }
}
