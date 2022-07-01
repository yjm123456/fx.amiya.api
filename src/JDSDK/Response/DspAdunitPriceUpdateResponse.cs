using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspAdunitPriceUpdateResponse:JdResponse{
      [JsonProperty("updatefeatureprice_result")]
public 				DspResult

                                                                                     updatefeaturepriceResult
 { get; set; }
	}
}
