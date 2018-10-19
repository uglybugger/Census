using System;
using System.Collections.Generic;
using System.Linq;
using Census.Api.Api;
using Microsoft.AspNetCore.Mvc;
using Shouldly;
using Xunit;

namespace Census.Tests.Unit.Conventions
{
    public class AllControllerClasses
    {
        [Theory]
        [MemberData(nameof(TestCases))]
        public void MustHaveAnApiControllerAttribute(Type controllerType)
        {
            controllerType.GetCustomAttributes(false)
                .OfType<ApiControllerAttribute>()
                .ShouldHaveSingleItem();
        }

        [Theory]
        [MemberData(nameof(TestCases))]
        public void MustOnlyInheritFromControllerBase(Type controllerType)
        {
            typeof(Controller).IsAssignableFrom(controllerType).ShouldBeFalse();
        }

        public static IEnumerable<object[]> TestCases()
        {
            return typeof(HomeController).Assembly
                .DefinedTypes
                .Where(t => typeof(ControllerBase).IsAssignableFrom(t))
                .Select(t => new object[] {t})
                .ToArray();
        }
    }
}