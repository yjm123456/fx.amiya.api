using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class BeautyDiaryTagDetail
    {
        public string Id { get; set; }

        public string BeautyDiaryId { get; set; }

        public string TagId { get; set; }

        public BeautyDiaryManage BeautyDiaryManage { get; set; }
        public BeautyDiaryTagInfo BeautyDiaryTagInfo { get; set; }
    }
}
