using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Census.Api.Api;
using Census.Contracts;
using Microsoft.AspNetCore.Mvc;
using Shouldly;
using Xunit;

namespace Census.Tests.Conventions
{
    public class AllControllerActionMethods
    {
        [Theory]
        [MemberData(nameof(TestCases))]
        public void MustBeAsync(TestCase testCase)
        {
            testCase.Method.GetCustomAttributes<AsyncStateMachineAttribute>().ShouldHaveSingleItem();
        }

        [Theory]
        [MemberData(nameof(TestCases))]
        public void MustTakeADtoAsAFirstParameter(TestCase testCase)
        {
            var parameterType = testCase.Method.GetParameters()[0].ParameterType;
            var isDtoType = typeof(ICommand).IsAssignableFrom(parameterType) ||
                            typeof(IRequest).IsAssignableFrom(parameterType);
            isDtoType.ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(TestCases))]
        public void MustTakeACancellationTokenAsASecondParameter(TestCase testCase)
        {
            testCase.Method.GetParameters()[1].ParameterType.ShouldBe(typeof(CancellationToken));
        }

        [Theory]
        [MemberData(nameof(TestCases))]
        public void MustHaveTheCorrectNumberOfParameters(TestCase testCase)
        {
            testCase.Method.GetParameters().Length.ShouldBe(2);
        }

        public class TestCase
        {
            public MethodInfo Method { get; }

            public TestCase(MethodInfo method)
            {
                Method = method;
            }

            public override string ToString()
            {
                return $"{Method.DeclaringType.FullName}.{Method.Name}";
            }
        }

        public static IEnumerable<object[]> TestCases()
        {
            return typeof(HomeController).Assembly
                                         .DefinedTypes
                                         .Where(t => typeof(ControllerBase).IsAssignableFrom(t))
                                         .SelectMany(t => t.DeclaredMethods)
                                         .Where(IsActionMethod)
                                         .Select(m => new TestCase(m))
                                         .Select(tc => new object[] {tc})
                                         .ToArray();
        }

        private static bool IsActionMethod(MethodInfo methodInfo)
        {
            // ReSharper disable ConvertIfStatementToReturnStatement
            if (typeof(IActionResult).IsAssignableFrom(methodInfo.ReturnType)) return true;
            if (typeof(Task<IActionResult>).IsAssignableFrom(methodInfo.ReturnType)) return true;
            return false;
        }
    }
}