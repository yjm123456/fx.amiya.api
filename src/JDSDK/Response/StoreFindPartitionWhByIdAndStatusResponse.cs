using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class StoreFindPartitionWhByIdAndStatusResponse:JdResponse{
      [JsonProperty("find_Partition_Warehouse_Result")]
public 				FindPartitionWarehouseResult

                                                                                                                                                     findPartitionWarehouseResult
 { get; set; }
	}
}
