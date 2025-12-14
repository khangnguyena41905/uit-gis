using System.Reflection;

namespace GIS.PERSISTENCE;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}