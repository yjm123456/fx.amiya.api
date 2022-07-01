using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RtwResult:JdObject{
      [JsonProperty("eclpRtwNo")]
public 				string

             eclpRtwNo
 { get; set; }
      [JsonProperty("isvRtwNum")]
public 				string

             isvRtwNum
 { get; set; }
      [JsonProperty("eclpSoNo")]
public 				string

             eclpSoNo
 { get; set; }
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("warehouseNo")]
public 				string

             warehouseNo
 { get; set; }
      [JsonProperty("source")]
public 				string

             source
 { get; set; }
      [JsonProperty("reason")]
public 				string

             reason
 { get; set; }
      [JsonProperty("createTime")]
public 				string

             createTime
 { get; set; }
      [JsonProperty("createUser")]
public 				string

             createUser
 { get; set; }
      [JsonProperty("status")]
public 				string

             status
 { get; set; }
      [JsonProperty("resultCode")]
public 				string

             resultCode
 { get; set; }
      [JsonProperty("msg")]
public 				string

             msg
 { get; set; }
	}
}
