using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularNet.Models
{
    public class BusinessDatabaseSettings : IBusinessDatabaseSettings
    {
        public string BusinessCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IBusinessDatabaseSettings
    {
        string BusinessCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
