using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ServiceItemInfo:JdObject{
      [JsonProperty("isvGoodsNo")]
public 				string

             isvGoodsNo
 { get; set; }
      [JsonProperty("partReceiveType")]
public 				string

             partReceiveType
 { get; set; }
      [JsonProperty("goodsStatus")]
public 				string

             goodsStatus
 { get; set; }
      [JsonProperty("wareType")]
public 				string

             wareType
 { get; set; }
      [JsonProperty("approveNotes")]
public 				string

             approveNotes
 { get; set; }
	}
}
