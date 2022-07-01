using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ResponseOrderStatus:JdObject{
      [JsonProperty("receipt_no")]
public 				string

                                                                                     receiptNo
 { get; set; }
      [JsonProperty("order_status_details")]
public 				List<string>

                                                                                                                     orderStatusDetails
 { get; set; }
      [JsonProperty("order_package_details")]
public 				List<string>

                                                                                                                     orderPackageDetails
 { get; set; }
	}
}
