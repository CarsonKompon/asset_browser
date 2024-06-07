using System;
using System.Text.Json;
using Sandbox;

namespace Browser;

public static class BinaryJson
{
    public static string TryGet( string text, out object obj )
    {
        obj = null;

        int totalBrackets = 0;
        int bracketCount = 0;
        int endIndex = 0;
        int index = 0;
        bool inString = false;
        for ( int i = text.Length - 1; i >= 0; i-- )
        {
            var chr = text[i];
            if ( chr == '"' )
            {
                if ( i == 0 || text[i - 1] != '\\' )
                    inString = !inString;
            }
            if ( !inString )
            {
                if ( chr == '}' )
                {
                    if ( totalBrackets == 0 )
                    {
                        endIndex = i;
                    }
                    bracketCount++;
                    totalBrackets++;
                }
                else if ( chr == '{' )
                {
                    bracketCount--;
                    totalBrackets++;
                }
            }

            if ( totalBrackets > 0 && bracketCount == 0 )
            {
                index = i;
                break;
            }
        }

        Log.Info( $"totalBrackets: {totalBrackets}, bracketCount: {bracketCount}, index: {index}, endIndex: {endIndex}" );

        if ( totalBrackets > 0 && bracketCount == 0 )
        {
            text = text.Substring( index, (endIndex - index) + 1 );
            obj = Json.Deserialize<object>( text );
            text = System.Text.Json.JsonSerializer.Serialize( obj, new JsonSerializerOptions { WriteIndented = true } );
            Log.Info( text );
            return text;
        }

        return "";
    }
}