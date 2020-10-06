using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Dictionary
{
    public class CollectionMapping
    {
        static Dictionary<string, string> _collection = new Dictionary<string, string>
        {
            {"UserModel", "Users"},
            {"UserBaseModel", "Users"}
        };

        public static string GetCollectionName(string modelName)
        {
            string result;
            if (_collection.TryGetValue(modelName, out result))
                return result;
            else
                return null;
        }

    }
}
