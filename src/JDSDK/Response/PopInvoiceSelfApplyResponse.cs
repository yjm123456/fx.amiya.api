using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopInvoiceSelfApplyResponse:JdResponse{
      [JsonProperty("applyinvoiceforown_result")]
public 				InvoiceOwnResult

                                                                                     applyinvoiceforownResult
 { get; set; }
	}
}
