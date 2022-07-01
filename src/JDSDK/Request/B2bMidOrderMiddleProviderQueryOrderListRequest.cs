using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class B2bMidOrderMiddleProviderQueryOrderListRequest : JdRequestBase<B2bMidOrderMiddleProviderQueryOrderListResponse>
    {
                                                                                                                                                                               public  		Nullable<int>
              orderTier
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageIndex
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              sortType
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              submitOrderTimeFrom
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              submitOrderTimeTo
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  jdOrderState {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              deliverState
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.b2b.mid.OrderMiddleProvider.queryOrderList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("orderTier", this.            orderTier
);
                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("sortType", this.            sortType
);
                                                                                                        parameters.Add("submitOrderTimeFrom", this.            submitOrderTimeFrom
);
                                                                                                        parameters.Add("submitOrderTimeTo", this.            submitOrderTimeTo
);
                                                                                                                                                parameters.Add("jdOrderState", this.            jdOrderState
);
                                                                                                                                parameters.Add("deliverState", this.            deliverState
);
                                                                            }
    }
}





        
 

