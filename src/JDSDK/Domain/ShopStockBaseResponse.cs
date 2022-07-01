using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ShopStockBaseResponse:JdObject{
      [JsonProperty("responseCode")]
public 				int

             responseCode
 { get; set; }
      [JsonProperty("errMsg")]
public 				string

             errMsg
 { get; set; }
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
      [JsonProperty("requestId")]
public 				string

             requestId
 { get; set; }
	}
}
