using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class LwbStatus:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("wbId")]
public 				long

             wbId
 { get; set; }
      [JsonProperty("sellerId")]
public 				long

             sellerId
 { get; set; }
      [JsonProperty("deptId")]
public 				long

             deptId
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("operation")]
public 				string

             operation
 { get; set; }
      [JsonProperty("operateSystem")]
public 				string

             operateSystem
 { get; set; }
      [JsonProperty("operateDate")]
public 				DateTime

             operateDate
 { get; set; }
      [JsonProperty("bizType")]
public 				byte

             bizType
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("updateTime")]
public 				DateTime

             updateTime
 { get; set; }
      [JsonProperty("createUser")]
public 				string

             createUser
 { get; set; }
      [JsonProperty("updateUser")]
public 				string

             updateUser
 { get; set; }
      [JsonProperty("yn")]
public 				byte

             yn
 { get; set; }
      [JsonProperty("statusDesc")]
public 				string

             statusDesc
 { get; set; }
      [JsonProperty("packageBarcode")]
public 				string

             packageBarcode
 { get; set; }
	}
}
