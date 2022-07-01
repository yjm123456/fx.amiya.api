using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AfsRefundDto:JdObject{
      [JsonProperty("customer_order_id")]
public 				string

                                                                                                                     customerOrderId
 { get; set; }
      [JsonProperty("typeId")]
public 				int

             typeId
 { get; set; }
      [JsonProperty("itemName")]
public 				string

             itemName
 { get; set; }
      [JsonProperty("itemMoney")]
public 					string

             itemMoney
 { get; set; }
	}
}
