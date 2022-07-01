using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpMasterQuerySupplierResponse:JdResponse{
      [JsonProperty("querysupplier_result")]
public 				List<string>

                                                                                     querysupplierResult
 { get; set; }
	}
}
