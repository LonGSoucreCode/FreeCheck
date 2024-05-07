using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCheck.BusinessLogic
{
    public interface ILogic<IParam, IResultData>
    {
        IResultData? Execute(IParam param);
    }
}
