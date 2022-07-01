using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class QcBackItem:JdObject{
      [JsonProperty("goodsName")]
public 				string

             goodsName
 { get; set; }
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("sellerGoodsSign")]
public 				string

             sellerGoodsSign
 { get; set; }
      [JsonProperty("serialNo")]
public 				string

             serialNo
 { get; set; }
      [JsonProperty("qualifiedQty")]
public 				int[]

             qualifiedQty
 { get; set; }
      [JsonProperty("checkResultStr")]
public 				string

             checkResultStr
 { get; set; }
      [JsonProperty("qcTimeStr")]
public 				string

             qcTimeStr
 { get; set; }
	}
}
