using BenchmarkDotNet.Attributes;

namespace ReflectionPerformance
{
    public class Runner
    {
        private Calculator _calc = new Calculator();

        [Benchmark]
        public void DirectMethodCall() => _calc.Add(2, 3);

        [Benchmark]
        public void ReflectionMethodCall()
        {
            var methodInfo = _calc.GetType().GetMethod("Add");
            methodInfo.Invoke(_calc, new object[] { 2, 3 });
        }
    }
}