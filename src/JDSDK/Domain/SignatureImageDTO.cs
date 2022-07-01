using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SignatureImageDTO:JdObject{
      [JsonProperty("deliveryId")]
public 				string

             deliveryId
 { get; set; }
      [JsonProperty("orderId")]
public 				string

             orderId
 { get; set; }
      [JsonProperty("signatureImage")]
public 				string

             signatureImage
 { get; set; }
	}
}
