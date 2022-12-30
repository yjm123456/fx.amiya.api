﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.GoodsShopCar
{
    public class UpdateGoodsShopCarDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 客户id
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public string GoodsId { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 城市id
        /// </summary>
        public int? CityId { get; set; }

        /// <summary>
        /// 医院id
        /// </summary>
        public int? HospitalId { get; set; }
        ///// <summary>
        ///// 购物车状态
        ///// </summary>
        //public int Status { get; set; }
        
        /// <summary>
        /// 选择的规格
        /// </summary>
        public string SelectStandard { get; set; }
    }
}
