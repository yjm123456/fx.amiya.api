using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SkuInfo:JdObject{
      [JsonProperty("sku_code")]
public 				long

                                                                                     skuCode
 { get; set; }
      [JsonProperty("num")]
public 				long

             num
 { get; set; }
      [JsonProperty("price")]
public 				double

             price
 { get; set; }
      [JsonProperty("money")]
public 				double

             money
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
	}
}
