using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderPackage:JdObject{
      [JsonProperty("packageNo")]
public 				string

             packageNo
 { get; set; }
      [JsonProperty("packWeight")]
public 				double

             packWeight
 { get; set; }
      [JsonProperty("thirdWayBill")]
public 				string

             thirdWayBill
 { get; set; }
      [JsonProperty("soPackItemsList")]
public 				List<string>

             soPackItemsList
 { get; set; }
      [JsonProperty("soPackMaterialList")]
public 				List<string>

             soPackMaterialList
 { get; set; }
      [JsonProperty("boxCodes")]
public 				string

             boxCodes
 { get; set; }
	}
}
