using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.BLL.Services.ServicesTesting
{
    public interface ISingletonServices
    {
        public string GetGuid();
    }

    public class SingletonServices : ISingletonServices
    {
        private Guid _guid;
        public SingletonServices()
        {
            _guid = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return _guid.ToString();
        }
    }
}
