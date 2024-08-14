

using PostSharp.Aspects;
namespace task3.aspect
{
    //aspects oriented programming postsharp
    public class LogAspect :OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine($"Entering {args.Method.Name} at {DateTime.UtcNow}");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine($"Exiting {args.Method.Name} at {DateTime.UtcNow}");
        }

        public override void OnException(MethodExecutionArgs args)
        {
            Console.WriteLine($"Exception in {args.Method.Name}: {args.Exception.Message}");
        }
    }
}
