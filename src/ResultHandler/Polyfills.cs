#if NETSTANDARD2_0

namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { }
}

namespace System.Diagnostics.CodeAnalysis
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property)]
    internal sealed class MaybeNullAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property)]
    internal sealed class AllowNullAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue)]
    internal sealed class MemberNotNullWhenAttribute : Attribute
    {
        public MemberNotNullWhenAttribute(bool returnValue, string member)
        {
            ReturnValue = returnValue;
            Members = new[] { member };
        }

        public bool ReturnValue { get; }
        public string[] Members { get; }
    }
}

#endif
