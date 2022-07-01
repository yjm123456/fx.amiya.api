using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PurchaseOrderSelectInfosRequest : JdRequestBase<PurchaseOrderSelectInfosResponse>
    {
                                                                                                                   public  		string
              startDate
 {get; set;}
                                                          
                                                          public  		string
              endDate
 {get; set;}
                                                          
                                                          public  		string
              orderStates
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              updateBeginTime
 {get; set;}
                                                          
                                                          public  		string
              updateEndTime
 {get; set;}
                                                          
                                                          public  		string
              provinceId
 {get; set;}
                                                          
                                                          public  		string
              cityId
 {get; set;}
                                                          
                                                          public  		string
              countyId
 {get; set;}
                                                          
                                                          public  		string
              townId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.purchase.order.select.infos";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("startDate", this.            startDate
);
                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                        parameters.Add("orderStates", this.            orderStates
);
                                                                                                        parameters.Add("pageNo", this.            pageNo
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("updateBeginTime", this.            updateBeginTime
);
                                                                                                        parameters.Add("updateEndTime", this.            updateEndTime
);
                                                                                                        parameters.Add("provinceId", this.            provinceId
);
                                                                                                        parameters.Add("cityId", this.            cityId
);
                                                                                                        parameters.Add("countyId", this.            countyId
);
                                                                                                        parameters.Add("townId", this.            townId
);
                                                    }
    }
}





        
 

