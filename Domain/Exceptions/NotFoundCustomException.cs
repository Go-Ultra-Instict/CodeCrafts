using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCrafts.Domain.Exceptions
{
    public class NotFoundCustomException:Exception
    {
        public NotFoundCustomException()
        {
                
        }
        public NotFoundCustomException(string message):base(message)
        {

        }
        public NotFoundCustomException(string entityName,string message) : base($"{entityName} is not {message}")
        {

        }

    }
}
