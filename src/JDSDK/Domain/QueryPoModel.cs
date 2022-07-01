using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class QueryPoModel:JdObject{
      [JsonProperty("poOrderNo")]
public 				string

             poOrderNo
 { get; set; }
      [JsonProperty("isvPoOrderNo")]
public 				string

             isvPoOrderNo
 { get; set; }
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("whNo")]
public 				string

             whNo
 { get; set; }
      [JsonProperty("supplierNo")]
public 				string

             supplierNo
 { get; set; }
      [JsonProperty("createUser")]
public 				string

             createUser
 { get; set; }
      [JsonProperty("poOrderStatus")]
public 				string

             poOrderStatus
 { get; set; }
      [JsonProperty("createTime")]
public 				string

             createTime
 { get; set; }
      [JsonProperty("completeTime")]
public 				string

             completeTime
 { get; set; }
      [JsonProperty("storageStatus")]
public 				string

             storageStatus
 { get; set; }
      [JsonProperty("poItemModelList")]
public 				List<string>

             poItemModelList
 { get; set; }
      [JsonProperty("qcBackItemList")]
public 				List<string>

             qcBackItemList
 { get; set; }
      [JsonProperty("qcBackErrItemList")]
public 				List<string>

             qcBackErrItemList
 { get; set; }
      [JsonProperty("resultCode")]
public 				string

             resultCode
 { get; set; }
      [JsonProperty("msg")]
public 				string

             msg
 { get; set; }
      [JsonProperty("poBatAttrModelList")]
public 				List<string>

             poBatAttrModelList
 { get; set; }
      [JsonProperty("diffBatAttrModelList")]
public 				List<string>

             diffBatAttrModelList
 { get; set; }
      [JsonProperty("productName")]
public 				string

             productName
 { get; set; }
      [JsonProperty("billingMode")]
public 				string

             billingMode
 { get; set; }
      [JsonProperty("receiveBoxNumber")]
public 				string

             receiveBoxNumber
 { get; set; }
      [JsonProperty("logicParam")]
public 				string

             logicParam
 { get; set; }
	}
}
