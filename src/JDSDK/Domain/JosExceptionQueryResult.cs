using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosExceptionQueryResult:JdObject{
      [JsonProperty("orderNo")]
public 				string

             orderNo
 { get; set; }
      [JsonProperty("isvOrderNo")]
public 				string

             isvOrderNo
 { get; set; }
      [JsonProperty("sellerName")]
public 				string

             sellerName
 { get; set; }
      [JsonProperty("deptName")]
public 				string

             deptName
 { get; set; }
      [JsonProperty("warehouseName")]
public 				string

             warehouseName
 { get; set; }
      [JsonProperty("code")]
public 				string

             code
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
      [JsonProperty("errReason")]
public 				string

             errReason
 { get; set; }
      [JsonProperty("solution")]
public 				string

             solution
 { get; set; }
      [JsonProperty("pauseTime")]
public 				string

             pauseTime
 { get; set; }
      [JsonProperty("isvCreateTime")]
public 				string

             isvCreateTime
 { get; set; }
      [JsonProperty("createTime")]
public 				string

             createTime
 { get; set; }
      [JsonProperty("orderTypeName")]
public 				string

             orderTypeName
 { get; set; }
	}
}
