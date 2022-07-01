using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ItemAttrApplyDto:JdObject{
      [JsonProperty("apply_id")]
public 				string

                                                                                     applyId
 { get; set; }
      [JsonProperty("apply_time")]
public 				DateTime

                                                                                     applyTime
 { get; set; }
      [JsonProperty("ware_group_id")]
public 				string

                                                                                                                     wareGroupId
 { get; set; }
      [JsonProperty("public_name")]
public 				string

                                                                                     publicName
 { get; set; }
      [JsonProperty("state")]
public 				int

             state
 { get; set; }
	}
}
