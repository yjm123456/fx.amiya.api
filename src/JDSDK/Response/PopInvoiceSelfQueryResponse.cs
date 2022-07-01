using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopInvoiceSelfQueryResponse:JdResponse{
      [JsonProperty("queryinvoiceforown_result")]
public 				InvoiceOwnQueryResult

                                                                                     queryinvoiceforownResult
 { get; set; }
	}
}
