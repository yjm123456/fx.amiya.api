using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ThirdPartContentplatformInfo.Input
{
    public class QuerySendOrderDataByLangZiVo
    {
        /// <summary>
        /// 服务商ID 固定值： E-31-31446
        /// </summary>
        public string FWSID { get; set; }
        /// <summary>
        /// 用户id 固定值: INTAMY
        /// </summary>
        public string USERID { get; set; }
        /// <summary>
        /// 机构 朗姿机构代码：6406
        /// </summary>
        public string JGBM { get; set; }
        /// <summary>
        /// 派单医院ID
        /// </summary>
        public string HOSPITALCOD { get; set; }
        /// <summary>
        /// 派单编号
        /// </summary>
        public string PDBH { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string KUNAM { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string KUSEX { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int AGE { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        public string KUPRO { get; set; }
        /// <summary>
        /// 所在区域
        /// </summary>
        public string REGION { get; set; }
        /// <summary>
        /// 电话1
        /// </summary>
        public string TEL1 { get; set; }
        /// <summary>
        /// 电话2
        /// </summary>
        public string TEL2 { get; set; }
        /// <summary>
        /// 电话3
        /// </summary>
        public string TEL3 { get; set; }
        /// <summary>
        /// 客户微信
        /// </summary>
        public string KHWX { get; set; }
        /// <summary>
        /// 客户QQ
        /// </summary>
        public string KHQQ { get; set; }
        /// <summary>
        /// 客户标签1
        /// </summary>
        public string KHBQ1 { get; set; }
        /// <summary>
        /// 客户标签2
        /// </summary>
        public string KHBQ2 { get; set; }
        /// <summary>
        /// 客户标签3
        /// </summary>
        public string KHBQ3 { get; set; }
        /// <summary>
        /// 意向项⽬
        /// </summary>
        public string YXXM { get; set; }
        /// <summary>
        /// 意向地区
        /// </summary>
        public string YXDQ { get; set; }
        /// <summary>
        /// 意向机构
        /// </summary>
        public string YXJG { get; set; }
        /// <summary>
        /// 派单备注
        /// </summary>
        public string PDTZ { get; set; }
        /// <summary>
        /// 派单⽇期
        /// </summary>
        public DateTime PDRQ { get; set; }
        /// <summary>
        /// 派单时间
        /// </summary>
        public string PDSJ { get; set; }
        /// <summary>
        /// 派单网咨
        /// </summary>
        public string PDWZ { get; set; }
        /// <summary>
        /// 平台项⽬类别1级
        /// </summary>
        public string PTXMLB1 { get; set; }
        /// <summary>
        /// 平台项⽬类别2级
        /// </summary>
        public string PTXMLB2 { get; set; }
        /// <summary>
        /// 平台项⽬类别3级
        /// </summary>
        public string PTXMLB3 { get; set; }
        /// <summary>
        /// 平台项目名称
        /// </summary>
        public string PTXMMC { get; set; }
    }
}
