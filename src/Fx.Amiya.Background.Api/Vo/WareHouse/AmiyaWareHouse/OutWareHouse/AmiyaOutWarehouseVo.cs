﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.WareHouse.AmiyaWareHouse.OutWareHouse
{
    public class AmiyaOutWarehouseVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }


        /// <summary>
        /// 物料名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 仓库
        /// </summary>
        public string WareHouseName { get; set; }
        /// <summary>
        /// 货架
        /// </summary>
        public string StorageRacksName { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal SinglePrice { get; set; }

        /// <summary>
        /// 出库数量
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public decimal AllPrice { get; set; }
        /// <summary>
        /// 领用部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 领用人
        /// </summary>
        public string UseEmployee { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }


        /// <summary>
        /// 创建人名字
        /// </summary>
        public string CreateByEmpName { get; set; }
    }
}
