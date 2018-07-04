using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;
using OHYModel;
using System.Linq.Expressions;

namespace OHYDAL
{
    public class OhyMongoClient : MongoClient
    {
        public OhyMongoClient()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ohyconn"].ConnectionString;
            var x = new MongoClient(connStr);
            _ohyDB = x.GetDatabase("ohydb");
        }

        private IMongoDatabase _ohyDB;

        private UpdateDefinition<T> CreateObjUpdateDef<T>(T obj)
        {
            var up = Builders<T>.Update;
            UpdateDefinition<T> upbuilder = null;

            obj.GetType().GetProperties().ToList().ForEach(a =>
            {
                if (upbuilder == null)
                    upbuilder = up.Set(a.Name, a.GetValue(obj));
                else
                    upbuilder = upbuilder.Set(a.Name, a.GetValue(obj));
            });
            return upbuilder;
        }

        public IMongoDatabase OhyDB { get { return _ohyDB; } }

        public List<T> Find<T>(string selector) where T : ModelBase
        {
            var coll = _ohyDB.GetCollection<T>(typeof(T).Name);
            return coll.Find(new JsonFilterDefinition<T>(selector))?.ToList();
        }

        public List<T> Find<T>(Expression<Func<T, bool>> filter) where T : ModelBase
        {
            var coll = _ohyDB.GetCollection<T>(typeof(T).Name);
            return coll.Find(filter).ToList();
        }

        public List<T> FindPage<T>(Expression<Func<T, bool>> filter, int pageIndex, out long total, int pageSize = 10, int sort = 0) where T : ModelBase
        {
            var coll = _ohyDB.GetCollection<T>(typeof(T).Name);
            total = coll.Find(filter).Count();
            if (sort == 0)
                return coll.Find(filter).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToList();
            else
            {
                var s = new JsonSortDefinition<T>("{\"_id\":" + sort + "}");
                return coll.Find(filter).Sort(s).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToList();
            }
        }

        public List<T> Find<T>(object filter) where T : ModelBase
        {
            var coll = _ohyDB.GetCollection<T>(typeof(T).Name);
            return coll.Find(new ObjectFilterDefinition<T>(filter))?.ToList();
        }

        public T FindOne<T>(string selector) where T : ModelBase
        {
            var coll = _ohyDB.GetCollection<T>(typeof(T).Name);
            return coll.Find(new JsonFilterDefinition<T>(selector))?.FirstOrDefault();
        }

        public T FindOne<T>(Expression<Func<T, bool>> filter) where T : ModelBase
        {
            var coll = _ohyDB.GetCollection<T>(typeof(T).Name);
            return coll.Find(filter).FirstOrDefault();
        }

        public T FindOne<T>(object filter) where T : ModelBase
        {
            var coll = _ohyDB.GetCollection<T>(typeof(T).Name);
            return coll.Find(new ObjectFilterDefinition<T>(filter))?.FirstOrDefault();
        }

        public List<T> FindAll<T>() where T : ModelBase
        {
            var coll = _ohyDB.GetCollection<T>(typeof(T).Name);
            return coll.Find(a => true).ToList();
        }

        public void InsertOne<T>(T t)
        {
            _ohyDB.GetCollection<T>(typeof(T).Name).InsertOne(t);
        }

        public void UpdateOneById<T>(T t) where T : ModelBase
        {
            var filter = Builders<T>.Filter.Eq("_id", t._id);

            var update = CreateObjUpdateDef(t);

            _ohyDB.GetCollection<T>(typeof(T).Name).UpdateOne(filter, update);
        }

        public void DeleteOneById<T>(T t) where T : ModelBase
        {
            var filter = Builders<T>.Filter.Eq("_id", t._id);
            _ohyDB.GetCollection<T>(typeof(T).Name).DeleteOne(filter);
        }

        //用户
        public IMongoCollection<UM> UserManagerUM
        {
            get
            {
                return OhyDB.GetCollection<UM>(nameof(UM));
            }
        }

        //首页文字
        public IMongoCollection<HomeText> HomenTextHt
        {
            get
            {
                return OhyDB.GetCollection<HomeText>(nameof(HomeText));
            }
        }

        //公司简介
        public IMongoCollection<CompanyProfile> CompanyProfileCp
        {
            get
            {
                return OhyDB.GetCollection<CompanyProfile>(nameof(CompanyProfile));
            }
        }

        //合作伙伴
        public IMongoCollection<CooperativePartner> CooperativePartnerCpp
        {
            get
            {
                return OhyDB.GetCollection<CooperativePartner>(nameof(CooperativePartner));
            }
        }

        //产品中心
        public IMongoCollection<Product> ProductP
        {
            get
            {
                return OhyDB.GetCollection<Product>(nameof(Product));
            }
        }

        //解决方案
        public IMongoCollection<Solution> SolutionS
        {
            get
            {
                return OhyDB.GetCollection<Solution>(nameof(Solution));
            }
        }

        //业绩展示
        public IMongoCollection<PerformancePresentation> PerformancePresentationPP
        {
            get
            {
                return OhyDB.GetCollection<PerformancePresentation>(nameof(PerformancePresentation));
            }
        }

        //新闻中心
        public IMongoCollection<PressCenter> PressCenterPc
        {
            get
            {
                return OhyDB.GetCollection<PressCenter>(nameof(PressCenter));
            }
        }

        //PDF
        public IMongoCollection<PDF> PDFP
        {
            get
            {
                return OhyDB.GetCollection<PDF>(nameof(PDF));
            }
        }
        //客户
        public IMongoCollection<Customer> CustomerC
        {
            get
            {
                return OhyDB.GetCollection<Customer>(nameof(Customer));
            }
        }

        //友情链接
        public IMongoCollection<FriendlyLink> FriendlyLinkFl
        {
            get
            {
                return OhyDB.GetCollection<FriendlyLink>(nameof(FriendlyLink));
            }
        }


    }
}
