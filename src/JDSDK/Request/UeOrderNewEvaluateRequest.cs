using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UeOrderNewEvaluateRequest : JdRequestBase<UeOrderNewEvaluateResponse>
    {
                                                                                                                                              public  		string
              beginDate
 {get; set;}
                                                          
                                                          public  		string
              venderCode
 {get; set;}
                                                          
                                                          public  		string
              endDate
 {get; set;}
                                                          
                                                          public  		string
              appid
 {get; set;}
                                                          
                                                          public  		string
              page
 {get; set;}
                                                          
                                                          public  		string
              serviceTypeId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                            		public  		string
  orderNos {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.ue.order.new.evaluate";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("beginDate", this.            beginDate
);
                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                        parameters.Add("appid", this.            appid
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("serviceTypeId", this.            serviceTypeId
);
                                                                                                                                                                        parameters.Add("orderNos", this.            orderNos
);
                                                                            }
    }
}





        
 

