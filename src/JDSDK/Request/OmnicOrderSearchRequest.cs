using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OmnicOrderSearchRequest : JdRequestBase<OmnicOrderSearchResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              currentPage
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startDate
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endDate
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              dateType
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  fieldList {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.omnic.order.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                        parameters.Add("currentPage", this.            currentPage
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("startDate", this.            startDate
);
                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                        parameters.Add("dateType", this.            dateType
);
                                                                                                                                                parameters.Add("fieldList", this.            fieldList
);
                                                                                                    }
    }
}





        
 

