using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Ryuu.Unity.Serialization.Json
{
    public static class JsonUtility
    {
        public static T Deserialize<T>(string jsonString, Func<T> fallbackProvider)
        {
            try
            {
                T objectFromJsonString = JsonConvert.DeserializeObject<T>(jsonString);
                // ReSharper disable once ConvertIfStatementToReturnStatement
                if (objectFromJsonString != null)
                {
                    return objectFromJsonString;
                }

                return fallbackProvider.Invoke();
            }
            catch (Exception exception)
            {
                Debug.LogError(exception);
                return fallbackProvider.Invoke();
            }
        }
    }
}