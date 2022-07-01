using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ItemPicApplyDto:JdObject{
      [JsonProperty("ware_id")]
public 				string

                                                                                     wareId
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("brand_id")]
public 				int

                                                                                     brandId
 { get; set; }
      [JsonProperty("category_id")]
public 				int

                                                                                     categoryId
 { get; set; }
      [JsonProperty("vendor_code")]
public 				string

                                                                                     vendorCode
 { get; set; }
      [JsonProperty("sku_list")]
public 				List<string>

                                                                                     skuList
 { get; set; }
      [JsonProperty("sku_list_long")]
public 				List<string>

                                                                                                                     skuListLong
 { get; set; }
      [JsonProperty("sku_list_lucency")]
public 				List<string>

                                                                                                                     skuListLucency
 { get; set; }
      [JsonProperty("brand_name")]
public 				string

                                                                                     brandName
 { get; set; }
      [JsonProperty("sale_state")]
public 				int

                                                                                     saleState
 { get; set; }
      [JsonProperty("category_name")]
public 				string

                                                                                     categoryName
 { get; set; }
	}
}
