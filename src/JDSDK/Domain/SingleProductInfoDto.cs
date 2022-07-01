using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SingleProductInfoDto:JdObject{
      [JsonProperty("wareId")]
public 				string

             wareId
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("model")]
public 				string

             model
 { get; set; }
      [JsonProperty("original_place")]
public 				string

                                                                                     originalPlace
 { get; set; }
      [JsonProperty("upc")]
public 				string

             upc
 { get; set; }
      [JsonProperty("packing")]
public 				int

             packing
 { get; set; }
      [JsonProperty("sku_unit")]
public 				string

                                                                                     skuUnit
 { get; set; }
      [JsonProperty("pack_type")]
public 				int

                                                                                     packType
 { get; set; }
      [JsonProperty("pkgInfo")]
public 				string

             pkgInfo
 { get; set; }
      [JsonProperty("warranty")]
public 				string

             warranty
 { get; set; }
      [JsonProperty("shelf_life")]
public 				int

                                                                                     shelfLife
 { get; set; }
      [JsonProperty("zh_brand")]
public 				string

                                                                                     zhBrand
 { get; set; }
      [JsonProperty("en_brand")]
public 				string

                                                                                     enBrand
 { get; set; }
      [JsonProperty("web_site")]
public 				string

                                                                                     webSite
 { get; set; }
      [JsonProperty("tel")]
public 				string

             tel
 { get; set; }
      [JsonProperty("length")]
public 				int

             length
 { get; set; }
      [JsonProperty("width")]
public 				int

             width
 { get; set; }
      [JsonProperty("height")]
public 				int

             height
 { get; set; }
      [JsonProperty("weight")]
public 					string

             weight
 { get; set; }
      [JsonProperty("market_price")]
public 					string

                                                                                     marketPrice
 { get; set; }
      [JsonProperty("purchase_price")]
public 					string

                                                                                     purchasePrice
 { get; set; }
      [JsonProperty("member_price")]
public 					string

                                                                                     memberPrice
 { get; set; }
      [JsonProperty("brand_id")]
public 				int

                                                                                     brandId
 { get; set; }
      [JsonProperty("brand_name")]
public 				string

                                                                                     brandName
 { get; set; }
      [JsonProperty("cid1")]
public 				int

             cid1
 { get; set; }
      [JsonProperty("cid_name1")]
public 				string

                                                                                     cidName1
 { get; set; }
      [JsonProperty("sub_categories")]
public 				List<string>

                                                                                     subCategories
 { get; set; }
      [JsonProperty("saler_code")]
public 				string

                                                                                     salerCode
 { get; set; }
      [JsonProperty("saler_name")]
public 				string

                                                                                     salerName
 { get; set; }
      [JsonProperty("purchaser_code")]
public 				string

                                                                                     purchaserCode
 { get; set; }
      [JsonProperty("purchaser_name")]
public 				string

                                                                                     purchaserName
 { get; set; }
      [JsonProperty("vendor_code")]
public 				string

                                                                                     vendorCode
 { get; set; }
      [JsonProperty("vendor_name")]
public 				string

                                                                                     vendorName
 { get; set; }
      [JsonProperty("full_category_name1")]
public 				string

                                                                                                                     fullCategoryName1
 { get; set; }
      [JsonProperty("wreadme")]
public 				string

             wreadme
 { get; set; }
      [JsonProperty("prop_infos_list")]
public 				List<string>

                                                                                                                     propInfosList
 { get; set; }
      [JsonProperty("ext_propI_infos_list")]
public 				List<string>

                                                                                                                                                     extPropIInfosList
 { get; set; }
      [JsonProperty("intro_html")]
public 				string

                                                                                     introHtml
 { get; set; }
      [JsonProperty("intro_mobile")]
public 				string

                                                                                     introMobile
 { get; set; }
      [JsonProperty("pc_template_html")]
public 				string

                                                                                                                     pcTemplateHtml
 { get; set; }
      [JsonProperty("pc_decoration_html")]
public 				string

                                                                                                                     pcDecorationHtml
 { get; set; }
      [JsonProperty("mobile_decoration_html")]
public 				string

                                                                                                                     mobileDecorationHtml
 { get; set; }
      [JsonProperty("videoId")]
public 				long

             videoId
 { get; set; }
      [JsonProperty("title")]
public 				string

             title
 { get; set; }
      [JsonProperty("modifyTime")]
public 				DateTime

             modifyTime
 { get; set; }
      [JsonProperty("issn")]
public 				string

             issn
 { get; set; }
      [JsonProperty("service")]
public 				string

             service
 { get; set; }
      [JsonProperty("salesRatio")]
public 				string

             salesRatio
 { get; set; }
      [JsonProperty("aftersales")]
public 				string

             aftersales
 { get; set; }
      [JsonProperty("catalogerCode")]
public 				string

             catalogerCode
 { get; set; }
      [JsonProperty("catalogerName")]
public 				string

             catalogerName
 { get; set; }
      [JsonProperty("salerDeptId")]
public 				string

             salerDeptId
 { get; set; }
      [JsonProperty("salerDeptName")]
public 				string

             salerDeptName
 { get; set; }
      [JsonProperty("stores")]
public 				List<string>

             stores
 { get; set; }
      [JsonProperty("itemNum")]
public 				string

             itemNum
 { get; set; }
      [JsonProperty("isFlashPurchase")]
public 				int

             isFlashPurchase
 { get; set; }
      [JsonProperty("flashProductor")]
public 				string

             flashProductor
 { get; set; }
      [JsonProperty("isJIT")]
public 				int

             isJIT
 { get; set; }
      [JsonProperty("isOverseaPurchase")]
public 				int

             isOverseaPurchase
 { get; set; }
      [JsonProperty("spwq")]
public 				int

             spwq
 { get; set; }
      [JsonProperty("dangerGoods")]
public 				int

             dangerGoods
 { get; set; }
      [JsonProperty("after_sale_desc")]
public 				string

                                                                                                                     afterSaleDesc
 { get; set; }
      [JsonProperty("store_property")]
public 				int

                                                                                     storeProperty
 { get; set; }
      [JsonProperty("design_concept")]
public 				string

                                                                                     designConcept
 { get; set; }
      [JsonProperty("sysp")]
public 				int

             sysp
 { get; set; }
      [JsonProperty("skuList")]
public 				List<string>

             skuList
 { get; set; }
      [JsonProperty("gifts_goods")]
public 				int

                                                                                     giftsGoods
 { get; set; }
      [JsonProperty("product_oil_number")]
public 				double

                                                                                                                     productOilNumber
 { get; set; }
      [JsonProperty("product_oil_unit")]
public 				string

                                                                                                                     productOilUnit
 { get; set; }
	}
}
