using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopInvoiceSelfAmountResponse:JdResponse{
      [JsonProperty("queryamountforown_result")]
public 				InvoiceOwnQueryAmountResult

                                                                                     queryamountforownResult
 { get; set; }
	}
}
