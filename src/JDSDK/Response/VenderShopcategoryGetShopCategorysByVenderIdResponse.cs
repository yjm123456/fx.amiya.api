using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class VenderShopcategoryGetShopCategorysByVenderIdResponse:JdResponse{
      [JsonProperty("getshopcategorysbyvenderid_result")]
public 				ShopCategoryResult

                                                                                     getshopcategorysbyvenderidResult
 { get; set; }
	}
}
