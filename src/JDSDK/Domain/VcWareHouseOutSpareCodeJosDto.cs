using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VcWareHouseOutSpareCodeJosDto:JdObject{
      [JsonProperty("returnPrice")]
public 					string

             returnPrice
 { get; set; }
      [JsonProperty("wareSku")]
public 				string

             wareSku
 { get; set; }
      [JsonProperty("wareName")]
public 				string

             wareName
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("snNo")]
public 				string

             snNo
 { get; set; }
      [JsonProperty("spareCode")]
public 				string

             spareCode
 { get; set; }
	}
}
