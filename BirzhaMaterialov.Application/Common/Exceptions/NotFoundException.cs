using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Application.Common.Exceptions
{
    /// <summary>
    /// Custom exception. Throws when entity not found in db.
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
        : base($"Entity \"{name}\" ({key}) not found.") { }
    }
}
