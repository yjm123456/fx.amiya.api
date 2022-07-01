using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StockDetail:JdObject{
      [JsonProperty("goods_no")]
public 				string

                                                                                     goodsNo
 { get; set; }
      [JsonProperty("warehouse_no")]
public 				string

                                                                                     warehouseNo
 { get; set; }
      [JsonProperty("stock_qty")]
public 				int

                                                                                     stockQty
 { get; set; }
      [JsonProperty("available_qty")]
public 				int

                                                                                     availableQty
 { get; set; }
      [JsonProperty("preemption_qty")]
public 				int

                                                                                     preemptionQty
 { get; set; }
      [JsonProperty("goods_status")]
public 				string

                                                                                     goodsStatus
 { get; set; }
	}
}
