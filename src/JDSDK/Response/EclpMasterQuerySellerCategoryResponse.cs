using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpMasterQuerySellerCategoryResponse:JdResponse{
      [JsonProperty("querySellerCategory_result")]
public 				SellerCategory

                                                                                     querySellerCategoryResult
 { get; set; }
	}
}
