using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SerialNumber:JdObject{
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("serialNumber")]
public 				string

             serialNumber
 { get; set; }
      [JsonProperty("bizType")]
public 				byte

             bizType
 { get; set; }
      [JsonProperty("bizNo")]
public 				string

             bizNo
 { get; set; }
      [JsonProperty("createTimeStr")]
public 				string

             createTimeStr
 { get; set; }
      [JsonProperty("warehouseNo")]
public 				string

             warehouseNo
 { get; set; }
      [JsonProperty("warehouseName")]
public 				string

             warehouseName
 { get; set; }
      [JsonProperty("bizTypeName")]
public 				string

             bizTypeName
 { get; set; }
	}
}
