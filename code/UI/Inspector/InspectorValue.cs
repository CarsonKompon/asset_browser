using System;
using Sandbox;

namespace Browser;

public class ModelInspectorValue
{
    public object this[(string, Type) key]
    {
        get
        {
            var animgraph = ModelPreview.Instance.Renderer.Model.AnimGraph;
            for ( int i = 0; i < animgraph.ParamCount; i++ )
            {
                var parameterName = animgraph.GetParameterName( i );
                if ( parameterName == key.Item1 )
                {
                    var parameterType = animgraph.GetParameterType( i );
                    if ( parameterType == typeof( float ) )
                    {
                        var floatVal = ModelPreview.Instance.Renderer.GetFloat( key.Item1 );
                        return floatVal;
                    }
                    else if ( parameterType == typeof( bool ) )
                    {
                        var boolVal = ModelPreview.Instance.Renderer.GetBool( key.Item1 );
                        return boolVal;
                    }
                    else if ( parameterType == typeof( int ) )
                    {
                        var intVal = ModelPreview.Instance.Renderer.GetInt( key.Item1 );
                        return intVal;
                    }
                    else if ( parameterType == typeof( Vector3 ) )
                    {
                        var vec3Val = ModelPreview.Instance.Renderer.GetVector( key.Item1 );
                        return vec3Val;
                    }
                    else if ( parameterType == typeof( Angles ) )
                    {
                        var quatVal = ModelPreview.Instance.Renderer.GetRotation( key.Item1 );
                        return quatVal;
                    }
                    else if ( parameterType == typeof( Rotation ) )
                    {
                        var quatVal = ModelPreview.Instance.Renderer.GetRotation( key.Item1 );
                        return quatVal;
                    }
                }
            }

            return null;
        }

        set
        {
            var keyy = key.Item1;
            var type = key.Item2;
            var val = value;

            if ( type == typeof( float ) )
            {
                ModelPreview.Instance.Renderer.Set( keyy, (float)val );
            }
            else if ( type == typeof( bool ) )
            {
                ModelPreview.Instance.Renderer.Set( keyy, (bool)val );
            }
            else if ( type == typeof( int ) )
            {
                ModelPreview.Instance.Renderer.Set( keyy, (int)val );
            }
            else if ( type == typeof( Vector3 ) )
            {
                ModelPreview.Instance.Renderer.Set( keyy, (Vector3)val );
            }
            else if ( type == typeof( Angles ) )
            {
                ModelPreview.Instance.Renderer.Set( keyy, (Angles)val );
            }
            else if ( type == typeof( Rotation ) )
            {
                ModelPreview.Instance.Renderer.Set( keyy, (Rotation)val );
            }
        }
    }
}