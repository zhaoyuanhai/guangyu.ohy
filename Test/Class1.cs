using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OHYDAL;
using mck= OHYDAL.MongoDBCollectionHelper;
using OHYModel;

namespace Test
{
    public class Class1
    {
        public static void Main()
        {
            OhyMongoClient client = new OhyMongoClient();
            //client.ClienteleClt.UpdateOne(mck.ObjToFilterDef<Clientele>(new { }), mck.ObjToUpdateDef<Clientele>(new object { }));
        }

        public string abc()
        {
            return "ni hao";
        }


    }
}
