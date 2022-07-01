using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopInvoiceSelfRedResponse:JdResponse{
      [JsonProperty("redinvoiceforown_result")]
public 				InvoiceOwnResult

                                                                                     redinvoiceforownResult
 { get; set; }
	}
}
