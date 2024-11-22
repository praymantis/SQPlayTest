using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Util
{
    public static T DeserializeObject<T>(this string jsonString, JsonSerializerSettings settings = null)
    {
        // Use a StringReader with a JsonReader for efficient streaming deserialization
        using (StringReader stringReader = new StringReader(jsonString))
        {
            using (JsonReader jsonReader = new JsonTextReader(stringReader))
            {
                JsonSerializer serializer = settings != null ?
                    JsonSerializer.CreateDefault(settings) :
                    JsonSerializer.CreateDefault();

                // Deserialize the JSON string to the specified type
                T obj = serializer.Deserialize<T>(jsonReader);

                // Return the deserialized object
                return obj;
            }
        }
    }
}
