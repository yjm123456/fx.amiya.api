using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class VenderShopQueryResponse:JdResponse{
      [JsonProperty("shop_jos_result")]
public 				ShopJosResult

                                                                                                                     shopJosResult
 { get; set; }
	}
}
