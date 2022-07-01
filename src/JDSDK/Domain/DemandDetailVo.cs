using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DemandDetailVo:JdObject{
      [JsonProperty("offer_goods_id")]
public 				int

                                                                                                                     offerGoodsId
 { get; set; }
      [JsonProperty("goods_name")]
public 				string

                                                                                     goodsName
 { get; set; }
      [JsonProperty("oe_num")]
public 				string

                                                                                     oeNum
 { get; set; }
      [JsonProperty("goods_number")]
public 				int

                                                                                     goodsNumber
 { get; set; }
      [JsonProperty("goods_measure_unit")]
public 				string

                                                                                                                     goodsMeasureUnit
 { get; set; }
      [JsonProperty("goods_quality_type")]
public 				int

                                                                                                                     goodsQualityType
 { get; set; }
      [JsonProperty("goods_quality_name")]
public 				int

                                                                                                                     goodsQualityName
 { get; set; }
      [JsonProperty("goods_price")]
public 					string

                                                                                     goodsPrice
 { get; set; }
      [JsonProperty("package_size")]
public 				int

                                                                                     packageSize
 { get; set; }
      [JsonProperty("shipping_fee")]
public 					string

                                                                                     shippingFee
 { get; set; }
      [JsonProperty("seller_remark")]
public 				string

                                                                                     sellerRemark
 { get; set; }
      [JsonProperty("create_offer_time")]
public 				DateTime

                                                                                                                     createOfferTime
 { get; set; }
      [JsonProperty("brand_name")]
public 				string

                                                                                     brandName
 { get; set; }
	}
}
