using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EdiPoDetailGetResponse:JdResponse{
      [JsonProperty("purchaseOrderDetailResultDTO")]
public 				JosPurchaseOrderDetailResultDTO

             purchaseOrderDetailResultDTO
 { get; set; }
	}
}
