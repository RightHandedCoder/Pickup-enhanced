﻿using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Service
{
    public class CredentialService<TCredential> : Service<TCredential>, ICredentialService<TCredential> where TCredential : Credential 
    {

    }
}
