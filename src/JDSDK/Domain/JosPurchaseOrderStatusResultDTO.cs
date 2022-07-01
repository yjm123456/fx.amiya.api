using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosPurchaseOrderStatusResultDTO:JdObject{
      [JsonProperty("purchaseOrderCode")]
public 				string

             purchaseOrderCode
 { get; set; }
      [JsonProperty("bipStatus")]
public 				int

             bipStatus
 { get; set; }
      [JsonProperty("bipLogicalDel")]
public 				int

             bipLogicalDel
 { get; set; }
	}
}
