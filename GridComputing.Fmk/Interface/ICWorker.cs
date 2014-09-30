using Computing.Fmk.Common;
using System.Collections.Generic;

namespace Computing.Fmk.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWorker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="targetId"></param>
        /// <returns></returns>
        object Run(CTask task, string targetId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblyList"></param>
        /// <returns></returns>
        string CreateAppDomain(IList<byte[]> assemblyList);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainId"></param>
        /// <returns></returns>
        bool TerminateAppDomain(string domainId);
    }
}
