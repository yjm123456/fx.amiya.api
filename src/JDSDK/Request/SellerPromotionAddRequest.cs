using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SellerPromotionAddRequest : JdRequestBase<SellerPromotionAddResponse>
    {
                                                                                                                                                                               public  		string
              name
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              type
 {get; set;}
                                                          
                                                          public  		string
                                                                                      beginTime
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      endTime
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
              bound
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              member
 {get; set;}
                                                          
                                                          public  		string
              slogan
 {get; set;}
                                                          
                                                          public  		string
              comment
 {get; set;}
                                                          
                                                          public  		Nullable<int>
                                                                                      favorMode
 {get; set;}
                                                                                                                                  
                                                                              public override string ApiName
            {
                get{return "jingdong.seller.promotion.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                        parameters.Add("begin_time", this.                                                                                    beginTime
);
                                                                                                        parameters.Add("end_time", this.                                                                                    endTime
);
                                                                                                        parameters.Add("bound", this.            bound
);
                                                                                                        parameters.Add("member", this.            member
);
                                                                                                        parameters.Add("slogan", this.            slogan
);
                                                                                                        parameters.Add("comment", this.            comment
);
                                                                                                        parameters.Add("favor_mode", this.                                                                                    favorMode
);
                                                                                                                            }
    }
}





        
 

