using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

public static class JSONHelper
{
    public static List<T> Deseriaize<T>(string path, List<T> list)
    {
        using (StreamReader r = new StreamReader(path))
        {
            string json = r.ReadToEnd();

            list =
                JsonConvert.DeserializeObject<List<T>>(json);
            return list;
        }
    }

    public static JsonSerializerSettings GetJsonSerializerSettings()
    {
        var serializerSettings = new JsonSerializerSettings();
        serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        serializerSettings.Formatting = Formatting.Indented;
        return serializerSettings;
    }

    public static JArray CreateJArray(string path)
    {
        string json = File.ReadAllText(path);
        dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        JArray jArray = (JArray)jsonObj;
        return jArray;
    }

    public static JArray UpdateJArrayElement<T>(JArray jArray, JToken jtoken, string jTokenPropertyName, T valueToCheck)
    {
        jArray.Where(x => x[jTokenPropertyName].Value<T>().Equals(valueToCheck))
                .FirstOrDefault().Replace(jtoken);
        return jArray;
    }

    public static void WriteToFile(string path, object jsonObj)
    {
        string output = Newtonsoft.Json.JsonConvert
                        .SerializeObject(jsonObj, GetJsonSerializerSettings().Formatting, GetJsonSerializerSettings());

        File.WriteAllText(path, output);
    }

    public static bool UpdateJSONElement<T>(string path, string jTokenProperty, object model, T valueToCheck)
    {
        var jArray = CreateJArray(path);
        var jToken = JToken.FromObject(model);
        jArray = UpdateJArrayElement(jArray, jToken, jTokenProperty, valueToCheck);
        WriteToFile(path, jArray);
        return true;
    }

    public static void CreateJSONElement(string path, object model)
    {
        var jArray = CreateJArray(path);
        var jToken = JToken.FromObject(model);
        jArray.Add(jToken);
        WriteToFile(path, jArray);
    }
}
