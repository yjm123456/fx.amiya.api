using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WaybillDTO:JdObject{
      [JsonProperty("waybillType")]
public 				int

             waybillType
 { get; set; }
      [JsonProperty("waybillCodes")]
public 				List<string>

             waybillCodes
 { get; set; }
      [JsonProperty("waybillCount")]
public 				int

             waybillCount
 { get; set; }
      [JsonProperty("providerId")]
public 				int

             providerId
 { get; set; }
      [JsonProperty("providerCode")]
public 				string

             providerCode
 { get; set; }
      [JsonProperty("branchCode")]
public 				string

             branchCode
 { get; set; }
      [JsonProperty("platformOrderNo")]
public 				string

             platformOrderNo
 { get; set; }
      [JsonProperty("vendorCode")]
public 				string

             vendorCode
 { get; set; }
      [JsonProperty("vendorName")]
public 				string

             vendorName
 { get; set; }
      [JsonProperty("vendorOrderCode")]
public 				string

             vendorOrderCode
 { get; set; }
      [JsonProperty("salePlatform")]
public 				string

             salePlatform
 { get; set; }
      [JsonProperty("fromAddress")]
public 				WaybillAddress

             fromAddress
 { get; set; }
      [JsonProperty("toAddress")]
public 				WaybillAddress

             toAddress
 { get; set; }
      [JsonProperty("weight")]
public 					string

             weight
 { get; set; }
      [JsonProperty("volume")]
public 					string

             volume
 { get; set; }
      [JsonProperty("goodsName")]
public 				string

             goodsName
 { get; set; }
      [JsonProperty("promiseTimeType")]
public 				int

             promiseTimeType
 { get; set; }
      [JsonProperty("promiseCompleteTime")]
public 				DateTime

             promiseCompleteTime
 { get; set; }
      [JsonProperty("goodsMoney")]
public 					string

             goodsMoney
 { get; set; }
      [JsonProperty("payType")]
public 				int

             payType
 { get; set; }
      [JsonProperty("shouldPayMoney")]
public 					string

             shouldPayMoney
 { get; set; }
      [JsonProperty("needGuarantee")]
public 				bool

             needGuarantee
 { get; set; }
      [JsonProperty("guaranteeMoney")]
public 					string

             guaranteeMoney
 { get; set; }
      [JsonProperty("state")]
public 				int

             state
 { get; set; }
      [JsonProperty("receiveTimeType")]
public 				int

             receiveTimeType
 { get; set; }
      [JsonProperty("warehouseCode")]
public 				string

             warehouseCode
 { get; set; }
      [JsonProperty("secondSectionCode")]
public 				string

             secondSectionCode
 { get; set; }
      [JsonProperty("thirdSectionCode")]
public 				string

             thirdSectionCode
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("extendField1")]
public 				string

             extendField1
 { get; set; }
      [JsonProperty("extendField2")]
public 				string

             extendField2
 { get; set; }
      [JsonProperty("extendField3")]
public 				string

             extendField3
 { get; set; }
      [JsonProperty("extendField4")]
public 				string

             extendField4
 { get; set; }
      [JsonProperty("extendField5")]
public 				string

             extendField5
 { get; set; }
      [JsonProperty("pin")]
public 				string

             pin
 { get; set; }
      [JsonProperty("appKey")]
public 				string

             appKey
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("expressPayMethod")]
public 				string

             expressPayMethod
 { get; set; }
      [JsonProperty("expressType")]
public 				string

             expressType
 { get; set; }
      [JsonProperty("settlementCode")]
public 				string

             settlementCode
 { get; set; }
      [JsonProperty("existWaybillCode")]
public 				bool

             existWaybillCode
 { get; set; }
      [JsonProperty("signReturn")]
public 				int

             signReturn
 { get; set; }
	}
}
