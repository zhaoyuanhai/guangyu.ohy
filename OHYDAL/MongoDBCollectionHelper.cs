using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace OHYDAL
{
    public static class MongoDBCollectionHelper
    {
        public static ObjectFilterDefinition<T> ObjToFilterDef<T>(object obj)
        {
            return new ObjectFilterDefinition<T>(obj);
        }

        public static JsonFilterDefinition<T> JsonToFilterDef<T>(string json)
        {
            return new JsonFilterDefinition<T>(json);
        }

        public static UpdateDefinition<T> ObjToUpdateDef<T>(object obj)
        {
            var up = Builders<T>.Update;
            UpdateDefinition<T> upbuilder = null;
            obj.GetType().GetProperties().ToList().ForEach(a =>
            {
                upbuilder = up.Set(a.Name, a.GetValue(obj));
            });

            return upbuilder;
        }

        public static JsonUpdateDefinition<T> JsonToUpdateDef<T>(string json)
        {
            return new JsonUpdateDefinition<T>(json);
        }
    }
}
