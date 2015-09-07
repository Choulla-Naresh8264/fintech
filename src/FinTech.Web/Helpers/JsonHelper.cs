using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace FinTech.Web.Helpers
{
    public class JsonHelper
    {
        public static void ConfigureSerializer(JsonSerializerSettings serializerSettings, bool camelCaseProperties = true)
        {
            serializerSettings.Formatting = Formatting.Indented;
            serializerSettings.Converters.Add(new StringEnumConverter { CamelCaseText = false });
            if (camelCaseProperties)
            {
                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }
            serializerSettings.DefaultValueHandling = DefaultValueHandling.Include | DefaultValueHandling.Populate;
            serializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializerSettings.NullValueHandling = NullValueHandling.Ignore;
        }

        public static JsonOutputFormatter GetConfiguredOutputFormatter()
        {
            var formatter = new JsonOutputFormatter();
            ConfigureSerializer(formatter.SerializerSettings);
            return formatter;
        }

        public static JsonInputFormatter GetConfiguredInputFormatter()
        {
            var formatter = new JsonInputFormatter();
            ConfigureSerializer(formatter.SerializerSettings);
            return formatter;
        }
    }
}
