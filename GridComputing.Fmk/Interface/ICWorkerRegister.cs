
using Computing.Fmk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Computing.Fmk.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICWorkerRegister
    {
        bool Register(CNode workNode);

        bool UnRegister(string workNodeId);
    }
}
