using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OmnicOrderShipinfoSearchRequest : JdRequestBase<OmnicOrderShipinfoSearchResponse>
    {
                                                                                                                                              public  		Nullable<int>
              dateType
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endDate
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              currentPage
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  fieldList {get; set; }
                                                                                                                                                                                                public  		Nullable<DateTime>
              startDate
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.omnic.order.shipinfo.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("dateType", this.            dateType
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("currentPage", this.            currentPage
);
                                                                                                                                                parameters.Add("fieldList", this.            fieldList
);
                                                                                                                                parameters.Add("startDate", this.            startDate
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                            }
    }
}





        
 

