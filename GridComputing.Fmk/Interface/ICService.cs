
using Computing.Fmk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Computing.Fmk.Interface
{
   public interface ICService
   {
       object Run(CTask task, string targetId);
       string CreateAppDomain(IList<byte[]> assemblyList);
       bool TerminateAppDomain(string domainId);

   }
}
