using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BillChargeMO:JdObject{
      [JsonProperty("orderType")]
public 				int

             orderType
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("venderId")]
public 				long

             venderId
 { get; set; }
      [JsonProperty("orderStatus")]
public 				string

             orderStatus
 { get; set; }
      [JsonProperty("completed")]
public 				DateTime

             completed
 { get; set; }
      [JsonProperty("outStockTime")]
public 				DateTime

             outStockTime
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("cancelTime")]
public 				DateTime

             cancelTime
 { get; set; }
      [JsonProperty("docCreateTime")]
public 				DateTime

             docCreateTime
 { get; set; }
      [JsonProperty("docUpdateTime")]
public 				DateTime

             docUpdateTime
 { get; set; }
      [JsonProperty("rfBusiType")]
public 				string

             rfBusiType
 { get; set; }
      [JsonProperty("feeList")]
public 				List<string>

             feeList
 { get; set; }
	}
}
