using dotNet5Features.InitOnlySetters;
using dotNet5Features.Records;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet5Features.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        //https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#init-only-setters
        // in this API we use a record as inputModel or API body
        [HttpPost("[action]")]
        public IActionResult RecorsUsage(SampleInputModel inputModel)
        {
            // this syntax a new syntax to create new instance from object's
            // this syntax when use type of object was be known
            SampleClass sampleClass = new() { Date = DateTime.Now };
            // Or
            //var sampleClass = new SampleClass() { Date = DateTime.Now };

            // we can init properties with pass values in constructors arg's 
            Teacher teacher = new("Sajjad", "Saharkhan", "Programming");

            // we can copy all of properties of instance to another instance and change some of them and re-init them
            Teacher newTeacher = teacher with { Subject = "Math" };

            // usage of record with methods
            RecordWithImplementation recordWithImplementation = new("Record");
            // we can call method like this...
            recordWithImplementation.LogFromInnerMethods();

            // usage of record with additional properties
            RecordWithAdditionalProperties recordWithAdditionalProperties = new(10);
            // we can set Additional property after create instance of record
            recordWithAdditionalProperties.Additional = 20;
            // we can get computational property value after create instance of record
            Console.WriteLine(recordWithAdditionalProperties.Fahrenheit);

            return Ok("record's learning Done!");
        }

        //https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#init-only-setters
        // in this API we review property set and get value how work! in new version of C#
        [HttpPost("[action]")]
        public IActionResult InitOnlySettersUsage()
        {
            // i explain this new syntax above
            SampleInitClass sampleInit = new(10)
            {
                InitFromConstructor = 20,
                NormalProperty = 50,
                InitFromObjectInitializer = 60
            };

            // Syntax Error! CS8852.
            //      can't set the value of init properties outside of defining
            //sampleInit.InitFromObjectInitializer = 100;
            //sampleInit.InitFromObjectInitializer = 100;

            // the velue of properties after define variable is:
            //      InitFromConstructor : 20 * it's not 10 because object initilizer run after constructor
            //      NormalProperty : 50
            //      InitFromObjectInitializer : 60
            //      ReadOnlyProperty : 0 * we can't change value of this property

            return Ok("Init only setters learning Done!");
        }

        //https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#pattern-matching-enhancements
        // in this API we put some roles in variable with new syntax
        [HttpPost("[action]")]
        public IActionResult PatternMatchingUsage()
        {
            // a sample variable defined to use below.
            char ch = 'F';

            if (ch is (>= 'A' and <= 'Z') or (>= 'a' and <= 'z') or '.')
                Console.WriteLine("is alphabet character");
            // this statement is equal to:
            if ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || ch == '.')
                Console.WriteLine("is alphabet character");

            int? nullableInt = null;
            if (nullableInt is not null)
                Console.WriteLine("the variable is not null");

            return Ok("Pattern matching enhancements learning Done!");
        }
    }
}
