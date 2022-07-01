using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class GoodsSerial:JdObject{
      [JsonProperty("businessNo")]
public 				string

             businessNo
 { get; set; }
      [JsonProperty("businessType")]
public 				string

             businessType
 { get; set; }
      [JsonProperty("departmentNo")]
public 				string

             departmentNo
 { get; set; }
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("serialNumber")]
public 				string

             serialNumber
 { get; set; }
	}
}
