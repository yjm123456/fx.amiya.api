using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
						using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class LogisticsOrderGetResponse:JdResponse{
      [JsonProperty("receipt_no")]
public 				string

                                                                                     receiptNo
 { get; set; }
      [JsonProperty("order_status_details")]
public 				List                <OrderStatusDetail>

                                                                                                                     orderStatusDetails
 { get; set; }
      [JsonProperty("order_package_details")]
public 				List                <OrderPackageDetail>

                                                                                                                     orderPackageDetails
 { get; set; }
	}
}
