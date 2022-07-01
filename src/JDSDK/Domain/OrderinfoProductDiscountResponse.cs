using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderinfoProductDiscountResponse:JdObject{
      [JsonProperty("coupon_price")]
public 				double

                                                                                     couponPrice
 { get; set; }
      [JsonProperty("coupon_type")]
public 				byte

                                                                                     couponType
 { get; set; }
      [JsonProperty("order_id")]
public 				string

                                                                                     orderId
 { get; set; }
      [JsonProperty("sku_id")]
public 				string

                                                                                     skuId
 { get; set; }
	}
}
