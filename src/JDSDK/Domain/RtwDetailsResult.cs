using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RtwDetailsResult:JdObject{
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("goodsLevelNo")]
public 				string

             goodsLevelNo
 { get; set; }
      [JsonProperty("planQty")]
public 				int

             planQty
 { get; set; }
      [JsonProperty("realQty")]
public 				int

             realQty
 { get; set; }
      [JsonProperty("isvGoodsNo")]
public 				string

             isvGoodsNo
 { get; set; }
      [JsonProperty("detailIsvSoNo")]
public 				string

             detailIsvSoNo
 { get; set; }
      [JsonProperty("detailEclpSoNo")]
public 				string

             detailEclpSoNo
 { get; set; }
      [JsonProperty("detailOrderLine")]
public 				string

             detailOrderLine
 { get; set; }
      [JsonProperty("planRtwReasonNo")]
public 				string

             planRtwReasonNo
 { get; set; }
      [JsonProperty("planRtwReasonDesc")]
public 				string

             planRtwReasonDesc
 { get; set; }
      [JsonProperty("realRtwReasonNo")]
public 				string

             realRtwReasonNo
 { get; set; }
      [JsonProperty("realPlanRtwReasonDesc")]
public 				string

             realPlanRtwReasonDesc
 { get; set; }
	}
}
