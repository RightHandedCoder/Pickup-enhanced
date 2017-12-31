using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Repository
{
    public class CredentialRepository<TCredential> : Repository<TCredential>, ICredentialRepository<TCredential> where TCredential : Credential
    {
        DataContext context = new DataContext();

        public Credential ValidateCredential(TCredential credential)
        {
            return context.Set<TCredential>().Where(c => c.Username == credential.Username && c.Password==credential.Password).SingleOrDefault() as Credential;
        }

        public bool CheckStatus(string username)
        {
            return context.Set<TCredential>().Where(s => s.Username == username).SingleOrDefault().Status;
        }
        
    }
        
}
