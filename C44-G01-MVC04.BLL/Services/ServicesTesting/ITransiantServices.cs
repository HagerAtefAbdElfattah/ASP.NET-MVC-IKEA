using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G01_MVC04.BLL.Services.ServicesTesting
{
    public interface ITransiantServices
    {
        public string GetGuid();
    }

    public class TransiantServices : ITransiantServices
    {
        private Guid _guid;
        public TransiantServices()
        {
            _guid = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return _guid.ToString();
        }
    }
}
