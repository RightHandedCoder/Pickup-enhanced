using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Service
{
    public interface ICredentialService<TCredential> : IService<TCredential> where TCredential : Credential
    {
    }
}
