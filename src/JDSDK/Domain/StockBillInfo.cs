using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StockBillInfo:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("stock_out_bill_id")]
public 				long

                                                                                                                                                     stockOutBillId
 { get; set; }
      [JsonProperty("com_id")]
public 				long

                                                                                     comId
 { get; set; }
      [JsonProperty("org_id")]
public 				long

                                                                                     orgId
 { get; set; }
      [JsonProperty("wh_id")]
public 				long

                                                                                     whId
 { get; set; }
      [JsonProperty("warehouse_name")]
public 				string

                                                                                     warehouseName
 { get; set; }
      [JsonProperty("goods_num_apply")]
public 				long

                                                                                                                     goodsNumApply
 { get; set; }
      [JsonProperty("goods_money_apply")]
public 				double

                                                                                                                     goodsMoneyApply
 { get; set; }
      [JsonProperty("time_apply")]
public 				DateTime

                                                                                     timeApply
 { get; set; }
      [JsonProperty("goods_num_actual")]
public 				long

                                                                                                                     goodsNumActual
 { get; set; }
      [JsonProperty("goods_money_actual")]
public 				double

                                                                                                                     goodsMoneyActual
 { get; set; }
      [JsonProperty("time_actual")]
public 				DateTime

                                                                                     timeActual
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("detail_list")]
public 				List<string>

                                                                                     detailList
 { get; set; }
      [JsonProperty("type")]
public 				int[]

             type
 { get; set; }
	}
}
