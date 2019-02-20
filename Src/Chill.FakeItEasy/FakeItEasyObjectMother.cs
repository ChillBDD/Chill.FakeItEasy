using System;
using System.Collections.Generic;
using System.Reflection;
using FakeItEasy;

namespace Chill.FakeItEasy
{
    /// <summary>
    /// An object mother that uses FakeItEasy to generate stubs.
    /// </summary>
    
    // ReSharper disable once UnusedMember.Global
    public class FakeItEasyObjectMother : IObjectMother
    {
        public bool IsFallback => true;

        public bool Applies(Type type)
        {
            return 
                type.GetTypeInfo().IsInterface && 
                !(type.GetTypeInfo().IsGenericType &&  type.GetGenericTypeDefinition() != typeof(IEnumerable<>)) &&
                !type.IsArray;
        }

        public T Create<T>(IChillContainer container) where T : class
        {
            return A.Fake<T>();
        }
    }
}