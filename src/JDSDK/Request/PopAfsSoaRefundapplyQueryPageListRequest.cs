using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopAfsSoaRefundapplyQueryPageListRequest : JdRequestBase<PopAfsSoaRefundapplyQueryPageListResponse>
    {
                                                                                                                                                                               public  		string
              ids
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              status
 {get; set;}
                                                          
                                                          public  		string
              orderId
 {get; set;}
                                                          
                                                          public  		string
              buyerId
 {get; set;}
                                                          
                                                          public  		string
              buyerName
 {get; set;}
                                                          
                                                          public  		string
              applyTimeStart
 {get; set;}
                                                          
                                                          public  		string
              applyTimeEnd
 {get; set;}
                                                          
                                                          public  		string
              checkTimeStart
 {get; set;}
                                                          
                                                          public  		string
              checkTimeEnd
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageIndex
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              storeId
 {get; set;}
                                                          
                                                          public  		string
                                                                                                                      openIdBuyer
 {get; set;}
                                                                                                                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.afs.soa.refundapply.queryPageList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("ids", this.            ids
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("buyerId", this.            buyerId
);
                                                                                                        parameters.Add("buyerName", this.            buyerName
);
                                                                                                        parameters.Add("applyTimeStart", this.            applyTimeStart
);
                                                                                                        parameters.Add("applyTimeEnd", this.            applyTimeEnd
);
                                                                                                        parameters.Add("checkTimeStart", this.            checkTimeStart
);
                                                                                                        parameters.Add("checkTimeEnd", this.            checkTimeEnd
);
                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("open_id_buyer", this.                                                                                                                    openIdBuyer
);
                                                                            }
    }
}





        
 

