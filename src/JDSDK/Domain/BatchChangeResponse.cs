using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BatchChangeResponse:JdObject{
      [JsonProperty("batchAttrChangeNo")]
public 				string

             batchAttrChangeNo
 { get; set; }
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("deptName")]
public 				string

             deptName
 { get; set; }
      [JsonProperty("allocativeCenterNo")]
public 				string

             allocativeCenterNo
 { get; set; }
      [JsonProperty("warehouseNo")]
public 				string

             warehouseNo
 { get; set; }
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("goodsLevel")]
public 				string

             goodsLevel
 { get; set; }
      [JsonProperty("preChangeSoNo")]
public 				string

             preChangeSoNo
 { get; set; }
      [JsonProperty("preChangePD")]
public 				string

             preChangePD
 { get; set; }
      [JsonProperty("preChangeGP")]
public 				string

             preChangeGP
 { get; set; }
      [JsonProperty("preChangeSupplier")]
public 				string

             preChangeSupplier
 { get; set; }
      [JsonProperty("preChangeDD")]
public 				string

             preChangeDD
 { get; set; }
      [JsonProperty("preChangeLC")]
public 				string

             preChangeLC
 { get; set; }
      [JsonProperty("preChangePOO")]
public 				string

             preChangePOO
 { get; set; }
      [JsonProperty("preChangeBatchNo")]
public 				string

             preChangeBatchNo
 { get; set; }
      [JsonProperty("preChangeMfrs")]
public 				string

             preChangeMfrs
 { get; set; }
      [JsonProperty("preChangePackBatchNo")]
public 				string

             preChangePackBatchNo
 { get; set; }
      [JsonProperty("preChangeBoxNo")]
public 				string

             preChangeBoxNo
 { get; set; }
      [JsonProperty("preChangeShop")]
public 				string

             preChangeShop
 { get; set; }
      [JsonProperty("afterChangeSoNo")]
public 				string

             afterChangeSoNo
 { get; set; }
      [JsonProperty("afterChangePD")]
public 				string

             afterChangePD
 { get; set; }
      [JsonProperty("afterChangeGP")]
public 				string

             afterChangeGP
 { get; set; }
      [JsonProperty("afterChangeSupplier")]
public 				string

             afterChangeSupplier
 { get; set; }
      [JsonProperty("afterChangeDD")]
public 				string

             afterChangeDD
 { get; set; }
      [JsonProperty("afterChangeLC")]
public 				string

             afterChangeLC
 { get; set; }
      [JsonProperty("afterChangePOO")]
public 				string

             afterChangePOO
 { get; set; }
      [JsonProperty("afterChangeBatchNo")]
public 				string

             afterChangeBatchNo
 { get; set; }
      [JsonProperty("afterChangeMfrs")]
public 				string

             afterChangeMfrs
 { get; set; }
      [JsonProperty("afterChangePackBatchNo")]
public 				string

             afterChangePackBatchNo
 { get; set; }
      [JsonProperty("afterChangeBoxNo")]
public 				string

             afterChangeBoxNo
 { get; set; }
      [JsonProperty("afterChangeShop")]
public 				string

             afterChangeShop
 { get; set; }
      [JsonProperty("changeNum")]
public 				int[]

             changeNum
 { get; set; }
      [JsonProperty("createTime")]
public 				string

             createTime
 { get; set; }
	}
}
