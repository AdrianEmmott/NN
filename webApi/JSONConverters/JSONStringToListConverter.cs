using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class JSONStringToListIntConverter : JsonConverter
{
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null ||
            reader.TokenType == JsonToken.StartArray)
        {
            return null;
        }

        // Convert a comma separated string to a list of ints
        return reader.Value.ToString().Split(',').Select(int.Parse).ToList();
    }
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(List<int>);
    }

    public override bool CanWrite { get { return true; } }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        writer.WriteValue(((List<int>)value).ToArray());
    }
}