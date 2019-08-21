using System;
using NUnit.Framework;

namespace Unity.Entities.Tests
{
#if NET_DOTS
    public class StandaloneFixmeAttribute : IgnoreAttribute
    {
        public StandaloneFixmeAttribute() : base("Need to fix for Tiny.")
        {
        }
    }
#else
    public class StandaloneFixmeAttribute : Attribute
    {
    }
#endif
}
