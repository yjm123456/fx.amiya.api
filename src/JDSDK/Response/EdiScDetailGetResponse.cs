using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EdiScDetailGetResponse:JdResponse{
      [JsonProperty("shipmentConfirmationDetailResultDTO")]
public 				JosShipmentConfirmationDetailResultDTO

             shipmentConfirmationDetailResultDTO
 { get; set; }
	}
}
