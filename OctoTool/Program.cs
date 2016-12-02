using System;
using System.Linq;

namespace OctoTool {

    class Program {

        static void Main(string[] args) {

            try {
                IoC.Initialize()
                    .GetInstance<IExecutor>()
                    .Execute(args);
            } catch (AggregateException e) {
                e.InnerExceptions
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Message));
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

    }
}
