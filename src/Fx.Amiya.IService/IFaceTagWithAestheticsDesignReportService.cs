using Fx.Amiya.Dto.AestheticsDesignReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IFaceTagWithAestheticsDesignReportService
    {
        Task AddFaceTagsAsync(AddFaceTagDto addDto);
        Task GetTagsByReportIdList(string reportId);

    }
}
