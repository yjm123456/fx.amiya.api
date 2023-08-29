﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class AmiyaWareHouse
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get;set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 归属仓库id
        /// </summary>
        public string GoodsSourceId { get; set; }
        /// <summary>
        /// 归属货架id
        /// </summary>
        public string StorageRacksId { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal SinglePrice { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? ExpireDate { get; set; }

        public AmiyaWareHouseNameManage WareHouseNameManage { get; set; }
        public List<InventoryList> InventoryList { get; set; }
        public List<AmiyaOutWarehouse> AmiyaOutWarehouseList { get; set; }
        public List<AmiyaInWarehouse> AmiyaInWarehouseList { get; set; }
    }
}
