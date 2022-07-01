using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SvcBookingListRequest : JdRequestBase<SvcBookingListResponse>
    {
                                                                                                                                              public  		Nullable<int>
              appId
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              verificationStatus
 {get; set;}
                                                          
                                                          public  		string
              storeName
 {get; set;}
                                                          
                                                          public  		string
              lcnNo
 {get; set;}
                                                          
                                                          public  		string
              mobile
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              submitTimeStart
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              submitTimeEnd
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageIndex
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.svc.booking.list";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("appId", this.            appId
);
                                                                                                                                                        parameters.Add("verificationStatus", this.            verificationStatus
);
                                                                                                        parameters.Add("storeName", this.            storeName
);
                                                                                                        parameters.Add("lcnNo", this.            lcnNo
);
                                                                                                        parameters.Add("mobile", this.            mobile
);
                                                                                                        parameters.Add("submitTimeStart", this.            submitTimeStart
);
                                                                                                        parameters.Add("submitTimeEnd", this.            submitTimeEnd
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                            }
    }
}





        
 

