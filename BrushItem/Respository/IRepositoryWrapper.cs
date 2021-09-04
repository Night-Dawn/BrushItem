using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrushItem.Respository
{
    /// <summary>
    /// 仓储包装器接口
    /// </summary>
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
    }
}
