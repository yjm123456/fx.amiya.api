using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StockBillDetail:JdObject{
      [JsonProperty("sku_id")]
public 				long

                                                                                     skuId
 { get; set; }
      [JsonProperty("ware_id")]
public 				long

                                                                                     wareId
 { get; set; }
      [JsonProperty("price")]
public 				double

             price
 { get; set; }
      [JsonProperty("apply_num")]
public 				long

                                                                                     applyNum
 { get; set; }
      [JsonProperty("apply_money")]
public 				double

                                                                                     applyMoney
 { get; set; }
      [JsonProperty("real_num")]
public 				long

                                                                                     realNum
 { get; set; }
      [JsonProperty("real_money")]
public 				double

                                                                                     realMoney
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("title")]
public 				string

             title
 { get; set; }
      [JsonProperty("attributes")]
public 				string

             attributes
 { get; set; }
	}
}
