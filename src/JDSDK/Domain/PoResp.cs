using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PoResp:JdObject{
      [JsonProperty("poVenderCode")]
public 				string

             poVenderCode
 { get; set; }
      [JsonProperty("poValidState")]
public 				int

             poValidState
 { get; set; }
      [JsonProperty("companyName")]
public 				string

             companyName
 { get; set; }
      [JsonProperty("popVenderId")]
public 				long

             popVenderId
 { get; set; }
      [JsonProperty("orderState")]
public 				int

             orderState
 { get; set; }
      [JsonProperty("poRealAmount")]
public 					string

             poRealAmount
 { get; set; }
      [JsonProperty("industryId")]
public 				long

             industryId
 { get; set; }
      [JsonProperty("invoiceType")]
public 				int

             invoiceType
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
      [JsonProperty("thirdPoId")]
public 				string

             thirdPoId
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("ignoreAudit")]
public 				int

             ignoreAudit
 { get; set; }
      [JsonProperty("submitFailMsg")]
public 				string

             submitFailMsg
 { get; set; }
      [JsonProperty("submitPoTime")]
public 				DateTime

             submitPoTime
 { get; set; }
      [JsonProperty("splitFlag")]
public 				int

             splitFlag
 { get; set; }
      [JsonProperty("poSource")]
public 				int

             poSource
 { get; set; }
      [JsonProperty("popShopId")]
public 				long

             popShopId
 { get; set; }
      [JsonProperty("poAmount")]
public 					string

             poAmount
 { get; set; }
      [JsonProperty("poAfterSalesStatus")]
public 				int

             poAfterSalesStatus
 { get; set; }
      [JsonProperty("poId")]
public 				long

             poId
 { get; set; }
      [JsonProperty("paymentType")]
public 				int

             paymentType
 { get; set; }
      [JsonProperty("shipmentType")]
public 				int

             shipmentType
 { get; set; }
      [JsonProperty("jbeanNumber")]
public 				long

             jbeanNumber
 { get; set; }
      [JsonProperty("poShopName")]
public 				string

             poShopName
 { get; set; }
      [JsonProperty("submitResultFlag")]
public 				int

             submitResultFlag
 { get; set; }
      [JsonProperty("poRemark")]
public 				string

             poRemark
 { get; set; }
      [JsonProperty("poStatus")]
public 				int

             poStatus
 { get; set; }
      [JsonProperty("userClientIp")]
public 				string

             userClientIp
 { get; set; }
      [JsonProperty("poTier")]
public 				int

             poTier
 { get; set; }
      [JsonProperty("submitOrderTime")]
public 				DateTime

             submitOrderTime
 { get; set; }
      [JsonProperty("userName")]
public 				string

             userName
 { get; set; }
      [JsonProperty("userId")]
public 				long

             userId
 { get; set; }
      [JsonProperty("poUserShopName")]
public 				string

             poUserShopName
 { get; set; }
      [JsonProperty("parentId")]
public 				long

             parentId
 { get; set; }
      [JsonProperty("userPin")]
public 				string

             userPin
 { get; set; }
      [JsonProperty("freightFee")]
public 					string

             freightFee
 { get; set; }
      [JsonProperty("jdOrderId")]
public 				long

             jdOrderId
 { get; set; }
      [JsonProperty("jdOrderStatus")]
public 				int

             jdOrderStatus
 { get; set; }
      [JsonProperty("cartResp")]
public 				CartResp

             cartResp
 { get; set; }
      [JsonProperty("poDetailResp")]
public 				PoDetailResp

             poDetailResp
 { get; set; }
	}
}
