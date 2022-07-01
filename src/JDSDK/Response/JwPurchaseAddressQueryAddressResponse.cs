using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class JwPurchaseAddressQueryAddressResponse:JdResponse{
      [JsonProperty("queryaddress_result")]
public 				AddressResponse

                                                                                     queryaddressResult
 { get; set; }
	}
}
