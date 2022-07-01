using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class TqmallGoodsRespVo:JdObject{
      [JsonProperty("goods_sn")]
public 				string

                                                                                     goodsSn
 { get; set; }
      [JsonProperty("goods_name")]
public 				string

                                                                                     goodsName
 { get; set; }
      [JsonProperty("goods_number")]
public 				int

                                                                                     goodsNumber
 { get; set; }
      [JsonProperty("supplier_name")]
public 				string

                                                                                     supplierName
 { get; set; }
      [JsonProperty("sale_price")]
public 				double

                                                                                     salePrice
 { get; set; }
      [JsonProperty("brand_name")]
public 				string

                                                                                     brandName
 { get; set; }
	}
}
