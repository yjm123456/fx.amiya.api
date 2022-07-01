using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SellerCategory:JdObject{
      [JsonProperty("deptId")]
public 				string

             deptId
 { get; set; }
      [JsonProperty("categoryNo")]
public 				string

             categoryNo
 { get; set; }
      [JsonProperty("categoryName")]
public 				string

             categoryName
 { get; set; }
      [JsonProperty("level")]
public 				string

             level
 { get; set; }
	}
}
