using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EdiPoStatusGetResponse:JdResponse{
      [JsonProperty("purchaseOrderStatusResultDTO")]
public 				JosPurchaseOrderStatusResultDTO

             purchaseOrderStatusResultDTO
 { get; set; }
	}
}
