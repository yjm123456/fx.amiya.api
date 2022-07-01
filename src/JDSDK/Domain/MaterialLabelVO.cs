using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class MaterialLabelVO:JdObject{
      [JsonProperty("id")]
public 				string

             id
 { get; set; }
      [JsonProperty("label_buyoutPrice")]
public 					string

                                                                                     labelBuyoutPrice
 { get; set; }
      [JsonProperty("label_cpcPrice")]
public 					string

                                                                                     labelCpcPrice
 { get; set; }
      [JsonProperty("label_name")]
public 				string

                                                                                     labelName
 { get; set; }
	}
}
