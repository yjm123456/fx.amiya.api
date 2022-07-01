using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class MaterialLableJO:JdObject{
      [JsonProperty("id")]
public 				string

             id
 { get; set; }
      [JsonProperty("label_name")]
public 				string

                                                                                     labelName
 { get; set; }
      [JsonProperty("buyout_price")]
public 					string

                                                                                     buyoutPrice
 { get; set; }
      [JsonProperty("cpc_price")]
public 					string

                                                                                     cpcPrice
 { get; set; }
	}
}
