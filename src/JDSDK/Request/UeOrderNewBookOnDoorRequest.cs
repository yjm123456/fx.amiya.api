using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UeOrderNewBookOnDoorRequest : JdRequestBase<UeOrderNewBookOnDoorResponse>
    {
                                                                                                                                              public  		string
              orderNo
 {get; set;}
                                                          
                                                          public  		string
              bookOperateDate
 {get; set;}
                                                          
                                                          public  		string
              bookDate
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              bookTimes
 {get; set;}
                                                          
                                                          public  		string
              createBy
 {get; set;}
                                                          
                                                          public  		string
              appid
 {get; set;}
                                                          
                                                          public  		string
              venderCode
 {get; set;}
                                                          
                                                          public  		string
              bookingStartDate
 {get; set;}
                                                          
                                                          public  		string
              bookingEndDate
 {get; set;}
                                                          
                                                          public  		string
              remark
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ue.order.new.bookOnDoor";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("bookOperateDate", this.            bookOperateDate
);
                                                                                                        parameters.Add("bookDate", this.            bookDate
);
                                                                                                        parameters.Add("bookTimes", this.            bookTimes
);
                                                                                                        parameters.Add("createBy", this.            createBy
);
                                                                                                        parameters.Add("appid", this.            appid
);
                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                                                        parameters.Add("bookingStartDate", this.            bookingStartDate
);
                                                                                                        parameters.Add("bookingEndDate", this.            bookingEndDate
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                            }
    }
}





        
 

