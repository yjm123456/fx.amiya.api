using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ItemPictureApplyDto:JdObject{
      [JsonProperty("apply_id")]
public 				string

                                                                                     applyId
 { get; set; }
      [JsonProperty("yn")]
public 				string

             yn
 { get; set; }
      [JsonProperty("state")]
public 				int

             state
 { get; set; }
      [JsonProperty("create_by")]
public 				string

                                                                                     createBy
 { get; set; }
      [JsonProperty("modify_by")]
public 				string

                                                                                     modifyBy
 { get; set; }
      [JsonProperty("create_time")]
public 				string

                                                                                     createTime
 { get; set; }
      [JsonProperty("modify_time")]
public 				string

                                                                                     modifyTime
 { get; set; }
      [JsonProperty("apply_time")]
public 				string

                                                                                     applyTime
 { get; set; }
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
      [JsonProperty("sale_state_name")]
public 				string

                                                                                                                     saleStateName
 { get; set; }
      [JsonProperty("state_name")]
public 				string

                                                                                     stateName
 { get; set; }
      [JsonProperty("item_pic_audit_dto")]
public 				ItemPicAuditDto

                                                                                                                                                     itemPicAuditDto
 { get; set; }
      [JsonProperty("is_publishSchedule")]
public 				int

                                                                                     isPublishSchedule
 { get; set; }
      [JsonProperty("publish_time")]
public 				DateTime

                                                                                     publishTime
 { get; set; }
	}
}
