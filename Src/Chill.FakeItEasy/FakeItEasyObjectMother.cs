using System;
using System.Collections.Generic;
using System.Reflection;

namespace Chill.FakeItEasy
{
    /// <summary>
    /// An object mother that uses FakeItEasy to generate stubs.
    /// </summary>

    // ReSharper disable once UnusedMember.Global
    public class FakeItEasyObjectMother : IObjectMother
    {
        public object Create(Type type, IChillObjectResolver objectResolver)
        {
            return global::FakeItEasy.Sdk.Create.Fake(type);
        }

        public bool IsFallback => true;

        public bool Applies(Type type)
        {
            return
                type.GetTypeInfo().IsInterface &&
                !(type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() != typeof(IEnumerable<>)) &&
                !type.IsArray;
        }
    }
}