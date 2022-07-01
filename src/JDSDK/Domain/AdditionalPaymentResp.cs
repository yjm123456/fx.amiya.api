using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AdditionalPaymentResp:JdObject{
      [JsonProperty("type")]
public 				int

             type
 { get; set; }
      [JsonProperty("code")]
public 				string

             code
 { get; set; }
      [JsonProperty("amount")]
public 					string

             amount
 { get; set; }
      [JsonProperty("description")]
public 				string

             description
 { get; set; }
	}
}
