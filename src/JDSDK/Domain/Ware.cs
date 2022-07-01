using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Ware:JdObject{
      [JsonProperty("wareId")]
public 				long

             wareId
 { get; set; }
      [JsonProperty("title")]
public 				string

             title
 { get; set; }
      [JsonProperty("categoryId")]
public 				long

             categoryId
 { get; set; }
      [JsonProperty("brandId")]
public 				long

             brandId
 { get; set; }
      [JsonProperty("templateId")]
public 				long

             templateId
 { get; set; }
      [JsonProperty("transportId")]
public 				long

             transportId
 { get; set; }
      [JsonProperty("wareStatus")]
public 				int

             wareStatus
 { get; set; }
      [JsonProperty("outerId")]
public 				string

             outerId
 { get; set; }
      [JsonProperty("itemNum")]
public 				string

             itemNum
 { get; set; }
      [JsonProperty("barCode")]
public 				string

             barCode
 { get; set; }
      [JsonProperty("wareLocation")]
public 				int

             wareLocation
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("offlineTime")]
public 				DateTime

             offlineTime
 { get; set; }
      [JsonProperty("onlineTime")]
public 				DateTime

             onlineTime
 { get; set; }
      [JsonProperty("colType")]
public 				int

             colType
 { get; set; }
      [JsonProperty("delivery")]
public 				string

             delivery
 { get; set; }
      [JsonProperty("adWords")]
public 				AdWords

             adWords
 { get; set; }
      [JsonProperty("wrap")]
public 				string

             wrap
 { get; set; }
      [JsonProperty("packListing")]
public 				string

             packListing
 { get; set; }
      [JsonProperty("weight")]
public 				float

             weight
 { get; set; }
      [JsonProperty("width")]
public 				int

             width
 { get; set; }
      [JsonProperty("height")]
public 				int

             height
 { get; set; }
      [JsonProperty("length")]
public 				int

             length
 { get; set; }
      [JsonProperty("props")]
public 				List<string>

             props
 { get; set; }
      [JsonProperty("features")]
public 				List<string>

             features
 { get; set; }
      [JsonProperty("images")]
public 				List<string>

             images
 { get; set; }
      [JsonProperty("shopCategorys")]
public 				List<string>

             shopCategorys
 { get; set; }
      [JsonProperty("mobileDesc")]
public 				string

             mobileDesc
 { get; set; }
      [JsonProperty("introduction")]
public 				string

             introduction
 { get; set; }
      [JsonProperty("zhuangBaIntroduction")]
public 				string

             zhuangBaIntroduction
 { get; set; }
      [JsonProperty("zhuangBaId")]
public 				string

             zhuangBaId
 { get; set; }
      [JsonProperty("introductionUseFlag")]
public 				string

             introductionUseFlag
 { get; set; }
      [JsonProperty("afterSales")]
public 				string

             afterSales
 { get; set; }
      [JsonProperty("logo")]
public 				string

             logo
 { get; set; }
      [JsonProperty("marketPrice")]
public 					string

             marketPrice
 { get; set; }
      [JsonProperty("costPrice")]
public 					string

             costPrice
 { get; set; }
      [JsonProperty("jdPrice")]
public 					string

             jdPrice
 { get; set; }
      [JsonProperty("brandName")]
public 				string

             brandName
 { get; set; }
      [JsonProperty("stockNum")]
public 				long

             stockNum
 { get; set; }
      [JsonProperty("categorySecId")]
public 				long

             categorySecId
 { get; set; }
      [JsonProperty("shopId")]
public 				long

             shopId
 { get; set; }
      [JsonProperty("promiseId")]
public 				long

             promiseId
 { get; set; }
      [JsonProperty("multiCategoryId")]
public 				long

             multiCategoryId
 { get; set; }
      [JsonProperty("multiCateProps")]
public 				List<string>

             multiCateProps
 { get; set; }
      [JsonProperty("sellPoint")]
public 				string

             sellPoint
 { get; set; }
      [JsonProperty("wareTax")]
public 				WareTax

             wareTax
 { get; set; }
      [JsonProperty("afterSaleDesc")]
public 				string

             afterSaleDesc
 { get; set; }
      [JsonProperty("zhuangBaMobileDesc")]
public 				string

             zhuangBaMobileDesc
 { get; set; }
      [JsonProperty("mobileZhuangBaId")]
public 				string

             mobileZhuangBaId
 { get; set; }
      [JsonProperty("mobileDescUseFlag")]
public 				string

             mobileDescUseFlag
 { get; set; }
      [JsonProperty("fitCaseHtmlPc")]
public 				string

             fitCaseHtmlPc
 { get; set; }
      [JsonProperty("fitCaseHtmlApp")]
public 				string

             fitCaseHtmlApp
 { get; set; }
      [JsonProperty("specialServices")]
public 				List<string>

             specialServices
 { get; set; }
      [JsonProperty("parentId")]
public 				long

             parentId
 { get; set; }
      [JsonProperty("wareGroupId")]
public 				long

             wareGroupId
 { get; set; }
      [JsonProperty("businessType")]
public 				string

             businessType
 { get; set; }
      [JsonProperty("designConcept")]
public 				string

             designConcept
 { get; set; }
      [JsonProperty("isArchival")]
public 				bool

             isArchival
 { get; set; }
      [JsonProperty("templateIds")]
public 				string

             templateIds
 { get; set; }
	}
}
