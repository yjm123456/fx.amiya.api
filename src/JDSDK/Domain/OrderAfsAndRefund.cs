using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderAfsAndRefund:JdObject{
      [JsonProperty("sameOrderServiceBill")]
public 				SameOrderServiceBill

             sameOrderServiceBill
 { get; set; }
      [JsonProperty("afsRefundId")]
public 				long

             afsRefundId
 { get; set; }
      [JsonProperty("refoundAmount")]
public 					string

             refoundAmount
 { get; set; }
      [JsonProperty("completeTime")]
public 				DateTime

             completeTime
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
	}
}
