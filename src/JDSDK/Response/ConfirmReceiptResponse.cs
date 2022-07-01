using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ConfirmReceiptResponse:JdResponse{
      [JsonProperty("confirmReceipt_result")]
public 				Result

                                                                                     confirmReceiptResult
 { get; set; }
	}
}
