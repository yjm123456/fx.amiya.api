using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AccountVO:JdObject{
      [JsonProperty("total_amount")]
public 				string

                                                                                     totalAmount
 { get; set; }
      [JsonProperty("available_amount")]
public 				string

                                                                                     availableAmount
 { get; set; }
      [JsonProperty("freeze_amount")]
public 				string

                                                                                     freezeAmount
 { get; set; }
	}
}
