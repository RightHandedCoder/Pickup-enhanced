using Pickup_Entity;
using Pickup_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Service
{
    public class CredentialService<TCredential> : Service<TCredential>, ICredentialService<TCredential> where TCredential : Credential 
    {
        CredentialRepository<TCredential> repo = new CredentialRepository<TCredential>();

        public Credential ValidateCredential(TCredential credential)
        {
            return repo.ValidateCredential(credential);
        }

        public bool CheckStatus(string username)
        {
            return repo.CheckStatus(username);
        }
    }
}
