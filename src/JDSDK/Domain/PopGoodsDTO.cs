using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PopGoodsDTO:JdObject{
      [JsonProperty("product_id")]
public 				int

                                                                                     productId
 { get; set; }
      [JsonProperty("pop_product_sn")]
public 				string

                                                                                                                     popProductSn
 { get; set; }
      [JsonProperty("oe_id")]
public 				string

                                                                                     oeId
 { get; set; }
      [JsonProperty("pop_product")]
public 				string

                                                                                     popProduct
 { get; set; }
      [JsonProperty("retail_shelf_num")]
public 				int

                                                                                                                     retailShelfNum
 { get; set; }
      [JsonProperty("retail_shelf")]
public 				List<string>

                                                                                     retailShelf
 { get; set; }
      [JsonProperty("wsale_shelf")]
public 				TradeShelfParam

                                                                                     wsaleShelf
 { get; set; }
	}
}
