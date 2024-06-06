using System;
namespace Browser;

[AttributeUsage( AttributeTargets.Class, AllowMultiple = true, Inherited = false )]
public class CustomInspectorAttribute : Attribute
{
    public string Type { get; }

    public CustomInspectorAttribute( string type )
    {
        Type = type;
    }
}